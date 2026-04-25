using Calculadora.Domain.Entities;
using Calculadora.Domain.Repository;
using Calculadora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByUsuarioAsync(string usuario)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync<Usuario>(u => u.usuario == usuario);
        }
    }
}
