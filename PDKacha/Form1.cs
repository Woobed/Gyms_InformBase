using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDKacha.enums;
using PDKacha.enums.Extentions;
using PDKacha.MockFile;
using PDKacha.ImageDownloader;
using System.Linq;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using PDKacha.Geolocation;

namespace PDKacha
{
    public partial class Form1 : Form
    {
        double latcur;
        double loncur;
        GeoCalculator geoCalculator;
        List<Gym> GymArray;
        Size standartS = new Size(1029, 611);
        Size hidefilterSize = new Size(769,611);
        public Form1()
        {
            GymArray = new List<Gym>();
            InitializeComponent();
            
            RouteBuilder result = new RouteBuilder();
            var geolocation = result.GetGeolocation();
            MessageBox.Show("Для построения маршрута на вашем устройстве должен быть включен доступ к местоположению для приложений\n" +
                " (For Windows 11)\n \"Пуск\" -> \"Параметры\" -> \"Конфиденциальность и защита\" -> \"Службы определения местоположения\" ->" +
                "\"Разрешить приложениям получать доступ к расположению\"", "ВНИМАНИЕ");
            while (geolocation == null)
                {
                    geolocation = result.GetGeolocation();
                }

                latcur = geolocation.Latitude;
                loncur = geolocation.Longtitude;
            MessageBox.Show("Если доступ к местоположению недоступен, то приложение не будет запущено");
            this.Size = hidefilterSize;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            FromTime.SelectedIndex = -1;
            ToTime.SelectedIndex = -1;
            TrainingType.SelectedIndex = -1;
            Sorting.SelectedIndex = -1;
            flowLayoutPanel1.Controls.Clear(); 
            GymArray = Gym.createGymList();
            fillFlowLayoutPanel(GymArray);
        }


        private void button2_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            if (TrainingType.SelectedIndex>-1)
            {
                GymArray.RemoveAll(mock => !mock.trainingType.Contains(TrainingType.SelectedItem.ToString()));
            }

