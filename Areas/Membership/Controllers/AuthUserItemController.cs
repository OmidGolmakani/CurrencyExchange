using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.Controllers;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.AuthUserItems;
using CurrencyExchange.Models.Dto.BankAccounts;
using CurrencyExchange.Models.Dto.Images;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Models.Repository.Services;
using CurrencyExchange.Models.Validation;
using CurrencyExchange.OtherServices.FileTransfer.Dto;
using CurrencyExchange.OtherServices.FileTransfer.Services;
using CurrencyExchange.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CurrencyExchange.Areas.Membership
{
    public class AuthUserItemController : BaseController<AuthUserItemController>, IAuthUserItemController
    {
        private readonly IMapper mapper;
        private readonly IAuthUserItem _authUserItemSrv;
        private readonly Account _accountSrv;
        private readonly IImage _imageSrv;
        private readonly Models.Repository.Services.Repository<AuthItem, int> _authItemsSrv;
        private readonly UploadService uploadSrv;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<BankAccount, long> _bankAccountSrv;
        private readonly ApplicationDbContext dbContext;

        public AuthUserItemController(IMapper mapper,
                                      ApplicationDbContext DbContext,
                                      IAuthUserItem authUserItemSrv,
                                      Account accountSrv,
                                      IImage imageSrv,
                                      Repository<AuthItem, int> authItemsSrv,
                                      UploadService _uploadSrv,
                                      UserManager<ApplicationUser> userManager,
                                      IRepository<BankAccount, long> bankAccountSrv) : base(mapper, DbContext)
        {
            this.mapper = mapper;
            this._authUserItemSrv = authUserItemSrv;
            this._accountSrv = accountSrv;
            this._imageSrv = imageSrv;
            this._authItemsSrv = authItemsSrv;
            this.uploadSrv = _uploadSrv;
            this._userManager = userManager;
            this._bankAccountSrv = bankAccountSrv;
            this.dbContext = DbContext;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CUAuthUserItemDto entity)
        {

            var _entity = mapper.Map<CUAuthUserItemDto, Models.Entity.AuthUserItem>(entity);
            AuthUserItemValidator validator = new AuthUserItemValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            var Result = _authUserItemSrv.Add(_entity);
            _authUserItemSrv.SaveChanges();
            return Ok(await Task.FromResult(Result.Result.Entity.Id));
        }

        [HttpPost("AddAuthAll")]
        public async Task<IActionResult> AddAll(IFormFile UserImgFile,
                                                IFormFile NationalCodeImgFile,
                                                IFormFile BankCardImgFile,
                                                [FromForm] CAuthUserItemsDto entity)
        {
            var Admin = _accountSrv.GetAll().Result.FirstOrDefault();
            var Auth = _authItemsSrv.GetAll().Result.ToList();
            var userInfo = _accountSrv.GetById(entity.UserId).Result;
            Models.Entity.BankAccount bankAccount = new BankAccount();
            Response UploadFileInfo = null;
            ImageValidator imgValidator = new ImageValidator(dbContext);
            ApplicationUserValidator userValidator = new ApplicationUserValidator(dbContext, _userManager);
            BankAccountValidator bankAccountValidator = new BankAccountValidator(dbContext);
            if (userInfo == null)
            {
                return NotFound("کاربر مورد نظر یافت نشد");
            }
            #region User Info
            userInfo.Name = entity.Step1.Name;
            userInfo.Family = entity.Step1.Family;
            userInfo.NationalCode = entity.Step2.NationalCode;
            userInfo.Tel = entity.Step1.Tel;
            userValidator.ValidateAndThrow(mapper.Map<ApplicationUser>(userInfo));
            _accountSrv.Update(userInfo);
            #endregion User Info
            #region Add Auth User Items
            var BackAccountAuth = await _authUserItemSrv.Add(new Models.Entity.AuthUserItem()
            {
                AdminId = Admin.Id,
                AdminConfirmDate = System.DateTime.Today,
                UserId = userInfo.Id,
                VerifyType = 1,
                AuthItemId = 2,
            });
            var UserAuth = await _authUserItemSrv.Add(new Models.Entity.AuthUserItem()
            {
                AdminId = Admin.Id,
                AdminConfirmDate = System.DateTime.Today,
                UserId = userInfo.Id,
                VerifyType = 1,
                AuthItemId = 1,
            });
            var NationalCodeAuth = await _authUserItemSrv.Add(new Models.Entity.AuthUserItem()
            {
                AdminId = Admin.Id,
                AdminConfirmDate = System.DateTime.Today,
                UserId = userInfo.Id,
                VerifyType = 1,
                AuthItemId = 3,
            });
            var TelAuth = await _authUserItemSrv.Add(new Models.Entity.AuthUserItem()
            {
                AdminId = Admin.Id,
                AdminConfirmDate = System.DateTime.Today,
                UserId = userInfo.Id,
                VerifyType = 1,
                AuthItemId = 4,
            });
            #endregion Add Auth User Items

            #region Bank Account
            bankAccount.IdType = (byte)Models.Enum.BankAccount.IdType.Card;
            bankAccount.Value = entity.Step3.BankCardNo;
            bankAccount.UserId = userInfo.Id;
            bankAccount.AuthUserItem = BackAccountAuth.Entity;
            bankAccountValidator.ValidateAndThrow(bankAccount);
            await _bankAccountSrv.Add(bankAccount);
            #endregion Bank Account
            #region Upload And Save User Image
            UploadFileInfo = await uploadSrv.Upload(UserImgFile, true);
            var UserImg = new Models.Entity.Image()
            {
                UserId = userInfo.Id,
                ImageTypeId = (byte)Models.Enum.Image.Type.UserPicture,
                FileName = UploadFileInfo.Url,
                AuthUserItem = UserAuth.Entity
            };
            imgValidator.ValidateAndThrow(UserImg);
            await _imageSrv.Add(UserImg);
            #endregion Upload And Save User Image
            #region Upload And Save NationalCode Image
            UploadFileInfo = await uploadSrv.Upload(NationalCodeImgFile, true);
            var NationalCodeImg = new Models.Entity.Image()
            {
                UserId = userInfo.Id,
                ImageTypeId = (byte)Models.Enum.Image.Type.NationalCard,
                FileName = UploadFileInfo.Url,
                AuthUserItem = NationalCodeAuth.Entity
            };
            imgValidator.ValidateAndThrow(NationalCodeImg);
            await _imageSrv.Add(UserImg);
            #endregion Upload And Save NationalCode Image
            #region Upload And Save CardNo Image
            UploadFileInfo = await uploadSrv.Upload(BankCardImgFile, true);
            var cardNoImg = new Models.Entity.Image()
            {
                UserId = userInfo.Id,
                ImageTypeId = (byte)Models.Enum.Image.Type.BankCard,
                FileName = UploadFileInfo.Url,
                AuthUserItem = BackAccountAuth.Entity
            };
            imgValidator.ValidateAndThrow(cardNoImg);
            await _imageSrv.Add(cardNoImg);
            #endregion Upload And Save CardNo Image
            _accountSrv.SaveChanges();
            return Ok(await Task.FromResult(0));
        }

        [HttpPost("Delete{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var _entity = await _authUserItemSrv.GetById(Id);
            if (_entity == null) return NotFound(DefaultMessages.NotFound);
            _authUserItemSrv.Remove(Id);
            _authUserItemSrv.SaveChanges();
            return Ok(Id.ToLong());
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CUAuthUserItemDto entity)
        {
            if (entity.Id == 0) return BadRequest(DefaultMessages.IdBadRequestWithAdd);
            Models.Entity.AuthUserItem _entity = new Models.Entity.AuthUserItem();
            mapper.Map<CUAuthUserItemDto, Models.Entity.AuthUserItem>(entity, _entity);
            AuthUserItemValidator validator = new AuthUserItemValidator(dbContext);
            validator.ValidateAndThrow(_entity);
            _authUserItemSrv.Update(_entity);
            _authUserItemSrv.SaveChanges();
            return Ok(await Task.FromResult(_entity.Id));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = mapper.Map<List<Models.Entity.AuthUserItem>>(await _authUserItemSrv.GetAll());
            if (Result.Count == 0)
            {
                return Ok(DefaultMessages.ListEmpty);
            }
            else
            {
                return Ok(Result);
            }
        }
        [HttpGet("GetAuthItemsByUser{UserId}")]
        public async Task<IActionResult> GetAuthItemsByUser(long UserId)
        {
            var Result = mapper.Map<List<Models.Entity.AuthUserItem>>(await _authUserItemSrv.GetAuthItemsByUser(UserId));
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
            var Result = mapper.Map<AuthUserItemDto>(await _authUserItemSrv.GetById(Id));
            if (Result == null)
            {
                return NotFound(DefaultMessages.NotFound);
            }
            else
            {
                return Ok(Result);
            }
        }

        [HttpPost("UpdateAuthUserStatus")]
        public async Task<ActionResult> UpdateAuthUserStatus(long UserId, long AdminId, byte Status)
        {
            await _authUserItemSrv.UpdateAuthUser(UserId, Status, AdminId);
            _authUserItemSrv.SaveChanges();
            return Ok("");
        }
    }
}
