using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDKacha.MockFile;
using PDKacha.ImageDownloader;
using System.Diagnostics;
using PDKacha.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using PDKacha.Geolocation;

namespace PDKacha
{
    public partial class Form2 : Form
    {
        

        private Gym currentGym;
        private RouteBuilder rb = new RouteBuilder();
        private int currentImageIndex;
        private List<Image> image = new List<Image>();
        private Label gymName = new Label();
        private Label phoneNumber = new Label();
        private Label reservPhoneNumber = new Label();
        private Label address = new Label();
        private Label workingTime = new Label();
        private Label rating = new Label();
        private List<string> treningTypes = new List<string>();
        private LinkLabel linkLabel = new LinkLabel();
        private LinkLabel routeLinkLabel = new LinkLabel();
        private DataTable priceListDT = new DataTable();
        private DataGridView priceList = new DataGridView();
        private double lon;
        private double lat;
        
        public Form2(Gym mock)
        {
            InitializeComponent();
            this.currentGym = mock;
            this.currentImageIndex = 0;

            this.gymName.Text=mock.gymName;
            this.phoneNumber.Text = mock.Contacts[0];
            this.reservPhoneNumber.Text = mock.Contacts[1];
            this.address.Text = mock.Contacts[3];
            this.lon = Convert.ToDouble(mock.Contacts[4]);
            this.lat = Convert.ToDouble(mock.Contacts[5]);

            this.treningTypes = mock.trainingType;

            /*priceListDT.Columns.Add("Название услуги");
            priceListDT.Columns.Add("Цена");
            
            for (int i = 0; i < mock.priceList.Count; i+=2)
            {
                DataRow row = priceListDT.NewRow();
                row["Название услуги"] = mock.priceList[i];
                row["Цена"] = mock.priceList[i + 1];
                this.priceListDT.Rows.Add(row);
            }
            priceList.DataSource = priceListDT;*/

            this.workingTime.Text = "c: " + mock.WorkingBeginTime.ToString("hh\\:mm") + " до: " + mock.WorkingEndTime.ToString("hh\\:mm");
            this.rating.Text = mock.rating.ToString();
            addAndFillPanel();

        } 
        private void addAndFillPanel()
        {

            //linkLabel
            this.linkLabel.Text = "Перейти на сайт";
            this.linkLabel.Location = new Point(panel2.Width-20-linkLabel.Width,50);
            this.linkLabel.Click += new EventHandler(Label_Click);
            this.linkLabel.Width = 8 * this.linkLabel.Text.Length;

            panel2.Controls.Add(linkLabel);

            // routeLinkLabel
            this.routeLinkLabel.Text = "Посторить маршрут";
            this.routeLinkLabel.Location = new Point(linkLabel.Location.X,linkLabel.Location.Y+5 + linkLabel.Height);
            this.routeLinkLabel.Click += new EventHandler(Create_Route_Click);
            this.routeLinkLabel.Width = 8 * this.routeLinkLabel.Text.Length;

            panel2.Controls.Add(routeLinkLabel);

            // GymName
            gymName.Width = 25 * gymName.Text.Length;
            gymName.Height = 35;
            gymName.Location = new Point(5, 5);
            gymName.Font = new Font(gymName.Font.FontFamily, 16);
            panel2.Controls.Add(gymName);

            

            //workingTime
            Label labelworkingTime = new Label();
            labelworkingTime.Text = "Время работы:";
            labelworkingTime.Width = 7 * labelworkingTime.Text.Length;
            labelworkingTime.Location = new Point(gymName.Location.X, +gymName.Location.Y + gymName.Height + 5);
            panel2.Controls.Add(labelworkingTime);

            workingTime.Location = new Point(labelworkingTime.Location.X + labelworkingTime.Width+3, labelworkingTime.Location.Y);
            panel2.Controls.Add(workingTime);

            //treningTypes
            Label labelTraining = new Label();
            labelTraining.Text = "Типы тренировок:";
            labelTraining.Location = new Point(labelworkingTime.Location.X, workingTime.Location.Y + workingTime.Height + 15);
            panel2.Controls.Add(labelTraining);

            Point lastTTLocation = new Point();
            lastTTLocation = labelTraining.Location;

            foreach (string tt in treningTypes)
            {
                Label trainingT = new Label();
                trainingT.Text = tt;
                trainingT.Width = 8 * trainingT.Text.Length;
                lastTTLocation.Y += 5 + trainingT.Height;
                trainingT.Location = lastTTLocation;
                panel2.Controls.Add(trainingT);
                
            }

            //PriceList
            Label labelPrice = new Label();
            labelPrice.Text = "C ценами можете ознакомиться на официальном сайте";
            labelPrice.Location = new Point(lastTTLocation.X, lastTTLocation.Y + 5 + labelTraining.Height);
            labelPrice.Width = 8 * labelPrice.Text.Length;
            panel2.Controls.Add(labelPrice);

            /*priceList.Location = new Point(labelPrice.Location.X, labelPrice.Location.Y + labelPrice.Height+5);
            priceList.Height = priceList.RowCount*8;
            priceList.Width = panel2.Width;
            panel2.Controls.Add(priceList);*/


            //phoneNumber
            phoneNumber.Location = new Point();

            //reservPhoneNumber
            reservPhoneNumber.Location = new Point();

            //address
            address.Location = new Point();

            //rating
            rating.Location = new Point();

            

            

            this.Controls.Add(panel2);
            
            
            
            
        }
        private async void Form2_Load(object sender, EventArgs e)
        {
            //pictureBox
            try
            {
                for (int i = 0; i < currentGym.imageURL.Count; i++)
                {
                    image.Add(await DownloadImage.LoadImageFromUrl(currentGym.imageURL[i]));
                }
                this.pictureBox1.Image = image[0];
                this.currentImageIndex = 0;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void Label_Click(object sender, EventArgs e)
        {
            Process.Start(currentGym.Contacts[2]);
        }

        private async void Create_Route_Click(object sender, EventArgs e)
        {
            var pogu = new RouteBuilder();
            RouteBuilder result = null;
            await Task.Run(() => { 
            while (result == null)
            {
                result =  pogu.GetGeolocation();
            }
            string startLat = result.Longtitude.ToString();
            string startLng = result.Latitude.ToString();

            string url = $"https://www.google.com/maps/dir/{startLng.Replace(',', '.')},{startLat.Replace(',', '.')}/{this.lon.ToString().Replace(',', '.')},{this.lat.ToString().Replace(',', '.')}";

            Process.Start(url);
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.currentImageIndex--;
            if (this.currentImageIndex < 0)
            {
                this.currentImageIndex = image.Count - 1;
            }
            pictureBox1.Image = image[this.currentImageIndex];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.currentImageIndex++;
            if (this.currentImageIndex >= image.Count)
            {
                this.currentImageIndex = 0;
            }
            this.pictureBox1.Image = image[this.currentImageIndex];
        }

        
    }
}
