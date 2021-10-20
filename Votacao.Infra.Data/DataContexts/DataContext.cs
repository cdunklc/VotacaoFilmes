using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votacao.Infra.Settings;

namespace Votacao.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SqlServerConexao { get; set; }

        public DataContext(AppSettings appSetings)
        {
            try
            {
                SqlServerConexao = new SqlConnection(appSetings.ConnectionString);
                SqlServerConexao.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (SqlServerConexao.State != System.Data.ConnectionState.Closed)
                    SqlServerConexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
