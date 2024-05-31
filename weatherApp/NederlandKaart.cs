using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace weatherApp
{
    public partial class NederlandKaart : Form
    {
        // Lijst van steden met hun geografische coördinaten
        private Dictionary<string, Point> stadCoördinaten = new Dictionary<string, Point>()
        {
            {"Amsterdam", new Point((int)(52.379189 * 10), (int)(4.899431 * 10))},
            {"Rotterdam", new Point((int)(51.9225 * 10), (int)(4.4777 * 10))},
            {"Lelystad", new Point((int)(52.5186 * 10), (int)(5.4714 * 10))},
            {"Coevorden", new Point((int)(52.6600 * 10), (int)(6.7406 * 10))},
            {"Meppel", new Point((int)(52.6950 * 10), (int)(6.1922 * 10))},
            {"Steenwijk", new Point((int)(52.7862 * 10), (int)(6.1193 * 10))},
            {"Lemmer", new Point((int)(52.8460 * 10), (int)(5.7068 * 10))},
            {"Stavoren", new Point((int)(52.8865 * 10), (int)(5.3628 * 10))},
            {"Kampen", new Point((int)(52.5550 * 10), (int)(5.9143 * 10))},
            {"Zwolle", new Point((int)(52.5168 * 10), (int)(6.0830 * 10))},
            {"Raalte", new Point((int)(52.3844 * 10), (int)(6.2750 * 10))},
            {"Almelo", new Point((int)(52.3566 * 10), (int)(6.6621 * 10))},
            {"Hengelo", new Point((int)(52.2653 * 10), (int)(6.7939 * 10))},
            {"Enschede", new Point((int)(52.2215 * 10), (int)(6.8937 * 10))},
            // Voeg hier de coördinaten van andere steden toe
        };

        // Schaal van de afbeelding (pixels per graad)
        private const double SchaalX = 100.0 / 431.0; // pixels per graad lengtegraad
        private const double SchaalY = 100.0 / 600.0; // pixels per graad breedtegraad

        public NederlandKaart()
        {
            InitializeComponent();
            this.pictureBox1.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            // Converteer pixelcoördinaten naar geografische coördinaten
            double lon = ((x - pictureBox1.Width / 2) * SchaalX) / 10.0;
            double lat = ((pictureBox1.Height / 2 - y) * SchaalY) / 10.0;

            // Zoek de dichtstbijzijnde stad
            string dichtstbijzijndeStad = ZoekDichtstbijzijndeStad(new Point((int)(lat * 10), (int)(lon * 10)));

            // Toon een melding met de naam van de stad
            MessageBox.Show($"Je hebt {dichtstbijzijndeStad} aangeraakt! Coördinaten: ({lat}, {lon})");
        }

        // Methode om de dichtstbijzijnde stad te vinden op basis van de geografische coördinaten
        private string ZoekDichtstbijzijndeStad(Point coördinaten)
        {
            string dichtstbijzijndeStad = "";
            double minAfstand = double.MaxValue;

            foreach (var pair in stadCoördinaten)
            {
                double afstand = BerekenAfstand(coördinaten, pair.Value);
                if (afstand < minAfstand)
                {
                    minAfstand = afstand;
                    dichtstbijzijndeStad = pair.Key;
                }
            }

            return dichtstbijzijndeStad;
        }

        // Hulpmethode om graden naar radialen om te zetten
        private double ToRadians(double val)
        {
            return (Math.PI / 180.0) * val;
        }

        // Methode om de afstand tussen twee punten te berekenen met behulp van de Haversine-formule
        private double BerekenAfstand(Point punt1, Point punt2)
        {
            double lat1 = punt1.X / 10;
            double lon1 = punt1.Y / 10;
            double lat2 = punt2.X / 10;
            double lon2 = punt2.Y / 10;

            const double R = 6371; // Radius van de aarde in kilometers

            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            return distance;
        }
    }
}
