using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weatherApp
{
    public partial class Form1 : Forms
    {
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MessageBox.Show($"{x}, {y}");
            double geschaaldeX = SchaalNaarLandKaart(x, 705, 52.3295182);
            double geschaaldeY = SchaalNaarLandKaart(y, 416, 4.9227935);

            MessageBox.Show($"Geschaalde x-coördinaat: {geschaaldeX}\nGeschaalde y-coördinaat: {geschaaldeY}");
        }

        private double SchaalNaarLandKaart(int waarde, int oorspronkelijkeMax, double landMapMax)
        {
            // Bepaal de juiste schalingsfactoren op basis van de voorbeelden die je hebt gegeven
            double minX = 787;
            double maxX = 941;
            double minY = 214;
            double maxY = 776;
            double landMapMinX = 52.4938392;
            double landMapMaxX = 53.241352;
            double landMapMinY = 5.4383556;
            double landMapMaxY = 6.5358827;

            // Schaal de waarde naar de landkaart voor zowel x als y coördinaten
            double geschaaldeX = landMapMinX + (waarde - minX) * (landMapMaxX - landMapMinX) / (maxX - minX);
            double geschaaldeY = landMapMinY + (waarde - minY) * (landMapMaxY - landMapMinY) / (maxY - minY);

            return geschaaldeX;
        }

    }
}