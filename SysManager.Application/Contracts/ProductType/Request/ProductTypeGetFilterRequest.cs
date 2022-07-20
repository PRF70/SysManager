﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.ProductType.Request
{
    public class ProductTypeGetFilterRequest
    {
        public string Name { get; set; }
        public string Active { get; set; }

        /// <summary>
        ///  Pagina atual da consulta
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Tamanho total da pagina
        /// </summary>
        public int pageSize { get; set; }
    }
}
