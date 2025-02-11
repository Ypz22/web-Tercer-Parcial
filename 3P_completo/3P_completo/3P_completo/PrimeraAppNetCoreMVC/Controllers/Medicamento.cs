using capaEntidad;
using capaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraAppNetCoreMVC.Controllers
{
    public class Medicamento : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string saludo()
        {
            return "Hola amigos";
        }
        public int numeroEntero()
        {
            return 18;
        }
        public double numeroDecimal()
        {
            return 5.6;
        }

        public List<UsuarioCLS> listarUsuario()
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.listarUsuarios();
        }
        public string cadena()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");
            return cadenaDato;
        }
    }
}
