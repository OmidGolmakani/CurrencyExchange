using CurrencyExchange.CustomException;
using CurrencyExchange.Helpers;
using CurrencyExchange.OtherServices.Base;
using CurrencyExchange.OtherServices.FileTransfer.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static CurrencyExchange.OtherServices.FileTransfer.Enum.Type;

namespace CurrencyExchange.OtherServices.FileTransfer.Services
{
    public class UploadService : BaseSevice
    {
        private readonly IOptions<UploadConfig> _UploadConfig;
        private readonly IWebHostEnvironment _env;

        public UploadService(IOptions<UploadConfig> UploadConfig, IWebHostEnvironment env)
        {
            this._UploadConfig = UploadConfig;
            this._env = env;
        }
        internal Task<Response> Upload(IFormFile file, bool Override)
        {
            string fullpath = "";
            try
            {
                if (file == null || string.IsNullOrEmpty(file.FileName))
                {
                    return Task.FromResult(new Response()
                    {
                        Code = FtpStatusCode.Undefined,
                        Description = "فایلی انتخاب نشده است"
                    });
                }
                var FileInfo = GetFileInfo(file);
                if (FileInfo.Result.FileType == Enum.Type.FileType.None)
                {
                    return Task.FromResult(FileInfo.Result.Response);
                }
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(_env.WebRootPath, _UploadConfig.Value.RootUrl));
                string FileName = $"Img{dir.GetFiles().Count() + 1}{Path.GetExtension(file.FileName)}";

                fullpath = Path.Combine(_env.WebRootPath, _UploadConfig.Value.RootUrl, FileName);
                long size = file.Length;

                if (file.Length > 0)
                {
                    //var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(fullpath))
                    {
                        file.CopyToAsync(stream);
                    }
                    FileInfo.Result.Response.Url = Path.Combine(_UploadConfig.Value.RootUrl, FileName);
                    FileInfo.Result.Response.Code = FtpStatusCode.CommandOK;
                    FileInfo.Result.Response.Description = "فایل با موفقیت آپلود شد";
                }
                return Task.FromResult(FileInfo.Result.Response);
            }
            catch (MyException ex)
            {
                DeleteFileFromServer(fullpath);
                throw ex;
            }
        }
        internal Task DeleteAsync(FileInfo fi)
        {
            return Task.Factory.StartNew(() => fi.Delete());
        }
        internal Task DeleteFileFromServer(string FileName)
        {
            try
            {
                if (FileName == "") return Task.Run(() => false);
                var file = Path.Combine(_env.WebRootPath, FileName);
                FileInfo fileInfo = new FileInfo(file);
                return DeleteAsync(fileInfo);
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
        internal Task<List<string>> GetImageValidTypes()
        {
            return Task.FromResult(new List<string>() { ".jpeg", ".png", ".jpg" });
        }
        internal Task<List<string>> GetValidTypes()
        {
            return GetImageValidTypes();
        }
        internal Task<FileUploadInfo> GetFileInfo(IFormFile file)
        {
            FileUploadInfo Result = new FileUploadInfo();
            if (string.IsNullOrEmpty(file.FileName))
            {
                Result = new FileUploadInfo()
                {
                    Response = new Response()
                    {
                        Code = FtpStatusCode.Undefined,
                        Description = "فایلی انتخاب نشده است"
                    }

                };
            }
            if (GetImageValidTypes().Result.FirstOrDefault(x => x == Path.GetExtension(file.FileName.ToLower())) == null)
            {
                Result = new FileUploadInfo()
                {
                    Response = new Response()
                    {
                        Code = FtpStatusCode.Undefined,
                        Description = "فایل مورد نظر غیر مجاز می باشد"
                    }

                };
            }
            else
            {
                Result = new FileUploadInfo()
                {
                    Response = new Response()
                    {
                        Code = FtpStatusCode.FileActionOK,
                        Description = "فایل مورد نظر مجاز است"
                    }
                    ,
                    Exctention = Path.GetExtension(file.FileName.ToLower()),
                    FileType = Enum.Type.FileType.Image,
                    Size = file.Length

                };

            }
            return Task.FromResult(Result);
        }
    }
}
