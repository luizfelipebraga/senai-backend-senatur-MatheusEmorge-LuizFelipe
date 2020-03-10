﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Viewmodels
{
    public class LoginViewmodel
    {
        // Define que o e-mail é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a senha é obrigatória
        [Required(ErrorMessage = "Informe a senha")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
