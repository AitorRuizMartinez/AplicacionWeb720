using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AplicacionWeb720.Pages.Participantes
{
    public class IndexModel : PageModel
    {
        public List<InfoParticipantes> listaParticipantes = new List<InfoParticipantes>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=720server;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM participantes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                InfoParticipantes participantes = new InfoParticipantes();
                                participantes.dorsal = "000" + reader.GetInt32(0);
                                participantes.nombre = reader.GetString(1);
                                participantes.apellidos = reader.GetString(2);
                                participantes.correo = reader.GetString(3);
                                participantes.telefono = reader.GetString(4);
                                participantes.altura = reader.GetString(5);
                                participantes.peso = reader.GetString(6);
                                participantes.fecha = reader.GetString(7);

                                listaParticipantes.Add(participantes);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class InfoParticipantes
    {
        public String dorsal;
        public String nombre;
        public String apellidos;
        public String correo;
        public String telefono;
        public String fecha;
        public String peso;
        public String altura;
    }
}
