using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace weatherApp
{
    public partial class NederlandKaart : Form
    {
        // Lijst van steden met hun geografische coördinaten
        private Dictionary<string, PointF> stadCoördinaten = new Dictionary<string, PointF>()
        {
            {"Amsterdam", new PointF(52.379189f, 4.899431f)},
            {"Rotterdam", new PointF(51.9225f, 4.4777f)},
            {"Lelystad", new PointF(52.5186f, 5.4714f)},
            {"Coevorden", new PointF(52.66f, 6.7406f)},
            {"Meppel", new PointF(52.695f, 6.1922f)},
            {"Steenwijk", new PointF(52.7862f, 6.1193f)},
            {"Lemmer", new PointF(52.846f, 5.7068f)},
            {"Stavoren", new PointF(52.8865f, 5.3628f)},
            {"Kampen", new PointF(52.555f, 5.9143f)},
            {"Zwolle", new PointF(52.5168f, 6.083f)},
            {"Raalte", new PointF(52.3844f, 6.275f)},
            {"Almelo", new PointF(52.3566f, 6.6621f)},
            {"Hengelo", new PointF(52.2653f, 6.7939f)},
            {"Enschede", new PointF(52.2215f, 6.8937f)},
            // Voeg hier de coördinaten van andere steden toe
        };

        private float schaalX = 93.89f;
        private float schaalY = 7.01f;
        private PointF oorsprong = new PointF(50.0f, 3.0f); // Linkeronderhoek als referentiepunt

        public NederlandKaart()
        {
            InitializeComponent();
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Converteer pixelwaarden naar geografische coördinaten
            float latitude = oorsprong.X + (e.Y / schaalY);
            float longitude = oorsprong.Y + (e.X / schaalX);

            string dichtstbijzijndeStad = VindDichtstbijzijndeStad(latitude, longitude);

            MessageBox.Show($"Je hebt geklikt op: {dichtstbijzijndeStad} (Lat: {latitude}, Long: {longitude})");
        }

        private string VindDichtstbijzijndeStad(float latitude, float longitude)
        {
            string dichtstbijzijndeStad = null;
            float kleinsteAfstand = float.MaxValue;

            foreach (var stad in stadCoördinaten)
            {
                float stadLatitude = stad.Value.X;
                float stadLongitude = stad.Value.Y;
                float afstand = BerekenAfstand(latitude, longitude, stadLatitude, stadLongitude);

                if (afstand < kleinsteAfstand)
                {
                    kleinsteAfstand = afstand;
                    dichtstbijzijndeStad = stad.Key;
                }
            }

            return dichtstbijzijndeStad;
        }

        private float BerekenAfstand(float lat1, float lon1, float lat2, float lon2)
        {
            return (float)Math.Sqrt(Math.Pow(lat1 - lat2, 2) + Math.Pow(lon1 - lon2, 2));
        }
    }
}
