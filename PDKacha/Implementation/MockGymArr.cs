using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDKacha.enums;
using PDKacha.enums.Extentions;

using PDKacha.Interfaces;
using static System.Net.WebRequestMethods;

namespace PDKacha.MockFile
{
    public class Gym
    {
        public double route { get; set; }
        public int IdGym { get; set; }
        public string gymName { get; set; }
        public TimeSpan WorkingBeginTime { get; set; }
        public TimeSpan WorkingEndTime { get; set; }
        public List<string> trainingType { get; set; }
        public List<string> priceList { get; set; }
        public List<string> Contacts { get; set; }
        public bool AdminAdded { get; set; }
        public int rating { get; set; }
        public int NumberReviews { get; set; }
        public List<string> imageURL { get; set; }

        



        public static List<Gym>createGymList()
        {
            SqlConnection connec = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter adapter;
            SqlCommand cmd;
            connec.Open();
            DataTable dt_gym = new DataTable();
            DataTable dt_contact = new DataTable();
            DataTable dt_image = new DataTable();
            DataTable dt_pricelist_raw = new DataTable();
            adapter = new SqlDataAdapter("select * from Gym", connec);
            adapter.Fill(dt_gym);
            adapter = new SqlDataAdapter("select * from PriceList", connec);
            adapter.Fill(dt_pricelist_raw);
            adapter = new SqlDataAdapter("select * from Image", connec);
            adapter.Fill(dt_image);
            adapter = new SqlDataAdapter("select * from Contact", connec);
            adapter.Fill(dt_contact);
            connec.Close();
            DataTable dt_pricelist = EncodeUnicode(dt_pricelist_raw);

            List<Gym> gyms = CreateObjFull(dt_gym, dt_contact, dt_image, dt_pricelist);

            return gyms;
        }

        private static List<Gym> CreateObjFull(DataTable dt_gym, DataTable dt_contact, DataTable dt_image, DataTable dt_pricelist)
        {

            List<Gym> gyms = new List<Gym>();


            int MaxGymId = Convert.ToInt32(dt_gym.Compute("MAX(IdGym)", ""));

            for (int i = 1; i < MaxGymId; i++)
            {

                Gym gym = new Gym();

                DataRow[] result = dt_gym.Select("IdGym = '" + i + "'");
                gym.IdGym = i;
                gym.gymName = result[0][0].ToString();
                string[] temp = result[0][1].ToString().Split(':');
                gym.WorkingBeginTime = new TimeSpan(Convert.ToInt32(temp[0]), (Convert.ToInt32(temp[1])), 0);
                temp = result[0][2].ToString().Split(':');
                gym.WorkingEndTime = new TimeSpan(Convert.ToInt32(temp[0]), (Convert.ToInt32(temp[1])), 0);
                gym.trainingType = new List<string>(result[0][3].ToString().Split(',').Select(s => s.Trim()));
                gym.priceList = CreateListFromPricelist(result[0][4].ToString(), dt_pricelist);
                gym.Contacts = CreateListFromJSONContacts(result[0][5].ToString(), dt_contact);
                gym.AdminAdded = Convert.ToBoolean(result[0][6]);
                gym.rating = Convert.ToInt32(result[0][7]);
                gym.NumberReviews = Convert.ToInt32(result[0][8]);

                gym.imageURL = CreateListFromJSONImages(i.ToString(), dt_image);

                gyms.Add(gym);
            }

            return gyms;

        }
        private static List<string> CreateListFromPricelist(string id, DataTable dt)
        {
            List<string> list = new List<string>();

            DataRow[] result = dt.Select("IDPriceList = " + id);

            string[] keks = result[0][0].ToString().Split(',');

            List<string[]> keks1 = new List<string[]>();

            List<string> k_fin = new List<string>();

            foreach (string kek in keks)
            {
                string[] t = kek.Split(new string[] { "Цена" }, StringSplitOptions.None);
                for (int i = 0; i < t.Length; i++)
                {
                    k_fin.Add(t[i]);
                }
            }


            for (int i = 0; i < k_fin.Count; i++)
            {
                string k = k_fin[i];
                /* if (i % 2 == 0)
                 {
                     k_fin[i] = k_fin[i].Split(':')[1].Replace(';', ' ').Replace('"', ' ');
                 } else
                 {
                     k_fin[i] = k_fin[i].Replace("\\n\\r", " ").Replace("}", string.Empty).Replace('"', ' ');
                     System.Console.WriteLine(k_fin[i]);
                 }*/
                list.Add(k);
            }




            return list;
        }
        private static List<string> CreateListFromJSONImages(string id, DataTable dt)
        {
            List<string> list = new List<string>();



            DataRow[] result = dt.Select("GymID = " + id);

            for (int i = 0; i < result.Length - 1; i++)
            {
                list.Add(result[i][0].ToString());
            }

            return list;
        }
        private static List<string> CreateListFromJSONContacts(string id, DataTable dt)
        {
            List<string> list = new List<string>();

            DataRow[] result = dt.Select("IdContact = '" + id + "'");

            for (int i = 0; i < 6; i++)
            {
                list.Add(result[0][i].ToString());
            }

            return list;
        }
        private static DataTable EncodeUnicode(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (row[col] != null && row[col] != DBNull.Value)
                    {
                        string cellValue = row[col].ToString();
                        cellValue = System.Text.RegularExpressions.Regex.Unescape(cellValue);
                        row[col] = cellValue;
                    }
                }
            }

