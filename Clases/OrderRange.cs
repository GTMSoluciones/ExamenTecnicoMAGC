using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class OrderRange
    {
        public int[][] build(int[] coleccion)
        {
            int[] iPar = coleccion.Where(x => x % 2 == 0).ToArray();
            int[] iImpar = coleccion.Where(x => x % 2 != 0).ToArray();
            Array.Sort(iPar);
            Array.Sort(iImpar);
            int[][] res = { iPar, iImpar };
            return res;
        } 
    }
}
