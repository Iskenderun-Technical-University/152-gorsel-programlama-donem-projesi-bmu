using hava_durumu1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace hava_durumu1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //https://api.openweathermap.org/data/2.5/weather?q=adana&mode=xml&lang=tr&units=metric&appid=646b4b6955adf41fcf779158706c39d8 kaynak site
        private void button1_Click(object sender, EventArgs e)
        {
            string api = "646b4b6955adf41fcf779158706c39d8";//apı mız
            string city = textBox1.Text;//sehri aldık
            try// gecersiz sehir girilirse diye kontrol
            {
                string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=tr&units=metric&appid=" + api;//siteye gittik
                XDocument weather = XDocument.Load(connection);//siteden verileri aldık
                var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;//burada sıcaklığı aldık
                var cloudy = weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;// burada hava durumunu aldık
                var humidity = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;//nem miktarını aldık
                var character = weather.Descendants("humidity").ElementAt(0).Attribute("unit").Value;//% işaretini aldık 

                string totally = character + humidity;
                label4.Text = totally;// nem mıktarını yazdık yazdırma işlemleri
                label3.Text = cloudy;//hava durumunu yazdırdık
                label2.Text = temp + "°C";//sıcaklık  mıktarını yazdırdık
                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                if (cloudy == "kapalı")
                {
                    var iconPath = Path.Combine(outPutDirectory, "resource\\cloudy.png");
                    string icon_path = new Uri(iconPath).LocalPath;
                    pictureBox1.Image = Image.FromFile(icon_path);
                    //pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\hava durumu 1.2\\hava durumu1\\resource\\cloudy.jpg");
                }
                if (cloudy == "açık")
                {
                    var iconPath = Path.Combine(outPutDirectory, "resource\\sunny.png");
                    string icon_path = new Uri(iconPath).LocalPath;
                    pictureBox1.Image = Image.FromFile(icon_path);
                    // pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\hava durumu 1.2\\hava durumu1\\resource\\sunny.jpg");
                }
                if (cloudy == "parçalı bulutlu" || cloudy == "az bulutlu")
                {
                    var iconPath = Path.Combine(outPutDirectory, "resource\\parialcloudy.png");
                    string icon_path = new Uri(iconPath).LocalPath;
                    pictureBox1.Image = Image.FromFile(icon_path);
                    //pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\hava durumu 1.2\\hava durumu1\\resource\\parialcloudy.png");
                }
                if (cloudy == "yağmurlu")
                {
                    var iconPath = Path.Combine(outPutDirectory, "resource\\rain.png");
                    string icon_path = new Uri(iconPath).LocalPath;
                    pictureBox1.Image = Image.FromFile(icon_path);
                    // pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\hava durumu 1.2\\hava durumu1\\resource\\rain.png");
                }
            }
            catch// gecersiz şehire yapılcak işlem 
            {
                MessageBox.Show("invalid city");
            }
        }
        private void Form3_Load(object sender, EventArgs e){ }
        private void label7_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
       
    }
}