            return dt;
        }




        /*public string gymName { get; set; }
        public List<string> trainingType {  get; set; }

        public List<string> imageURL;

        public string phoneNumber { get; set; }
        public string phoneNumberRes { get; set; }
        public string webLinc {  get; set; }
        public string workingStartTime { get; set; }
        public string workingEndTime { get; set; }
        public string address { get; set; }

        public List <string> priceList{ get; set; }
        public int rating { get; set; }
        
        public static List<Mock> returnMockGymArr()
        {

            List<Mock> mocks = new List<Mock>
            {
                new Mock {gymName = "туда сюда качок",
                    trainingType = new List<string>{TrainingEnum.Group.GetDescription(),TrainingEnum.PublicGym.GetDescription(),TrainingEnum.Fighting.GetDescription()},
                    imageURL = new List<string> { "https://gas-kvas.com/grafic/uploads/posts/2023-09/1695826313_gas-kvas-com-p-kartinki-s-kotikami-1.jpg", "https://gas-kvas.com/grafic/uploads/posts/2023-09/1695931386_gas-kvas-com-p-kartinki-s-kotami-18.jpg", "https://haipovo.ru/wp-content/uploads/2021/06/44.jpg" },
                    phoneNumber = "",
                    phoneNumberRes = "-",
                    webLinc = "https://mail.ru/",
                    rating = 5,
                    workingStartTime = "8.00",
                    workingEndTime = "23.20",
                    priceList = new List<string>{"Разовое посещение", "200", "Месячный абонемент", "2000", "Годовой абонемент","20000", "Тренировки с тренером (8 шт)", "3000" },
                    address = "Улица Пушкина, д. Колотушкина"
                    },
                    
                new Mock {gymName = "Juk c ruсhkoj",
                    trainingType = new List<string>{TrainingEnum.Fighting.GetDescription(),TrainingEnum.PublicGym.GetDescription(),},
                    imageURL = new List<string>{ "https://gas-kvas.com/grafic/uploads/posts/2023-09/1695826323_gas-kvas-com-p-kartinki-s-kotikami-31.jpg" },
                    phoneNumber = "444444",
                    phoneNumberRes = "-",
                    workingStartTime = "8.00",
                    workingEndTime = "23.20",
                    priceList = new List<string>{"Разовое посещение", "200", "Месячный абонемент", "2000", "Годовой абонемент","20000", "Тренировки с тренером (8 шт)", "3000" },
                    webLinc = "https://hsreplay.net",
                    address = "Улица Лермонтова, д. 123",
                    rating = 5,
                },
                new Mock {gymName = "Алаберды",
                    trainingType = new List<string>{TrainingEnum.Pool.GetDescription(), },
                    imageURL = new List<string>{ "https://www.w-dog.ru/wallpapers/4/14/355619619236524/ryzhij-kotik-oblizyvaet-lapku.jpg" },
                    phoneNumber = "11111111",
                    phoneNumberRes = "-",
                    webLinc = "https://anixart.net"
                },
                new Mock {gymName = "Барабиджон fitness",
                    trainingType = new List<string>{TrainingEnum.Yoga.GetDescription(),},
                    imageURL = new List<string>{ "https://gas-kvas.com/grafic/uploads/posts/2023-09/1695826322_gas-kvas-com-p-kartinki-s-kotikami-27.jpg" },
                    phoneNumber = "2222222",
                    phoneNumberRes = "-",
                    webLinc = "https://jut.su"
                },
                new Mock {gymName = "Максим fit",
                    trainingType = new List<string>{TrainingEnum.Pool.GetDescription(),},
                    imageURL = new List<string>{ "https://wdorogu.ru/images/wp-content/uploads/2020/10/f1fda080713507f02387.jpg" },
                    phoneNumber = "3333333",
                    phoneNumberRes = "88888",
                    webLinc = "https://vk.com"
                },
            };
            return mocks;
        }*/
    }


}
