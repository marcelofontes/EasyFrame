using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEM;


namespace NBR6118_2014
{
    public struct DsgResult
    {
        // input
        public double IF_Mdx;
      
        public double IF_Vdy;

            
        //mensagens
        public List<string> Warnings;
        public List<string> Errors;

        // areas de armaduras
        public double Asi;
        public double Ass;
        public double Asi_real;
        public double Ass_real;
        public double Asw;
        public double Asw_real;
        public double Wk;                               // abertura de fissuras 
        public double diam_bar_sup;
        public double diam_bar_inf;
        public double diam_bar_estribo;
        public int nLongSupBars;
        public int nLongInfBars;
        public int nEstribosPorMetro;
        public string status;

        public Dictionary<double, int> longSupBars; // diam barra - quantidade de barras - solucoes possíveis
        public Dictionary<double, int> longInfBars;
        public Dictionary<double, int> estribos;    // diam barra - quantidade de barras por metro - soluçoes possiveis



        public double wi;     // flecha inicial
        public double wdif;   // flecha diferida
        public double wtotal; // flecha total
        public double wLim;   // flecha limite
        public string Def_status;
    }
    public class NBR6118
    {
        private int agressividade;
        private CsSection CS;
        private IntForces internalForces;
        private Dictionary<string, double> Def_SLS; // deformation for service combinations
        private double Mkx;     // Max bending moment for Freq SLS combination
        private float W;        // abertura máxima de fissura em mm
        private double Ast;     // armadura tracionada cm2
        private double Asc;     // armatura comprimida cm2
        private double Asw;     // armadura cisalhamento cm2
        double ro;     // taxa de armadura inferior 
        double ro_l;   // taxa de armadura superior 
        private DsgResult results;
        private const double GAMA_C = 1.4;
        private const double GAMA_S = 1.15;
        private const double RO_MIN = 0.0015;
        private const double DEFLECTION_LIMIT = 250;
        private List<Rebar> rebar = new List<Rebar>();
        double Ecs;
        private const double MIN_LONG_DIAM = 1.0; // diâmetro minimo das barras longitudinais tracionadas
        private List<double> vaos;  // lista de vaos da viga
        private double position;  // coordenada na viga para verificaçao da flecha

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_CS"></param>
        /// <param name="_internalForces"></param>
        /// <param name="_agressiv"></param>
        public NBR6118(CsSection _CS,
                        IntForces _internalForces, 
                        int _agressiv,
                        List<Rebar> _rebar, 
                        double _Mkx, 
                        double _Ecs,
                        Dictionary<string,double> _Def_SLS,
                        List<double> _vaos,
                        double _position)
        {
            this.results.Warnings = new List<string>();
            this.results.Errors = new List<string>();
            this.CS = _CS;
            this.internalForces = _internalForces;
            this.Mkx = _Mkx;  // momento nominal para verificacao SLS
            this.agressividade = _agressiv;
            this.rebar = _rebar;
            results.IF_Mdx = this.internalForces.Mx;
            results.IF_Vdy = this.internalForces.Vy;
            this.Ecs = _Ecs;
            this.vaos = _vaos;
            this.position = _position;
           
            Def_SLS = _Def_SLS;

            switch (agressividade)
            {
                case 1:
                    this.W = 0.4f;
                    break;
                case 2:
                    this.W = 0.3f;
                    break;
                case 3:
                    this.W = 0.3f;
                    break;
                case 4:
                    this.W = 0.2f;
                    break;
                default:
                    this.W = 0.4f;
                    break;
            }
        }

