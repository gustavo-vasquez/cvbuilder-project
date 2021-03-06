﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class CertificatesDTO
    {
        public int CertificateID { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
