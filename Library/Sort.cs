using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Library
{
    public class Sort
    {
        public List<String> r(string a)
        {
            List<String> list = new List<String>();
            XDocument xdoc = XDocument.Load("play.xml");
            XElement root = xdoc.Element("settings");


            foreach (XElement el in root.Elements())
            {
                string name = el.Element($"{a}").Value;
                list.Add(name);
            }
            list=list.Distinct().ToList();
            return list;
        }
    }
}
