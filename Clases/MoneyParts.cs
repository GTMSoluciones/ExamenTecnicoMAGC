using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class MoneyParts
    {
        private List<double> denominaciones = new List<double> { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };
        public Dictionary<double, List<double>> build(string cadena)
        {
            double moneda=Convert.ToDouble(cadena);            
            var CombinacionesSplits = new Dictionary<double, List<double>>();
            double denominacion = 0;
            int idDenominacion = 0;
            int idx = 0;
            var denomMax = denominaciones.Where(x=>x<=moneda).Max();
            while (denominacion <= denomMax)
            {
                denominacion = denominaciones[idDenominacion];

                int absoluteValue = (int) Math.Round(moneda / denominacion,2);
                var valueToSplit = Math.Round(moneda - (double)(absoluteValue * denominacion),2);
                int absoluteValueSplit = 0;
                var splits = new List<double>();
                while (absoluteValueSplit < absoluteValue)
                {
                    splits.Add(denominacion);
                    absoluteValueSplit++;
                }
                var nrorep = splits.Count();
                if (Math.Round(splits.Sum(),2)==moneda)
                {
                    CombinacionesSplits[idx] = splits;
                    idx++;
                }
                else
                {
                    var splitAnt = splits;
                    var idMaxDenomSplit=completar2(moneda, splits, idDenominacion);
                    CombinacionesSplits[idx] = splits;
                    idx++;
                    //if (idMaxDenomSplit!=idDenominacion && idMaxDenomSplit>0)
                    //{
                    //    while (idMaxDenomSplit>0)
                    //    {
                    //        splits = splitAnt;
                    //        idMaxDenomSplit = completar2(moneda, splits, idMaxDenomSplit);
                    //        AllPossibleSplits[idx] = splits;
                    //        idx++;
                    //    }
                    //}
                }

                if (idDenominacion>0 && nrorep>0)
                {
                    absoluteValueSplit = 0;
                    while (nrorep>1)
                    {
                        nrorep = nrorep - 1;
                        splits = new List<double>();
                        for (int i = 0; i < nrorep; i++)
                        {
                            splits.Add(denominacion);   
                        }
                        completar2(moneda, splits, idDenominacion);
                        CombinacionesSplits[idx] = splits;
                        idx++;
                    }     
                }
                idDenominacion = idDenominacion + 1;

            }

            return CombinacionesSplits;
        }
        private int completar2(double mon,List<double> split,int indexDenom)
        {
            var sumList = split.Sum();
            double denominacion=0;
            int indexDdenomEval=indexDenom;
            while (sumList<mon)
            {
                denominacion = denominaciones[indexDdenomEval - 1];
                if ((Math.Round(sumList+denominacion,2))<=mon)
                {                    
                    split.Add(denominacion);
                    sumList = Math.Round(split.Sum(),2);
                }
                else
                {
                    indexDdenomEval = indexDdenomEval - 1;
                    if (indexDdenomEval == 0)
                        break;
                }
            }
            var denomList = split.Where(x => x == denominaciones[indexDenom]).ToList();
            double denomMax = 0;
            if(denomList.Count>0)
            {
                denomMax = denomList.Max();
            }
            var id = denominaciones.IndexOf(denomMax);
            if (id != null)
                id = 0;
            return id;
        }
    }
}
