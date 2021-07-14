using CurrencyExchange.CustomException;
using CurrencyExchange.Helpers;
using CurrencyExchange.OtherServices.Base;
using CurrencyExchange.OtherServices.FileTransfer.Dto;
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

        public UploadService(IOptions<UploadConfig> UploadConfig)
        {
            this._UploadConfig = UploadConfig;
        }
        internal Task<Response> Upload(IFormFile file, bool Override)
        {

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

                long size = file.Length;

                if (file.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyToAsync(stream);
                    }
                }
                return Task.FromResult(FileInfo.Result.Response);
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
