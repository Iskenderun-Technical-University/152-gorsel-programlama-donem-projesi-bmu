using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace hava_durumu1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //https://api.openweathermap.org/data/2.5/weather?q=adana&mode=xml&lang=tr&units=metric&appid=646b4b6955adf41fcf779158706c39d8
        private void button1_Click(object sender, EventArgs e)
        {
            string api = "646b4b6955adf41fcf779158706c39d8";
            string city=textBox1.Text;
            string connection = "https://api.openweathermap.org/data/2.5/weather?q="+city+"&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument weather=  XDocument.Load(connection);
            var temp=weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var cloudy=weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            var humidity=weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var character = weather.Descendants("humidity").ElementAt(0).Attribute("unit").Value;
            string totally = character + humidity;
            label4.Text=totally;
            label3.Text = cloudy;
            label2.Text = temp;
            // Image.FromFile("C:\\Users\\deneme\\Desktop\\cloudy.jpg");
               if (cloudy=="kapalı")
               {
                   pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\cloudy.jpg");
               }
               if (cloudy == "açık")
               {
                   pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\sunny.jpg");
               }
               if (cloudy == "parçalı bulutlu")
               {
                   pictureBox1.Image = Image.FromFile("C:\\Users\\deneme\\Desktop\\parialcloudy.png");
               }
            
        }
    }
}
