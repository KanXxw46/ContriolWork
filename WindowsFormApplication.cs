using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Navigation;

namespace ControlWork
{
    public class WindowsFormApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                String url = "http://api.openweathermap.org/data/2.5/forecast?id=524901&APPID={YOUR API KEY}";

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse =
                    (HttpWebResponse)myHttpWebRequest.GetResponse();
                StreamReader myStreamReader = new
                StreamReader(myHttpWebResponse.GetResponseStream());

                String html = myStreamReader.ReadToEnd();


                String pattern = "Температура:</h2>(.*)&deg;C";
                Match match = Regex.Match(html, pattern);

                label1.Text = "В Москве +2 градуса, прохладно";
            }
        }
    }

    public class Form
    {

    }
}
