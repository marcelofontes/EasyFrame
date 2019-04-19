using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
//using System.Data.SQLite.Linq;

namespace DATAACCESS
{

    [Database(Name = "CSTable")]
    public class DBLinqMapping 
       {

        public Table<WProfile>       W;
        public Table<CSProfile>     CS;
        public Table<VSProfile>     VS;
        public Table<CVSProfile>    CVS;
        public Table<PSProfile>     PS;
        public Table<PSaProfile>    PSa;
        public Table<VSMProfile>    VSM;


        public DBLinqMapping()
        {
            string path = Directory.GetCurrentDirectory() + @"\Data\"+"CSTable.db";
            
            try
            {
                SQLiteConnection con = new SQLiteConnection("Data Source = " + path);
                var context = new DataContext(con);
                
                Console.WriteLine("Banco de dados de perfis aberto com sucesso");

                // Mapping tables
                W = context.GetTable<WProfile>();
                CS = context.GetTable<CSProfile>();
                CVS = context.GetTable<CVSProfile>();
                PS = context.GetTable<PSProfile>();
                VS = context.GetTable<VSProfile>();
                VSM = context.GetTable<VSMProfile>();
                PSa = context.GetTable<PSaProfile>();

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    // table mapping to use linq
    [Table(Name = "W")]
    public class WProfile
    {
        //public clsMaterial material { set; get; }

        [Column(IsPrimaryKey = true)]    public int ID { set; get; }
        [Column]    public string nome { set; get; }
        [Column]    public double peso { set; get; }

        //[Column] public string table;
        [Column]    public double A { set; get; }
        [Column]    public double d { set; get; }       // out-out depth
        [Column]    public double tw { set; get; }
        [Column]    public double bf { set; get; }
        [Column]    public double tf { set; get; }
        [Column]    public double Ix { set; get; }
        [Column]    public double Wx { set; get; }
        [Column]    public double rx { set; get; }
        [Column]    public double Zx { set; get; }
        [Column]    public double Iy { set; get; }
        [Column]    public double Wy { set; get; }
        [Column]    public double ry { set; get; }
        [Column]    public double Zy { set; get; }
        [Column]    public double rT { set; get; }
        [Column]    public double IT { set; get; }
        [Column]    public double Cw { set; get; }
        [Column]    public double R  { set; get; }
        [Column]    public int profCode { set; get; }
        [Column]    public int fabrication { set; get; }

        //[Column] public double YCG { set; get; }
        //[Column] public double XCG { set; get; }

        //[Column] public double alpha { set; get; }   // lip angle

        public WProfile() { }

      }

    // table mapping to use linq
    [Table(Name = "CS")]
    public class CSProfile
    {
        //public clsMaterial material { set; get; }

        [Column(IsPrimaryKey = true)]        public int ID { set; get; }
        [Column]        public string nome { set; get; }
        [Column]        public double peso { set; get; }

        //[Column] public string table;
        [Column]        public double A { set; get; }
        [Column]        public double d { set; get; }       // out-out depth
        [Column]        public double tw { set; get; }
        [Column]        public double bf { set; get; }
        [Column]        public double tf { set; get; }
        [Column]        public double Ix { set; get; }
        [Column]        public double Wx { set; get; }
        [Column]        public double rx { set; get; }
        [Column]        public double Zx { set; get; }
        [Column]        public double Iy { set; get; }
        [Column]        public double Wy { set; get; }
        [Column]        public double ry { set; get; }
        [Column]        public double Zy { set; get; }
        [Column]        public double rT { set; get; }
        [Column]        public double IT { set; get; }
        [Column]        public double Cw { set; get; }
        [Column]        public double R  { set; get; }
        [Column]        public int profCode { set; get; }
        [Column]        public int fabrication { set; get; }

        //[Column] public double YCG { set; get; }
        //[Column] public double XCG { set; get; }

        //[Column] public double alpha { set; get; }   // lip angle

        public CSProfile() { }

    }

    // table mapping to use linq
    [Table(Name = "VS")]
    public class VSProfile
    {
        //public clsMaterial material { set; get; }

        [Column(IsPrimaryKey = true)]        public int ID { set; get; }
        [Column]        public string nome { set; get; }
        [Column]        public double peso { set; get; }

        //[Column] public string table;
        [Column]        public double A { set; get; }
        [Column]        public double d { set; get; }       // out-out depth
        [Column]        public double tw { set; get; }
        [Column]        public double bf { set; get; }
        [Column]        public double tf { set; get; }
        [Column]        public double Ix { set; get; }
        [Column]        public double Wx { set; get; }
        [Column]        public double rx { set; get; }
        [Column]        public double Zx { set; get; }
        [Column]        public double Iy { set; get; }
        [Column]        public double Wy { set; get; }
        [Column]        public double ry { set; get; }
        [Column]        public double Zy { set; get; }
        [Column]        public double rT { set; get; }
        [Column]        public double IT { set; get; }
        [Column]        public double Cw { set; get; }
        [Column]        public double R  { set; get; }
        [Column]        public int profCode { set; get; }
        [Column]        public int fabrication { set; get; }

        //[Column] public double YCG { set; get; }
        //[Column] public double XCG { set; get; }

        //[Column] public double alpha { set; get; }   // lip angle

        public VSProfile() { }

    }

    // table mapping to use linq
    [Table(Name = "CVS")]
    public class CVSProfile
    {
        //public clsMaterial material { set; get; }

        [Column(IsPrimaryKey = true)]        public int ID { set; get; }
        [Column]        public string nome { set; get; }
        [Column]        public double peso { set; get; }

        //[Column] public string table;
        [Column]        public double A { set; get; }
        [Column]        public double d { set; get; }       // out-out depth
        [Column]        public double tw { set; get; }
        [Column]        public double bf { set; get; }
        [Column]        public double tf { set; get; }
        [Column]        public double Ix { set; get; }
        [Column]        public double Wx { set; get; }
        [Column]        public double rx { set; get; }
        [Column]        public double Zx { set; get; }
        [Column]        public double Iy { set; get; }
        [Column]        public double Wy { set; get; }
        [Column]        public double ry { set; get; }
        [Column]        public double Zy { set; get; }
        [Column]        public double rT { set; get; }
        [Column]        public double IT { set; get; }
        [Column]        public double Cw { set; get; }
        [Column]        public double R  { set; get; }
        [Column]        public int profCode { set; get; }
        [Column]        public int fabrication { set; get; }

        //[Column] public double YCG { set; get; }
        //[Column] public double XCG { set; get; }

        //[Column] public double alpha { set; get; }   // lip angle

        public CVSProfile() { }

    }

    // table mapping to use linq
    [Table(Name = "PS")]
    public class PSProfile
    {
        //public clsMaterial material { set; get; }

        [Column(IsPrimaryKey = true)]        public int ID { set; get; }
        [Column]        public string nome { set; get; }
        [Column]        public double peso { set; get; }

        //[Column] public string table;
        [Column]        public double A { set; get; }
        [Column]        public double d { set; get; }       // out-out depth
        [Column]        public double tw { set; get; }
        [Column]        public double bf { set; get; }
        [Column]        public double tf { set; get; }
        [Column]        public double Ix { set; get; }
        [Column]        public double Wx { set; get; }
        [Column]        public double rx { set; get; }
        [Column]        public double Zx { set; get; }
        [Column]        public double Iy { set; get; }
        [Column]        public double Wy { set; get; }
        [Column]        public double ry { set; get; }
        [Column]        public double Zy { set; get; }
        [Column]        public double rT { set; get; }
        [Column]        public double IT { set; get; }
        [Column]        public double Cw { set; get; }
        [Column]        public double R  { set; get; }
        [Column]        public int profCode { set; get; }
        [Column]        public int fabrication { set; get; }

        //[Column] public double YCG { set; get; }
        //[Column] public double XCG { set; get; }

        //[Column] public double alpha { set; get; }   // lip angle

        public PSProfile() { }

    }

    [Table(Name = "VSM")]
    public class VSMProfile
    {
        
        [Column(IsPrimaryKey =true)]        public int ID { set; get; }
        [Column]        public string nome { set; get; }
        [Column]        public double peso { set; get; }
        [Column]        public double A { set; get; }
        [Column]        public double d { set; get; }       // out-out depth
        [Column]        public double tw { set; get; }
        [Column]        public double bfs { set; get; }
        [Column]        public double bfi { set; get; }
        [Column]        public double tfs { set; get; }
        [Column]        public double tfi { set; get; }
        [Column]        public double Ix { set; get; }
        [Column]        public double Wxs { set; get; }
        [Column]        public double Wxi { set; get; }
        [Column]        public double rx { set; get; }
        [Column]        public double Zx { set; get; }
        [Column]        public double Iy { set; get; }
        [Column]        public double Wy { set; get; }
        [Column]        public double ry { set; get; }
        [Column]        public double Zy { set; get; }
        [Column]        public double rT { set; get; }
        [Column]        public double IT { set; get; }
        [Column]        public double Cw { set; get; }
        [Column]        public double R  { set; get; }
        [Column]        public int profCode;
        [Column]        public int fabrication;

        public VSMProfile() { }

    }

    [Table(Name = "PSa")]
    public class PSaProfile
    {

        [Column(IsPrimaryKey = true)]        public int ID { set; get; }
        [Column]        public string nome { set; get; }
        [Column]        public double peso { set; get; }
        [Column]        public double A { set; get; }
        [Column]        public double d { set; get; }       // out-out depth
        [Column]        public double tw { set; get; }
        [Column]        public double bfs { set; get; }
        [Column]        public double bfi { set; get; }
        [Column]        public double tfs { set; get; }
        [Column]        public double tfi { set; get; }
        [Column]        public double Ix { set; get; }
        [Column]        public double Wxs { set; get; }
        [Column]        public double Wxi { set; get; }
        [Column]        public double rx { set; get; }
        [Column]        public double Zx { set; get; }
        [Column]        public double Iy { set; get; }
        [Column]        public double Wy { set; get; }
        [Column]        public double ry { set; get; }
        [Column]        public double Zy { set; get; }
        [Column]        public double rT { set; get; }
        [Column]        public double IT { set; get; }
        [Column]        public double Cw { set; get; }
        [Column]        public double R  { set; get; }
        [Column]        public int profCode;
        [Column]        public int fabrication;

        public PSaProfile() { }


    }
    }