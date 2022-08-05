using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionWeb720.Pages.Participantes
{
    public class CrearModel : PageModel
    {
        public InfoParticipantes infoParticipantes = new InfoParticipantes();
        public String campovacio = ""; 
        public String
        public void OnGet()
        {
        }

        public void OnPost()
        {
            infoParticipantes.nombre = Request.Form["nombre"];
            infoParticipantes.apellidos = Request.Form["apellidos"];
            infoParticipantes.correo = Request.Form["correo"];
            infoParticipantes.telefono = Request.Form["telefono"];
            infoParticipantes.altura = Request.Form["altura"];
            infoParticipantes.peso = Request.Form["peso"];
            infoParticipantes.fecha = Request.Form["fecha"];

            if (infoParticipantes.nombre.Length == 0 || infoParticipantes.apellidos.Length == 0 || 
                infoParticipantes.peso.Length == 0 || infoParticipantes.altura.Length == 0 || 
                infoParticipantes.correo.Length == 0 || infoParticipantes.telefono.Length == 0 ||
                infoParticipantes.fecha.Length == 0)
            {
                campovacio = "Rellena todos los campos para continuar.";
                return;
            }
        }
    }
}
