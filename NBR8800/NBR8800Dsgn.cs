using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEM;



namespace NBR8800
{
    public struct DsgResult
    {
        // input
        public double IF_Mx;
        public double IF_My;
        public double IF_Compression;
        public double IF_Tension;
        public double IF_Vx;
        public double IF_Vy;
        public double Lb;
        public double Cb;
        //resistances
        public double BendingX;
        public double BendingY;
        public double Compression;
        public double Tension;
        public double ShearX;
        public double ShearY;
        public double Comb_Bending_compression;
        public double comb_Bending_Tension;
        // unit check
        public double uc_BendingX;
        public double uc_BendingY;
        public double uc_Compression;
        public double uc_Tension;
        public double uc_ShearX;
        public double uc_ShearY;
        public double uc_Comb_bending_compression;
        public double uc_Comb_bending_Tension;
    }

    public struct Classification
    {
        public string BendingX_Web;
        public string BendingX_topFlange;
        public string BendingX_bottomFlange;

        public string BendingY_Web;
        public string BendingY_topFlange;
        public string BendingY_bottomFlange;

        public string Compr_Web;
        public string Compr_topFlange;
        public string Compr_bottomFlange;
    }

    public class NBR8800Dsgn
    {
        private clsCsSection CS;
        private double lb       { set; get; } // unbraced length
        //public double               lbbottom                    { set; get; } // bottom flange unbraced length
        public double lbx       { set; get; } // buckling length in X-X
        public double lby       { set; get; } // bucklin length in YY
        public double lbt       { set; get; } // tortional buckling length
        private double cb       { set; get; }
        public double lambda_w  { set; get; }
        public double lambda_fs { set; get; }
        public double lambda_pf { set; get; }
        public double lambda_rf { set; get; }
        public double lambda_fi { set; get; }
        public double lambda_pw { set; get; }
        public double lambda_rw { set; get; }
        public double lambda_p  { set; get; }  // for LTB
        public double lambda_r  { set; get; }  // for LTB
        public double lambda    { set; get; }               // for LTB
        public double lambda_cx { set; get; }  // for Compression in X-X
        public double lambda_cy { set; get; }  // for Compression in Y-Y
        public double Mplx      { set; get; }  // plastic moment
        public double Mply      { set; get; }  // plastic moment
        public double Vplx      { set; get; }
        public double Vply      { set; get; }
        public double MRd       { set; get; }  // elasto - plastic moment limit
        public double Mcr_FLT   { set; get; }  // critical elastic moment
        public double Mcrx_FLM  { set; get; }
        public double Mcry_FLM  { set; get; }
        public double Mcrx_FLA  { set; get; }
        public double Mcry_FLA  { set; get; }
        public double Mrx_FLA   { set; get; }
        public double Mry_FLA   { set; get; }
        public double Mrx_FLM   { set; get; }
        public double Mry_FLM   { set; get; }
        public double Mrx_FLT   { set; get; }
        public double Mry_FLT   { set; get; }
        public double kx        { set; get; }
        public double ky        { set; get; }
        public double kt        { set; get; }
        public double Qs        { set; get; }
        public double Qa        { set; get; }
        public double Q         { set; get; }
        public double a         { set; get; }    // distance between stiffeners
        public double CompFactor_X { set; get; } // compression reduction factor
        public double Kv        { set; get; }    // Shear buckling factor

        public double kc        { set; get; }
        public double hc        { set; get; }
        public double hp        { set; get; }
        private double gama1 = 1.1;
        private double alphay;
        private double Iyc;
        private double Iyt;
        
        

        private List<string> errorList  =new List<string>();
        private List<string> warningList = new List<string>();

        /// <summary>
        /// Classe - Compacta, semit-compacta, esbelta
        /// </summary>
        public Classification classe;
        IntForces internalForces;
        DsgResult res;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_CS">Cros Section</param>
        /// <param name="_intforces">Internal forces</param>
        /// <param name="_a">Distance between stiffners</param>
        /// <param name="_cb">moment gradiente factor</param>
        /// <param name="_lb">unbraced length for bending</param>
        public                      NBR8800Dsgn(clsCsSection _CS, 
                                                IntForces _intforces, 
                                                double _a, 
                                                double _cb, 
                                                double _lb, 
                                                double _lbx, 
                                                double _lby, 
                                                double _lbt)
                            {
                                CS = _CS;
                                internalForces = _intforces;
                                cb = _cb;
                                a = _a*100;//[cm]
                                lb = _lb*100; //[cm]
                                res = res = new DsgResult();
                                lbx = _lbx;
                                lby = _lby;
                                lbt = _lbt;

                                res.IF_Mx = internalForces.Mx;
                                res.IF_My = internalForces.My;
                                res.IF_Vx = internalForces.Vx;
                                res.IF_Vy = internalForces.Vy;
                                res.IF_Compression = internalForces.N > 0 ? 0 : internalForces.N;
                                res.IF_Tension = internalForces.N > 0 ? internalForces.N : 0;
                                res.Lb = _lb;
                                res.Cb = _cb;

                            }

        public                      NBR8800Dsgn()
        {

        }

        /// <summary>
        /// Manage the design according to internal forces input
        /// </summary>
        /// <returns></returns>
        public DsgResult            startDesign()
        {
                bendingCheck();

            return res;
        }

        /// <summary>
        ///  define section classification for bending
        /// </summary>
        /// <returns></returns>
        private Classification      bendingClassification()
        {
            double E = CS.material.E * 1e-1; //[kN/cm2]
            double fy = CS.material.Fy;
            
           

            if (internalForces.Mx!=0)
            {
                Mplx = CS.Zx * fy; //[kN.cm]
                #region Perfis I soldados ou laminados com dois eixos de simetria perfis U
                // perfis I soldados ou Laminados com dois eixos de simetria
                if (((CS.profCode == 100) || (CS.profCode == 101||CS.profCode==103 || CS.profCode==104)) && (CS.fabrication == 1 || CS.fabrication == 2))
                {
                    double bf = CS.bfs;
                    double tf = CS.tfs;
                    double tw = CS.tw;
                    double d = CS.d;
                    double r = CS.R;
                    double hw;

                    if (CS.fabrication == 2)
                    {
                        hw = d - 2 * tf - 2 * r;
                        lambda_rf = 0.83 * Math.Sqrt(E / (0.7 * fy));
                    }
                    else
                    {
                        hw = d - 2 * tf;
                        lambda_rf = 0.95 * Math.Sqrt(E / ((0.7 * fy) / kc));
                    }

                    lambda_fs = bf / (2 * tf);
                    lambda_w = hw / tw;
                    lambda_pw = 3.76 * Math.Sqrt(E / fy);
                    lambda_pf = 0.38 * Math.Sqrt(E / fy);
                    lambda_rw = 5.70 * Math.Sqrt(E / fy);

                    if(CS.profCode==103 || CS.profCode == 104) { lambda_fs = bf / tf; }
                    // checando esbeltez da alma
                    Mrx_FLA = fy * CS.Wxs;  //[kN.cm]
                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingX_Web = "compacta";
                    }
                    else if ((lambda_w > lambda_pw) && (lambda_w <= lambda_rw))
                    {
                        classe.BendingX_Web = "semi-compacta";
                    }
                    else
                    {
                        classe.BendingX_Web = "esbelta";
                    }

                    // checando esbeltez dos flanges
                    Mrx_FLM = 0.7 * fy * CS.Wxs;//[kN.cm]
                    if (lambda_fs <= lambda_pf)
                    {
                        classe.BendingX_topFlange = "compacta";
                        classe.BendingX_bottomFlange = "compacta";
                    }
                    else if ((lambda_fs > lambda_pf) && (lambda_fs <= lambda_rf))
                    {
                        classe.BendingX_topFlange = "semi-compacta";
                        classe.BendingX_bottomFlange = "semi-compacta";
                    }
                    else
                    {
                        classe.BendingX_topFlange = "esbelta";
                        classe.BendingX_bottomFlange = "esbelta";
                    }
                }
                #endregion
            
                #region Perfis I soldados com um eixo de simetria

                if (CS.profCode == 102 && CS.fabrication == 1)
                {
                    double bfs = CS.bfs;
                    double tfs = CS.tfs;
                    double bfi = CS.bfi;
                    double tfi = CS.tfi;
                    double tw = CS.tw;
                    double d = CS.d;
                    double r = CS.R;
                    double hw;

                    hw = d - tfs - tfi;

                    kc = 4 / (Math.Sqrt(hw / tw));
                    if (kc < 0.35) { kc = 0.35; }
                    else if (kc > 0.76) { kc = 0.76; }

                    hc = define_hc();
                    hp = define_hp();

                    lambda_fs = bfs / (2 * tfs);
                    lambda_fi = bfi / (d * tfi);
                    lambda_w = hc / tw;

                    lambda_rw = 5.70 * Math.Sqrt(E / fy);
                    lambda_pf = 0.38 * Math.Sqrt(E / fy);

                    if (CS.fabrication == 1)
                    {
                        lambda_rf = 0.95 * Math.Sqrt(E * kc / (0.7 * fy));
                    }
                    else
                    {
                        lambda_rf = 0.83 * Math.Sqrt(E / (0.7 * fy));
                    }

                    double A1;
                    double A2;

                    //checking note 9 on table G.1  - Annex G

                    if (bfs >= bfi)
                    {
                        A1 = bfs * tfs;
                        A2 = bfi * tfi + (d - tfs - tfi) * tw;
                    }
                    else
                    {
                        A1 = bfi * tfi;
                        A2 = bfs * tfs + (d - tfs - tfi) * tw;
                    }

                    if (!((alphay < 1 / 9) || (alphay > 9)) || (A2 < A1))
                    {
                        warningList.Add(" Relação alphay inválida / Relação de áreas inválida - ver NBR8800 - Anexo G - tabela G.1 nota 9");
                    }

                    // classification
                    // web
                    if (internalForces.Mx > 0)
                    {
                        Mrx_FLA = fy * CS.Wxs; //[kN.cm]
                    }
                    else
                    {
                        Mrx_FLA = fy * CS.Wxi; //[kN.cm]
                    }

                    lambda_pw = ((hc / hp) * Math.Sqrt(E / fy)) / (0.54 * Mplx / Mrx_FLA - 0.09);

                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingX_Web = "compacta";
                    }
                    else if ((lambda_w > lambda_pw) && (lambda_w <= lambda_rw))
                    {
                        classe.BendingX_Web = "semi-compacta";
                    }
                    else
                    {
                        classe.BendingX_Web = "esbelta";
                    }

                    // checando esbeltez dos flanges
                    // top flange

                    if (internalForces.Mx > 0)
                    {
                        Mrx_FLM = 0.7 * fy * CS.Wxs; //[kN.cm]
                    }
                    else
                    {
                        Mrx_FLM = 0.7 * fy * CS.Wxi; //[kN.cm]
                    }

                    if (lambda_fs <= lambda_pf)
                    {
                        classe.BendingX_topFlange = "compacta";
                    }
                    else if ((lambda_fs > lambda_pf) && (lambda_fs <= lambda_rf))
                    {
                        classe.BendingX_topFlange = "semi-compacta";
                    }
                    else
                    {
                        classe.BendingX_topFlange = "esbelta";
                    }

                    // bottom flange
                    if (lambda_fi <= lambda_pf)
                    {
                        classe.BendingX_bottomFlange = "compacta";
                    }
                    else if ((lambda_fi > lambda_pf) && (lambda_fi <= lambda_rf))
                    {
                        classe.BendingX_bottomFlange = "semi-compacta";
                    }
                    else
                    {
                        classe.BendingX_bottomFlange = "esbelta";
                    }
                }
                #endregion

