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
    public class PerfilCS
    {

        public  bool      insertProfile(CS perfilCS)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.CS.InsertOnSubmit(perfilCS);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  CS        getProfileByName(string name)
        {
           
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
       
                CS p = (from pf in db.CS where pf.nome == name select pf).SingleOrDefault();
                db.Dispose();
            return p;
         
        }

        public  CS        getProfileByID(int id)
        {
           DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                // CS oCS = new CS();
                CS p = (from pf in db.CS where pf.ID == id select pf).SingleOrDefault();
                return p;
                db.Dispose();
           
        }

        public  List<CS>  getCSTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<CS> L = (from table in db.CS select table).ToList<CS>();
            db.Dispose();
            return L; 
        }

        public  List<CS>  getCSTableOrderedByWeight()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<CS> L = (from table in db.CS orderby table.peso select table ).ToList<CS>();
            db.Dispose();
            return L;
        }

        public  bool      deleteProfile(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                CS c = (from sel in db.CS where sel.nome == name select sel).SingleOrDefault();

                db.CS.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool      deleteProfile(int id)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                CS c = (from sel in db.CS where sel.ID == id select sel).SingleOrDefault();

                db.CS.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool      updateProfile(CS perfilCS)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                CS p = (from sel in db.CS where sel.ID == perfilCS.ID select sel).SingleOrDefault();
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
