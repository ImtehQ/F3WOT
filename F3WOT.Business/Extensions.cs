using F3WOT.Business.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        public static NuFeed ToFeed(this XmlNodeList xmlNodes)
        {
            NuFeed feed = new NuFeed();
            foreach (XmlNode rssNode in xmlNodes)
            {
                rssNode.FillObjectWithXmlNode(ref feed);
            }
            return feed;
        }

        public static void FillObjectWithXmlNode(this XmlNode node, ref NuFeed target)
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
