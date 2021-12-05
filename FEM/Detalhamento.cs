using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public class Detalhamento
    {
        public int NEstriboMetro { set; get; }
        public int NBarSuperior { set; get; }
        public int NBarInferior { set; get; }
        public double DiamEstribo { set; get; }
        public double DiamBarSuperior { set; get; }
        public double DiamBarInferior { set; get; }
        public double LTrecho { set; get; }
        public double LBarSuperior { set; get; }
        public double LBarInferior { set; get; }
        public double LEstribo { set; get; }
        public double Asi { set; get; }
        public double Ass {set;get;}
        
        public double Peso_Asi { set; get; }
        public double Peso_Ass { set; get; }
        public double Peso_Asw { set; get; }
        public double VolumeConcreto { set; get; }
        public double AreaForma { set; get; }
        public double b;
        public double h;
        public bool IsEndOfSpan;
        public double Cover;


        public Detalhamento(double _b, double _h, double _LTrecho, bool _IsEndOfSpan, double _Cover)
        {

            this.b = _b;
            this.h = _h;
            this.LTrecho = _LTrecho;
            this.AreaForma = LTrecho * (2 * h*0.01 + b*0.01); // valor em m2
            this.VolumeConcreto = b * h * LTrecho*0.0001;    // valor em m3
            this.IsEndOfSpan = _IsEndOfSpan;
            this.Cover = _Cover;

        }
        public void CalculaPesoAço()
        {
            double gancho;
            if (IsEndOfSpan)
            {
                gancho = (h - 2 * Cover - 8*DiamEstribo*0.1)*0.01; // valor em m             
            }
            else
            {
                gancho = 0;
            }
            LBarInferior = LTrecho + gancho + 30*DiamBarInferior*0.001;                    // valor em m com transpasse de 30xD
            LBarSuperior = LBarInferior - 2 * DiamBarSuperior*0.001 +30*DiamBarSuperior*0.001;   // valor em m com transpasse de 30xD
            LEstribo = (2 * b + 2 * h + 10) * 0.01;               // valor em m

            Peso_Asi = LBarInferior * Asi * 7850 * 0.0001;  // peso em kg
            Peso_Ass = LBarSuperior * Ass  * 7850 * 0.0001;  // peso em kg

            double AreaEstribo = (Math.PI * this.DiamEstribo * this.DiamEstribo*0.01 / 4)*0.0001;
            Peso_Asw = Math.Round(NEstriboMetro * LTrecho,0) * LEstribo * AreaEstribo * 7850; // peso total de estribos ,em kg, no trecho
        }


    }
}
