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
    public class PerfilPSa
    {

        public bool insertProfile(PSa PerfilPSa)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.PSa.InsertOnSubmit(PerfilPSa);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PSa getProfileByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            PSa p = (from pf in db.PSa where pf.nome == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public PSa getProfileByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            // CS oCS = new CS();
            PSa p = (from pf in db.PSa where pf.ID == id select pf).SingleOrDefault();
            db.Dispose();
            return p;
         }

        public List<PSa> getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<PSa> L = (from table in db.PSa select table).ToList<PSa>();
            db.Dispose();
            return L;
        }

        public List<PSa> getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<PSa> L = (from table in db.PSa orderby table.peso select table).ToList<PSa>();
            db.Dispose();
            return L;
        }

        public bool deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                PSa c = (from sel in db.PSa where sel.nome == name select sel).SingleOrDefault();

                db.PSa.DeleteOnSubmit(c);
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
                PSa c = (from sel in db.PSa where sel.ID == id select sel).SingleOrDefault();

                db.PSa.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateProfile(PSa perfilPSa)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                PSa p = (from sel in db.PSa where sel.ID == perfilPSa.ID select sel).SingleOrDefault();
                p.A = perfilPSa.A;
                p.bfs = perfilPSa.bfs;
                p.bfi = perfilPSa.bfi;
                p.tfi = perfilPSa.tfi;
                p.tfs = perfilPSa.tfs;
                p.Cw = perfilPSa.Cw;
                p.d = perfilPSa.d;
                p.IT = perfilPSa.IT;
                p.Ix = perfilPSa.Ix;
                p.Iy = perfilPSa.Iy;
                p.nome = perfilPSa.nome;
                p.peso = perfilPSa.peso;
                p.ProfCode = perfilPSa.ProfCode;
                p.R = perfilPSa.R;
                p.rT = perfilPSa.rT;
                p.rx = perfilPSa.rx;
                p.ry = perfilPSa.ry;
                p.tw = perfilPSa.tw;
                p.Wxs = perfilPSa.Wxs;
                p.Wxi = perfilPSa.Wxi;
                p.Wy = perfilPSa.Wy;
                p.Zx = perfilPSa.Zx;
                p.Zy = perfilPSa.Zy;
                p.Fabrication = perfilPSa.Fabrication;

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
