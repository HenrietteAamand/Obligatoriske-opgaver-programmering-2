using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAfTing
{
    class Program
    {
        static void Main(string[] args)
        {
            String splitStreng = "Dette/Er/En/Prøve";
            string[] splitArray = splitStreng.Split('/');

            for (int i = 0; i < splitArray.Length; i++)
            {
                Console.WriteLine(splitArray[i] + "\n");
            }

        }
    }
}
