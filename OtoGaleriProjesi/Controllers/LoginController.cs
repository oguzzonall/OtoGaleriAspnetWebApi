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
    public class LoginController : ApiController
    {
        private OtoGaleriDB context = new OtoGaleriDB();

        [HttpPost]
        public LoginResponseDto GirisYap(LoginRequstDto loginRequstDto)
        {
            uyeler uye = context.uyeler.FirstOrDefault(x =>
                x.kullaniciadi == loginRequstDto.kad && x.kullanicisifre == loginRequstDto.sifre);
            LoginResponseDto loginResponseDto=new LoginResponseDto();
            if (uye != null)
            {
                loginResponseDto.id = uye.id;
                loginResponseDto.kadi = uye.kullaniciadi;
            }

            return loginResponseDto;
        }
    }
} 
