using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OtoGaleriProjesi.Dto.RequestDto;
using OtoGaleriProjesi.Dto.ResponseDto;
using OtoGaleriProjesi.Models;

namespace OtoGaleriProjesi.Controllers
{
    public class MailController : ApiController
    {
        OtoGaleriDB context = new OtoGaleriDB();
        [HttpPost]
        public DogrulamaResponseDto Dogrulama(DogrulamaRequestDto dogrulamaRequestDto)
        {
            uyeler uye = context.uyeler.FirstOrDefault(x =>
                x.kullaniciadi == dogrulamaRequestDto.kadi && x.dogrulamakodu == dogrulamaRequestDto.kod);
            if (uye != null)
            {
                if (uye.durum == false)
                {
                    uye.durum = true;
                    context.uyeler.AddOrUpdate(uye);
                    if (context.SaveChanges() > 0)
                    {
                        return new DogrulamaResponseDto()
                        {
                            result = "Kayıt Başarılı",
                            tf = true
                        };
                    }
                    else
                    {
                        return new DogrulamaResponseDto()
                        {
                            result = "Doğrulama İşlemi Başarısız Oldu.",
                            tf = false
                        };
                    }
                }
                else
                {
                    return new DogrulamaResponseDto()
                    {
                        result = "Kullanıcı Zaten Aktif",
                        tf = false
                    };
                }
            }
            else
            {
                return new DogrulamaResponseDto()
                {
                    result = "Doğrulama Kodu Hatalıdır.",
                    tf = false
                };
            }
        }
    }
}
