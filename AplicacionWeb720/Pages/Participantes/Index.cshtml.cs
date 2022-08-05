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

                String connectionString = "Data Source =.\\sqlexpress; Initial Catalog = 720server; Integrated Security = True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM dbo.participantes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                InfoParticipantes participantesInfo = new InfoParticipantes();
                                participantesInfo.dorsal = "000" + reader.GetInt32(0);
                                participantesInfo.nombre = reader.GetString(1);
                                participantesInfo.apellidos = reader.GetString(2);
                                participantesInfo.correo = reader.GetString(3);
                                participantesInfo.telefono = "" + reader.GetInt32(4);
                                participantesInfo.altura = "" + reader.GetInt32(5);
                                participantesInfo.peso = "" + reader.GetInt32(6);
                                participantesInfo.fecha = "" + reader.GetInt32(7);

                                listaParticipantes.Add(participantesInfo);
                            }
                        }
                    }
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
