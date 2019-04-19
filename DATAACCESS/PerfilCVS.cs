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
    public class PerfilCVS
    {

        public bool insertProfile(CVS perfilCVS)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.CVS.InsertOnSubmit(perfilCVS);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CVS getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            CVS p = (from pf in db.CVS where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public CVS getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            CVS p = (from pf in db.CVS where pf.ID == id select pf).SingleOrDefault();
            db.Dispose();
            return p;
            

        }

        public List<CVS> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<CVS> L = (from table in db.CVS select table).ToList<CVS>();
            db.Dispose();
            return L;
        }

        public List<CVS> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<CVS> L = (from table in db.CVS orderby table.peso select table).ToList<CVS>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                CVS c = (from sel in db.CVS where sel.nome == name select sel).SingleOrDefault();

                db.CVS.DeleteOnSubmit(c);
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
                CVS c = (from sel in db.CVS where sel.ID == id select sel).SingleOrDefault();

                db.CVS.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(CVS perfilCS)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                CVS p = (from sel in db.CVS where sel.ID == perfilCS.ID select sel).SingleOrDefault();
                p.A = perfilCS.A;
                p.bf = perfilCS.bf;
                p.Cw = perfilCS.Cw;
                p.d = perfilCS.d;
                p.IT = perfilCS.IT;
                p.Ix = perfilCS.Ix;
                p.Iy = perfilCS.Iy;
                p.nome = perfilCS.nome;
                p.peso = perfilCS.peso;
                p.ProfCode = perfilCS.ProfCode;
                p.R = perfilCS.R;
                p.rT = perfilCS.rT;
                p.rx = perfilCS.rx;
                p.ry = perfilCS.ry;
                p.tf = perfilCS.tf;
                p.tw = perfilCS.tw;
                p.Wx = perfilCS.Wx;
                p.Wy = perfilCS.Wy;
                p.Zx = perfilCS.Zx;
                p.Zy = perfilCS.Zy;
                p.Fabrication = perfilCS.Fabrication;

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
