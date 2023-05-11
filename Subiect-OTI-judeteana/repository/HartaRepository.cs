using Microsoft.Extensions.Configuration;
using Subiect_OTI_judeteana.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana.repository
{
    public class HartaRepository
    {
        private string connectionString;
        private DataAcces dataAcces;

        public HartaRepository()
        {
            this.dataAcces = new DataAcces();

            this.connectionString =GetConnection();

        }

        public List<Harta> getAllHarti()
        {

            string sql = "select * from harta";

            return dataAcces.LoadData<Harta, dynamic>(sql, new { }, connectionString);

        }

        public string GetConnection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("Default");
            return connectionStringIs;
        }

    }
}
