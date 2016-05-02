using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        string Temperature;
        string Condition;
        string Humidity;
        string Windspeed;
        string Town;
        string Region;
        string Country;
        string Code;
        string Local;
        string woeid;
        string LastUpdate;
        string[] next_day = new string[10];
        string[] next_cond = new string[10];
        string[] next_condt = new string[10];
        string[] next_high = new string[10];
        string[] next_low = new string[10];

        public Form1()
        {
            InitializeComponent();
            woeid = "CAXX2317";
            getWeather();
            label1.Text = Temperature;
            label2.Text = Town + ", " + Region;
            label6.Text = Condition;
            label7.Text = Humidity;
            label8.Text = Windspeed;
            label10.Text = string.Format("\u00B0") + "F";
            label12.Text = next_day[1];
            label15.Text = next_day[2];
            label17.Text = next_day[3];
            label19.Text = next_day[4];
            label20.Text = Country;
            label13.Text = next_condt[1];
            label14.Text = next_condt[2];
            label16.Text = next_condt[3];
            label18.Text = next_condt[4];

            label21.Text = next_high[1] + string.Format("\u00B0") + "F";
            label24.Text = next_high[2] + string.Format("\u00B0") + "F";
            label26.Text = next_high[3] + string.Format("\u00B0") + "F";
            label28.Text = next_high[4] + string.Format("\u00B0") + "F";
            label22.Text = next_low[1] + string.Format("\u00B0") + "F";
            label23.Text = next_low[2] + string.Format("\u00B0") + "F";
            label25.Text = next_low[3] + string.Format("\u00B0") + "F";
            label27.Text = next_low[4] + string.Format("\u00B0") + "F";
            setIcons();
            setIcon();

        }

        private void setIcons()
        {
            //pictureBox1.Image = Image.FromFile(getString(next_cond[1]));
            //pictureBox3.Image = Image.FromFile(getString(next_cond[2]));
            //pictureBox4.Image = Image.FromFile(getString(next_cond[3]));
            //pictureBox5.Image = Image.FromFile(getString(next_cond[4]));
        }

       // private string getString(string code)
        //{
            /*if (code.Equals("3200"))
            {
                return "../Pics/na.png";
            }
            else
            {
                return "../Pics/" + code + ".png";
            }
            */
      //  }

        private void setIcon()
        {
            if (Code.Equals("3200"))
            {
                pictureBox2.Image = Image.FromFile("../Pics/na.png");
            }
            else
            {
                string st = "../Pics/" + Code + ".png";
                //pictureBox2.Image = Image.FromFile(st);
            }
        }

        private void getWeather()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;

            //check each child of the parent element
            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == "city")
                {
                    Town = child.Attributes["name"].Value;
                }

                if (child.Name == "temperature")
                {
                    Temperature = child.Attributes["value"].Value;
                }

                if (child.Name == "wind")
                {
                    foreach (XmlNode grandchild in child.ChildNodes)
                    {
                        if (grandchild.Name == "speed")
                        {
                            Windspeed = grandchild.Attributes["name"].Value;
                        }
                    }
                }
                if (child.Name == "lastupdate")
                {
                    LastUpdate = child.Attributes["value"].Value;
                }
                if (child.Name == "weather")
                {
                    Code = child.Attributes["number"].Value;
                }
            }

            XmlDocument docForecast = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parentForecast;
            parent = doc.DocumentElement;

            //check each child of the parent element
            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == "forecast")
                {
                    foreach (XmlNode grandChild in child.ChildNodes)
                    {
                        foreach (XmlNode greatGrandChild in grandChild.ChildNodes)
                        {
                            if (greatGrandChild.Name == "temperature")
                            {
                                

                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
            getWeather();
            label1.Text = Temperature;
            label2.Text = Town + ", " + Region;
            label6.Text = Condition;
            label7.Text = Humidity;
            label8.Text = Windspeed;
            label10.Text = string.Format("\u00B0") + "F";
            label12.Text = next_day[1];
            label15.Text = next_day[2];
            label17.Text = next_day[3];
            label19.Text = next_day[4];
            label20.Text = Country;
            label13.Text = next_condt[1];
            label14.Text = next_condt[2];
            label16.Text = next_condt[3];
            label18.Text = next_condt[4];
            setIcons();
            setIcon();
        }
    }
}

