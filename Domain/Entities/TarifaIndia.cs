using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Entities
{
    public class TarifaIndia : TarifaBase
    {
        public TarifaIndia() => pais_nombre = "India";
        public override decimal CalcularCosto(decimal peso) => peso * 5;
    }
}
