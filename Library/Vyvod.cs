using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Controls;

namespace Library
{
    public class Vyvod
    {

        public void  r(ListBox LB,string a)
        {
            XDocument xmlDocument = XDocument.Load("play.xml");
            var name = xmlDocument.Element("settings")?
                .Elements("set")
                .FirstOrDefault(p => p.Element("name")?.Value == LB.SelectedItem.ToString()); ;
            if (name != null)
            {
                var bob = name.Element("pl");
                if (bob != null) bob.Value = $"{a}";


                xmlDocument.Save("play.xml");

            }
        }
    }
}
