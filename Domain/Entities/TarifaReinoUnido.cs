using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Entities
{
    public class TarifaReinoUnido : TarifaBase
    {
        public TarifaReinoUnido() => pais_nombre = "Reino Unido";
        public override decimal CalcularCosto(decimal peso) => peso * 10;
    }
}
