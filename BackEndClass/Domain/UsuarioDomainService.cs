﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Domain
{
    public class UsuarioDomainService
    {
        public string ValidateFirstName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }

        public string ValidateLastName(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                return "El campo no puede estar vacio";
            }

            return "El campo fue validado con exito";
        }
    }
}