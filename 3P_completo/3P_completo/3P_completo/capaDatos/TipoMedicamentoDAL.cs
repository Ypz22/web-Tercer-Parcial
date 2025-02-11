using capaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace capaDatos
{
    public class TipoMedicamentoDAL
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> Lista = null;

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO, NOMBRE, DESCRIPCION FROM TipoMedicamento WHERE BHABILITADO = 1", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if(drd != null)
                        {
                            TipoMedicamentoCLS oTipoMedicamentoCLS;
                            Lista = new List<TipoMedicamentoCLS>();

                            while (drd.Read())
                            {
                                oTipoMedicamentoCLS = new TipoMedicamentoCLS();
                                oTipoMedicamentoCLS.idTipoMedicamento = drd.GetInt32(0);
                                oTipoMedicamentoCLS.nombre = drd.GetString(1);
                                oTipoMedicamentoCLS.descripcion = drd.GetString(2);
                                Lista.Add(oTipoMedicamentoCLS);
                            }
                        }
                    }
                }
                catch(Exception)
                {
                    cn.Close();
                    Lista = null;
                }
            }

            return Lista;
        }

        public List<UsuarioCLS> listarUsuarios()
        {
            List<UsuarioCLS> Lista = null;

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOUSUARIO, NOMBRE, DESCRIPCION FROM TipoUsuario WHERE BHABILITADO = 1", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            UsuarioCLS oTipoMedicamentoCLS;
                            Lista = new List<UsuarioCLS>();

                            while (drd.Read())
                            {
                                oTipoMedicamentoCLS = new UsuarioCLS();
                                oTipoMedicamentoCLS.idTipoUsuario = drd.GetInt32(0);
                                oTipoMedicamentoCLS.nombre = drd.GetString(1);
                                oTipoMedicamentoCLS.descripcion = drd.GetString(2);
                                Lista.Add(oTipoMedicamentoCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    Lista = null;
                }
            }

            return Lista;
        }
        /*
    {
        List<TipoMedicamentoCLS> Lista = new List<TipoMedicamentoCLS>();
        Lista.Add(new TipoMedicamentoCLS {
            idMedicamento = 1,
            nombre = "Analgésico",
            descripcion = "Desc 1"
        });
        Lista.Add(new TipoMedicamentoCLS
        {
            idMedicamento = 2,
            nombre = "Antibiótico",
            descripcion = "Desc 2"
        });
        Lista.Add(new TipoMedicamentoCLS
        {
            idMedicamento = 3,
            nombre = "Paracetalemol",
            descripcion = "Desc 3"
        });
        return Lista;

    }
}*/
    }
}