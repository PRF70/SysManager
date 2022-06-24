﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.Users.Request
{
    /// <summary>
    /// Classe de "Contrato" responsavel pela requisição de cadastro de usuário
    /// </summary>
    public class UserPostRequest
    {
        /// <summary>
        /// Propriedade que refere-se ao nome do usuário
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Propriedade que refere-se ao e-mail do usuário
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Propriedade que refere-se a senha do usuário
        /// </summary>
        public string Password { get; set; }

    }
}
