using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATAACCESS
{
    /// <summary>
    /// Gerencia a tabela de perfis CS
    /// </summary>
    public class PerfilVS    {

        public bool insertProfile(VS PerfilVS)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.VS.InsertOnSubmit(PerfilVS);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public VS getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            VS p = (from pf in db.VS where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public VS getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            VS p = (from pf in db.VS where pf.ID == id select pf).SingleOrDefault();
            db.Dispose();
            return p;
           

        }

        public List<VS> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<VS> L = (from table in db.VS select table).ToList<VS>();
            db.Dispose();
            return L;
        }

        public List<VS> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<VS> L = (from table in db.VS orderby table.peso select table).ToList<VS>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                VS c = (from sel in db.VS where sel.nome == name select sel).SingleOrDefault();

                db.VS.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteProfile(int id)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                VS c = (from sel in db.VS where sel.ID == id select sel).SingleOrDefault();

                db.VS.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(VS perfilVS)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                VS p = (from sel in db.VS where sel.ID == perfilVS.ID select sel).SingleOrDefault();
                p.A = perfilVS.A;
                p.bf = perfilVS.bf;
                p.Cw = perfilVS.Cw;
                p.d = perfilVS.d;
                p.IT = perfilVS.IT;
                p.Ix = perfilVS.Ix;
                p.Iy = perfilVS.Iy;
                p.nome = perfilVS.nome;
                p.peso = perfilVS.peso;
                p.ProfCode = perfilVS.ProfCode;
                p.R = perfilVS.R;
                p.rT = perfilVS.rT;
                p.rx = perfilVS.rx;
                p.ry = perfilVS.ry;
                p.tf = perfilVS.tf;
                p.tw = perfilVS.tw;
                p.Wx = perfilVS.Wx;
                p.Wy = perfilVS.Wy;
                p.Zx = perfilVS.Zx;
                p.Zy = perfilVS.Zy;
                p.Fabrication = perfilVS.Fabrication;

                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
