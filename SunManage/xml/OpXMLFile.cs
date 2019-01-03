using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SunManage.xml
{
    class OpXMLFile
    {
        // 实现对Opml文件的操作
        public bool OprationOpmlFile(string file, string[] xpathstr, string OprationMode, string Title, string Url)
        {
            try
            {
                XmlDocument opmldoc = new XmlDocument();
                opmldoc.Load(file);

                XmlNode body = opmldoc.SelectSingleNode("//body");
                switch (OprationMode)
                {
                    case "AddRss":
                        foreach (string s in xpathstr)
                        {
                            XmlNode AddRss = body.SelectSingleNode("outline[@title=\"" + s.ToString() + "\"]");
                            body = AddRss;
                        }

                        XmlElement addrss = opmldoc.CreateElement("outline");
                        addrss.SetAttribute("title", Title);
                        addrss.SetAttribute("type", "rss");
                        addrss.SetAttribute("xmlUrl", Url);
                        body.AppendChild(addrss);

                        opmldoc.Save(file);
                        break;
                    case "AddML":
                        foreach (string s in xpathstr)
                        {
                            XmlNode AddML = body.SelectSingleNode("outline[@title=\"" + s.ToString() + "\"]");
                            body = AddML;
                        }

                        XmlElement appml = opmldoc.CreateElement("outline");
                        appml.SetAttribute("title", Title);
                        body.AppendChild(appml);

                        opmldoc.Save(file);
                        break;
                    case "AddM":
                        foreach (string s in xpathstr)
                        {
                            XmlNode AddML = body.SelectSingleNode("outline[@title=\"" + s.ToString() + "\"]");
                            body = AddML;
                        }
                       
                        XmlElement appml1 = opmldoc.CreateElement("outline");
                        appml1.SetAttribute("title", Title);
                        XmlNode parent1 = body.ParentNode;
                        parent1.AppendChild(appml1);

                        opmldoc.Save(file);
                        break;
                    case "Del":

                        foreach (string s in xpathstr)
                        {
                            XmlNode Deling = body.SelectSingleNode("outline[@title=\"" + s.ToString() + "\"]");
                            body = Deling;
                        }

                        XmlNode parent = body.ParentNode;
                        parent.RemoveChild(body);

                        opmldoc.Save(file);

                        break;
                    case "Rename":
                        foreach (string s in xpathstr)
                        {
                            XmlNode Rename = body.SelectSingleNode("outline[@title=\"" + s.ToString() + "\"]");
                            body = Rename;
                        }

                        body.Attributes["title"].InnerText = Title;
                        opmldoc.Save(file);
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        //创建顶层目录
        public bool CreateRootSon(string file, string Title)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNode body = doc.SelectSingleNode("//body");

                XmlElement appml = doc.CreateElement("outline");
                appml.SetAttribute("title", Title);
                body.AppendChild(appml);

                doc.Save(file);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
