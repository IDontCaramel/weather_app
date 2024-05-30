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
    public partial class Form1 : Form
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

            double geschaaldeX = SchaalNaarLandKaart(x, 705, 52.3295182);
            double geschaaldeY = SchaalNaarLandKaart(y, 416, 4.9227935);

            MessageBox.Show($"Geschaalde x-coördinaat: {geschaaldeX}\nGeschaalde y-coördinaat: {geschaaldeY}");
        }

        private double SchaalNaarLandKaart(int waarde, int oorspronkelijkeMax, double landMapMax)
        {
            double oorspronkelijkeBereik = oorspronkelijkeMax - 0; // Minimumwaarde is altijd 0 voor de PictureBox
            double landMapBereik = landMapMax - 0;

            // Schaal de waarde naar de landkaart
            double geschaaldeWaarde = (waarde * landMapBereik) / oorspronkelijkeBereik;

            return geschaaldeWaarde;
        }
    }
}