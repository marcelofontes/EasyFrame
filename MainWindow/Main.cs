using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Sql;
using System.Linq;
using FEM;



namespace Beam
{
    class teste
    {
        
        //static void Main(string[] args)
        //{
        //    List<double> v = new List<double>();
        //    v.Add(10);
        //    //v.Add(8.5);
        //    // v.Add(5);

        //    // generate Load Classes
        //    //clsLoadClass l1 = new clsLoadClass(1, "PP", 1.25, 1, 1, 1,false);
        //    // clsLoadClass lc2 = new clsLoadClass(1, "SC", 1.25, 1, 1, 1,false);


        //    CsSection c = new CsSection();
        //    //DBLinqMapping db = new DBLinqMapping();

        //    //var i = from aa in db.W where aa.nome == "W 530 x 66,0" select aa;
        //    //var a = i.ToList();
                          
        //    //    c.Name = a[0].nome;
        //    //    c.wgt = a[0].peso;
        //    //    c.A = a[0].A;
        //    //    c.d = a[0].d;
        //    //    c.tw = a[0].tw;
        //    //    c.bfs = a[0].bf;
        //    //    c.bfi = a[0].bf;
        //    //    c.tfi = a[0].tf;
        //    //    c.tfs = a[0].tf;
        //    //    c.Ix = a[0].Ix;
        //    //    c.Wxs = a[0].Wx;
        //    //    c.Wxi = a[0].Wx;
        //    //    c.rx = a[0].rx;
        //    //    c.Zx = a[0].Zx;
        //    //    c.Iy = a[0].Iy;
        //    //    c.Wy = a[0].Wy;
        //    //    c.ry = a[0].ry;
        //    //    c.Zy = a[0].Zy;
        //    //    c.rT = a[0].rT;
        //    //    c.It = a[0].IT;
        //    //    c.Cw = a[0].Cw;
        //    //    c.R  = a[0].R;
        //    //    c.profCode = a[0].profCode;
        //    //    c.fabrication = a[0].fabrication;
        //    //    c.material = new SteelMaterial("A36", 200000000, 77000000, 25, 40);    //[KN/m2]

           
        //    Beam.clsBeam b = new Beam.clsBeam(1, "Viga", v, c);

        //    //clsLoad l = new clsLoad(1, "teste", 1, 0, -10, 0, new clsLoadCase(1, "Peso", l1),LoadType.D,0);
        //    clsLoad ld1 = new clsLoad(1, "teste", 0, -50, 0, b.LCase.First(), LoadType.D, 0); // [kN/m]
        //    //clsLoad ld3 = new clsLoad(1, "teste", 0, -50, 0, new clsLoadCase(1, "SC", lc2), LoadType.D, 0); // [kN/m]
        //    //clsLoad ld4 = new clsLoad(1, "teste", 0, -10, 0, new clsLoadCase(1, "SC", lc2), LoadType.D, 0); // [kN/m]
        //    //clsLoad ld5 = new clsLoad(1, "teste", 0, -10, 0, new clsLoadCase(1, "SC", lc2), LoadType.D, 0); // [kN/m]

        //    //clsLoad ld2 = new clsLoad(1, "teste",  0, -100, 0, new clsLoadCase(1, "SC", lc2), LoadType.P, 2.5);
        //    //clsLoad ld6 = new clsLoad(1, "teste", 0, -10, 0, new clsLoadCase(1, "SC", lc2), LoadType.P, 7);


        //    // b.addLineLoad(l, 1);
        //    b.addLineLoad(ld1);
        //    //b.addLineLoad(ld3);
        //    //b.addLineLoad(ld4);
        //    //b.addLineLoad(ld5);

        //    //b.addPointLoadonBeam(ld2);
        //    //b.addPointLoadonBeam(ld6);

        //    b.AssembleModel();
        //    b.solveEquation();
        //    b.calculateInternalForces();
        //    b.calculateReactions();
        //    b.calculeSpanInternalForces();
        //    b.calculateSpanDisplacements();
        //    var cb = b.calculateCb(3, b.LCombination.First());
        //    var teste = b.calculateCombIntForces(b.LCombination.First());

        //    //IntForces iF = b.getInternalForces("SC", 10);

        //    //DBAccess db = new DBAccess("CSTable.db");
        //    //string sql = "SELECT * FROM CVS";
        //    //List<SQLiteDataReader> r =db.consulta(sql);
        //    //// List<string> res = db.consulta(sql);
        //    Console.WriteLine(c.Name);

        //    // db.closeDB();
        //    Console.ReadKey();
            

        //}
    }
}
