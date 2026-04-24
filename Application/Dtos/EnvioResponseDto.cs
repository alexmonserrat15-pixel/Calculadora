using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Dtos
{
    public class EnvioResponseDto
    {
        public string pais_nombre { get; set; }
        public decimal peso { get; set; }
        public decimal tarifa_usd { get; set; }
        public decimal costo_total { get; set; }
    }
}
