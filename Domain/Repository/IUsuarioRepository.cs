using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByUsuarioAsync(string usuario);
    }
}
