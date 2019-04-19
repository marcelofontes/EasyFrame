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
    public class PerfilW
    {

        public bool insertProfile(W PerfilW)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.W.InsertOnSubmit(PerfilW);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                db.Dispose();
                return false;
            }
            
        }

        public W getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            W p = (from pf in db.W where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public W getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            W p = (from pf in db.W where pf.ID == id select pf).SingleOrDefault();
            return p;
            db.Dispose();

        }

        public List<W> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<W> L = (from table in db.W select table).ToList<W>();
            db.Dispose();
            return L;
        }

        public List<W> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<W> L = (from table in db.W orderby table.peso select table).ToList<W>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                W c = (from sel in db.W where sel.nome == name select sel).SingleOrDefault();

                db.W.DeleteOnSubmit(c);
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
                W c = (from sel in db.W where sel.ID == id select sel).SingleOrDefault();

                db.W.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(W perfilW)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                W p = (from sel in db.W where sel.ID == perfilW.ID select sel).SingleOrDefault();
                p.A = perfilW.A;
                p.bf = perfilW.bf;
                p.Cw = perfilW.Cw;
                p.d = perfilW.d;
                p.IT = perfilW.IT;
                p.Ix = perfilW.Ix;
                p.Iy = perfilW.Iy;
                p.nome = perfilW.nome;
                p.peso = perfilW.peso;
                p.ProfCode = perfilW.ProfCode;
                p.R = perfilW.R;
                p.rT = perfilW.rT;
                p.rx = perfilW.rx;
                p.ry = perfilW.ry;
                p.tf = perfilW.tf;
                p.tw = perfilW.tw;
                p.Wx = perfilW.Wx;
                p.Wy = perfilW.Wy;
                p.Zx = perfilW.Zx;
                p.Zy = perfilW.Zy;
                p.Fabrication = perfilW.Fabrication;

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
