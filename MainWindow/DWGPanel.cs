using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using FEM;
using Beam;
using System.Drawing;


namespace MainWin
{
    class DWGPanel: Panel
    {
        Graphics        g;
        Pen             penViga         = new Pen           (Color.Blue,5);
        Pen             penSupp         = new Pen           (Color.Red);
        Pen             penDim          = new Pen           (Color.Red, 1);
        Pen             penPLoad        = new Pen           (Color.Yellow, 1);
        SolidBrush      brushSupp       = new SolidBrush    (Color.Red);
        SolidBrush      brushLatSupp    = new SolidBrush    (Color.Green);
        SolidBrush      brushDim        = new SolidBrush    (Color.Red);
        SolidBrush      brushDimText    = new SolidBrush    (Color.Green);
        SolidBrush      brushPLoad      = new SolidBrush    (Color.Yellow);
        Font            fontDimText     = new Font          ("Arial", 14);

        double          aspectRatio;
        int             maxWidth;
        int             maxHeight;
        double          Length;
        List<PointF>    LP              = new List<PointF>();
        List<float>     lbTop;
        List<float>     lbBottom;
        List<dwgPointLoad>    pPointLoad;
        
        bool            drawDim         = true;
        double          dimOffset;        // in %

        public                  DWGPanel()
        {
            //this.BackColor = System.Drawing.Color.Black;
            g = this.CreateGraphics();

            lbTop           = new List<float>();
            lbBottom        = new List<float>();
            pPointLoad      = new List<dwgPointLoad>();

        }

        public void             drawBeam(List<PointF> Plist, List<float> lbtop,List<float> lbbottom)
        {
            LP = Plist.ToList();
            g = this.CreateGraphics();
            g.Clear(SystemColors.InactiveCaption);
            double sc;
            double L;
            PointF pt1, pt2, p1, p2;
            int n = Plist.Count();
            double Ymax = this.Height - 15;

            Length = Plist.Last().X;

            sc = (this.Width - 30) / Length;

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    pt1 = new PointF(15, 0);
                    p1 = pt1;
                    p1.Y = (float)Ymax / 2;
                    this.drawSupport(p1, sc);
                }
                else
                {
                    //pt1 = Plist[i-1];
                    p1 = Plist[i - 1];
                    p1.X = (float)sc * p1.X + 15;
                    p1.Y = (float)Ymax / 2;

                    pt2 = Plist[i];
                    p2 = pt2;
                    p2.X = (float)sc * p2.X + 15;
                    p2.Y = (float)Ymax / 2;

                    g.DrawLine(penViga, p1, p2);
                    this.drawSupport(p2, sc);
                    this.drawDimension(p1, p2, sc);
                }
            }

            // draw lateral support
            int nn = lbtop.Count();
            int m = lbbottom.Count();

            float[] a = new float[nn];
            lbtop.CopyTo(a);
            this.lbTop = a.ToList();

            float[] b = new float[m];
            lbbottom.CopyTo(b);
            this.lbBottom = b.ToList();

            for (int ii = 0; ii < nn; ii++)
            {
                lbtop[ii] *= (float)sc;
                lbtop[ii] += 15;
            }
            for (int ii = 0; ii < m; ii++)
            {
                lbbottom[ii] *= (float)sc;
                lbbottom[ii] += 15;
            }
            

