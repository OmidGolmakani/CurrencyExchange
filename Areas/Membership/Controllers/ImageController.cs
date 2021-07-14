using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.Images;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.OtherServices.FileTransfer.Services;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class ImageController : BaseController<ImageController>, IImageController
    {
        private readonly IImage _ImageSrv;
        private readonly UploadService _uploadSrv;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public ImageController(IImage imageSrv,
                               UploadService uploadSrv,
                               IMapper mapper,
                               ApplicationDbContext DbContext) : base(mapper, DbContext)
        {
            this._ImageSrv = imageSrv;
            this._uploadSrv = uploadSrv;
            this.mapper = mapper;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUImageDto entity)
        {
            var _entity = mapper.Map<CUImageDto, Image>(entity);
            ImageValidator validator = new ImageValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _ImageSrv.Add(_entity);
            _ImageSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("AddImageWithUpload")]
        public async Task<IActionResult> AddImageWithUpload(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            CUImageDto entity = new CUImageDto();

            var _entity = mapper.Map<CUImageDto, Image>(entity);
            ImageValidator validator = new ImageValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            //var UploadResult = await _uploadSrv.Upload(entity.FileName, true);
            //_entity.FileName = UploadResult.Url;
            var Result = _ImageSrv.Add(_entity);
            _ImageSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }
        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _ImageSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _ImageSrv.Remove(Id);
            _ImageSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUImageDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            Image _entity = new Image();
            mapper.Map<CUImageDto, Image>(entity, _entity);
            ImageValidator validator = new ImageValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _ImageSrv.Update(_entity);
            _ImageSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<ImageDto>>(await _ImageSrv.GetAll());
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpGet("GetDetail{Id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            var Result = mapper.Map<ImageDto>(await _ImageSrv.GetById(Id));
            if (Result == null)
            {
                return NotFound(DefaultMessages.NotFound);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpGet("GetByUserId{UserId}")]
        public async Task<IActionResult> GetByUserId(long UserId)
        {
            var Result = mapper.Map<List<ImageDto>>(await _ImageSrv.GetImageByUserId(UserId));
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
    }
}
