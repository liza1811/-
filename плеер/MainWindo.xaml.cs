using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Media;
using Library;

namespace плеер
{
    /// <summary>
    /// Логика взаимодействия для MainWindo.xaml
    /// </summary>
    public partial class MainWindo : Page
    {
        SoundPlayer player;
        Vyvod v = new Vyvod();
        Sort sort = new Sort();
        public MainWindo()
        {
           
            InitializeComponent();
            
          
            string year = "year";
                string Exitor = "Exitor";
                string genre = "genre";
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("play.xml");
                List<String> list = new List<String>();
                list = sort.r(year);

                List<String> list1 = new List<String>();
                list1 = sort.r(Exitor);

                List<String> list2 = new List<String>();
                list2 = sort.r(genre);

                foreach (var name in list)
                {
                    cb1.Items.Add(name);
                }
                foreach (var name in list1)
                {
                    cb2.Items.Add(name);
                }
                foreach (var name in list2)
                {
                    cb3.Items.Add(name);
                }
            XDocument xdoc = XDocument.Load("set.xml");
            var Zadat = xdoc.Element("settings")?
          .Elements("seto")
          .FirstOrDefault(p => p.Attribute("name")?.Value == "baz");



            //var Top = Zadat.Element("top");
            //Application.Current.MainWindow.Top = Convert.ToDouble(Top.Value);

            //var Left = Zadat.Element("left");
            //Application.Current.MainWindow.Left = Convert.ToDouble(Left.Value);


            var color = Zadat.Element("color");
            if (color.Value == "#FFF5DEB3")
            {
                Wind.Background = Brushes.Wheat;
                b2.Background = Brushes.Wheat;
                bt1.Background = Brushes.LightCoral;
                bt2.Background = Brushes.LightCoral;
                bt3.Background = Brushes.LightCoral;
                bt4.Background = Brushes.LightCoral;
                bt5.Background = Brushes.LightCoral;
                bt6.Background = Brushes.LightCoral;


            }
            if (color.Value == "#FF696969")
            {
                b2.Background = Brushes.DimGray;
                Wind.Background = Brushes.DimGray;
                bt1.Background = Brushes.DarkGray;
                bt2.Background = Brushes.DarkGray;
                bt3.Background = Brushes.DarkGray;
                bt4.Background = Brushes.DarkGray;
                bt5.Background = Brushes.DarkGray;
                bt6.Background = Brushes.DarkGray;

            }

        }
        
   
        private void Button_Click(object sender, RoutedEventArgs e)
            {
                lb.Items.Clear();

                XDocument xdoc = XDocument.Load("play.xml");
                XElement root = xdoc.Element("settings");


                foreach (XElement el in root.Elements())
                {
                    if (cb1.SelectedItem == null && cb2.SelectedItem == null && cb3.SelectedItem == null)
                    {
                        string name = el.Element("name").Value;
                        lb.Items.Add(name);
                    }
                    else if (cb1.SelectedItem != null && cb2.SelectedItem != null && cb3.SelectedItem == null)
                    {
                        if (el.Element("year").Value == cb1.Text && el.Element("Exitor").Value == cb2.Text)
                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }
                    else if (cb1.SelectedItem != null && cb2.SelectedItem == null && cb3.SelectedItem != null)
                    {
                        if (el.Element("genre").Value == cb3.Text && el.Element("year").Value == cb1.Text)
                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }
                    else if (cb1.SelectedItem == null && cb2.SelectedItem != null && cb3.SelectedItem != null)
                    {
                        if (el.Element("genre").Value == cb3.Text && el.Element("Exitor").Value == cb2.Text)
                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }
                    else if (cb1.SelectedItem != null && cb2.SelectedItem == null && cb3.SelectedItem == null)
                    {
                        if (el.Element("year").Value == cb1.Text)

                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }
                    else if (cb1.SelectedItem == null && cb2.SelectedItem != null && cb3.SelectedItem == null)
                    {
                        if (el.Element("Exitor").Value == cb2.Text)

                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }
                    else if (cb1.SelectedItem == null && cb2.SelectedItem == null && cb3.SelectedItem != null)
                    {
                        if (el.Element("genre").Value == cb3.Text)

                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }
                    else
                    {
                        if (el.Element("genre").Value == cb3.Text && el.Element("year").Value == cb1.Text && el.Element("Exitor").Value == cb2.Text)
                        {
                            string name = el.Element("name").Value;
                            lb.Items.Add(name);
                        }
                    }


                }


            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
            try
            {
                if (lb.SelectedItems.Count != 0)
                {
                    XDocument xdoc = XDocument.Load("play.xml");
                    var Unit = xdoc.Element("settings")?
                            .Elements("set")
                                .FirstOrDefault(p => p.Element("name")?.Value == lb.SelectedItem.ToString());
                    var put = Unit?.Element("put")?.Value;
                    var l = System.IO.Path.GetFullPath($@"{put}");
                    player = new SoundPlayer(l);
                    player.Play();
                }
                else
                {
                    MessageBox.Show("Выберите песню для воспроизведения");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"(расширение должно быть .wav)");
            }
            }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
            
