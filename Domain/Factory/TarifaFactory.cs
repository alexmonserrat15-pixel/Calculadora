using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Factory
{
    public static class TarifaFactory
    {
        public static TarifaBase Crear(string paisNombre)
        {
            return paisNombre switch
            {
                "India" => new TarifaIndia(),
                "Estados Unidos" => new TarifaEstadosUnidos(),
                "Reino Unido" => new TarifaReinoUnido(),
                _ => throw new KeyNotFoundException($"No existe tarifa para: {paisNombre}")
            };
        }
    }
}
