namespace Calculadora.MVC.Models
{
    public class EnvioViewModel
    {
        public string pais_nombre { get; set; }
        public decimal peso { get; set; }
        public List<string> Paises { get; set; } = new List<string>();

        // Resultado
        public decimal tarifa_usd { get; set; }
        public decimal costo_total { get; set; }
        public bool MostrarResultado { get; set; } = false;
    }
}