        public DsgResult StartDegsign()
        {
            CheckForBending();
            CheckForShear();
            CheckDeformation();
            CheckStatus();

            return results;
        }
        /// <summary>
        /// faz a verificaçao para o esforço de momento fletor
        /// </summary>
        private void CheckForBending()
        {
            double Mi;       // momento reduzido
            double MiLim;    // momento reduzido limite
            double Csi;      // profundidade da linha neutra
            double CsiLim;   // profundidade da linha neutra limite para armadura simples
            double Md = this.internalForces.Mx*100;  // kN.cm
            double b = this.CS.b;
            double h = this.CS.h;
            double c = this.CS.cover;
            double d = h - c-1;
            double fyd = 0.1 * 500 / GAMA_S; // kN/cm2
            double fck = 0.1 * this.CS.material.Fck; // kN/cm2
            double sigma_cd = 0.85 * fck / GAMA_C;
            double sigma_sdl;
            double dl;
            double epsonLs;
            double delta;
            double Csia = 0.26;
            const double AS_MONTAGEM = 0.4; // 2 barras de 5 mm


            // determinaçao dos limites da seçao
            if (this.CS.material.Fck <= 35)
            {
                MiLim = 0.2952;
                CsiLim = 0.45;
            }
            else
            {
                MiLim = 0.2408;
                CsiLim = 0.35;
            }


            // cálculo do momento reduzido

            Mi = Math.Abs(Md) / (b * d * d * sigma_cd);

            dl = this.CS.cover+1;
            delta = dl / d;

            // armadura simples
            if (Mi <= MiLim)
            {
                Csi = 1.25 * (1 - Math.Sqrt((1 - 2 * Mi)));
                Ast = 0.8 * Csi * b * d * sigma_cd / fyd;
                Asc = AS_MONTAGEM;
                Ast = Check_As_Min(Ast);
            }
            // armadura dupla
            else
            {


                // verifica se a seçao comporta armadura dupla
                if (CsiLim > delta && CsiLim >= Csia)
                {
                    epsonLs = 0.0035 * (CsiLim - delta) / CsiLim;
                    sigma_sdl = 20000 * epsonLs <= fyd ? 20000 * epsonLs : fyd;
                    Asc = (Mi - MiLim) * b * d * sigma_cd / ((1 - delta) * sigma_sdl);
                    Asc = Math.Max(Asc, AS_MONTAGEM);
                    Ast = (0.8 * CsiLim + (Mi - MiLim) / (1 - delta)) * (b * d * sigma_cd / fyd);
                    Ast = Check_As_Min(Ast);
                    if (Asc+Ast >= 0.04 * b * h)
                    {
                        this.results.Errors.Add("Seçao de concreto insuficiente. Aumente a seção");
                    }
                }
                // senao
                else
                {
                    this.results.Errors.Add("Seçao de concreto insuficiente. Aumente a seção");
                 
                }
            }

            // checa se houve erros
            if (this.results.Errors.Count()==0)
            {
                // Checa se o momento é positivo ou negativo
                if (Md >= 0)
                {
                    this.results.Asi = Ast;
                    this.results.Ass = Asc;

                }
                else
                {
                    this.results.Asi = Asc;
                    this.results.Ass = Ast;
                }
                ro = Ast / (b * d);
                ro_l = Asc / (b * d);
                
                UseCommercialLongitudinalBars();

                double diam = Md >= 0 ? this.results.diam_bar_inf : this.results.diam_bar_sup;
                checkCrackOppening(Mi, delta, Mkx, diam);
                
            }
           
        }

        /// <summary>
        /// checa armadura mínima de traçao
        /// </summary>
        /// <param name="_As"></param>
        /// <returns></returns>
        private double Check_As_Min(double _As)
        {
            double AsMin;
            double As = _As;

            AsMin = RO_MIN * this.CS.b * this.CS.h; // cm2
            if (As < AsMin)
            {
                As = AsMin;
            }
            return As;
        }

        /// <summary>
        /// calcula armadura para cisalhamento
        /// </summary>
        private void CheckForShear()
        {
            double Twd;
            double Vd;
            double bw;
            double d;
            double Twu;
            double alpha_v;
            double Td;
            double Tc;
            double fck;
            double Psi3 = 0.09; // valor determinado para o caso de flexao simples
            double fyd;
            double Asw_min;

            Vd = this.internalForces.Vy;
            bw = this.CS.b;
            d = this.CS.h - this.CS.cover;
            fck = 0.1*this.CS.material.Fck;
            fyd = 0.1*500 / 1.15;

            // cálculo da tensao cisalhante
            alpha_v = 1 - fck / 250;
            // calculo da tensao limite
            Twu = 0.27 * alpha_v * fck / 1.4;
            Twd = Vd / (bw * d);
            // limitacao da tensao atuante
            if (Twd > Twu)
            {
                this.results.Errors.Add("Tensão de cisalhamento acima do limite. Sugestão: aumentar largura da viga.");
                
            }
            else
            {
                Tc = Psi3 * Math.Pow(fck, 0.6666666);
                Td = 1.11 * (Twd - Tc)>0? 1.11 * (Twd - Tc):0;
                Asw = 100 * bw * Td / fyd;

                //calcula armadura minima
               // Asw_min = CheckAswMin();
               // Asw = Asw > Asw_min ? Asw : Asw_min;
                this.results.Asw = Asw;
                UseCommercialTransveralBars();
               // this.results.status = "OK";
            }


        }

