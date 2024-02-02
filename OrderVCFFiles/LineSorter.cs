using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderVCFFiles
{
    class LineSorter : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            if (x == null) { return 1; }
            else if (y == null) { return -1; }
            else 
            {
                string[] itemsA = x.Split('\t');
                string[] itemsB = y.Split('\t');

                int a = Convert.ToInt32(itemsA[1]);
                int b = Convert.ToInt32(itemsB[1]);
                return a - b;
            }

        }
    }
}
