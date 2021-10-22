using F3WOT.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace F3WOT.Business
{
    public static class Extensions
    {
        public static void Add<T>(this List<T> list, T data)
        {
            if(data != null)
                list.Add(data);
        }

        public static Feed ToFeed(this XmlNodeList xmlNodes)
        {
            Feed feed = new Feed();
            foreach (XmlNode rssNode in xmlNodes)
            {
                rssNode.FillObjectWithXmlNode(ref feed);
            }
            return feed;
        }

        public static void FillObjectWithXmlNode(this XmlNode node, ref Feed target)
        {
            if (node.HasChildNodes == false)
                return;

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.ChildNodes.Count == 1)
                {
                    string propertyName = childNode.Name;
                    string propertyValue = childNode.InnerText;

                    PropertyInfo pi = target.GetType().GetProperty(propertyName);

                    if (pi != null)
                        pi.SetValue(target, Convert.ChangeType(propertyValue, pi.PropertyType), null);

                    else // search if such field exists
                    {
                        FieldInfo fi = target.GetType().GetField(propertyName);

                        if (fi != null)
                            fi.SetValue(target, Convert.ChangeType(propertyValue, fi.FieldType));
                    }
                }
                else if (childNode.ChildNodes.Count > 1)
                {
                    childNode.FillObjectWithXmlNode(ref target);
                }
                else { }
            }
        }

    }
}
