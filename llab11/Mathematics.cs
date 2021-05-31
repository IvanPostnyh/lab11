using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_11
{
    public class Mathematics
    {
        public double Average(double[] pop)
        {
            double average = 0;
            for (int i = 1; i < 6; i++)
            {
                average += (i) * pop[i];
            }

            return average;
        }

        public int Prosent(double E, double M)
        {
            double prosent = (Math.Abs(E - M)) / E;
            int prosenttt = (int)(prosent * 100);
            return prosenttt;
        }

        public double Variance(double[] pop)
        {
            double varoance = 0;
            for (int i = 1; i < 6; i++)
            {
                varoance += (i) * (i) * pop[i];
            }

            varoance -= Average(pop) * Average(pop); ;

            return varoance;
        }

        public double Xi(int[] first, double[] second, int max)
        {
            double xi = 0;

            for (int i = 1; i < 6; i++)
            {

                xi += (first[i] * first[i]) / (double)(max * second[i]);
            }
            xi -= max;
            return xi;
        }
    }
}