            this.drawLateralSupport(lbtop, lbbottom);


        }

        public void             drawSupport(PointF pt, double scaleFactor)
        {
            double sc       = scaleFactor;
            float  x, y;
            x               = (float)(pt.X);
            y               = (float)(pt.Y);
           
            PointF pt1          = new PointF(x,y);
            PointF pt2          = new PointF(x - 10, y + 20);
            PointF pt3          = new PointF(x + 10, y + 20);
            PointF[] listpoint  = new PointF[3];

            listpoint[0]        = pt1;
            listpoint[1]        = pt2;
            listpoint[2]        = pt3;
            g.FillPolygon(brushSupp, listpoint);
        }

        public void             drawDimension(PointF pt1, PointF pt2, double scaleFactor)
        {
            double sc       = scaleFactor;
            double L        = Math.Round((pt2.X - pt1.X)/sc,2);
            double Laux     = (pt2.X - pt1.X);
            this.dimOffset  = 0.05 * Laux;
            double dO       = dimOffset;
            
            if (drawDim)
            {
                // draw extension lines
                PointF p1       = new PointF((float)(pt1.X ), (float)(pt1.Y + 0.02 * Length*sc));
                PointF p2       = new PointF((float)(pt1.X ), (float)(p1.Y + 50));
                g.DrawLine(penDim, p1, p2);

                PointF p3       = new PointF((float)(pt2.X ), (float)(pt2.Y  + 0.02 * Length*sc));
                PointF p4       = new PointF((float)(pt2.X ), (float)(p2.Y));
                g.DrawLine(penDim, p3, p4);

                // draw left arrow
                double ha, wa;
                ha              = 0.01 * Length*sc;
                wa              = 0.5 * ha;

                PointF p5       = new PointF(p2.X, (float)(p2.Y - 0.05 * p2.Y));
                PointF p6       = new PointF((float)(p1.X + ha), (float)(p5.Y + wa / 2));
                PointF p7       = new PointF((float)(p1.X + ha), (float)(p5.Y - wa / 2));
                PointF[] lp1    = new PointF[3];
                lp1[0]          = p5;
                lp1[1]          = p6;
                lp1[2]          = p7;
                g.FillPolygon(brushDim, lp1);

                // draw right arrow
                PointF p8       = new PointF(p3.X, (float)(p2.Y - 0.05 * p2.Y));
                PointF p9       = new PointF((float)(p3.X - ha), (float)(p8.Y + wa / 2));
                PointF p10      = new PointF((float)(p3.X - ha), (float)(p8.Y - wa / 2));
                PointF[] lp2    = new PointF[3];
                lp2[0]          = p8;
                lp2[1]          = p9;
                lp2[2]          = p10;
                g.FillPolygon(brushDim, lp2);

                g.DrawLine(penDim, p5, p8);
                string cota     = (0.5 * (p3.X + p1.X)).ToString();
                var wth         = g.MeasureString(cota, fontDimText, 200);

                // draw dimension text
                PointF p11      = new PointF((float)(0.5 * ((pt1.X + pt2.X) - wth.Width/sc / 2)), (float)(p5.Y + 0.01 * Laux));
                g.DrawString(L.ToString(), fontDimText, brushDimText, p11);
            }


        }

        public void             drawLateralSupport(List<float> lbtop, List<float> lbbottom)
        {
           
            float x, y;
            double Ymax         = this.Height - 15;
            PointF[] listpoint  = new PointF[3];

           foreach(var p in lbtop)
            {
                x = p;
                y = (float)Ymax/2;

                PointF pt1 = new PointF(x, y);
                PointF pt2 = new PointF(x - 5, y - 10);
                PointF pt3 = new PointF(x + 5, y - 10);

                listpoint[0] = pt1;
                listpoint[1] = pt2;
                listpoint[2] = pt3;
                g.FillPolygon(brushLatSupp, listpoint);
            }

            foreach (var p in lbbottom)
            {
                x = p;
                y = (float)Ymax / 2;

                PointF pt1 = new PointF(x, y);
                PointF pt2 = new PointF(x - 5, y + 10);
                PointF pt3 = new PointF(x + 5, y + 10);

                listpoint[0] = pt1;
                listpoint[1] = pt2;
                listpoint[2] = pt3;
                g.FillPolygon(brushLatSupp, listpoint);
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (LP.Count>0)
            {
                this.drawBeam(this.LP,this.lbTop,this.lbBottom);
            }
            base.OnPaint(e);
        }

        public void             drawPointLoad(List<dwgPointLoad> PointLoad,double scaleFactor)
        {
            //double sc = scaleFactor;
            //float x, y;
            ////x = (float)(pt.X);
            ////y = (float)(pt.Y);

            //PointF pt1 = new PointF(x, y);
            //PointF pt2 = new PointF(x - 7, y - 30);
            //PointF pt3 = new PointF(x + 7, y - 30);
            //PointF[] listpoint = new PointF[3];

            //listpoint[0] = pt1;
            //listpoint[1] = pt2;
            //listpoint[2] = pt3;
            //g.FillPolygon(brushPLoad, listpoint);

            //PointF pt4 = new PointF(x, y + 150);

            //g.DrawLine(penPLoad, pt1, pt4);
        }

        public void             addPointLoad(dwgPointLoad pLoad)
        {
            this.pPointLoad.Add(pLoad);
        }
    }


    public class dwgPointLoad
    {
        public float value { get; set; }
        public PointF point { get; set; }
        public string loadType { get; set; }

        public dwgPointLoad() { }

        public dwgPointLoad(PointF _point, float _value, string _loadType)
        {
            value       = _value;
            point       = _point;
            loadType    = _loadType;
        }
        
    }
}
