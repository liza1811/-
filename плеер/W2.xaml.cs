using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Xml;

namespace плеер
{
    /// <summary>
    /// Логика взаимодействия для W2.xaml
    /// </summary>
    public partial class W2 : Page
    {
        public W2()
        {
            InitializeComponent();
            c();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string put;


            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                put = file.FileName;
                t_put1.Text = put.Replace(@"\", @"\\");
            }
        }
        public void c()
        {
            var elements = XElement.Load("play.xml");
            data.DataContext = elements;
            MainWindo vf = new MainWindo();
            string color = Convert.ToString(vf.Background);
            if (color == "#FFF5DEB3")
            {
                w2.Background = Brushes.Wheat;
                t_naz.Background = Brushes.LightCoral;
                t_nazT.Background = Brushes.LightCoral;
                t_name1.Background = Brushes.LightCoral;
                t_put1.Background = Brushes.LightCoral;
                t_putT.Background = Brushes.LightCoral;
                t_janr1.Background = Brushes.LightCoral;
                t_janrT.Background = Brushes.LightCoral;
                t_isp1.Background = Brushes.LightCoral;
                t_ispT.Background = Brushes.LightCoral;
                t_year1.Background = Brushes.LightCoral;
                t_yearT.Background = Brushes.LightCoral;
                t_dell.Background = Brushes.LightCoral;
                b1.Background = Brushes.Wheat;
                b2.Background = Brushes.Wheat;
                b3.Background = Brushes.Wheat;
                data.Background = Brushes.Wheat;


            }
            if (color == "#FF696969")
            {
                w2.Background = Brushes.DimGray;
                t_naz.Background = Brushes.DarkGray;
                t_nazT.Background = Brushes.DarkGray;
                t_name1.Background = Brushes.DarkGray;
                t_put1.Background = Brushes.DarkGray;
                t_putT.Background = Brushes.DarkGray;
                t_janr1.Background = Brushes.DarkGray;
                t_janrT.Background = Brushes.DarkGray;
                t_isp1.Background = Brushes.DarkGray;
                t_ispT.Background = Brushes.DarkGray;
                t_year1.Background = Brushes.DarkGray;
                t_yearT.Background = Brushes.DarkGray;
                t_dell.Background = Brushes.DarkGray;
                b1.Background = Brushes.DimGray;
                b2.Background = Brushes.DimGray;
                b3.Background = Brushes.DimGray;
                data.Background = Brushes.DimGray;

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(t_janr1.Text!=""&& t_put1.Text!="" && t_name1.Text != "" && t_isp1.Text != "" && t_year1.Text != "")
            {
                try
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("play.xml");
                    XmlElement xRoot = xmlDocument.DocumentElement;
                    XmlElement personE = xmlDocument.CreateElement("set");

                    XmlElement nameE = xmlDocument.CreateElement("name");
                    XmlElement exitorE = xmlDocument.CreateElement("Exitor");
                    XmlElement yearE = xmlDocument.CreateElement("year");
                    XmlElement genreE = xmlDocument.CreateElement("genre");
                    XmlElement putE = xmlDocument.CreateElement("put");
                    XmlElement pl = xmlDocument.CreateElement("pl");
                    XmlText genreT = xmlDocument.CreateTextNode(t_janr1.Text);
                    XmlText putT = xmlDocument.CreateTextNode(t_put1.Text);
                    XmlText nameT = xmlDocument.CreateTextNode(t_name1.Text);
                    XmlText exitorT = xmlDocument.CreateTextNode(t_isp1.Text);
                    XmlText yearT = xmlDocument.CreateTextNode(t_year1.Text);
                    XmlText lT = xmlDocument.CreateTextNode("");


                    nameE.AppendChild(nameT);
                    exitorE.AppendChild(exitorT);
                    yearE.AppendChild(yearT);
                    genreE.AppendChild(genreT);
                    putE.AppendChild(putT);
                    pl.AppendChild(lT);
                    personE.AppendChild(genreE);
                    personE.AppendChild(putE);
                    personE.AppendChild(nameE);
                    personE.AppendChild(exitorE);
                    personE.AppendChild(yearE);
                    personE.AppendChild(pl);

                    xRoot.AppendChild(personE);
                    xmlDocument.Save("play.xml");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
            c();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                XDocument xmlDocument = XDocument.Load("play.xml");
                var name = xmlDocument.Element("settings")?
                    .Elements("set")
                    .FirstOrDefault(p => p.Element("name")?.Value == t_naz.Text); ;
                if (name != null)
                {
                    var bob = name.Element("name");
                    if (bob != null) t_nazT.Text= bob.Value;
                    var age = name.Element("year");
                    if (age != null)  t_yearT.Text= age.Value ;
                    var company = name.Element("genre");
                    if (company != null)  t_janrT.Text= company.Value ;
                    var isp = name.Element("genre");
                    if (isp != null)  t_ispT.Text =isp.Value ;
                    var put = name.Element("put");
                    if (put != null)  t_putT.Text= put.Value;


                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            c();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                XDocument xmlDocument = XDocument.Load("play.xml");
                var name = xmlDocument.Element("settings")?
                    .Elements("set")
                    .FirstOrDefault(p => p.Element("name")?.Value == t_naz.Text); ;
                if (name != null)
                {
                    var bob = name.Element("name");
                    if (bob != null) bob.Value = t_nazT.Text;
                    var age = name.Element("year");
                    if (age != null) age.Value = t_yearT.Text;
                    var company = name.Element("genre");
                    if (company != null) company.Value = t_janrT.Text;
                    var isp = name.Element("genre");
                    if (isp != null) isp.Value = t_ispT.Text;
                    var put = name.Element("put");
                    if (put != null) put.Value= t_putT.Text ;

                    xmlDocument.Save("play.xml");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            c();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                XDocument xmlDocument = XDocument.Load("play.xml");
                XElement root = xmlDocument.Element("settings");
                if (root != null)
                {
                    var bob = root.Elements("set").FirstOrDefault(p => p.Element("name").Value == t_dell.Text);


                    if (bob != null)
                    {
                        bob.Remove();
                        xmlDocument.Save("play.xml");
                    }
                }
                c();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            c();

        }
    }
    }


