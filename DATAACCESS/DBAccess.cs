using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace DATAACCESS
{
    public class DBAccess
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        string path;

        public DBAccess(string dbfile)
        {
            path = Directory.GetCurrentDirectory() + @"\Data\"+dbfile;
            conn = new SQLiteConnection("Data Source = "+ path);
            cmd = new SQLiteCommand(conn);
            try
            {
                conn.Open();
                Console.WriteLine("Banco de dados de perfis aberto com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<SQLiteDataReader> consulta(string sql)
        {
            cmd.CommandText = sql;
            SQLiteDataReader rd = cmd.ExecuteReader();
            List<SQLiteDataReader> r = new List<SQLiteDataReader>();
                while(rd.Read())
                {
                    Console.WriteLine(rd["nome"]);
                    r.Add(rd);
                }
            
            Console.WriteLine("Banco de dados de Perfis fechado com sucesso.");
            return r;
        }
        
    }

   
}
