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
    public class PerfilC 
    {

        public bool insertProfile(C perfilC)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.C.InsertOnSubmit(perfilC);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public C getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            C p = (from pf in db.C where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public C getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            C p = (from pf in db.C where pf.ID == id select pf).SingleOrDefault();
            return p;
            db.Dispose();

        }

        public List<C> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<C> L = (from table in db.C select table).ToList<C>();
            db.Dispose();
            return L;
        }

        public List<C> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<C> L = (from table in db.C orderby table.peso select table).ToList<C>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                C c = (from sel in db.C where sel.nome == name select sel).SingleOrDefault();

                db.C.DeleteOnSubmit(c);
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
                C c = (from sel in db.C where sel.ID == id select sel).SingleOrDefault();

                db.C.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(C perfilC)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                C p = (from sel in db.C where sel.ID == perfilC.ID select sel).SingleOrDefault();
                p.A = perfilC.A;
                p.bf = perfilC.bf;
                p.Cw = perfilC.Cw;
                p.d = perfilC.d;
                p.IT = perfilC.IT;
                p.Ix = perfilC.Ix;
                p.Iy = perfilC.Iy;
                p.nome = perfilC.nome;
                p.peso = perfilC.peso;
                p.ProfCode = perfilC.ProfCode;
                p.rT = perfilC.rT;
                p.rx = perfilC.rx;
                p.ry = perfilC.ry;
                p.tf = perfilC.tf;
                p.tw = perfilC.tw;
                p.Wx = perfilC.Wx;
                p.Wy = perfilC.Wy;
                p.Zx = perfilC.Zx;
                p.Zy = perfilC.Zy;
                p.Fabrication = perfilC.Fabrication;

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
