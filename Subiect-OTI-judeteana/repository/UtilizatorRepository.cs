using Microsoft.Extensions.Configuration;
using Subiect_OTI_judeteana.data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect_OTI_judeteana.repository
{
    public class UtilizatorRepository
    {
        private string connectionString;
        private DataAcces dataAcces;

        public UtilizatorRepository()
        {
            this.dataAcces = new DataAcces();

            this.connectionString =GetConnection();

        }

        public List<Utilizator> getAllUtilizatori()
        {

            string sql = "SELECT *FROM utilizatori";

            return dataAcces.LoadData<Utilizator, dynamic>(sql, new { }, connectionString);

        }

        public void isUtilizator(string name,string password)
        {

            string sql = "select case when exists (select 1 from utilizatori where name=@name and password=@password) then 1 else 0 end";

            this.dataAcces.LoadData<Utilizator,dynamic>(sql, new { name,password },connectionString);


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
