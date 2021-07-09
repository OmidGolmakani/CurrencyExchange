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
        internal Task<Response> Upload(IFormFile file, bool Override, string Directory)
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
                if (string.IsNullOrEmpty(Directory))
                {
                    return Task.FromResult(new Response()
                    {
                        Code = FtpStatusCode.FileActionAborted,
                        Description = "آدرس پوشه بر روی سرور مشخص نشده است"
                    });
                }
                if (Override == false)
                {
                    if (FtpDirectoryExists(file.FileName).Result)
                    {
                        return Task.FromResult(new Response()
                        {
                            Code = FtpStatusCode.FileActionOK,
                            Description = "فایل مورد نظر وجود دارد"
                        });
                    }
                }
                var FileInfo = GetFileInfo(file);
                if (FileInfo.Result.FileType == Enum.Type.FileType.None)
                {
                    return Task.FromResult(FileInfo.Result.Response);
                }
                var MaxSize = GetMaxSize(file);
                if (MaxSize.Result == -4)
                {
                    return Task.FromResult(new Response()
                    {
                        Code = FtpStatusCode.FileActionAborted,
                        Description = "فایل مورد نظر بزرگتر از اندازه تغریف شده می باشد"
                    });
                }
                var Result = FtpCreateDirectory(Directory);
                //Create an FtpWebRequest
                var request = (FtpWebRequest)WebRequest.Create(string.Format("{0}/{1}/{2}", _UploadConfig.Value.Url, Directory, file.FileName));
                //Set the method to UploadFile
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //Set the NetworkCredentials
                request.Credentials = new NetworkCredential(_UploadConfig.Value.UserName,
                                                            _UploadConfig.Value.Password);

                //Set buffer length to any value you find appropriate for your use case
                byte[] buffer = new byte[1024];
                var stream = file.OpenReadStream();
                byte[] fileContents;
                //Copy everything to the 'fileContents' byte array
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.ReadAsync(buffer, 0, buffer.Length).Result) > 0)
                    {
                        ms.WriteAsync(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }

                //Upload the 'fileContents' byte array 
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.WriteAsync(fileContents, 0, fileContents.Length);
                }

                //Get the response
                // Some proper handling is needed
                //var response =  request.GetResponse() as FtpWebResponse;
                var response = request.GetResponseAsync().Result as FtpWebResponse;
                return Task.FromResult(new Response()
                {
                    Code = response.StatusCode,
                    Description = response.StatusDescription,
                    Url = response.ResponseUri.OriginalString.Replace("ftp://", "")

                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal Task<long> GetMaxSize(IFormFile file)
        {
            try
            {
                ///File Is Not Selected
                if (file == null || file.FileName == "") return Task.FromResult<long>(-1);
                var FileInfo = GetFileInfo(file).Result;
                ///File Is Not Valid
                if (FileInfo.FileType == FileType.None) return Task.FromResult<long>(-2);
                ///Maximum Size File Is Not Define
                var MaxFileInfo = _UploadConfig.Value.MaxSize.FirstOrDefault(x => x.FileType == FileInfo.FileType);
                if (MaxFileInfo.Size <= 0) Task.FromResult<long>(-3);
                ///File Is Big
                if (MaxFileInfo.Size < ((file.Length / 1024).ToDecimal() / 1024).ToDecimal()) Task.FromResult<long>(-4);
                return Task.FromResult<long>(file.Length);
            }
            catch (Exception ex)
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
        internal Task<bool> FtpDirectoryExists(string Directory)
        {
            bool IsExists = true;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_UploadConfig.Value.Url + Directory);
                request.Credentials = new NetworkCredential(_UploadConfig.Value.UserName, _UploadConfig.Value.Password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                IsExists = false;
            }
            return Task.FromResult(IsExists);
        }
        internal Task<Dto.Response> FtpCreateDirectory(string Directory)
        {
            try
            {
                var Url = _UploadConfig.Value.Url + Directory;
                Task<bool> DirExistResult = FtpDirectoryExists(Directory);
                DirExistResult.Wait();
                if (DirExistResult.Result == true)
                {
                    return Task.FromResult(new Dto.Response()
                    {
                        Code = FtpStatusCode.DataAlreadyOpen,
                        Description = "مسیر مورد نظر قبلا ایجاد شده است",
                        Url = Url
                    });
                }
                WebRequest request = WebRequest.Create(Url);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(_UploadConfig.Value.UserName, _UploadConfig.Value.Password);
                using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
                {
                    return Task.FromResult(new Dto.Response()
                    {
                        Code = resp.StatusCode,
                        Description = resp.StatusDescription,
                        Url = Url
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