                #region Perfis tubulares redondos
                if (CS.profCode == 111)
                {
                    double D = CS.d;
                    double t = CS.tw;
                    lambda_w = D / t;

                    lambda_pw = 0.07 * E / fy;
                    lambda_rw = 0.31 * E / fy;

                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingX_bottomFlange = "compacta";
                        classe.BendingX_Web = "compacta";
                        classe.BendingX_topFlange = "compacta";
                    }
                    if (lambda_w > lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingX_bottomFlange = "semi-compacta";
                        classe.BendingX_Web = "semi-compacta";
                        classe.BendingX_topFlange = "semi-compacta";
                    }
                    if (lambda_w > lambda_rw)
                    {
                        classe.BendingX_bottomFlange = "esbelta";
                        classe.BendingX_Web = "esbelta";
                        classe.BendingX_topFlange = "esbelta";
                    }
                }
                #endregion

                #region Perfis Caixao soldados ou tubos retangulares laminados
                if (CS.profCode == 109 || CS.profCode == 110)
                {

                    double tw = CS.tw;
                    double hw = CS.d - CS.tfs - CS.tfi - CS.R;
                    double bfs = CS.bfs;
                    double bfi = CS.bfi;
                    double tfs = CS.tfs;
                    double tfi = CS.tfi;

                    lambda_w = hw / tw;
                    lambda_fs = bfs / tfs;
                    lambda_fi = bfi / tfi;

                    lambda_pf = 1.12 * Math.Sqrt(E / fy);
                    lambda_rf = 1.4 * Math.Sqrt(E / fy);
                    lambda_rw = 5.7 * Math.Sqrt(E / fy);

                    // perfil caixao
                    if (CS.profCode == 109)
                    {
                        lambda_pw = 3.76 * Math.Sqrt(E / fy);
                    }
                    // tubo retangular
                    else if (CS.profCode == 110)
                    {
                        lambda_pw = 2.42 * Math.Sqrt(E / fy);
                    }

                    //Alma
                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingX_Web = "compacta";
                    }
                    else if (lambda_w > lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingX_Web = "semi-compata";
                    }
                    else if (lambda_w > lambda_rw)
                    {
                        classe.BendingX_Web = "esbelta";
                    }

                    //Mesa superior
                    if (lambda_fs <= lambda_pf)
                    {
                        classe.BendingX_bottomFlange = "compacta";
                    }
                    else if (lambda_fs > lambda_pf && lambda_w <= lambda_rf)
                    {
                        classe.BendingX_bottomFlange = "semi-compata";
                    }
                    else if (lambda_fs > lambda_rf)
                    {
                        classe.BendingX_bottomFlange = "esbelta";
                    }

