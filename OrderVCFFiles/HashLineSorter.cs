using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderVCFFiles
{
    class HashLineSorter : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            if (x == null) { return 1; }
            else if (y == null) { return -1; }
            else
            {
                int a = getChromosomeNumber(x);
                int b = getChromosomeNumber(y);

                if (a == b)
                { return x.CompareTo(y); }
                else
                { return a - b; }
            }
            
        }
        private int getChromosomeNumber(string line)
        {
            int a;
            int index;
            int indexComma = line.IndexOf(",");
            int indexUnderScore = line.IndexOf("_");
            if (indexUnderScore > -1 && indexUnderScore < indexComma)
            { index = indexUnderScore; }
            else
            { index = indexComma; }

            string bit = line.Substring(13, index - 13).Replace("chr", "");
            if (bit.StartsWith("X") || bit.StartsWith("x"))
            { a = 23; }
            else if (bit.StartsWith("Y") || bit.StartsWith("y"))
            { a = 24; }
            else if (bit.StartsWith("M") || bit.StartsWith("m"))
            { a = 25; }
            else if (bit.StartsWith("U") || bit.StartsWith("u"))
            { a = 26; }
            else { a = Convert.ToInt32(bit); }
            return a;
        }
    }
}

