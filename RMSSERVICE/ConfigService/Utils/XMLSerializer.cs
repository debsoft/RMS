/*
 * Author: Mutawaqqil Billah
 * Date: 2004-08-21
 * Last updated: 2006-03-04
 * Version: 1.2
 *
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using RMS;

namespace ConfigUtils
{
    /// <summary>
    /// XMLSerializer Class Util
    /// 
    /// TODO:
    ///		Clean up "overloaded" method implementations, they should use
    ///		the same base method.
    /// </summary>
    public class XMLSerializer
    {
        public static void SerializeCollectionToFile(object oObject, string sFilename, string sRootElementName)
        {
            try
            {
                XmlRootAttribute ra = new XmlRootAttribute();
                ra.Namespace = string.Empty;
                ra.ElementName = sRootElementName;
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(oObject.GetType(), ra);

                XmlTextWriter xmlWriter = new XmlTextWriter(sFilename, Encoding.Unicode);
                xmlSerializer.Serialize(xmlWriter, oObject);
                xmlWriter.Close();
            }
            catch (Exception exp)
            {
                throw new XMLSerializerException(string.Format("Error saving object to file: {0}", exp.Message), exp);
            }
        }
        public static void SerializeObjectToFile(object oObject, string sFileName)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(oObject.GetType());

                XmlTextWriter xmlWriter = new XmlTextWriter(sFileName, Encoding.Unicode);
                xmlSerializer.Serialize(xmlWriter, oObject);
                xmlWriter.Close();
            }
            catch (Exception exp)
            {
                throw new XMLSerializerException(string.Format("Error saving object to file: {0}", exp.Message), exp);
            }
        }

        public static object DeserializeCollectionFromFile(Type tOjectType, string sFilename, string sRootElementName)
        {
            object oRetval = null;

            try
            {
                if (File.Exists(sFilename))
                {
                    XmlRootAttribute ra = new XmlRootAttribute();
                    ra.Namespace = string.Empty;
                    ra.ElementName = sRootElementName;
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(tOjectType, ra);

                    XmlTextReader oXmlReader = new XmlTextReader(sFilename);

                    if (xmlSerializer.CanDeserialize(oXmlReader))
                        oRetval = xmlSerializer.Deserialize(oXmlReader);

                    oXmlReader.Close();

                }
                else
                {
                    throw (new Exception(string.Format("File '{0}' not found.", sFilename)));
                }
            }
            catch (Exception exp)
            {
                throw new XMLSerializerException(string.Format("Error loading object from file: {0}", exp.Message), exp);
            }

            return oRetval;
        }
        public static object DeserializeObjectFromFile(Type tOjectType, string sFileName)
        {
            object oRetval = null;

            try
            {
                if (File.Exists(sFileName))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(tOjectType);

                    XmlTextReader oXmlReader = new XmlTextReader(sFileName);

                    if (xmlSerializer.CanDeserialize(oXmlReader))
                        oRetval = xmlSerializer.Deserialize(oXmlReader);

                    oXmlReader.Close();

                }
                else
                {
                    throw new IOException(string.Format("File '{0}' not found.", sFileName));
                    //throw (new Exception(string.Format("File '{0}' not found.", sFileName)));
                }
            }
            catch (Exception exp)
            {
                throw new XMLSerializerException(string.Format("Error loading object from file: {0}", exp.Message), exp);
            }

            return oRetval;
        }

        public static T DeserializeCollectionFromFile<T>(string sFilename, string sRootElementName)
        {
            object oRetval = null;

            try
            {
                if (File.Exists(sFilename))
                {
                    XmlRootAttribute ra = new XmlRootAttribute();
                    ra.Namespace = string.Empty;
                    ra.ElementName = sRootElementName;
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T), ra);

                    XmlTextReader oXmlReader = new XmlTextReader(sFilename);

                    if (xmlSerializer.CanDeserialize(oXmlReader))
                        oRetval = xmlSerializer.Deserialize(oXmlReader);

                    oXmlReader.Close();

                }
                else
                {
                    throw new IOException(string.Format("File '{0}' not found.", sFilename));
                    //throw (new Exception(string.Format("File '{0}' not found.", sFilename)));
                }
            }
            catch (Exception exp)
            {
                throw new XMLSerializerException(string.Format("Error loading object from file: {0}", exp.Message), exp);
            }

            return (T)oRetval;
        }
        public static T DeserializeObjectFromFile<T>(string sFileName)
        {
            object oRetval = null;

            try
            {
                if (File.Exists(sFileName))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                    XmlTextReader oXmlReader = new XmlTextReader(sFileName);

                    if (xmlSerializer.CanDeserialize(oXmlReader))
                        oRetval = xmlSerializer.Deserialize(oXmlReader);

                    oXmlReader.Close();

                }
                else
                {
                    throw new IOException(string.Format("File '{0}' not found.", sFileName));
                    //throw (new Exception(string.Format("File '{0}' not found.", sFileName)));
                }
            }
            catch (Exception exp)
            {
                throw new XMLSerializerException(string.Format("Error loading object from file: {0}", exp.Message), exp);
            }

            return (T)oRetval;
        }

    }//class

    public class XMLSerializerException : Exception
    {
        public XMLSerializerException() { }
        public XMLSerializerException(string message) : base(message) { }
        public XMLSerializerException(string message, Exception innerException) : base(message, innerException) { }
    }
}//ns
