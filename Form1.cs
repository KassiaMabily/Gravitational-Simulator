using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Universe universe = new Universe();
        List<CelestialBody> matrix = new List<CelestialBody>();

        private List<Point> points = new List<Point>();


        public Form1()
        {
            InitializeComponent();

            

            this.Paint += Form1_Load;
        }

        async private void Form1_Load(object sender, EventArgs e)
        {

            matrix = universe.ReadCelestialBodies();
            List<string> output = new List<string>();


            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Red, 2);

            if (matrix.Count > 1)
            {
                for (int iteration = 0; iteration < 10000; iteration++)
                {
                    

                    for (int i = 0; i < matrix.Count; ++i)
                    {
                        for (var j = i + 1; j < matrix.Count; ++j)
                        {
                            universe.CalculateGravitationalForce(matrix[i], matrix[j]);
                        }

                        RectangleF rect = new RectangleF(new PointF((float)matrix[i].getPosX(), (float)matrix[i].getPosY()), new Size(Convert.ToInt32(matrix[i].getRadius()), (int)matrix[i].getRadius()));
                        g.FillEllipse(System.Drawing.Brushes.Red, rect);
                        g.DrawEllipse(pen, rect);
                    }



                    universe.ApplyForceToBodies(matrix);

                    output = universe.WriteIterationBodies(output, matrix);

                    universe.ApplyColisionsToBodies(matrix);

                    universe.CleanForces(matrix);

                    await Task.Delay(250);

                    g.Clear(SystemColors.Control);
                }
            }
        }

    }
}
