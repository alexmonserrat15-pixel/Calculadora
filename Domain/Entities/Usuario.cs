using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string password_hash { get; set; }
        public DateTime creado_en { get; set; }
    }
}
