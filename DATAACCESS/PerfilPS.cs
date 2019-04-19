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
    public class PerfilPS
    {

        public bool insertProfile(PS perfilPS)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.PS.InsertOnSubmit(perfilPS);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PS getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            PS p = (from pf in db.PS where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public PS getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            PS p = (from pf in db.PS where pf.ID == id select pf).SingleOrDefault();
            db.Dispose();
            return p;
           

        }

        public List<PS> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<PS> L = (from table in db.PS select table).ToList<PS>();
            db.Dispose();
            return L;
        }

        public List<PS> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<PS> L = (from table in db.PS orderby table.peso select table).ToList<PS>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                PS c = (from sel in db.PS where sel.nome == name select sel).SingleOrDefault();

                db.PS.DeleteOnSubmit(c);
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
                PS c = (from sel in db.PS where sel.ID == id select sel).SingleOrDefault();

                db.PS.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(PS perfilPS)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                PS p = (from sel in db.PS where sel.ID == perfilPS.ID select sel).SingleOrDefault();
                p.A = perfilPS.A;
                p.bf = perfilPS.bf;
                p.Cw = perfilPS.Cw;
                p.d = perfilPS.d;
                p.IT = perfilPS.IT;
                p.Ix = perfilPS.Ix;
                p.Iy = perfilPS.Iy;
                p.nome = perfilPS.nome;
                p.peso = perfilPS.peso;
                p.ProfCode = perfilPS.ProfCode;
                p.R = perfilPS.R;
                p.rT = perfilPS.rT;
                p.rx = perfilPS.rx;
                p.ry = perfilPS.ry;
                p.tf = perfilPS.tf;
                p.tw = perfilPS.tw;
                p.Wx = perfilPS.Wx;
                p.Wy = perfilPS.Wy;
                p.Zx = perfilPS.Zx;
                p.Zy = perfilPS.Zy;
                p.Fabrication = perfilPS.Fabrication;

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
