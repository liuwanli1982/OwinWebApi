using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace MvcApiDemo.Controllers
{
    public class SimpleXmlConverter
    {
        static string XmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        public static string ToXml<T>(IEnumerable<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count() == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(XmlHeader);

            XElement element = ToXElement<T>(entities, rootName);
            builder.Append(element.ToString());

            return builder.ToString();
        }

        public static XmlDocument ToXmlDocument<T>(IEnumerable<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count() == 0)
            {
                return null;
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(ToXml<T>(entities, rootName));

            return xmlDocument;
        }

        public static XDocument ToXDocument<T>(IEnumerable<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count() == 0)
            {
                return null;
            }

            return XDocument.Parse(ToXml<T>(entities, rootName));
        }

        public static XElement ToXElement<T>(IEnumerable<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count() == 0)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(rootName))
            {
                rootName = typeof(T).Name;
            }

            XElement element = new XElement(rootName);

            foreach (T entity in entities)
            {
                element.Add(ToXElement<T>(entity));
            }

            return element;
        }

        public static string ToXml<T>(T entity) where T : new()
        {
            if (entity == null)
            {
                return string.Empty;
            }

            XElement element = ToXElement<T>(entity);

            return element.ToString();
        }

        public static XElement ToXElement<T>(T entity) where T : new()
        {
            if (entity == null)
            {
                return null;
            }

            XElement element = new XElement(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties();
            XElement innerElement = null;
            object propertyValue = null;

            foreach (PropertyInfo property in properties)
            {
                propertyValue = property.GetValue(entity, null);
                innerElement = new XElement(property.Name, propertyValue);
                element.Add(innerElement);
            }

            return element;
        }

        public static XElement ToXElement(Type type)
        {
            if (type == null)
            {
                return null;
            }

            XElement element = new XElement(type.Name);
            PropertyInfo[] properties = type.GetProperties();
            XElement innerElement = null;

            foreach (PropertyInfo property in properties)
            {
                innerElement = new XElement(property.Name, null);
                element.Add(innerElement);
            }

            return element;
        }
    }
}