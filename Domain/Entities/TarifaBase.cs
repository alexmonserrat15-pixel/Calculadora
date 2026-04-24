using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Entities
{
    public abstract class TarifaBase
    {
        public string pais_nombre { get; set; }
        public abstract decimal CalcularCosto(decimal peso);
    }
}
