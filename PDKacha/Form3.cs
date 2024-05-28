using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDKacha
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lat = "51.648627";
            string lon = "39.190235";
            string latitude = "51.648627";
            string longitude = "39.1876601";

            string googleMapsUrl = $"https://www.google.com/maps/place/51°38'55.1\"N+39°11'24.9\"E/@{latitude},{longitude},17z/data=!3m1!4b1!4m4!3m3!8m2!3d{latitude}!4d{longitude}?entry=ttu";

            // Кодируем URL
            string encodedUrl = Uri.EscapeUriString(googleMapsUrl);
            try
            {
                webBrowser1.Navigate(encodedUrl);
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
            }

        }
    }
}
