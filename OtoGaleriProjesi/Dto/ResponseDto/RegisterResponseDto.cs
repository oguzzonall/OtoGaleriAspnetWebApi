using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoGaleriProjesi.Dto.ResponseDto
{
    public class RegisterResponseDto
    {
        public string result { get; set; }
        public bool tf { get; set; }
        public string dogrulamaKodu { get; set; }
    }
}