            try
            {
                if (lb.SelectedItems.Count != 0)
                {
                    player.Stop();
                }
                else
                {
                    MessageBox.Show("Песня не выбрана");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

            private void Button_Click_3(object sender, RoutedEventArgs e)
            {

                if (lb.SelectedItems.Count != 0)
                {
                    string a = "+";
                    v.r(lb, a);
                }
                else
                {
                    MessageBox.Show("Выберите песню для добавления в плейлист");
                }
            }

            private void Button_Click_4(object sender, RoutedEventArgs e)
            {

                if (lb.SelectedItems.Count != 0)
                {
                    string a = "";
                    v.r(lb, a);
                }
                else
                {
                    MessageBox.Show("Выберите песню для удаления из плейлиста");
                }
                c();
            }
            public void c()
            {
                lb.Items.Clear();


                XDocument xdoc = XDocument.Load("play.xml");
                XElement root = xdoc.Element("settings");

                foreach (XElement el in root.Elements())
                {
                    if (el.Element("pl").Value == "+")
                    {
                        string name = el.Element("name").Value;
                        lb.Items.Add(name);
                    }
                   
                }
            }

            private void Button_Click_5(object sender, RoutedEventArgs e)
            {
                c();
            }

            private void Button_Click_6(object sender, RoutedEventArgs e)
            {


                W2 page = new W2();

                this.NavigationService.Navigate(page);


            }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Wind.Background = Brushes.DimGray;
            b2.Background = Brushes.DimGray;
            bt1.Background = Brushes.DarkGray;
            bt2.Background = Brushes.DarkGray;
            bt3.Background = Brushes.DarkGray;
            bt4.Background = Brushes.DarkGray;
            bt5.Background = Brushes.DarkGray;
            bt6.Background = Brushes.DarkGray;
           
            XDocument xdoc = XDocument.Load("set.xml");
            var Zapis = xdoc.Element("settings")?
                .Elements("seto")
                .FirstOrDefault(p => p.Attribute("name")?.Value == "baz");

            w1 page1 = new w1();
            page1.Background = Brushes.DimGray;
            


            var color = Zapis.Element("color");
            color.Value = Convert.ToString(Wind.Background);

            xdoc.Save("set.xml");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Wind.Background = Brushes.Wheat;
            b2.Background = Brushes.Wheat;
            bt1.Background = Brushes.LightCoral;
            bt2.Background = Brushes.LightCoral;
            bt3.Background = Brushes.LightCoral;
            bt4.Background = Brushes.LightCoral;
            bt5.Background = Brushes.LightCoral;
            bt6.Background = Brushes.LightCoral;
            
            XDocument xdoc = XDocument.Load("set.xml");
            var Zapis = xdoc.Element("settings")?
                .Elements("seto")
                .FirstOrDefault(p => p.Attribute("name")?.Value == "baz");


            var Top = Zapis.Element("top");
            Top.Value = Convert.ToString(Application.Current.MainWindow.Top);
            var Left = Zapis.Element("left");
            Left.Value = Convert.ToString(Application.Current.MainWindow.Left);
            var color = Zapis.Element("color");
            color.Value = Convert.ToString(Wind.Background);
            xdoc.Save("set.xml");
        }
    }
    }