using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AplicacionWeb720.Pages.Participantes
{
    public class CrearModel : PageModel
    {
        public InfoParticipantes infoParticipantes = new InfoParticipantes();
        public String campovacio = "";
        public String correcto = "";
        public double imc;
        public int edad;
        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            infoParticipantes.nombre = Request.Form["nombre"];
            infoParticipantes.apellidos = Request.Form["apellidos"];
            infoParticipantes.email = Request.Form["email"];
            infoParticipantes.telefono = Request.Form["telefono"];
            infoParticipantes.altura = Request.Form["altura"];
            infoParticipantes.peso = Request.Form["peso"];
            infoParticipantes.fecha = int.Parse(Request.Form["fecha"]);

            double altura = double.Parse(infoParticipantes.altura) / 100;
            imc = int.Parse(infoParticipantes.peso) / (Math.Pow(altura,2));

            edad = 2022 - infoParticipantes.fecha;
            
            // CONDICIONAL PARA RECHAZAR PARTICIPANTES

            if (infoParticipantes.nombre.Length == 0 || infoParticipantes.apellidos.Length == 0 || 
                infoParticipantes.peso.Length == 0 || infoParticipantes.altura.Length == 0 || 
                infoParticipantes.email.Length == 0 || infoParticipantes.telefono.Length == 0)

            
            {
                campovacio = "Rellena todos los campos para continuar.";
                return;
            }

            else if (imc<18.0 || imc>34.0)
            {
                campovacio = "El imc no está admitido.";
                return;
            }
            
            else if ( edad > 60)

            {
                campovacio = "Eres demasiado mayor para participar";
                return;
            }
            // Guardar el nuevo participante en la base de datos.

            try
            {
                String connectionString = "Data Source =.\\sqlexpress; Initial Catalog = 720server; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO participantes " +
                        "(nombre, apellidos, email, telefono, fecha, altura, peso) VALUES " +
                        "(@nombre, @apellidos, @email, @telefono, @fecha, @altura, @peso);";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection)){
                        command.Parameters.AddWithValue("@nombre", infoParticipantes.nombre);
                        command.Parameters.AddWithValue("@apellidos", infoParticipantes.apellidos);
                        command.Parameters.AddWithValue("@email", infoParticipantes.email);
                        command.Parameters.AddWithValue("@telefono", infoParticipantes.telefono);
                        command.Parameters.AddWithValue("@fecha", infoParticipantes.fecha);
                        command.Parameters.AddWithValue("@altura", infoParticipantes.altura);
                        command.Parameters.AddWithValue("@peso", infoParticipantes.peso);

                        command.ExecuteNonQuery();
                    }
                
                }
            }
            catch (Exception ex)
            {
                campovacio=ex.Message;
                return;
            }

            infoParticipantes.nombre = ""; infoParticipantes.apellidos = "";
            infoParticipantes.email = ""; infoParticipantes.telefono = "";
            infoParticipantes.altura = ""; infoParticipantes.fecha = 0;
            infoParticipantes.peso = "";

            correcto = "Participante añadido correctamente.";

        }
    }
}
