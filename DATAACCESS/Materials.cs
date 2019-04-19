using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAACCESS
{
   public class Materials
    {
        public bool insertMaterial(Material mat)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            try
            {
                db.Materials.InsertOnSubmit(mat);
                db.SubmitChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Material getMaterialByName(string name)
        {

            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            Material p = (from pf in db.Materials where pf.name == name select pf).SingleOrDefault();
            db.Dispose();
            return p;

        }

        public Material getMaterialByID(int id)
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
            Material p = (from pf in db.Materials where pf.ID == id select pf).SingleOrDefault();
            return p;
            db.Dispose();

        }

        public List<Material> getMaterialTable()
        {
            DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();

            List<Material> L = (from table in db.Materials select table).ToList<Material>();
            db.Dispose();
            return L;
        }

        public bool deleteMaterial(string name)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                Material c = (from sel in db.Materials where sel.name == name select sel).SingleOrDefault();

                db.Materials.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteMaterial(int id)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                Material c = (from sel in db.Materials where sel.ID == id select sel).SingleOrDefault();

                db.Materials.DeleteOnSubmit(c);
                db.SubmitChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateMaterial(Material mat)
        {
            try
            {
                DataAccsessDataClassesDataContext db = new DataAccsessDataClassesDataContext();
                Material p = (from sel in db.Materials where sel.ID == mat.ID select sel).SingleOrDefault();
                p.name = mat.name;
                p.E = mat.E;
                p.G = mat.G;
                p.Fy = mat.Fy;
                p.Fu = mat.Fu;
                p.unitWeight = mat.unitWeight;
                
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
