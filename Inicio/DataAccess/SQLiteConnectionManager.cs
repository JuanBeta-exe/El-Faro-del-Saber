using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;

namespace LoginV1.DataAccess
{
    internal static class SQLiteConnectionManager
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        /// <summary>
        /// Obtiene una nueva conexión SQLite.
        /// </summary>
        /// <returns>Una instancia de SQLiteConnection.</returns>
        public static SQLiteConnection GetConnection()
        {
            try
            {
                var connection = new SQLiteConnection(cadena);
                return connection;
            }
            catch (Exception ex)
            {
                // Manejo de errores al obtener la conexión
                throw new Exception("Error al crear la conexión a la base de datos.", ex);
            }
        }
    }
}
