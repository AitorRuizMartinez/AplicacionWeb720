using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AplicacionWeb720.Pages.Participantes
{
    public class EditarModel : PageModel
    {
        public InfoParticipantes Participantes = new InfoParticipantes();
        public String campovacio = "";
        public String correcto = "";
        

        public void OnGet(int id)
        {
            

            try
            {
                String connectionString = "Data Source =.\\sqlexpress; Initial Catalog = 720server; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))

                {
                    connection.Open();
                    String sql = "SELECT * FROM participantes WHERE id="+id;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                InfoParticipantes infoParticipantes = new InfoParticipantes();
                                infoParticipantes.id = "" + reader.GetInt32(0);
                                infoParticipantes.nombre = reader.GetString(1);
                                infoParticipantes.apellidos = reader.GetString(2);
                                infoParticipantes.email = reader.GetString(3);
                                infoParticipantes.telefono = "" + reader.GetInt32(4);
                                infoParticipantes.fecha = reader.GetInt32(5);
                                infoParticipantes.altura = "" + reader.GetInt32(6);
                                infoParticipantes.peso = "" + reader.GetInt32(7);
                                

                                Participantes = infoParticipantes;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                campovacio = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            InfoParticipantes infoParticipantes = new InfoParticipantes();
            infoParticipantes.id = Request.Form["id"];
            infoParticipantes.nombre = Request.Form["nombre"];
            infoParticipantes.apellidos = Request.Form["apellidos"];
            infoParticipantes.email = Request.Form["email"];
            infoParticipantes.telefono = Request.Form["telefono"];
            infoParticipantes.fecha = int.Parse(Request.Form["fecha"]);
            infoParticipantes.peso = Request.Form["peso"];
            infoParticipantes.altura = Request.Form["altura"];


            if (infoParticipantes.nombre.Length == 0 || infoParticipantes.apellidos.Length == 0 ||
                infoParticipantes.peso.Length == 0 || infoParticipantes.altura.Length == 0 ||
                infoParticipantes.email.Length == 0 || infoParticipantes.telefono.Length == 0)
            {
                campovacio = "Rellena todos los campos para continuar.";
                return;
            }

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=720server;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE participantes " +
                        "SET nombre=@nombre, apellidos=@apellidos, email=@email, telefono=@telefono, fecha=@fecha, peso=@peso, altura=@altura " +
                        " WHERE id="+ int.Parse(infoParticipantes.id);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", infoParticipantes.nombre);
                        command.Parameters.AddWithValue("@apellidos", infoParticipantes.apellidos);
                        command.Parameters.AddWithValue("@email", infoParticipantes.email);
                        command.Parameters.AddWithValue("@telefono", infoParticipantes.telefono);
                        command.Parameters.AddWithValue("@fecha", infoParticipantes.fecha);
                        command.Parameters.AddWithValue("@peso", infoParticipantes.peso);
                        command.Parameters.AddWithValue("@altura", infoParticipantes.altura);
                        
                        


                        command.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception ex)
            {
                campovacio = ex.Message;
                return;
            }

            Response.Redirect("/Participantes/Index");
        }

    }
}
