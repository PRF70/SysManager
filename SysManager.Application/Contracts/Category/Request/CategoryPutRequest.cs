﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.Category.Request
{
    /// <summary>
    /// Classe responsavel como contrato para requisição de alteração
    /// </summary>
    public class CategoryPutRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