                    // Mesa inferior
                    if (lambda_fi <= lambda_pf)
                    {
                        classe.BendingX_topFlange = "compacta";
                    }
                    else if (lambda_fi > lambda_pf && lambda_w <= lambda_rf)
                    {
                        classe.BendingX_topFlange = "semi-compata";
                    }
                    else if (lambda_fi > lambda_rf)
                    {
                        classe.BendingX_topFlange = "esbelta";
                    }

                }
                #endregion

                #region Perfil T soldado ou laminado e cantoneiras duplas com afastamento
                if(CS.profCode==105 || CS.profCode == 106 || CS.profCode==108)
                {
                    double bf = CS.tfs;
                    double tf = CS.tfs;
                    double d = CS.d;
                    double tw = CS.tw;

                    lambda_fs = bf / (2 * tf);
                    lambda_fi = lambda_fs;
                    lambda_w = lambda_w = d / tw;

                    
                    // critérios estabelecidos no AISC-360-16
                    lambda_pf = 0.38 * Math.Sqrt(E / fy);
                    lambda_rf = 1.0 * Math.Sqrt(E / fy);
                    lambda_pw = 0.84 * Math.Sqrt(E / fy);
                    lambda_rw = 1.52 * Math.Sqrt(E / fy);

                    if(lambda_w <= lambda_pw)
                    {
                        classe.BendingX_Web = "compacta";
                    }
                    else if(lambda_w > lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingX_Web = "semi-compacta";
                    }
                    else if (lambda_w > lambda_rw)
                    {
                        classe.BendingX_Web = "esbelta";
                    }

                    if ( lambda_fs <= lambda_pf)
                    {
                        classe.BendingX_topFlange = "compacta";
                        classe.BendingX_bottomFlange = "compacta";
                    }
                    else if ( lambda_fs > lambda_pf && lambda_fs <= lambda_rf)
                    {
                        classe.BendingX_topFlange = "semi-compacta";
                        classe.BendingX_bottomFlange = "semi-compacta";
                    }
                    else if ( lambda_fs > lambda_rf)
                    {
                        classe.BendingX_topFlange = "esbelta";
                        classe.BendingX_bottomFlange = "esbelta";
                    }

                }
                #endregion

                #region cantoneiras de abas iguais e desiguais
                if (CS.profCode == 107)
                {
                    double bfs = CS.bfs;
                    double bfi = CS.bfi;
                    double tfs = CS.tfs;
                    double tfi = CS.tfi;
                    double d = CS.d;
                    double tw = CS.tw;
                    
                    lambda_pw = 0.54 * Math.Sqrt(E / fy);
                    lambda_rw = 0.91 * Math.Sqrt(E / fy);

                    lambda_pf = 0.54 * Math.Sqrt(E / fy);
                    lambda_rf = 0.91 * Math.Sqrt(E / fy);

                    lambda_fs = bfs / tfs;                  // tomar bfs como sendo sempre a aba maior
                    lambda_fi = bfi / tfi;                  // tomar bfi como sendo sempre a aba menor

                    // aba maior
                    if (lambda_fs <= lambda_pf)
                    {
                        classe.BendingX_topFlange = "compacta";
                    }
                    else if(lambda_fs > lambda_pf && lambda_pf <= lambda_rf)
                    {
                        classe.BendingX_topFlange = "semit-compacta";
                    }
                    else if ( lambda_fs > lambda_rf)
                    {
                        classe.BendingX_topFlange = "esbelta";
                    }

                    // aba menor
                    if(lambda_fi <= lambda_pf)
                    {
                        classe.BendingX_bottomFlange = "compacta";
                    }
                    else if ( lambda_fi > lambda_pf && lambda_fi <= lambda_rf)
                    {
                        classe.BendingX_bottomFlange = "semi-compacta";
                    }
                    else if ( lambda_fi > lambda_rf)
                    {
                        classe.BendingX_bottomFlange = "esbelta";
                    }
                   
                }
                #endregion


            }

            if (internalForces.My != 0)
            {
                Mply = CS.Zy * fy; //[kN.cm]
                double tw = CS.tw;
                double hw = CS.d - CS.tfs - CS.tfi - CS.R;
                double bfs = CS.bfs;
                double bfi = CS.bfi;
                double tfs = CS.tfs;
                double tfi = CS.tfi;

                kc = 4 / (Math.Sqrt(hw / tw));

                #region Perfis I Soldados e laminados com um ou dois eixos de simetria e perfis U 
                if (CS.profCode == 100 || CS.profCode == 101 || CS.profCode==102 ||CS.profCode == 103||CS.profCode==104)
                {
                    lambda_pw = 1.12 * Math.Sqrt(E / fy);
                    lambda_rw = 1.4 * Math.Sqrt(E / fy);
                    lambda_pf = 0.38 * Math.Sqrt(E / fy);
                    lambda_w = hw / tw;

                    // se for soldado
                    if (CS.fabrication == 1)
                    {
                        lambda_rf = 0.95 * Math.Sqrt(E * kc / (0.7 * fy));
                    }
                    // se for laminado
                    else if (CS.fabrication == 2)
                    {
                        lambda_rf = 0.83 * Math.Sqrt(E / (0.7 * fy));
                    }

                    if (CS.profCode==100 || CS.profCode == 101)
                    {
                        lambda_fi = bfi / (2 * tfi);
                        lambda_fs = bfs / (2 * tfs);
                    }
                    else if(CS.profCode==103 || CS.profCode == 104)
                    {
                        lambda_fs = bfs / tfs;
                        lambda_fi = bfi / tfi;
                    }

                    if (lambda_fs <= lambda_pf)
                    {
                        classe.BendingY_topFlange = "compacta";
                    }
                   else if (lambda_fs>lambda_pf && lambda_fs <= lambda_rf)
                    {
                        classe.BendingY_topFlange = "semi-compacta";
                    }
                    else if (lambda_fs > lambda_rf)
                    {
                        classe.BendingY_topFlange = "esbelta";
                    }

                    if (lambda_fi <= lambda_pf)
                    {
                        classe.BendingY_topFlange = "compacta";
                    }
                    else if (lambda_fi > lambda_pf && lambda_fi <= lambda_rf)
                    {
                        classe.BendingY_topFlange = "semi-compacta";
                    }
                    else if (lambda_fi > lambda_rf)
                    {
                        classe.BendingY_topFlange = "esbelta";
                    }

                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingY_Web = "compacta";
                    }
                    else if(lambda_w>lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingY_Web = "semi-compacta";
                    }
                    else if (lambda_w > lambda_rw)
                    {
                        classe.BendingY_Web = "esbelta";
                    }
                }
                #endregion

                #region Perfis tubulares redondos
                if (CS.profCode == 111)
                {
                    double D = CS.d;
                    double t = CS.tw;
                    lambda_w = D / t;

                    lambda_pw = 0.07 * E / fy;
                    lambda_rw = 0.31 * E / fy;

                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingX_bottomFlange = "compacta";
                        classe.BendingX_Web = "compacta";
                        classe.BendingX_topFlange = "compacta";
                    }
                    if (lambda_w > lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingX_bottomFlange = "semi-compacta";
                        classe.BendingX_Web = "semi-compacta";
                        classe.BendingX_topFlange = "semi-compacta";
                    }
                    if (lambda_w > lambda_rw)
                    {
                        classe.BendingX_bottomFlange = "esbelta";
                        classe.BendingX_Web = "esbelta";
                        classe.BendingX_topFlange = "esbelta";
                    }
                }
                #endregion

                #region Perfis Caixao soldados ou tubos retangulares laminados
                if(CS.profCode==109 || CS.profCode == 110)
                {
                    lambda_w = hw / tw;
                    lambda_fs = bfs / tfs;
                    lambda_fi = bfi / tfi;

                    lambda_pf = 1.12 * Math.Sqrt(E / fy);
                    lambda_rf = 1.4 * Math.Sqrt(E / fy);

                    if (CS.profCode == 109)
                    {
                        lambda_rw = 3.76 * Math.Sqrt(E / fy);
                    }
                    else if (CS.profCode == 110)
                    {
                        lambda_rw = 2.42 * Math.Sqrt(E / fy);
                    }

                    if (lambda_w <= lambda_pw)
                    {
                        classe.BendingY_Web = "compacta";
                    }
                    else if ( lambda_w>lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingY_Web = "semi-compata";
                    }
                    else if (lambda_w > lambda_rw)
                    {
                        classe.BendingY_Web = "esbelta";
                    }

                    if (lambda_fs <= lambda_rw)
                    {
                        classe.BendingY_bottomFlange = "compacta";
                    }
                    else if (lambda_fs > lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingY_bottomFlange = "semi-compata";
                    }
                    else if (lambda_fs > lambda_rw)
                    {
                        classe.BendingY_bottomFlange = "esbelta";
                    }

                    if (lambda_fi <= lambda_rw)
                    {
                        classe.BendingY_topFlange = "compacta";
                    }
                    else if (lambda_fi > lambda_pw && lambda_w <= lambda_rw)
                    {
                        classe.BendingY_topFlange = "semi-compata";
                    }
                    else if (lambda_fi > lambda_rw)
                    {
                        classe.BendingY_topFlange = "esbelta";
                    }

                }
                #endregion
            }

            return classe;
        }

        /// <summary>
        /// Define hc - compressed part of the web
        /// </summary>
        /// <returns></returns>
        private double              define_hc()
        {
            double bfs = CS.bfs;
            double tfs = CS.tfs;
            double bfi = CS.bfi;
            double tfi = CS.tfi;
            double tw = CS.tw;
            double d = CS.d;
            double Hc;

            // top flange in compression
            if (internalForces.Mx >= 0)
            {
                Hc = (CS.d - CS.YCG - CS.tfs) * 2;
                Iyc = tfs * bfs * bfs * bfs / 12;
                Iyt = tfi * bfi * bfi * bfi / 12;
                alphay = Iyc / Iyt;
            }

            // bottom flange in compression
            else
            {
                Hc = (CS.YCG - CS.tfi) * 2;
                Iyt = tfs = bfs * bfs * bfs / 12;
                Iyc = tfi * bfi * bfi * bfi / 12;
                alphay = Iyc / Iyt;
            }
            return Hc;
        }

        /// <summary>
        /// define hp in related to PNL
        /// </summary>
        /// <returns></returns>
        private double              define_hp()
        {
            double bfs = CS.bfs;
            double tfs = CS.tfs;
            double bfi = CS.bfi;
            double tfi = CS.tfi;
            double tw = CS.tw;
            double d = CS.d;
            double Hp;
            double fy = CS.material.Fy;

            // top flange in compression
            if (internalForces.Mx >= 0)
            {
                Hp = ((bfi * tfi + (d - tfs - tfi) * tw - bfs * tfs) / tw) * 2;
                Mrx_FLM = 0.7 * fy * CS.Wxs; //[kN.cm]
            }

            // bottom flange in compression
            else
            {
                Hp = ((bfs * tfs + (d - tfs - tfi) * tw - bfi * tfi) / tw) * 2;
                Mrx_FLM = 0.7 * fy * CS.Wxi; //[kN.cm]
            }
            return Hp;
        }

        /// <summary>
        ///  check for bending moment in X and Y axis
        /// </summary>
        /// <param name="_cb"></param>
        /// <param name="lbbottom"></param>
        /// <param name="lbtop"></param>
        /// <returns></returns>
        public void                 bendingCheck()
        {
            double Mx = internalForces.Mx; //[kN.m]
            double ry = CS.ry;
            double E = CS.material.E * 1e-1; //[kN/cm2]
            double fy = CS.material.Fy;
            double Iy = CS.Iy;
            double J = CS.It;
            double beta1;
            double W = CS.Wxs;
            double Cw = CS.Cw;
            double d = CS.d;
            double Zx = CS.Zx;
            double Zy = CS.Zy;
            double Wy = CS.Wy;
            List<double> reslt = new List<double>();

            classe = bendingClassification();

            beta1 = 0.7 * fy * CS.Wxs / (E * J);

            // para flexao na maior inércia
            if (internalForces.Mx != 0)
            {
                #region Perfis I e U
                // I profile double symmetric and U
                if (CS.profCode == 100 || CS.profCode == 101 || CS.profCode==103 || CS.profCode==104)
                {
                    // for non-slender web profiles - annex G
                    if (lambda_w <= 5.7 * Math.Sqrt(E / fy))
                    {
                        #region FLT
                        // for positive bending moment
                        // top flange in compression

                        lambda_p = 1.76 * Math.Sqrt(E / fy);
                        lambda_r = (1.38 * Math.Sqrt(Iy * J) / (ry * J * beta1)) * Math.Sqrt(1 + Math.Sqrt(1 + 27 * Cw * beta1 * beta1 / Iy));
                        lambda = lb / ry;
                       
                        //----------------------------------
                        Mrx_FLT = 0.7 * fy * W; //[kN.cm]

                        if (lambda <= lambda_p)
                        {
                            reslt.Add(Mplx * 0.01 / gama1); //[kN.m]
                        }
                        else if ((lambda > lambda_p) && (lambda <= lambda_r))
                        {
                            double aux;
                            aux = (cb / gama1) * (Mplx - (Mplx - Mrx_FLT) * (lambda - lambda_p) / (lambda_r - lambda_p));
                            reslt.Add(aux * 0.01); //[kN.m]
                        }
                        else
                        {
                            Mcr_FLT = ((cb * Math.PI * Math.PI * E * Iy) / (lb * lb)) * Math.Sqrt((Cw / Iy) * (1 + 0.039 * (J * lb * lb / Cw))); //[kN.cm]
                            reslt.Add(Mcr_FLT * 0.01 / gama1); //[kN.m]
                        }

                        #endregion

                        #region FLM
                        // checking Flanges

                        double lbda;

                        if (Mx >= 0)
                        {
                            lbda = lambda_fs;
                        }
                        else
                        {
                            lbda = lambda_fi;
                        }

                        //-------------------------------
                        if (CS.fabrication == 1)
                        {
                            Mcrx_FLM = (0.90 * E * kc / (lbda * lbda)) * CS.Wxs; //[kN.cm]
                        }
                        else
                        {
                            Mcrx_FLM = (0.69 * E / (lbda * lbda)) * CS.Wxs; //[kN.cm]
                        }
                        //-------------------------------

                        //if (lbda <= lambda_pf)
                        if (classe.BendingX_topFlange.CompareTo("compacta") == 0)
                        {
                            reslt.Add(Mplx * 0.01 / gama1); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange.CompareTo("semi-compacta") == 0)
                        //else if ((lbda > lambda_pf) && (lbda <= lambda_rf))
                        {
                            double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLM) * (lbda - lambda_pf) / (lambda_rf - lambda_pf));
                            reslt.Add(aux*0.01);
                        }
                        else
                        {
                            reslt.Add(Mcrx_FLM * 0.01 / gama1); //[kN.m]
                        }
                    }

                    #endregion

                        #region FLA

                    // if (lambda_w <= lambda_pw)
                    if (classe.BendingX_Web.CompareTo("compacta") == 0)
                    {
                        reslt.Add(Mplx * 0.01 / gama1); //[kN.m]
                    }

                    else if (classe.BendingX_Web.CompareTo("semi-compacta") == 0)
                    //else if (lambda_w > lambda_pw)
                    {
                        double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLA) * ((lambda_w - lambda_pw) / (lambda_rw - lambda_pw)));
                        reslt.Add(aux * 0.01); //[kN.m]
                    }
                    #endregion


                    // check for slender web profiles - annex H
                    else
                    {
                        warningList.Add("Viga com alma esbelta - dimensionamento de acordo com o Anexo H ");
                        double aux = bendingCheckSlenderWeb();
                        reslt.Add(aux); //[kN.m]
                    }
                    res.BendingX = reslt.Min();
                    res.uc_BendingX = Math.Abs(internalForces.Mx / reslt.Min());
                }
                #endregion

                #region Tubo circular
                if (CS.profCode == 111)
                {
                    double D = CS.d;
                    double t = CS.tw;
                   
                    if (D / t <= 0.45 * E / fy)
                    {
                        if (classe.BendingX_Web == "compacta")
                        {
                            Mplx = CS.Zx * fy;
                            res.BendingX = Mplx *0.01/ gama1; //[kN.m]
                            res.uc_BendingX = Math.Abs(internalForces.Mx) / res.BendingX;
                        }
                        else if (classe.BendingX_Web == "semi-compacta")
                        {
                            res.BendingX = (1 / gama1) * (0.021 * E / (D / t) + fy) * W * 0.01; //[kN.m]
                            res.uc_BendingX = Math.Abs(internalForces.Mx) / res.BendingX;
                        }
                        else if (classe.BendingX_Web == "esbelta")
                        {
                            res.BendingX = (1 / gama1) * (0.33 * E / (D / t)) * W * 0.01; //[kN.m]
                            res.uc_BendingX = Math.Abs(internalForces.Mx) / res.BendingX;
                        }
                    }
                    else
                    {
                        errorList.Add("Relação D/t para tubos acima do permitido - item G.2.7");
                        res.BendingX = 0;
                        res.uc_BendingX = 999;
                    }
                }
                #endregion

                #region Perfis T e cantoneira dupla

                if(CS.profCode==105 || CS.profCode == 106 || CS.profCode==108)
                {

                    double My = CS.Wxs * fy;

                    if (internalForces.Mx > 0)
                    {
                        My = CS.Wxs * fy;
                        Mplx = Zx * fy <= W * fy ? Zx * fy : 1.6 * My;
                    }

                    else
                    {
                        My = CS.Wxi* fy;
                        Mplx = My;
                    }

                    warningList.Add("Dimensionamento feito segundo critérios do AISC-360-16");

                    #region FLT

                    double Lp = 1.76 * ry * Math.Sqrt(E / fy);
                    double Lr = 1.95 * (E / fy) * (Math.Sqrt(Iy * J) / W) * Math.Sqrt(2.36 * (fy / E) * d * W / J + 1);

                    if (lb <= Lp)
                    {
                        res.BendingX = Mplx*0.01 / gama1; //[kN.m]
                    }
                    else if(lb>Lp && lb <= Lr)
                    {
                        res.BendingX = (Mplx - (Mplx - My) * ((lb - Lp) / (Lr - Lp)) / gama1)*0.01; //[kN.m]
                    }
                    else if (lb > Lr)
                    {
                        double B;

                        if (internalForces.Mx > 0) { B = 2.3 * (d / lb) * Math.Sqrt(Iy / J); }
                        else { B = -2.3 * (d / lb) * Math.Sqrt(Iy / J); }

                        Mcr_FLT = 0.01*((1.95 * E / lb) * Math.Sqrt(Iy * J) * (B + Math.Sqrt(1 + B * B))); //[kN.m]
                        reslt.Add(Mcr_FLT / gama1);
                    }
                    #endregion

                    #region FLM
                    if (internalForces.Mx > 0)
                    {
                        if (classe.BendingX_topFlange == "compacta")
                        {
                            reslt.Add(Mplx * 0.01 / gama1); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "semi-compacta")
                        {

                            double aux = Mplx - (Mplx - 0.7 * fy * W) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf));

                            if (aux > 1.6 * My) { aux = 1.6 * My; }

                            reslt.Add(aux * 0.01 / gama1); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "esbelta")
                        {
                            double Wx = CS.Wxs;
                            if (internalForces.Mx < 0)
                            {
                                Wx = CS.Wxi;
                            }
                            double aux = 0.7 * E * Wx / Math.Pow((lambda_fs), 2);
                            reslt.Add(aux * 0.01 / gama1);//[kN.m]
                        }
                    }
                    else if (internalForces.Mx < 0)
                    {
                        reslt.Add(Mplx * 0.01 / gama1);
                        warningList.Add("Flange tracionado - FLM nao se aplica");
                    }
                    
                    #endregion

                    #region FLA

                    // FLA só se aplica se a borda livre da alma estiver comprimida
                    if (internalForces.Mx < 0)
                    {
                        double Fcr;

                        // para cantoneira dupla

                        if (CS.profCode == 108)
                        {
                            if (classe.BendingX_Web == "compacta")
                            {
                                reslt.Add(W * fy *0.01/ gama1);//[kN.m]
                            }
                            else if (classe.BendingX_Web == "semi-compacta")
                            {
                                double Mn = fy * W * (2.43 - 1.72 * lambda_w * Math.Sqrt(fy / E));
                                reslt.Add(Mn*0.01 / gama1);//[kN.m]
                            }
                            else if (classe.BendingX_Web == "esbelta")
                            {
                                Fcr = 0.71 * E / Math.Pow(lambda_w, 2);
                                reslt.Add(Fcr * W *0.01/ gama1); //[kN.m]
                            }
                        }

                        else 
                        {
                            if (classe.BendingX_Web == "compacta")
                            {
                                reslt.Add(W * fy *0.01/ gama1);//[kN.m]
                            }
                            else if (classe.BendingX_Web == "semi-compacta")
                            {
                                Fcr = (1.43 - 0.515 * lambda_w * Math.Sqrt(fy / E)) * fy;
                                reslt.Add(W * Fcr *0.01/ gama1);//[kN.m]
                            }
                            else if (classe.BendingX_Web == "esbelta")
                            {
                                Fcr = 1.52 * E / Math.Pow(lambda_w, 2);
                                reslt.Add(W * Fcr*0.01 / gama1); //[kN.m]
                            }
                        }
                    }

                    else
                    {
                        reslt.Add(0.01 * Mplx / gama1);
                        warningList.Add("borda livre da alma em tração - FLA não se aplica");
                    }

                    #endregion

                    res.BendingX = reslt.Min();
                    res.uc_BendingX = Math.Abs(internalForces.Mx / reslt.Min());
                }
                #endregion

                #region Perfis I monossimétricos

                if (CS.profCode == 102)
                {
                    double Ycg = CS.YCG;
                    double dc;
                    double tfs = CS.tfs;
                    double tfi = CS.tfi;
                    double ryc = 0;
                    double bfs = CS.bfs;
                    double tw = CS.tw;
                    double A = CS.A;
                    double bfi = CS.bfi;
                    double beta2 = 0;
                    double beta3 = 0;
                    double Wc = 0;
                    double Wt = 0;


                    if (internalForces.Mx > 0)
                    {
                        dc = d - tfs - Ycg;
                        Iyc = tfs * Math.Pow(bfs, 3) / 12 + dc * Math.Pow(tw, 3);

                        ryc =Math.Sqrt(tfs * Math.Pow(bfs, 3) / 12 + dc * Math.Pow(tw, 3)/A);
                        Wc = CS.Wxs;
                        Wt = CS.Wxi;
                        beta1 = 0.7 * fy * Wc / (E * J);
                    }
                    else if (internalForces.Mx < 0)
                    {
                        dc = Ycg;
                        Iyc = tfs * Math.Pow(bfs, 3) / 12 + dc * Math.Pow(tw, 3);

                        ryc = Math.Sqrt(tfi * Math.Pow(bfi, 3) / 12 + dc * Math.Pow(tw, 3) / A);
                        Wc = CS.Wxi;
                        Wt = CS.Wxs;
                        beta1 = 0.7 * fy * Wc / (E * J);
                    }

                    #region FLT

                    beta3 = 0.45 * (d - (tfs + tfi) / 2) * ((alphay - 1) / (alphay + 1));
                    beta2 = 5.2 * beta1 * beta3 + 1;
                    lambda = lb / ryc;
                    lambda_p = 1.76 * Math.Sqrt(E / fy);
                    lambda_r = 1.38 * (Math.Sqrt(Iy * J) / (ryc * J * beta1)) * Math.Sqrt(beta2 + Math.Sqrt(beta2 * beta2 + 27 * Cw * beta1 * beta1 / Iy));

                    Mcr_FLT = cb*Math.Pow(Math.PI,2)*E * Iy / (Math.Pow(lb, 2)) * (beta3 + Math.Sqrt(beta3 * beta3 + (Cw / Iy) * (0.039 * J * Math.Pow(lb, 2) / Cw)));
                    Mrx_FLT = 0.7 * fy * Wc > fy * Wt ? 0.7 * fy * Wc : fy * Wt;

                    if (lambda <= lambda_p)
                    {
                        reslt.Add(Mplx*0.01 / gama1); //[kN.m]
                    }
                    else if ( lambda>lambda_p && lambda<= lambda_r)
                    {
                        double aux = (cb / gama1) * (Mplx - (Mplx - Mrx_FLT) * ((lambda - lambda_p) / (lambda_r - lambda_p)));
                        reslt.Add(aux*0.01); //[kN.m]
                    }
                    else if (lambda > lambda_r)
                    {
                        double aux = Mcr_FLT / gama1 < Mplx / gama1 ? Mcr_FLT / gama1 : Mplx / gama1;
                        reslt.Add(aux*0.01); //[kN.m]
                    }

                    #endregion

                    #region FLM

                    if (internalForces.Mx > 0)
                    {
                        if (classe.BendingX_topFlange =="compacta" )
                        {
                            reslt.Add(Mplx *0.01/ gama1); //[kN.m]
                        }

                        else if (classe.BendingX_topFlange=="semi-compacta")
                        {
                            double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLM) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf)));
                            reslt.Add(aux*0.01); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "esbelta")
                        {
                            reslt.Add(Mcrx_FLM*0.01 / gama1); //[kN.m]
                        }
                    }
                    
                    else if (internalForces.Mx < 0)
                    {
                        if (classe.BendingX_bottomFlange == "compacta")
                        {
                            reslt.Add(Mplx*0.01 / gama1); //[kN.m]
                        }

                        else if (classe.BendingX_bottomFlange == "semi-compacta")
                        {
                            double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLM) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf)));
                            reslt.Add(aux*0.01); //[kN.m]
                        }
                        else if (classe.BendingX_bottomFlange == "esbelta")
                        {
                            reslt.Add(Mcrx_FLM *0.01/ gama1); //[kN.m]
                        }
                    }

                    #endregion

                    #region FLA

                    if (classe.BendingX_Web == "compacta")
                    {
                        reslt.Add(Mplx*0.01 / gama1); //[kN.m]
                    }

                    else if (classe.BendingX_Web == "semi-compacta")
                    {
                        double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLM) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf)));
                        reslt.Add(aux*0.01 ); //[kN.m]
                    }
                    else if (classe.BendingX_Web == "esbelta")
                    {
                        reslt.Add(Mcrx_FLM*0.01 / gama1); //[kN.m]
                    }
                    #endregion

                    res.BendingX = reslt.Min();
                    res.uc_BendingX = Math.Abs(internalForces.Mx / res.BendingX);
                }
                #endregion

                #region Cantoneiras simples

                if (CS.profCode == 107)
                {
                    double b = CS.bfs;
                    double t = CS.tw;
                    double My = CS.Wxs * fy;
                    
                    #region FLT

                    warningList.Add(" Este software considera a flexão de cantoneiras em relação aos eixos geométricos, segundo a norma AISC-360-16");
                    warningList.Add(" Para a flexão de cantoneiras, considera-se que a aba horizontal encontra-se comprimida para cargas gravitacionais");
                    if (internalForces.Mx > 0)
                    {
                        Mcr_FLT = 0.58 * E * Math.Pow(b, 4) * cb * (Math.Sqrt(1 + 0.88 * (Math.Pow(lb * t / (b * b), 2)) - 1)) / (lb * lb);
                    }
                    else if (internalForces.Mx < 0)
                    {
                        Mcr_FLT = 0.58 * E * Math.Pow(b, 4) * cb * (Math.Sqrt(1 + 0.88 * (Math.Pow(lb * t / (b * b), 2)) + 1)) / (lb * lb);
                    }

                    if (My / Mcr_FLT <= 1.0)
                    {
                        double Mn = (1.92-1.17*Math.Sqrt(My/Mcr_FLT))*My<1.5*My? (1.92 - 1.17 * Math.Sqrt(My / Mcr_FLT)) * My:1.5 * My;
                        reslt.Add(Mn*0.01 / gama1); //[kN.m]
                    }
                    else if (My / Mcr_FLT > 1.0)
                    {
                        double Mn = (0.92 - 0.17 * Mcr_FLT / My) * Mcr_FLT;
                        reslt.Add(Mn*0.01 / gama1); //[kN.m]
                    }
                    #endregion

                    #region FLM
                    // FLM só ocorre para momento positivo - flange em compressao
                    if (internalForces.Mx > 0)
                    {
                        if (classe.BendingX_topFlange == "compacta")
                        {
                            reslt.Add(My * 0.01 / gama1); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "semi-compacta")
                        {
                            double Mn = fy * W * (2.43 - 1.72 * (b / t) * Math.Sqrt(fy / E));
                            reslt.Add(Mn * 0.01 / gama1); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "esbelta")
                        {
                            double Fcr = 0.71 * E / Math.Pow(b / t, 2);
                            reslt.Add(W * Fcr * 0.01 / gama1); //[kN.m]
                        }
                    }
                    // FLM nao ocorre.
                    else if (internalForces.Mx < 0)
                    {
                        reslt.Add(My * 0.01/ gama1);
                    }

                    #endregion

                    res.BendingX = reslt.Min();
                    res.uc_BendingX = Math.Abs(internalForces.Mx / res.BendingX);
                }
                #endregion

                #region Perfis Caixao soldado e tubo retangular

                if(CS.profCode==109 || CS.profCode == 110)
                {
                    double A = CS.A;
                    double tfs = CS.tfs;
                    double tfi = CS.tfi;
                    double bfi = CS.bfi;
                    double bfs = CS.bfs;
                    double tw = CS.tw;
                    double h = CS.d - tfs - tfi;
                    double Wef = 0;
                    

                    #region FLT

                    Mcr_FLT = 2 * cb * E * Math.Sqrt(J * A) / lambda;
                    Mrx_FLT = 0.7 * W * fy;

                    lambda = lb / ry;
                    lambda_p = (0.13 * E / Mplx) * Math.Sqrt(J * A);
                    lambda_r = (2.00 * E / Mrx_FLT) * Math.Sqrt(J * A);

                    if (lambda <= lambda_p)
                    {
                        reslt.Add(Mplx*0.01 / gama1); //[kN.m]
                    }
                    else if (lambda>lambda_p && lambda <= lambda_r)
                    {
                        double Mn = (cb / gama1) * (Mplx - (Mplx - Mrx_FLT) * ((lambda - lambda_p) / (lambda_r - lambda_p)));
                        reslt.Add(Mn*0.01 / gama1); //[kN.m]
                    }
                    else if (lambda > lambda_r)
                    {
                        double Mn = Mcr_FLT  < Mplx ? Mcr_FLT : Mplx ;
                        reslt.Add(Mn*0.01 / gama1); //[kN.m]
                    }
                    #endregion

                    #region FLM

                    if (internalForces.Mx > 0)
                    {
                        if (classe.BendingX_topFlange == "compacta")
                        {
                            reslt.Add(Mplx / gama1);
                        }
                        else if (classe.BendingX_topFlange == "semi-compacta")
                        {
                            double Ycg;
                            double bef;

                            if (CS.profCode == 109)
                            {
                                bef = 1.92 * tfs * Math.Sqrt(E / fy) * (1 - (0.34 / lambda_fs) * Math.Sqrt(E / fy)) < bfs ?
                                      1.92 * tfs * Math.Sqrt(E / fy) * (1 - (0.34 / lambda_fs) * Math.Sqrt(E / fy)) : bfs;
                            }
                            else
                            {
                                bef = 1.92 * tfs * Math.Sqrt(E / fy) * (1 - (0.38 / lambda_fs) * Math.Sqrt(E / fy)) < bfs ?
                                      1.92 * tfs * Math.Sqrt(E / fy) * (1 - (0.38 / lambda_fs) * Math.Sqrt(E / fy)) : bfs;
                            }

                            Ycg = CS.YCG * 10 - (bfs - bef) * tfs * (d - tfs) / A; //[mm]

                            double Ief = 2 * (tw * h * h * h / 12 + tw * h * Math.Pow((h / 2 - Ycg + tfi), 2)) +
                                         bfi * tfi * tfi * tfi / 12 + bfi * tfi * Math.Pow((tfi * 0.5), 2) +
                                         bef * tfs * tfs * tfs / 12 + bef * tfs * Math.Pow((d - Ycg - tfs * 0.5),2);

                            double y = Math.Max(Ycg, d - Ycg);
                            Wef = Ief / y;
                            Mrx_FLM = Wef * fy;

                            double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLM) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf)));
                            reslt.Add(aux * 0.01); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "esbelta")
                        {
                            Mcrx_FLM = (Wef * Wef / W) * fy;
                            double aux = Mcrx_FLM <= Mplx ? Mcrx_FLM : Mplx;
                            reslt.Add(aux * 0.01 / gama1); //[kN.m]
                        }
                    }

                    else if (internalForces.Mx < 0)
                    {
                        if (classe.BendingX_topFlange == "compacta")
                        {
                            reslt.Add(Mplx / gama1);
                        }
                        else if (classe.BendingX_topFlange == "semi-compacta")
                        {
                            double Ycg;
                            double bef;

                            if (CS.profCode == 109)
                            {
                                bef = 1.92 * tfi * Math.Sqrt(E / fy) * (1 - (0.34 / lambda_fi) * Math.Sqrt(E / fy)) < bfi ?
                                      1.92 * tfi * Math.Sqrt(E / fy) * (1 - (0.34 / lambda_fi) * Math.Sqrt(E / fy)) : bfi;
                            }
                            else
                            {
                                bef = 1.92 * tfi * Math.Sqrt(E / fy) * (1 - (0.38 / lambda_fi) * Math.Sqrt(E / fy)) < bfi ?
                                      1.92 * tfi * Math.Sqrt(E / fy) * (1 - (0.38 / lambda_fi) * Math.Sqrt(E / fy)) : bfi;
                            }

                            Ycg = CS.YCG * 10 - (bfi - bef) * tfi * tfi*0.5 / A; //[mm]

                            double Ief = 2 * (tw * h * h * h / 12 + tw * h * Math.Pow((h / 2 - Ycg + tfi), 2)) +
                                         bef * tfi * tfi * tfi / 12 + bef * tfi * Math.Pow((tfi * 0.5), 2) +
                                         bfs * tfs * tfs * tfs / 12 + bfs * tfs * Math.Pow((d - Ycg - tfs * 0.5),2);

                            double y = Math.Max(Ycg, d - Ycg);
                            Wef = Ief / y;
                            Mrx_FLM = Wef * fy;

                            double aux = (1 / gama1) * (Mplx - (Mplx - Mrx_FLM) * ((lambda_fi - lambda_pf) / (lambda_rf - lambda_pf)));
                            reslt.Add(aux * 0.01); //[kN.m]
                        }
                        else if (classe.BendingX_topFlange == "esbelta")
                        {
                            Mcrx_FLM = (Wef * Wef / W) * fy;
                            double aux = Mcrx_FLM <= Mplx ? Mcrx_FLM : Mplx;
                            reslt.Add(aux * 0.01 / gama1); //[kN.m]
                        }
                    }
 
                    #endregion

                    #region FLA

                    if (classe.BendingX_Web == "compacta")
                    {
                        reslt.Add(Mplx*0.01 / gama1); //[kN.m]
                    }
                    else if (classe.BendingX_Web == "semi-compacta")
                    {
                        Mrx_FLA = W * fy;

                        double Mn = (1 / gama1) * (Mplx - (Mplx - Mrx_FLA) * ((lambda_w - lambda_pw) / (lambda_rw - lambda_pw)));
                        reslt.Add(Mn*0.01); //[kN.m]
                    }

                    else if (classe.BendingX_Web == "esbelta")
                    {
                        warningList.Add("Perfil com alma esbelta na coberto pela NBR8800 - Dimensionamento seguno item F7.3-c da AISC-360-16");
                        double Rpg;
                        double Fcr;
                        kc = 4;
                        double aw = 0; ;
                        double hc = define_hc();

                        if (internalForces.Mx > 0)
                        {
                           aw = 2 * h * tw / bfs;
                        }
                        else if (internalForces.Mx < 0)
                        {
                            aw = 2 * h * tw / bfi;
                        }

                        Rpg = 1 - (aw / (1200 + 300 * aw)) * (hc / tw - 5.7 * Math.Sqrt(E / fy));
                        if (Rpg > 1) { Rpg = 1; }

                        Fcr = 0.9 * E * kc / Math.Pow(lambda_fs, 2);
                        double Mn = Rpg * Fcr * W;

                        reslt.Add(Mn * 0.01 / gama1);
                    }
                    #endregion
                    res.BendingX = reslt.Min();
                    res.uc_BendingX = Math.Abs(internalForces.Mx / res.BendingX);
                }

                #endregion

            }

            // Para flexao na menor inércia
            if (internalForces.My != 0)
            {
                Mcry_FLM = Wy * 0.7 * fy;
                double tw = CS.tw;
                double hw = CS.d - CS.tfs - CS.tfi - CS.R;
                double xcg = CS.XCG;

                #region Perfis I, I monossimetrico e U

                // todo: quando form fazer o programa para 3D, terá que incluir o angulo de rotação da seção
              
                    if (CS.profCode == 100 || CS.profCode == 101 || CS.profCode == 102 || CS.profCode == 103 || CS.profCode == 104)
                    {
                    if (internalForces.My > 0)
                    {
                        #region FLM

                        if (classe.BendingY_bottomFlange == "compacta" && classe.BendingY_topFlange == "compacta")
                        {
                            reslt.Add(Mply*0.01 / gama1);
                        }
                        else if (classe.BendingY_bottomFlange == "semi-compacta" || classe.BendingY_topFlange == "semi-compacta")
                        {
                            double aux = (1 / gama1) * (Mply - (Mply - Mrx_FLM) * ((lambda_fi - lambda_pf) / (lambda_rf - lambda_pf)));
                            double aux1 = (1 / gama1) * (Mply - (Mply - Mrx_FLM) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf)));
                            double aux2 = Math.Min(aux, aux1);

                            reslt.Add(aux2*0.01 / gama1);
                        }
                        else if (classe.BendingY_bottomFlange == "esbelta" || classe.BendingY_topFlange == "esbelta")
                        {
                            reslt.Add(Mcry_FLM*0.01 / gama1);
                        }
                        #endregion

                    else if (internalForces.My < 0)
                    {
                            if(CS.profCode==100 || CS.profCode==101 || CS.profCode == 102)
                            {
                                #region FLM

                                if (classe.BendingY_bottomFlange == "compacta" && classe.BendingY_topFlange == "compacta")
                                {
                                    reslt.Add(Mply / gama1);
                                }
                                else if (classe.BendingY_bottomFlange == "semi-compacta" || classe.BendingY_topFlange == "semi-compacta")
                                {
                                    double aux = (1 / gama1) * (Mply - (Mply - Mrx_FLM) * ((lambda_fi - lambda_pf) / (lambda_rf - lambda_pf)));
                                    double aux1 = (1 / gama1) * (Mply - (Mply - Mrx_FLM) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf)));
                                    double aux2 = Math.Min(aux, aux1);

                                    reslt.Add(aux2*0.01);
                                }
                                else if (classe.BendingY_bottomFlange == "esbelta" || classe.BendingY_topFlange == "esbelta")
                                {
                                    reslt.Add(Mcry_FLM*0.01 / gama1);
                                }

                                #endregion
                            }
                            else if (CS.profCode==103 || CS.profCode == 104)
                            {
                                #region FLA para perfils U com alma comprimida

                                double bef = 0;
                                double b = 0;
                                double Iyef = 0;
                                double Wyef = 0;

                                bef = 1.92 * tw * Math.Sqrt(E / fy) * (1 - (0.34 / lambda_w) * Math.Sqrt(E / fy)) < hw ?
                                      1.92 * tw * Math.Sqrt(E / fy) * (1 - (0.34 / lambda_w) * Math.Sqrt(E / fy)) : hw;

                                b = hw - bef;

                                Iyef = Iy - (b * tw * tw * tw / 12 + b * tw * Math.Pow(xcg-0.5*tw,2));
                                Wyef = Iyef / xcg;

                                Mry_FLA = Wyef * fy;
                                Mcry_FLA = (Wyef * Wyef / Wy) * fy;

                                if (classe.BendingY_Web == "compacta")
                                {
                                    reslt.Add(Mply*0.01 / gama1);
                                }
                                else if (classe.BendingY_Web == "semi-compacta")
                                {
                                    double aux = (1 / gama1) * (Mply - (Mply - Mry_FLA) * ((lambda_w - lambda_pw) / (lambda - lambda_rw - lambda_pw)));
                                    reslt.Add(aux*0.01);
                                }

                                #endregion
                            }
                    }
                       
                    }
                    res.BendingY = reslt.Min();
                    res.uc_BendingY = Math.Abs(internalForces.My / res.BendingY);
                }
                #endregion

                #region Perfil T
                    if(CS.profCode==105 || CS.profCode == 106)
                {
                    double My = CS.Wy * fy;
                    warningList.Add("Flexao em torno do eixo Y para perfis nao é cobertura pela NBR8800. Para esta verificação considera-se apenas a flambagem local das mesas e o escoamento conforme AISC-360-16.");

                    #region FLM
                    if (classe.BendingY_topFlange == "compacta")
                    {
                        reslt.Add(Mply * 0.01 / gama1); //[kN.m]
                    }
                    else if (classe.BendingY_topFlange == "semi-compacta")
                    {

                        double aux = Mply - (Mply - 0.7 * fy * Wy) * ((lambda_fs - lambda_pf) / (lambda_rf - lambda_pf));

                        if (aux > 1.6 * My) { aux = 1.6 * My; }

                        reslt.Add(aux * 0.01 / gama1); //[kN.m]
                    }
                    else if (classe.BendingY_topFlange == "esbelta")
                    {
                       
                        double aux = 0.7 * E * Wy / Math.Pow((lambda_fs), 2);
                        reslt.Add(aux * 0.01 / gama1);//[kN.m]
                    }
                    #endregion

                    #region Escoamento

                    reslt.Add(Mply * 0.01 / gama1);
                    #endregion

                    res.BendingY = reslt.Min();
                    res.uc_BendingY = Math.Abs(internalForces.My / res.BendingY);
                }
                #endregion

            }
        }

        /// <summary>
        /// check for beams with slender webs
        /// return resistance
        /// </summary>
        private double              bendingCheckSlenderWeb()
        {
            double Kpg;
            double ryt;
            double Iyc;
            double Iyt;
            double hw;
            double bf;
            double tf;
            double bfs = CS.bfs;
            double bfi = CS.bfi;
            double tfs = CS.tfs;
            double tfi = CS.tfi;
            double d = CS.d;
            double tw = CS.tw;
            double Mx = internalForces.Mx;
            double Af;
            double E = CS.material.E * 1e-5;
            double fy = CS.material.Fy;
            double Wxt;
            double Wxc;
            double ar;
            double lambda_f;

            List<double> res = new List<double>();

            double A1;
            double A2;

            //checking Item H.1.3

            if (bfs >= bfi)
            {
                A1 = bfs * tfs;
                A2 = bfi * tfi + (d - tfs - tfi) * tw;
            }
            else
            {
                A1 = bfi * tfi;
                A2 = bfs * tfs + (d - tfs - tfi) * tw;
            }

            if (((alphay >= 1 / 9) && (alphay <= 9)) && (A2 > A1))
            {
                hw = (d - tfs - tfi) * tw;
                // check moment direction and calculate parameter accordinly
                if (Mx >= 0)
                {
                    Af = bfs * tfs;
                    Wxt = CS.Wxs;
                    Wxc = CS.Wxi;
                    ryt = tfs * bfs * bfs * bfs / 12 + (hc / 3) * Math.Pow(tw, 3);
                    //lambda = lbtop / ryt;
                    lambda = lb / ryt;
                    ar = hw / Af;
                    //lambda_f = bfs / (2 * tfs);
                    lambda_f = lambda_fs;
                }
                else
                {
                    Af = bfi * tfi;
                    Wxt = CS.Wxi;
                    Wxc = CS.Wxs;
                    ryt = tfi * bfi * bfi * bfi / 12 + (hc / 3) * Math.Pow(tw, 3);
                    //lambda = lbbottom / ryt;
                    lambda = lb / ryt;
                    ar = hw / Af;
                    //lambda_f = bfi / (2 * tfi);
                    lambda_f = lambda_fi;
                }

                if (hw / Af <= 10)
                {
                    double ah = a / (d - tfs - tfi);
                    double limit;
                    if (d / tw <= 260)
                    {
                        if (ah <= 1.5)
                        {
                            limit = 11.7 * Math.Sqrt(E / fy);
                        }
                        else { limit = 0.42 * E / fy; }

                        if (ah <= limit)
                        {
                            // checking item H.2.1
                            res.Add(Wxt * fy*0.01 / gama1); // tension flange [kN.m}

                            // checking item H.2.2 - FLT
                            #region FLT
                            lambda_p = 1.1 * Math.Sqrt(E / fy);
                            lambda_r = Math.PI * (Math.Sqrt(E / (0.7 * fy)));
                            Kpg = 1 - (ar / (1200 + 300 * ar) * (hc / tw - 5.7 * Math.Sqrt(E / fy)));

                            if (lambda <= lambda_p)
                            {
                                double aux = Kpg * Wxc * fy / gama1; //[kN.cm]
                                res.Add(aux*0.01); //[kN.m]
                            }
                            else if ((lambda > lambda_p) && (lambda <= lambda_r))
                            {
                                double aux = (1 / gama1) * cb * Kpg * (1 - 0.3 * ((lambda - lambda_p) / (lambda_r - lambda_p))) * Wxc * fy; //[kN.cm]
                                if (aux > Kpg * Wxc * fy / gama1) { aux = Kpg * Wxc * fy / gama1; } //[kN.cm]
                                res.Add(aux*0.01); //[kN.m]
                            }
                            else
                            {
                                double aux = (1 / gama1) * (cb * Kpg * Math.Pow(Math.PI, 2) * E * Wxc) / Math.Pow(lambda, 2); //[kN.cm]
                                if (aux > Kpg * Wxc * fy / gama1) { aux = Kpg * Wxc * fy / gama1; } //[kN.cm]
                                res.Add(aux*0.01);//[kN.m]
                            }
                            #endregion

                            // checkin item H.2.3 - FLM
                            #region FLM
                            // lambda_pf = 0.38 * Math.Sqrt(E / fy);
                            //lambda_rf = 0.95 * Math.Sqrt(kc * E / (0.7 * fy));

                            if (lambda_f <= lambda_pf)
                            {
                                double aux = Kpg * Wxc * fy / gama1; //[kN.cm]
                                res.Add(aux*0.01); //[kN.m]
                            }
                            else if ((lambda_f > lambda_pf) && (lambda_f <= lambda_rf))
                            {
                                double aux = (1 / gama1) * Kpg * (1 - 0.3 * ((lambda_f - lambda_pf) / (lambda_rf - lambda_pf))) * Wxc * fy; //[kN.cm]
                                res.Add(aux*0.01); //[kN.m]
                            }
                            else
                            {
                                double aux = (1 / gama1) * (0.9 * Kpg * E * kc * Wxc / Math.Pow(lambda_f, 2)); //[kN.cm]
                                res.Add(aux*0.01); //[kN.m]
                            }
                            #endregion
                        }
                    }
                }
            }
            else
            {
                errorList.Add(" Esbeltez da alma acima do permitido - checar anexo H - item H.1.3");
            }

            return res.Min();
        }

        public List<string>         getErrorList()   { return errorList; }

        public List<string>         getWarningList() { return warningList; }

        /// <summary>
        /// calculate buckling load of compressed members
        /// </summary>
        /// <returns></returns>
        private double              DefineNe()
        {
            double Ne=0;
            double Ix = CS.Ix;
            double Iy = CS.Iy;
            double rx = CS.rx;
            double ry = CS.ry;
            double E = CS.material.E * 0.1; //[kN/cm2]
            double G = CS.material.G * 0.1; //[kN/cm2]
            double Cw = CS.Cw;
            double Nex=0;
            double Ney=0;
            double Nez=0;
            double Neyz = 0;
            double r0=0;
            double x0 = 0;
            double J = CS.It;
            CS.defineCG();
            double y0 = CS.YCG*0.1;

            r0 = Math.Sqrt(x0 * x0 + y0 * y0 + rx * rx + ry * ry);

            // todo: fazer o calculo do Ne para outros tipos de perfis - cantoneiras e perfis assimetricos

            #region Perfil I duplamente simetrico
            if (CS.profCode ==100 || CS.profCode== 101)
            {
                Nex = Math.Pow(Math.PI, 2) * E * Ix / (kx * lbx * lbx);
                Ney = Math.Pow(Math.PI, 2) * E * Iy / (ky * lby * lby);
                r0 = Math.Sqrt(x0 * x0 + y0 * y0 + rx * rx + ry * ry);
                Nez = (1 / Math.Pow(r0, 2) * ((Math.Pow(Math.PI, 2)*E*Cw)/Math.Pow((kt*lbt),2))+G*J);

                Ne = Math.Min(Nex, Math.Min(Ney, Nez));
            }
            #endregion

            #region Pefil I monossimetrico
            else if (CS.profCode == 102)
            {
                Nex = Math.Pow(Math.PI, 2) * E * Ix / (kx * lbx * lbx);
                Ney = Math.Pow(Math.PI, 2) * E * Iy / (ky * lby * lby);
                Nez = (1 / Math.Pow(r0, 2) * ((Math.Pow(Math.PI, 2) * E * Cw) / Math.Pow((kt * lbt), 2)) + G * J);
                Neyz = ((Ney + Nez) / (2 * (1 - Math.Pow((y0 / r0), 2))))*(1-Math.Sqrt((1-4*Ney*Nez*(Math.Pow(y0/r0,2)))/(Math.Pow(Ney+Nez,2))));

                Ne = Math.Min(Nex, Neyz);
            }
            #endregion

            #region Perfil tubo circular e tubo retangular e perfil caixão
            if (CS.profCode == 111 || CS.profCode==110||CS.profCode==109)
            {
                Nex = Math.Pow(Math.PI, 2) * E * Ix / (kx * lbx * lbx);
                Ney = Math.Pow(Math.PI, 2) * E * Iy / (ky * lby * lby);
                Ne = Math.Min(Nex, Neyz);
            }
            #endregion

            #region Perfil U

            if(CS.profCode==103 || CS.profCode == 104)
            {
                Ney = Math.Pow(Math.PI, 2) * E * Iy / (ky * lby * lby);

                Nex = Math.Pow(Math.PI, 2) * E * Ix / (kx * lbx * lbx);
                Nez = (1/Math.Pow(r0,2))*(Math.Pow(Math.PI,2)*E*Cw/(Math.Pow((kt*lbt),2)+G*J));

                Neyz = ((Nex + Nez) / (2 * (1 - Math.Pow(x0 / r0, 2)))) * (1 - Math.Sqrt(1 - 4*Nex * Nez * (1 - Math.Pow(x0 / r0, 2)) / Math.Pow(Nex + Nez, 2)));
                Ne = Math.Min(Ney, Neyz);
            }
            #endregion

            #region Perfil T e cantoneira dupla

            if (CS.profCode == 105 || CS.profCode == 106 || CS.profCode==108)
            {
                Nex = Math.Pow(Math.PI, 2) * E * Ix / (kx * lbx * lbx);

                Ney = Math.Pow(Math.PI, 2) * E * Iy / (ky * lby * lby);
                Nez = (1 / Math.Pow(r0, 2)) * (Math.Pow(Math.PI, 2) * E * Cw / (Math.Pow((kt * lbt), 2) + G * J));

                Neyz = ((Ney + Nez) / (2 * (1 - Math.Pow(y0 / r0, 2)))) * (1 - Math.Sqrt(1 - 4 * Ney * Nez * (1 - Math.Pow(y0 / r0, 2)) / Math.Pow(Ney + Nez, 2)));
                Ne = Math.Min(Nex, Neyz);
            }
            #endregion

            #region Cantoneira simples
            if (CS.profCode == 107)
            {
                double aux = 0;
                double lbx1 = 0;

                aux = lbx / rx;
                if(aux>=0 && aux <= 80)
                {
                    lbx1 = 72 * rx + 0.75 * lbx;
                }
                else if (aux > 80)
                {
                    lbx1 = 32 * rx + 1.25 * lbx;
                }
               Nex = Math.Pow(Math.PI, 2) * E * Ix / (lbx1*lbx1);
                Ne = Nex;
            }
            #endregion

            return Ne;
        }

        private Classification      CompressionClassification()
        {
            double E = CS.material.E * 0.1; //[kN/cm2]
            double fy = CS.material.Fy;     //[kN/cm2]
            double bfs = CS.bfs;
            double bfi = CS.bfi;
            double d = CS.d;
            double tw = CS.tw;
            double tfs = CS.tfs;
            double tfi = CS.tfi;
            double R = CS.R;
            double kc = 0;
            
            Classification classe = new Classification();

            #region Grupo 1 - Alma e Mesa de Tubo quadrado
            if (CS.profCode == 110)
            {
                lambda_pw = 1.4 * Math.Sqrt(E / fy);
                lambda_w = (d - tfs - tfi - 2 * R) / tw;

                lambda_pf = lambda_pw;
                lambda_fs = (bfs - 2 * tw - 2 * R) / tfs;
                lambda_fi = (bfi - 2 * tw - 2 * R) / tfi;

                if (lambda_fs <= lambda_pf) { classe.Compr_topFlange = "compacta"; }
                else if (lambda_fs > lambda_pf && lambda_fs <= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_topFlange = "esbelta"; }

                if (lambda_fi <= lambda_pf) { classe.Compr_bottomFlange = "compacta"; }
                else if (lambda_fi > lambda_pf && lambda_fi <= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_bottomFlange = "esbelta"; }

                if (lambda_w <= lambda_pw) { classe.Compr_Web = "compacta"; }
                else if (lambda_w > lambda_pw && lambda_w <= lambda_rw) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_Web = "esbelta"; }
            }
            #endregion

            #region Grupo 2 - Alma de perfis I soldados e laminados, caixa soldado, U soldado e laminado, U soldado e laminado
            if (CS.profCode == 100
                || CS.profCode == 101
                || CS.profCode == 102
                || CS.profCode == 103
                || CS.profCode == 104
                || CS.profCode == 109)
            {
                lambda_pw = 1.49 * Math.Sqrt(E / fy);
                lambda_w = (d - tfs - tfi - 2 * R) / tw;

                if (lambda_w <= lambda_pw) { classe.Compr_Web = "compacta"; }
                else if (lambda_w > lambda_pw && lambda_w <= lambda_rw) { classe.Compr_Web = "semi-compacta"; }
                else { classe.Compr_Web = "esbelta"; }
            }
            #endregion

            #region Grupo 3 - Abas Cantoneiras laminadas e soldadas siMplxes ou duplas

            if (CS.profCode == 107 || CS.profCode ==108)
            {
                lambda_pw = 0.45 * Math.Sqrt(E / fy);
                lambda_rw = 0.91 * Math.Sqrt(E / fy);
                lambda_rf = lambda_rw;
                lambda_w = d / tw;

                lambda_pf = lambda_pw;
                lambda_fs = (bfs / tfs);
                lambda_fi = (bfi / tfi);

                if (lambda_fs <= lambda_pf) { classe.Compr_topFlange = "compacta"; }
                else if (lambda_fs > lambda_pf && lambda_fs <= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_topFlange = "esbelta"; }

                if (lambda_fi <= lambda_pf) { classe.Compr_bottomFlange = "compacta"; }
                else if (lambda_fi > lambda_pf && lambda_fi <= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_bottomFlange = "esbelta"; }

                if (lambda_w <= lambda_pw) { classe.Compr_Web = "compacta"; }
                else if (lambda_w > lambda_pw && lambda_w <= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_Web = "esbelta"; }
            }
            #endregion

            #region Grupo 4 - Mesas de perfis I, U, T e Cantoneira dupla todos laminados 
            if (CS.profCode==101||CS.profCode==103||CS.profCode==105)
            {
                
                lambda_pf = 0.56 * Math.Sqrt(E / fy);
                lambda_rf = 1.03 * Math.Sqrt(E / fy);
                lambda_fs = bfs / (2 * tfs);
                lambda_fi = bfi / (2 * bfi);

                if (lambda_fs <= lambda_pf) { classe.Compr_topFlange = "compacta"; }
                else if( lambda_fs > lambda_pf && lambda_fs <= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_topFlange = "esbelta"; }

                if (lambda_fi <= lambda_pf) { classe.Compr_bottomFlange = "compacta"; }
                else if (lambda_fi > lambda_pf && lambda_fi <= lambda_rf) { classe.Compr_bottomFlange = "semi-compacta"; }
                else { classe.Compr_bottomFlange = "esbelta"; }

            }
            #endregion

            #region Grupo 5 - Mesas de perfis I, U, T Soldados e perfil I soldado assimetrico
            if (  CS.profCode == 100 
                ||CS.profCode == 104 
                ||CS.profCode == 106
                ||CS.profCode == 102)
            {
                kc = 4 / (Math.Sqrt((d - tfs - tfi) / tw));
                if (kc < 0.35) { kc = 0.35; }
                else if (kc > 0.76) { kc = 0.76; }

                lambda_pf = 0.64 * Math.Sqrt(E *kc/ fy);
                lambda_fs = bfs / (2 * tfs);
                lambda_fi = bfi / (2 * bfi);
                lambda_rf = 1.17 * Math.Sqrt(E * kc / fy);


                if (lambda_fs <= lambda_pf) { classe.Compr_topFlange = "compacta"; }
                else if(lambda_fs>lambda_pf && lambda_fs<= lambda_rf) { classe.Compr_topFlange = "semi-compacta"; }
                else { classe.Compr_topFlange = "esbelta"; }

                if (lambda_fi <= lambda_pf) { classe.Compr_bottomFlange = "compacta"; }
                else if(lambda_fi>lambda_pf && lambda_fi <= lambda_rf) { classe.Compr_bottomFlange = "semi-compacta"; }
                else { classe.Compr_bottomFlange = "esbelta"; }
            }
            #endregion

            #region Grupo 6 - Alma de perfil T laminado e soldado
            if (CS.profCode == 105 || CS.profCode == 106)
            {
                lambda_pw = 0.75 * Math.Sqrt(E / fy);
                lambda_rw = 1.03 * Math.Sqrt(E / fy);
                lambda_w = d  / tw;

                if (lambda_w <= lambda_pw) { classe.Compr_Web = "compacta"; }
                else if(lambda_w>lambda_pw && lambda_w <= lambda_rw) { classe.Compr_Web = "semi-compacta"; }
                else { classe.Compr_Web = "esbelta"; }
            }
            #endregion

            #region Tubo circular
            if (CS.profCode == 111)
            {
                double D = CS.d;
                double t = CS.tw;
                lambda_w = D / t;

                lambda_pw = 0.11 * E / fy;
                lambda_rw = 0.45 * E / fy;

                if (lambda_w <= lambda_pw)
                {
                    classe.Compr_Web = "compacta";
                }
                else if ( lambda_w>lambda_pw && lambda_w <= lambda_rw)
                {
                    classe.Compr_Web = "semi-compacta";
                }
                else if (lambda_w > lambda_rw)
                {
                    classe.Compr_Web = "esbelta";
                }
            }
            #endregion

            return classe;
        }

        private void                CheckCompressionLocalBuckling()
        {
            double E = CS.material.E * 0.1; //[kN/cm2]
            double fy = CS.material.Fy; //[kN/cm2]
            classe = CompressionClassification();
            double tw = CS.tw;
            double tfs = CS.tfs;
            double tfi = CS.tfi;
            double R = CS.R;
            double d = CS.d;
            Qs = 1;
            Qa = 1;
            Q = 1;


            #region F.2a - Grupo 3 - Cantoneiras duplas com travejamento e siMplxes

            if (CS.profCode == 107)
            {
                if (classe.Compr_Web == "compacta" && classe.Compr_topFlange == "compacta" && classe.Compr_bottomFlange == "compacta")
                {
                    Qs = 1;
                }
                else if (classe.Compr_Web == "semi-compacta" || classe.Compr_topFlange == "semi-compacta" || classe.Compr_bottomFlange == "semi-compacta")
                {
                    double Qs1 = 1.34 - 0.76 * lambda_fs * Math.Sqrt(fy / E);
                    double Qs2 = 1.34 - 0.76 * lambda_fi * Math.Sqrt(fy / E);
                    double Qs3 = 1.34 - 0.76 * lambda_w * Math.Sqrt(fy / E);
                    double aux = Math.Min(Qs1, Qs2);
                    Qs = Math.Min(aux, Qs3);
                }
                else if (classe.Compr_Web == "esbelta" || classe.Compr_topFlange == "esbelta" || classe.Compr_bottomFlange == "esbelta")
                {
                    double Qs1 = 0.53 * E / (fy * (lambda_w) * lambda_w);
                    double Qs2 = 0.53 * E / (fy * (lambda_fs) * lambda_fs);
                    double Qs3 = 0.53 * E / (fy * (lambda_fi) * lambda_fi);
                    double aux = Math.Min(Qs1, Qs2);
                    Qs = Math.Min(aux, Qs3);
                }
            }
            #endregion

            #region F.2b - Grupo 4 - Mesas de perfis I, U, T e Cantoneira dupla todos laminados 
            if (CS.profCode == 101 || CS.profCode == 103 || CS.profCode == 105)
            {
                if (classe.Compr_topFlange == "compacta" && classe.Compr_bottomFlange == "compacta")
                {
                    Qs = 1;
                }
                else if (classe.Compr_topFlange == "semi-compacta" || classe.Compr_bottomFlange == "semi-compacta")
                {
                    double Qs1 = 1.415 - 0.74 * lambda_fs * Math.Sqrt(fy / E);
                    double Qs2 = 1.415 - 0.74 * lambda_fi * Math.Sqrt(fy / E);
                    Qs = Math.Min(Qs1, Qs2);

                }
                else if (classe.Compr_topFlange == "esbelta" || classe.Compr_bottomFlange == "esbelta")
                {
                    double Qs1 = 0.69 * E / (fy * lambda_fs * lambda_fs);
                    double Qs2 = 0.69 * E / (fy * lambda_fi * lambda_fi);
                    Qs = Math.Min(Qs1, Qs2);
                }
            }
            #endregion

            #region F.2c - Grupo 5 - Mesas de perfis I, U, T Soldados e perfil I soldado assimetrico
            if (CS.profCode == 100
               || CS.profCode == 104
               || CS.profCode == 106
               || CS.profCode == 102)
            {
                if (classe.Compr_topFlange == "compacta" && classe.Compr_bottomFlange == "compacta")
                {
                    Qs = 1;
                }
                else if (classe.Compr_topFlange == "semi-compacta" || classe.Compr_bottomFlange == "semi-compacta")
                {
                    double Qs1 = 1.415 - 0.65 * lambda_fs * Math.Sqrt(fy /(kc* E));
                    double Qs2 = 1.415 - 0.65 * lambda_fi * Math.Sqrt(fy /(kc* E));
                    Qs = Math.Min(Qs1, Qs2);

                }
                else if(classe.Compr_topFlange == "esbelta" || classe.Compr_bottomFlange == "esbelta")
                {
                    double Qs1 = 0.90 * E * kc / (fy * lambda_fs * lambda_fs);
                    double Qs2 = 0.90 * E * kc / (fy * lambda_fi * lambda_fi);
                    Qs = Math.Min(Qs1, Qs2);
                }
            }
            #endregion

            #region F.2d - Grupo 6 - Alma de perfil T laminado e soldado
            if (CS.profCode == 105 || CS.profCode == 106)
            {
                if (classe.Compr_Web == "compacta")
                {
                    Qs = 1;
                }
                else if (classe.Compr_Web == "semi-compacta")
                {
                    Qs = 1.908 - 1.22 * lambda_w * Math.Sqrt(fy / E);
                }
                else if (classe.Compr_Web == "esbelta")
                {
                    
                    Qs = 0.69 * E / (fy * lambda_w * lambda_w);
                   
                }
            }
            #endregion

            #region F3.2 - Grupos 1 e 2 - Almas elementos AA

            if (   CS.profCode == 100
                || CS.profCode == 101
                || CS.profCode == 102
                || CS.profCode == 103
                || CS.profCode == 104
                || CS.profCode == 109
                || CS.profCode == 110) 
            {
                if (lambda_w > lambda_pw)
                {

                    double X = 0;  // fator de redução a compressao com Q=1;
                    double lambda0 = 0;
                    double Ag = CS.A;
                    double Ne;
                    double sigma;
                    double bef;
                    double ca;
                    double Aef;

                    ca = CS.profCode == 110 ? 0.38 : 0.34;
                    Ne = DefineNe();

                    lambda0 = Math.Sqrt((a * fy / Ne));
                    if (X <= 1.5)
                    {
                        X = Math.Pow(0.658, Math.Pow(lambda0, 2));
                    }
                    else if (X > 1.5)
                    {
                        X = 0.877 / (Math.Pow(lambda0, 2));
                    }
                    sigma = X * fy;


                    bef = 1.92 * tw * Math.Sqrt(E / fy) * (1 - (ca / lambda_w) * Math.Sqrt(E / sigma));
                    if (bef > (d - tfs - tfi - R)) { bef = d - tfs - tfi - R; }

                    // se for tubo retangular ou caixao
                    if(CS.profCode==109 || CS.profCode == 110)
                    {
                        Aef = Ag - 2 * ((d - tfs - tfi - R) - bef) * tw;
                    }
                    else
                    {
                        Aef = Ag - (d - tfs - tfi - R) * tw;
                    }

                    Qa = Aef / Ag;
                }
            }

            #endregion

            #region F4 - tubos circulares
            if (CS.profCode == 111)
            {
                try
                {
                    if (classe.Compr_Web == "compacta")
                    {
                        Qa = 1;
                        Qs = 1;
                    }
                    if (classe.Compr_Web == "semi-compacta")
                    {
                        Qs = 1;
                        Qa = 0.038 * E / (lambda_w * fy) + 1.5;
                    }
                    if (classe.Compr_Web == "esbelta")
                    {
                        throw new Exception("Relação D/t acima do permitido. Altere as dimensões do perfil");
                    }
                }
                catch(Exception ex)
                {
                    errorList.Add("Relação D/t acima do permitido. Altere as dimensões do perfil. Item F.4 - Anexo F - NBR8800.");
                }
               
            }
            #endregion

            Q = Qs * Qa;
        }

        /// <summary>
        /// calculate the compression resistance
        /// </summary>
        /// <returns></returns>
        private void                CompressionCheck()
        {
            double rx = CS.rx;
            double ry = CS.ry;
            double rt = CS.rT;
            double Ag = CS.A;
            double fy = CS.material.Fy;
            

            if(internalForces.N < 0)
            {
                // check slenderness limit (<=200)
                lambda_cx = lbx / rx;
                lambda_cy = lby / ry;

                if (lambda_cx <= 200 && lambda_cy <= 200)
                {
                    CheckCompressionLocalBuckling();
                    double Ne = DefineNe();
                    double lambda0 = Math.Sqrt(Q * Ag * fy / Ne);

                    if (lambda0 <= 1.5)
                    {
                        double aux = Math.Pow(lambda0, 2);
                        CompFactor_X = Math.Pow(0.658, aux);
                    }
                    else if (lambda0 > 1.5)
                    {
                        double aux = Math.Pow(lambda0, 2);
                        CompFactor_X = 0.877 / aux;
                    }

                    res.Compression = CompFactor_X * Q * Ag * fy / gama1;
                }
                else
                {
                    errorList.Add("Perfil com esbeltez maior que 200. lambda_x = " + lambda_cx + "," + "lambda_y = " + lambda_cy);
                }

                res.uc_Compression = Math.Abs(internalForces.N / res.Compression);
               
            }
           
        }

        private void                ShearCheck()
        {
            double E = CS.material.E;
            double fy = CS.material.Fy;
            double h = CS.d - CS.tfs - CS.tfi - CS.R;
            double tw = CS.tw;
            double Aw = CS.d * tw * 1e-2; //[cm2]
            double reslt;

            Vply = 0.6 * Aw * fy;


            // caso de flexao na maior inércia
            if (internalForces.Vy != 0)
            {
                // calculo de kv
                if (a / h > 3 || a / h > (Math.Pow(260 / (h / tw), 2)))
                {
                    Kv = 5;
                }
                else
                {
                    Kv = 5 + 5 / Math.Pow(a / h, 2);
                }

                lambda_pw = 1.1 * Math.Sqrt(Kv * E / fy);
                lambda_rw = 1.37 * Math.Sqrt(Kv * E / fy);

                if (lambda_w <= lambda_pw)
                {
                    res.ShearY = Vply / gama1;
                }
                else if (lambda_w > lambda_pw && lambda_w <= lambda_rw)
                {
                    res.ShearY = (lambda_pw / lambda_w) * Vply / gama1;
                }
                else if (lambda_w > lambda_rw)
                {
                    res.ShearY = 1.24 * Math.Pow((lambda_pw / lambda_w), 2) * Vply / gama1;
                }

                res.uc_ShearY = Math.Abs(internalForces.Vy / res.ShearY);
            }
            
           
        }
    }

}
