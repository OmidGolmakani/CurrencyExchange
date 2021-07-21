using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Images
{
    public class ImageDto:Base.BaseDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public byte ImageTypeId { get; set; }
        public string ImageTypeName
        {
            get
            {
                Enum.Image.Type imageType = (Enum.Image.Type)ImageTypeId;
                switch (imageType)
                {
                    case Enum.Image.Type.BirthCertificate:
                        return "شناسنامه";
                    case Enum.Image.Type.NationalCard:
                        return "کارت ملی";
                    case Enum.Image.Type.BankCard:
                        return "کارت بانکی";
                    case Enum.Image.Type.UserPicture:
                        return "تصویر کاربر";
                    default:
                        return "";
                }
            }
        }
    public string FileName { get; set; }
    public string Description { get; set; }
}
}
