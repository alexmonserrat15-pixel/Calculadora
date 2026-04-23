using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Entities
{
    public class Tasa
    {
        public int id { get; set; }
        public string pais_nombre { get; set; }
        public decimal tarifa_usd { get; set; }
        public DateTime creado_en { get; set; }
    }
}
