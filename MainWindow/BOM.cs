using Beam;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWin
{
    class BOM
    {
        List<clsBeam> ListaVigas;
        List<string> Warnings;
        List<string> Errors;
      


        public BOM(List<clsBeam> _ListaVigas, string _NomeBOM, string _NomeResumo)
        {
            this.ListaVigas = _ListaVigas;
            GeraRelatorioResumoPorViga(_NomeBOM);
            CalculaResumoMateriais(_NomeResumo);
           
        }
        public void GeraRelatorioResumoPorViga(string _NomeBOM)
        {
            
            double VolumeConcreto = 0;
            double AreaForma = 0;
            Dictionary<double, double> ResumoAcoPorViga = new Dictionary<double, double>();

            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\"+_NomeBOM, false);
            using (fl)
            {
                fl.WriteLine("\t\t\t\t\t\t{0,50:f2}", "RESUMO DE MATERIAIS POR VIGA");
                foreach (var viga in ListaVigas)
                {

                    // cabeçalhos
                    fl.WriteLine("Nome: {0,10:F2}", viga.Name);
                    fl.WriteLine("{0,-20:f2}\t{1,10:f2}\t{2,10:f2}\t{3,20:f2}\t\t\t{4,28:f2}\t\t\t\t{5,12:f2}", "TRECHO", "SEÇAO(cm)", "AREA DE FORMA(m2)", "SUPERIOR", "INFERIOR", "ESTRIBOS");
                    fl.WriteLine("\t\t\t\t\t{0,30:f2}\t{1,10:f2}\t{2,10:f2}\t{3,10:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}\t{7,10:f2}", "DIAM", "QTDE", "PESO(kg)", "DIAM", "QTDE", "PESO(kg)", "DIAM", "PESO(kg)");
                    var det = viga.DetalhamentoViga;
                    // valores
                    if (!CheckErrors(viga))// se nao tiver erros
                    {
                        foreach (var trecho in det)
                        {
                            double Bitola;
                            if (ResumoAcoPorViga.TryGetValue(trecho.Value.DiamBarInferior, out Bitola))
                            {
                                ResumoAcoPorViga[trecho.Value.DiamBarInferior] += trecho.Value.Peso_Asi;
                            }
                            else
                            {
                                ResumoAcoPorViga.Add(trecho.Value.DiamBarInferior, trecho.Value.Peso_Asi);
                            }

                            if (ResumoAcoPorViga.TryGetValue(trecho.Value.DiamBarSuperior, out Bitola))
                            {
                                ResumoAcoPorViga[trecho.Value.DiamBarSuperior] += trecho.Value.Peso_Ass;
                            }
                            else
                            {
                                ResumoAcoPorViga.Add(trecho.Value.DiamBarSuperior, trecho.Value.Peso_Ass);
                            }

                            if (ResumoAcoPorViga.TryGetValue(trecho.Value.DiamEstribo, out Bitola))
                            {
                                ResumoAcoPorViga[trecho.Value.DiamEstribo] += trecho.Value.Peso_Asw;
                            }
                            else
                            {
                                ResumoAcoPorViga.Add(trecho.Value.DiamEstribo, trecho.Value.Peso_Asw);
                            }


                            fl.WriteLine("{0,-20:f2}\t{1,10:f2}\t{2,10:f2}\t{3,13:f2}\t{4,10:f2}\t{5,10:f2}\t{6,10:f2}\t{7,10:f2}\t{8,10:f2}\t{9,10:f2}\t{10,10:f2}",
                                                                                                            trecho.Key,
                                                                                                            trecho.Value.b + " x " + trecho.Value.h,
                                                                                                            trecho.Value.AreaForma,
                                                                                                            trecho.Value.DiamBarSuperior,
                                                                                                            trecho.Value.NBarSuperior,
                                                                                                            trecho.Value.Peso_Ass,
                                                                                                            trecho.Value.DiamBarInferior,
                                                                                                            trecho.Value.NBarInferior,
                                                                                                            trecho.Value.Peso_Asi,
                                                                                                            trecho.Value.DiamEstribo,
                                                                                                            trecho.Value.Peso_Asw);
                            VolumeConcreto += trecho.Value.VolumeConcreto;
                            AreaForma += trecho.Value.AreaForma;

                        }

                            var resumo = ResumoAcoPorViga.OrderBy(x => x.Key);
                            fl.WriteLine();
                            fl.WriteLine("VOLUME DE CONCRETO: \t{0,10:f2} m3", VolumeConcreto);
                            fl.WriteLine("ÁREA DE FORMA: \t\t{0,10:f2} m2", AreaForma);
                            fl.WriteLine("RESUMO DE AÇO:");
                            fl.WriteLine("{0,5:f2}\t{1,5:f2}", "DIAM. (mm)", "PESO (kg)");

                            foreach (var bitola in resumo)
                            {
                                fl.WriteLine("{0,-15:f2}\t{1,5:f2} kg", bitola.Key, bitola.Value);
                            }
                            string divisao = new string('-', 180);
                            fl.WriteLine(divisao);

                            fl.WriteLine();
                            ResumoAcoPorViga.Clear();
                            AreaForma = 0;
                            VolumeConcreto = 0;

                        
                    }
                    else
                    {
                        fl.WriteLine("***********Erro no cálculo da viga!************");
                        string divisao = new string('-', 180);
                        fl.WriteLine(divisao);

                        fl.WriteLine();
                    }
                       
                    
                }
            }
            fl.Close();

        }
        public void CalculaResumoMateriais(string _NomeResumo)
        {
            double VolumeConcreto = 0;
            double AreaForma = 0;
            Dictionary<double, double> ResumoAcoPorViga = new Dictionary<double, double>();
            int ErrorCount=0;

            StreamWriter fl = new StreamWriter(ProjectInfo.projectPath + @"\Beams\"+_NomeResumo, false);

            using (fl)
            {
                foreach (var viga in ListaVigas)
                {
                    if (!CheckErrors(viga))
                    {
                        var det = viga.DetalhamentoViga;
                        foreach (var trecho in det)
                        {
                            double Bitola;
                            if (ResumoAcoPorViga.TryGetValue(trecho.Value.DiamBarInferior, out Bitola))
                            {
                                ResumoAcoPorViga[trecho.Value.DiamBarInferior] += trecho.Value.Peso_Asi;
                            }
                            else
                            {
                                ResumoAcoPorViga.Add(trecho.Value.DiamBarInferior, trecho.Value.Peso_Asi);
                            }

                            if (ResumoAcoPorViga.TryGetValue(trecho.Value.DiamBarSuperior, out Bitola))
                            {
                                ResumoAcoPorViga[trecho.Value.DiamBarSuperior] += trecho.Value.Peso_Ass;
                            }
                            else
                            {
                                ResumoAcoPorViga.Add(trecho.Value.DiamBarSuperior, trecho.Value.Peso_Ass);
                            }

                            if (ResumoAcoPorViga.TryGetValue(trecho.Value.DiamEstribo, out Bitola))
                            {
                                ResumoAcoPorViga[trecho.Value.DiamEstribo] += trecho.Value.Peso_Asw;
                            }
                            else
                            {
                                ResumoAcoPorViga.Add(trecho.Value.DiamEstribo, trecho.Value.Peso_Asw);
                            }

                            VolumeConcreto += trecho.Value.VolumeConcreto;
                            AreaForma += trecho.Value.AreaForma;

                        }

                       
                    }
                    else
                    {
                        ErrorCount++;
                    }
                  

                }
                var resumo = ResumoAcoPorViga.OrderBy(x => x.Key);
                fl.WriteLine();
                fl.WriteLine("RESUMO DE MATERIAIS DO PROJETO");
                fl.WriteLine();
                fl.WriteLine("VOLUME DE CONCRETO: \t{0,20:f2} m3", VolumeConcreto);
                fl.WriteLine("ÁREA DE FORMA: \t\t{0,20:f2} m2", AreaForma);
                fl.WriteLine("RESUMO DE AÇO:");
                fl.WriteLine("{0,5:f2}\t{1,5:f2}", "DIAM. (mm)", "PESO (kg)");

                foreach (var bitola in resumo)
                {
                    fl.WriteLine("{0,-15:f2}\t{1,5:f2} kg", bitola.Key, bitola.Value);
                }

                if (ErrorCount > 0) { fl.WriteLine("*******Há vigas com erro que nao foram dimensionadas!*******"); }
            }
            fl.Close();
        }   
        public bool CheckWarnings(clsBeam viga)
        {

            this.Warnings = new List<string>();
                     
          //  foreach( var viga in ListaVigas)
          //  {
                var combi = viga.results.Keys.ToList();
                foreach( var cb in combi)
                {
                    var result = viga.results[cb].Values;
                    
                    var Wrn = (from w in result where w.status != "OK" select w.Warnings).ToList();
                    foreach(var i in Wrn)
                    {
                       this. Warnings.AddRange(i);
                    }
                }

          //  }
            return Warnings.Count != 0;
           

        }
        public bool CheckErrors(clsBeam viga)
        {
            this.Errors = new List<string>();


          //  foreach (var viga in ListaVigas)
          //  {
                var combi = viga.results.Keys.ToList();
                foreach (var cb in combi)
                {
                    var result = viga.results[cb].Values;
                    
                    var Wrn = (from w in result where w.status != "OK" select w.Errors).ToList();
                    foreach (var i in Wrn)
                    {
                        this.Errors.AddRange(i);
                    }
                }

           // }
            return Errors.Count != 0;


        }
    }
}
