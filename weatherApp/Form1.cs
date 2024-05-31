using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace weatherApp
{
    public partial class Form1 : Form
    {
        // Lijst van steden met hun geografische coördinaten
        private Dictionary<string, Point> stadCoördinaten = new Dictionary<string, Point>()
        {
            {"Amsterdam", new Point((int)(52.379189), (int)(4.899431))},
            {"Rotterdam", new Point((int)(51.9225), (int)(4.4777))},
            {"Lelystad", new Point((int)(52.5186), (int)(5.4714))},
            {"Coevorden", new Point((int)(52.6600), (int)(6.7406))},
            {"Meppel", new Point((int)(52.6950), (int)(6.1922))},
            {"Steenwijk", new Point((int)(52.7862), (int)(6.1193))},
            {"Lemmer", new Point((int)(52.8460), (int)(5.7068))},
            {"Stavoren", new Point((int)(52.8865), (int)(5.3628))},
            {"Kampen", new Point((int)(52.5550), (int)(5.9143))},
            {"Zwolle", new Point((int)(52.5168), (int)(6.0830))},
            {"Raalte", new Point((int)(52.3844), (int)(6.2750))},
            {"Almelo", new Point((int)(52.3566), (int)(6.6621))},
            {"Hengelo", new Point((int)(52.2653), (int)(6.7939))},
            {"Enschede", new Point((int)(52.2215), (int)(6.8937))},
            // Voeg hier de coördinaten van andere steden toe
        };

        // Schalen voor de conversie
        public float XScale =(0.00698269f);
        public float YScale = (0.13281604f);

        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            float x = e.X;
            float y = e.Y;

            float xcordinaat = (x * XScale);
            float ycordinaat = (y * YScale);

            MessageBox.Show($"Muiscoördinaten: {x}, {y}\nGeografische coördinaten: {xcordinaat}, {ycordinaat}");
        }

        
    }
}
