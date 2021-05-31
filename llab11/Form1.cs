using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_11
{
    public partial class Form1 : Form
    {
        double tb_1, tb_2, tb_3, tb_4, tb_5;
        double fouth;
        int max;
        int xx;
        double N = 9.488;
        public Options a = new Options();
        int[] Statistic = new int[6];
        double[] Vera = new double[6];
        double[] Maid = new double[6];

        private void timer1_Tick(object sender, EventArgs e)
        {
                if (xx < 6)
                {

                    chart1.Series[0].Points.AddXY(0, Vera[xx]);
                    xx++;
                }
                else
                {
                    timer1.Stop();
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public Form1()
                {
                    InitializeComponent();
                }

        

        private void button1_Click(object sender, EventArgs e)
        {
            tb_1 = Convert.ToDouble(textBox1.Text);
            tb_2 = Convert.ToDouble(textBox2.Text);
            tb_3 = Convert.ToDouble(textBox3.Text);
            tb_4 = Convert.ToDouble(textBox4.Text);
            max = Convert.ToInt32(textBox5.Text);
            fouth = tb_1 + tb_2 + tb_3 + tb_4;
            if ((fouth < 1))
            {
                Maid[5] = tb_5 = 1 - fouth;
                button1.Text = tb_5.ToString();
            }
            else
            {
                button1.Text = "Неправильно";
            }

        }
        private void button2_Click(object sender, EventArgs e)
            {
                Maid[1] = tb_1 = Convert.ToDouble(textBox1.Text);
                Maid[2] = tb_2 = Convert.ToDouble(textBox2.Text);
                Maid[3] = tb_3 = Convert.ToDouble(textBox3.Text);
                Maid[4] = tb_4 = Convert.ToDouble(textBox4.Text);
                max = Convert.ToInt32(textBox5.Text);

                fouth = tb_1 + tb_2 + tb_3 + tb_4;
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, 0);
                xx = 0;


                Statistic = a.Statistical(tb_1, tb_2, tb_3, tb_4, tb_5, max);

                for (int i = 1; i < 6; i++)
                {
                    Vera[i] = (double)Statistic[i] / max;
                    Vera[i] = Math.Round(Vera[i], 3);

                }

                label7.Text = "Received:" + " " + Vera[1].ToString();
                label8.Text = "Received:" + " " + Vera[2].ToString();
                label9.Text = "Received:" + " " + Vera[3].ToString();
                label10.Text = "Received:" + " " + Vera[4].ToString();
                label11.Text = "Received:" + " " + Vera[5].ToString();

                Mathematics mathematics = new Mathematics();

                timer1.Start();

                double E = mathematics.Average(Vera);
                double M = mathematics.Average(Maid);
                label12.Text = "Average: " + E + " (error = " + mathematics.Prosent(E, M).ToString() + "%)";
                E = mathematics.Variance(Vera);
                M = mathematics.Variance(Maid);
                label13.Text = "Variance: " + Math.Round(E, 3) + " (error = " + mathematics.Prosent(E, M).ToString() + "%)";

                double m = mathematics.Xi(Statistic, Maid, max);
                if (m > N)
                {
                    label14.Text = "Chi - squared: " + Math.Round(m, 3).ToString() + ">" + N + " true";
                }
                else
                {
                    label14.Text = "Chi - squared: " + Math.Round(m, 3).ToString() + "<" + N + " false";
                }
            }
        

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
