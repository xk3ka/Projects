using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation02
{

    public class Solution
    {
        private List<string> Lines { get; set; }

        public Solution(List<string> lines)
        {
            Lines = lines;
        }

        public List<string> Run(int N)
        {
            int paragraph = 1;
            int i = 0;

            while (i < Lines.Count)
            {
                if (Lines[i].Trim() == "")
                {
                    int j = 0;
                    while (Lines[i + j].Trim() == "" && i + j < Lines.Count)
                    {
                        j++;
                    }
                    if (i != 0)
                    {
                        paragraph++;
                    }
                    i += j;
                }

                if (paragraph == N)
                {
                    int j = 0;
                    while (i + j < Lines.Count && Lines[i + j].Trim() != "")
                    {
                        j++;
                    }
                    Lines.RemoveRange(i, j);
                    break;
                }
                i++;
            }
            return Lines;
        }
    }
}
