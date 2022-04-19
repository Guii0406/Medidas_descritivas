using System;
using System.Collections.Generic;
using System.Linq;

namespace PROGRAMA_MEDIDAS_DESCRITIVAS
{
   static class Calcula
    {
        public static double MediaAritmetica(List<double> lista)
        {
            double numerador = lista.Sum();
            double denominador = lista.Count();

            return Math.Round(numerador / denominador, 2);
        }
        public static double VarianciaAmostral(List<double> lista, double media)
        {
            double numerador = 0;
            double denominador = lista.Count - 1;
            foreach(double n in lista)
            {
                numerador += Math.Pow((n - media), 2);
            }
            return Math.Round(numerador / denominador, 2);
        }
        public static double DesvioPadrao(double varianciaAmostral)
        {
            return Math.Round(Math.Sqrt(varianciaAmostral), 2);
        }
        public static double CoeficienteDeVariacao(double media, double desvioPadrao)
        {
            return Math.Round((desvioPadrao / media) * 100, 2);
        }
        public static string HomogenioOuHeterogenio(double coeficiente)
        {
            if(coeficiente <= 30)
            {
                return "Homogênio";
            }
            else
            {
                return "Heterogênio";
            }
        }
        public static double Mediana(List<double> lista)
        {
            lista = lista.OrderBy(x => x).ToList();
            
            if(lista.Count % 2 == 0)
            {
                int posicao1 = (lista.Count / 2) - 1;
                int posicao2 = (lista.Count / 2);
                return Math.Round((lista[posicao1] + lista[posicao2]) / 2.0, 2);
            }
            else
            {
                int posicao = lista.Count / 2;
                return lista[posicao];
            }
        }
    }
}
