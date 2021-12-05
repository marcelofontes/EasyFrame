using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM
{
    public enum TipoAgregado { BASALTO, GRANITO, CALCARIO, ARENITO };
    public class Material:clsFEM
    {
        // Caracteristicas gerais
        int ID;
        string Classe;
        public double E { get; set; }
        public double G { get; set; }
        public double uniWeight { get; set; }

   
        // caracteristicas para concreto
        public double Fck { set; get; } // MPa
        public double Eci { set; get; }
        public double Ecs;  
        private double alphaI;
        private double alphaE;
        private TipoAgregado Agregado;


        public Material() { }
        public Material(int _ID, string _Name, double _Fck, TipoAgregado _Agregado)
        {
            this.Name = _Name;
            this.ID = _ID;
            this.Fck = _Fck;
            this.Name = _Name;
            this.Agregado = _Agregado;
            this.fillProperties();
            
        }
        private void fillProperties()
        {
            switch (this.Agregado)
            {
                case TipoAgregado.BASALTO:
                    alphaE = 1.2f;
                    break;
                case TipoAgregado.GRANITO:
                    alphaE = 1.0f;
                    break;
                case TipoAgregado.CALCARIO:
                    alphaE = 0.9f;
                    break;
                case TipoAgregado.ARENITO:
                    alphaE = 0.7f;
                    break;
            }


            this.alphaI = 0.8 + 0.2 * Fck / 80 <= 1 ? 0.8 + 0.2 * Fck / 80 : 1;

            if (Fck >= 20 && Fck <= 50)
            {
                this.E = alphaE * 5600 * Math.Sqrt(Fck); // MPa

            }

            else if (Fck >= 55 && Fck <= 90)
            {
                this.E = 21500 * alphaE * Math.Pow(Fck / 10 + 1.25, 1 / 3);
            }

            else
            {
                throw new ArgumentException("Valor inválido para Fck, de acordo com NBR6118:2014", nameof(Fck));
            }
            this.Eci = E;
            this.Ecs = alphaI * Eci;
            this.G = Ecs / 2.4;
            this.uniWeight = 25;  // kN/m3

        }
    }
    
}

