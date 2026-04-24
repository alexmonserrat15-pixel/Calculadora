using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Entities
{
    public class TarifaEstadosUnidos : TarifaBase
    {
        public TarifaEstadosUnidos() => pais_nombre = "Estados Unidos";
        public override decimal CalcularCosto(decimal peso) => peso * 8;
    }

}
