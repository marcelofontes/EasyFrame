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
    public class PerfilVSM
    {

        public bool insertProfile(VSM PerfilVSM)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.VSM.InsertOnSubmit(PerfilVSM);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public VSM getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            VSM p = (from pf in db.VSM where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public VSM getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            VSM p = (from pf in db.VSM where pf.ID == id select pf).SingleOrDefault();
            db.Dispose();
            return p;
           
        }

        public List<VSM> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<VSM> L = (from table in db.VSM select table).ToList<VSM>();
            db.Dispose();
            return L;
        }

        public List<VSM> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<VSM> L = (from table in db.VSM orderby table.peso select table).ToList<VSM>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                VSM c = (from sel in db.VSM where sel.nome == name select sel).SingleOrDefault();

                db.VSM.DeleteOnSubmit(c);
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
                VSM c = (from sel in db.VSM where sel.ID == id select sel).SingleOrDefault();

                db.VSM.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(VSM perfilVSM)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                VSM p = (from sel in db.VSM where sel.ID == perfilVSM.ID select sel).SingleOrDefault();
                p.A = perfilVSM.A;
                p.bfs = perfilVSM.bfs;
                p.bfi = perfilVSM.bfi;
                p.tfi = perfilVSM.tfi;
                p.tfs = perfilVSM.tfs;
                p.Cw = perfilVSM.Cw;
                p.d = perfilVSM.d;
                p.IT = perfilVSM.IT;
                p.Ix = perfilVSM.Ix;
                p.Iy = perfilVSM.Iy;
                p.nome = perfilVSM.nome;
                p.peso = perfilVSM.peso;
                p.ProfCode = perfilVSM.ProfCode;
                p.R = perfilVSM.R;
                p.rT = perfilVSM.rT;
                p.rx = perfilVSM.rx;
                p.ry = perfilVSM.ry;
                p.tw = perfilVSM.tw;
                p.Wxs = perfilVSM.Wxs;
                p.Wxi = perfilVSM.Wxi;
                p.Wy = perfilVSM.Wy;
                p.Zx = perfilVSM.Zx;
                p.Zy = perfilVSM.Zy;
                p.Fabrication = perfilVSM.Fabrication;

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