        /// <summary>
        /// Calcula armadura minima de cisalhamento
        /// </summary>
        /// <returns></returns>
        private double CheckAswMin(double _fyk)
        {

            double fctm;
            double fyk = _fyk;  //kN/cm2
            double fck = this.CS.material.Fck;
            double ro_min;
            double bw = this.CS.b;


            
            if (fck <= 50)
            {
                fctm = 0.3 * Math.Pow(fck, 0.6666666);
            }
            else
            {
                fctm = 2.12 * Math.Log(1 + 0.11 * fck);
            }
            ro_min = 0.2 * fctm / fyk;

            return ro_min * bw*100;
        }

        /// <summary>
        /// Converte area de aço em barras de diametro comercial
        /// </summary>
        private void UseCommercialLongitudinalBars()
        {
            Dictionary<double, int> nbars_sup = new Dictionary<double, int>(); // numero de barras superiores
            Dictionary<double, int> nbars_inf = new Dictionary<double, int>(); // numero de barras inferiores
            int nb;
            foreach (var b in rebar)
            {
                if (this.internalForces.Mx > 0)
                {
                    if (0.1*b.diam >= MIN_LONG_DIAM)
                    {

                        nb = Convert.ToInt32((Math.Ceiling(this.results.Asi / b.area)));
                        if (nb > 1)
                        {
                            nbars_inf.Add(b.diam, nb);
                        }
                        
                        
                             
                    }

                    nb = Convert.ToInt32(Math.Ceiling(this.results.Ass / b.area));
                    if (nb > 1)
                    {
                         nbars_sup.Add(b.diam, nb);
                    }
                }
                else
                {
                    if (0.1*b.diam >= MIN_LONG_DIAM)
                    {
                        nb = Convert.ToInt32(Math.Ceiling(this.results.Ass / b.area));
                        if (nb > 1)
                        {
                            nbars_sup.Add(b.diam, nb);
                        }
                    }
                    nb = Convert.ToInt32(Math.Ceiling(this.results.Asi / b.area));
                    if (nb > 1)
                    {
                        nbars_inf.Add(b.diam, nb);
                    }
                }

            }
            if (this.results.Errors.Count == 0)
            {
                this.results.longInfBars = nbars_inf;
                this.results.longSupBars = nbars_sup;
                this.results.diam_bar_inf = nbars_inf.First().Key;
                this.results.diam_bar_sup = nbars_sup.First().Key;
                this.results.nLongInfBars = nbars_inf.First().Value;
                this.results.nLongSupBars = nbars_sup.First().Value;
                var area = rebar.Find(c => c.diam == this.results.diam_bar_inf).area;
                this.results.Asi_real = this.results.nLongInfBars * area;               // atualiza a area de aço real
                area = rebar.Find(c => c.diam == this.results.diam_bar_sup).area;
                this.results.Ass_real = this.results.nLongSupBars*area; // atualiza a área de aço real

            }
           

        }
        /// <summary>
        /// covnerte area de aço em barras de diametro comercial
        /// </summary>
        private void UseCommercialTransveralBars()
        {
            Dictionary<double, int> nbars = new Dictionary<double, int>();
            const double SLIM = 30; // cm

            foreach (var b in rebar)
            {
                var Asw_min = CheckAswMin(b.fy);
                 this.results.Asw = this.results.Asw > Asw_min ? this.results.Asw : Asw_min;
                if (0.1 * b.diam <= this.CS.b / 10)
                {
                    int nb;
                    nb = Math.Max(1,Convert.ToInt32(Math.Ceiling(this.results.Asw / (2 * b.area)))); // numero de barras por metro

                    if (100 / nb <= 0.6 * this.CS.h && 100 / nb <= SLIM)
                    {
                        nbars.Add(b.diam, nb);
                    }
                    else
                    {
                        double aux = 0.6 * this.CS.h >= SLIM ? SLIM : 0.6 * this.CS.h;
                        nb = Convert.ToInt32(Math.Ceiling(100 / aux));
                        nbars.Add(b.diam, nb);
                    }
                }


            }
            if (this.results.Errors.Count == 0)
            {
                this.results.estribos = nbars;
                this.results.diam_bar_estribo = nbars.First().Key;
                this.results.nEstribosPorMetro = nbars.First().Value;
                var area = rebar.Find(c => c.diam == this.results.diam_bar_estribo).area;
                this.results.Asw_real = this.results.nEstribosPorMetro * area * 2;   // considerando estribos de dois ramos
            }
           

        }
        /// <summary>
        /// calcula a abertura de fissuras - OBS: desconsidera abertura de fissuras devido a retraçao
        /// </summary>
        /// <param name="Mi"></param>
        /// <param name="delta"></param>
        /// <param name="M"></param>
        private void checkCrackOppening(double Mi, double delta, double M, double diam)
        {
            double sigma_S;
            double fctm;
            double ro_se;
            double Ace;
            double h0;
            double k2;
            double n = 20000 / Ecs;
            double Csi;
            double b = this.CS.b;
            double d = this.CS.h - this.CS.cover;
            double x;
            double fck = this.CS.material.Fck;
            double Wk;
            double Wk1;
            double Wk2;
            double Tbm;
            const double N1 = 1 / 4;

            Csi = -n * (ro + ro_l) + Math.Sqrt(n * n * Math.Pow(ro + ro_l, 2) + 2 * n * (ro + delta * ro_l));
            k2 = (1 / 6) * Csi * Csi * (3 - Csi) + n * ro_l * (Csi - delta) * (1 - Csi);

            sigma_S = n * (1 - Csi) * M / (k2 * b * d * d);
            x = d * Csi;

            h0 = 2.5 * (this.CS.h - d);
            h0 = h0 < ((this.CS.h - x) / 3) ? h0 : (this.CS.h - x) / 3;
            Ace = b * h0;


            ro_se = this.Ast / Ace;

            if (fck <= 50)
            {
                fctm = 0.3 * Math.Pow(fck, 2 / 3);
            }
            else
            {
                fctm = 2.12 * Math.Log(1 + 0.11 * fck);
            }

            //sigma_S0 = (1 + n * ro_se) * fctm / ro_se;
            Wk1 = (diam / (12.5 * N1)) * (sigma_S / 20000) * 3 * sigma_S / fctm;
            Wk2 = (diam / 12.5 * N1) * (sigma_S / 20000) * (4 / ro_se + 45);
            Wk = Math.Min(Wk1, Wk2);

            this.results.Wk = Wk;
            if (Wk > W)
            {
                this.results.Warnings.Add("Abertura máxima de fissuras acima do limite permitido.");
            }



        }
        /// <summary>
        /// Checa deformaçao da viga
        /// </summary>
        private void CheckDeformation()
        {
            // A flecha imediata é a flecha da analise linear
            // a flecha diferida é calculada nesta rotina
            // a flecha total é a flecha imediata multiplicada pelo fator de flecha diferida

            double alpha_f;
            double delta_CSI;
            double b = this.CS.b;
            double d = this.CS.h - this.CS.cover;
            double As_l = this.Asc;
            double csi;
            double t = 1; // tempo em meses para calculo da flecha diferida
            double wi; // flecha inicial
            double wdif; // flecha diferida
            double wfinal; // flecha final
            double L; // vao da viga
            double wLim;

            

            csi = 0.68 * (Math.Pow(0.996, t)) * Math.Pow(t, 0.32);
            delta_CSI = 2 - csi;

            alpha_f = delta_CSI / (1 + 50 * ro_l);
            wi = this.Def_SLS.Max(c => c.Value)*100; // cm

            wdif = alpha_f * wi;
            wfinal = wi + wdif;
            L = GetVao()*100; // cm
            wLim = L / DEFLECTION_LIMIT;


            if (Math.Abs(wfinal) <= wLim) { this.results.Def_status = "OK"; }
            else { this.results.Def_status = "NÃO PASSA";
                   this.results.Warnings.Add("Flecha excessiva"); }


            this.results.wdif = wdif;
            this.results.wi = wi;
            this.results.wLim = wLim;
            this.results.wtotal = wfinal;
        }
       /// <summary>
       /// Verifica o vao em que está a seçao analisada
       /// </summary>
       /// <returns> L </returns>
        private double GetVao()
        {
            double L=0;
            double x = this.position;
            int i = this.vaos.Count();

            double aux = this.vaos.First();
            for (int j = 0; j < i; j++)
            {
                
                if (x <= aux) { L=this.vaos[j]; }
                else
                {
                    aux += this.vaos[j + 1];

                }
            }
            return L;
        }

        private void CheckStatus()
        {
            if (this.results.Errors.Count()== 0 && this.results.Warnings.Count() == 0) 
            { 
                this.results.status = "OK";
            }
            else if( (this.results.Errors.Count() == 0 && this.results.Warnings.Count!= 0)||(this.results.Def_status == "NÃO PASSA"))
            {  
                this.results.status = "OK*"; 
            }

            else if (this.results.Errors.Count!=0 ) {
                this.results.status = "Erro"; 
            }
        }   
    }

}
