using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OtoGaleriProjesi.Dto.RequestDto;
using OtoGaleriProjesi.Dto.ResponseDto;
using OtoGaleriProjesi.Models;

namespace OtoGaleriProjesi.Controllers
{
    public class KayitController : ApiController
    {
        private OtoGaleriDB context = new OtoGaleriDB();
        [HttpPost]
        public RegisterResponseDto KayitOl(RegisterRequstDto registerRequstDto)
        {
            uyeler uye = context.uyeler.FirstOrDefault(x => x.kullaniciadi == registerRequstDto.kad);
            if (uye == null)
            {
                String dogrulama = new Random().Next(0, 100000).ToString();
                context.uyeler.Add(new uyeler()
                {
                    dogrulamakodu = dogrulama,
                    durum = false,
                    kullaniciadi = registerRequstDto.kad,
                    kullanicisifre = registerRequstDto.sifre
                });
                if (context.SaveChanges() > 0)
                {
                    return new RegisterResponseDto()
                    {
                        dogrulamaKodu = dogrulama,
                        result = "Kayıt Başarılı",
                        tf = true
                    };
                }
                else
                {
                    return new RegisterResponseDto()
                    {
                        dogrulamaKodu = dogrulama,
                        result = "Kayıt Başarısız Oldu",
                        tf = false
                    };
                }
            }
            else
            {
                return new RegisterResponseDto()
                {
                    result = "Böyle Bir Kayıt Var",
                    tf = false
                };
            }
         }
    }
}
