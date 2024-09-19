using System.Data.SqlClient;

namespace CurdDeYoutube.Datos
{
    public class ConexionDB
    {
        private string cadenaSql = string.Empty;

        public ConexionDB()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSql = builder.GetSection("ConnectionStrings:CadenaSql").Value;
        }

        public string getCadenaSql()
        {
            return cadenaSql;

        }

    }
}
