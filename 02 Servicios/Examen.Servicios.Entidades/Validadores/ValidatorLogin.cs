using Examen.Servicios.Entidades.Modelo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Servicios.Entidades.Validadores
{
    public class ValidatorLogin : AbstractValidator<Usuario>
    {
        public ValidatorLogin()
        {
            RuleFor(u => u.Correo).EmailAddress();
            RuleFor(u => u.Correo).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