            if (FromTime.SelectedIndex > -1 && ToTime.SelectedIndex > -1)
            {
                
                string[] temp = FromTime.SelectedItem.ToString().Split(':');
                TimeSpan from = new TimeSpan(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]),0);
                temp = ToTime.SelectedItem.ToString().Split(':');
                TimeSpan to = new TimeSpan(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), 0);
                if (from > to)
                {
                    MessageBox.Show("Время указано неверно");
                    return;
                }
                GymArray.RemoveAll(mock => !(mock.WorkingBeginTime < from || mock.WorkingEndTime > to));
            }

            if (Sorting.SelectedIndex > -1)
            {
                if(Sorting.SelectedItem.ToString() == SortEnum.RatingIncrease.GetDescription())
                {
                    GymArray = GymArray.OrderBy(mock => mock.rating).ToList();
                }
                if(Sorting.SelectedItem.ToString() == SortEnum.RatingDecrease.GetDescription())
                {
                    GymArray = GymArray.OrderByDescending(mock => mock.rating).ToList();
                }
                if (Sorting.SelectedItem.ToString() == SortEnum.DistanceDecreace.GetDescription())
                {
                    GymArray = GymArray.OrderByDescending(mock => mock.route).ToList();
                }
                if (Sorting.SelectedItem.ToString() == SortEnum.DistanceIncreace.GetDescription())
                {
                    GymArray = GymArray.OrderBy(mock => mock.route).ToList();
                }
            }
            fillFlowLayoutPanel(GymArray);
        }

        private async void fillFlowLayoutPanel(List<Gym> mocks)
        {
            try
            {
                if (mocks.Count > 0)
                {
                    foreach (Gym mock in mocks)
                    {
                        Panel panel = new Panel();
                        Label gymName = new Label();
                        Label treningType = new Label();
                        Label ratingLabel = new Label();
                        Label roteLabel = new Label();
                        Button button = new Button();
                        PictureBox pictureBox = new PictureBox();
                        mock.route= Math.Round(GeoCalculator.CalculateDistance(latcur, loncur, Convert.ToDouble(mock.Contacts[4]), Convert.ToDouble(mock.Contacts[5])), 2);

                        //Panel
                        panel.Size = new Size(flowLayoutPanel1.Width - 10, 100);
                        panel.Tag = mock;

                        //Label gymName
                        gymName.Text = mock.gymName;
                        gymName.Location = new Point(pictureBox.Location.X + pictureBox.Width + 5, panel.Location.Y + 5);
                        gymName.Size = new Size(300, 30);

                        //rating
                        ratingLabel.Text = "Рейтинг: " + mock.rating;
                        ratingLabel.Location = new Point(gymName.Location.X + gymName.Width + 5, gymName.Location.Y + 5);
                        panel.Controls.Add(ratingLabel);

                        //Label treningType
                        for (int i = 0; i < mock.trainingType.Count; i++)
                        {
                            if (mock.trainingType.Count <= 3)
                            {
                                if (i != mock.trainingType.Count - 1)
                                {
                                    treningType.Text += mock.trainingType[i];
                                    treningType.Text += ", ";
                                }
                                else
                                {
                                    treningType.Text += mock.trainingType[i];
                                }

                            }
                            else
                            {
                                treningType.Text += mock.trainingType[i];
                                if (i == 2)
                                {
                                    treningType.Text += "...";
                                    break;
                                }
                                else
                                {
                                    treningType.Text += ", ";
                                }
                            }
                        }


                        treningType.Location = new Point(pictureBox.Location.X + pictureBox.Width + 5, panel.Location.Y + 40);
                        treningType.Size = new Size(200, 30);

                        //rote
                        roteLabel.Text = "Приблизительно "+ mock.route.ToString() + " км";
                        roteLabel.Location = new Point(treningType.Location.X,treningType.Location.Y+treningType.Height+5);
                        roteLabel.Width = 8 * roteLabel.Text.Length;
                        panel.Controls.Add(roteLabel);

                        //Button
                        button.Text = "Подробнее";
                        button.Click += new EventHandler(button_Click);
                        button.Size = new Size(90, 50);
                        button.Location = new Point(panel.Location.X + panel.Width - 100, panel.Location.Y + panel.Height - 70);
                        button.Tag = mock;

                        


                        //PictureBox
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Size = new Size(panel.Height - 10, panel.Height + 20);

                        Image image;
                        if (mock.imageURL.Count != 0)
                        {
                            image = await DownloadImage.LoadImageFromUrl(mock.imageURL[0]);
                            if (image != null)
                            {
                                pictureBox.Image = image;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не удалось загрузить изображение");
                        }


                        panel.Controls.Add(pictureBox);
                        panel.Controls.Add(gymName);
                        panel.Controls.Add(treningType);
                        panel.Controls.Add(button);
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
                else
                {
                    MessageBox.Show("Нет элементов удовлетворяющих фильтрам");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
        
        private void button_Click(object obj, EventArgs e)
        {
            try
            {
                Button button = obj as Button;
                Gym mock = (Gym)button.Tag;
                Form2 form2 = new Form2(mock);
                form2.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка приведения типов данных: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (SortEnum sortType in Enum.GetValues(typeof(SortEnum)))
            {
                Sorting.Items.Add(sortType.GetDescription());
            }
            for (int hour=0;hour<24; hour++)
            {
                for (int minute=0;minute<60; minute+=30)
                {
                    TimeSpan temp = new TimeSpan(hour, minute,0);
                    FromTime.Items.Add(temp.ToString("hh\\:mm"));
                    ToTime.Items.Add(temp.ToString("hh\\:mm"));
                }
            }
            foreach (TrainingEnum training in Enum.GetValues(typeof(TrainingEnum)))
            {
                TrainingType.Items.Add(training.GetDescription());
            }
            GymArray = Gym.createGymList();
            fillFlowLayoutPanel(GymArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.Size == standartS)
            {
                this.Size = hidefilterSize;
                return;
            }
            if (this.Size == hidefilterSize)
            {
                this.Size = standartS;
                return;

            }
        }
    }
}
