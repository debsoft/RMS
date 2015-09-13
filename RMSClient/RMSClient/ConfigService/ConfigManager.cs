using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using ConfigUtils;

namespace RMS
{
    /// <summary>
    /// ConfigManager class.
    /// Loads main config and all specified config files.
    /// At the moment the main service config filename 
    /// is hardcoded to "ConfigFiles/Config.xml".
    /// </summary>
    /// <todo>
    /// Logging has not been implemented.
    /// Search for LOG:
    /// </todo>
    public sealed class ConfigManager
    {
        private static List<ConfigFile> m_oConfigFiles = null;

        private static string m_sServiceConfigFile = AppDomain.CurrentDomain.BaseDirectory + "config\\Config.xml";
        private static object _monitor = new object();
        private const string CONFIGSERVICE = "ConfigService";

        /// <summary>
        /// Static constructor for ConfigManager.
        /// Loads service config and all config files.
        /// </summary>
        static ConfigManager()
        {
            Debug.WriteLine("Constructing ConfigManager object.", "ConfigManager.ctor");
            Logger.Write("Constructing ConfigManager object.", LogLevel.Debug, CONFIGSERVICE);

            try
            {
                lock (_monitor)
                {
                    LoadServiceConfig();
                    LoadAllConfigFiles(); //maybe wrap this call with a null check?
                }
            }
            catch (Exception exp)
            {
                //LOG: error
                //Logger
                Debug.WriteLine("Exception error while constructing ConfigManager object: " + exp.Message, "ConfigManager.ctor");
                Logger.Write("Exception error while constructing ConfigManager object: " + exp.Message, LogLevel.Error, CONFIGSERVICE);
            }
        }

        /// <summary>
        /// Gets the config object for the specified type.
        /// Note: A reference is returned, any changes made to the config object 
        /// is persisted until 'ReloadConfig' is called or assemly is reloaded.
        /// </summary>
        /// <typeparam name="T">The generic type of the config object to get.</typeparam>
        /// <returns>A config object.</returns>
        public static T GetConfig<T>()
        {
            T oRetval = default(T);
            ConfigFile oConfigFile = null;
            Type tObjType = typeof(T);
            string sTypename;

            Debug.WriteLine("Getting config object for type '" + tObjType.FullName + "'.", "ConfigManager.GetConfig<T>");
            //Logger.Write("Getting config object for type '" + tObjType.FullName + "'.", LogLevel.Debug, CONFIGSERVICE);

            try
            {
                if (m_oConfigFiles!=null && m_oConfigFiles.Count > 0)
                {
                    if (tObjType.IsGenericType && tObjType.GetGenericTypeDefinition().Equals(typeof(List<>)))
                    {
                        if (tObjType.GetGenericArguments().Length > 0)
                        {
                            sTypename = tObjType.GetGenericArguments()[0].AssemblyQualifiedName;
                            oConfigFile = m_oConfigFiles.Find(delegate(ConfigFile obj) { return obj.Typename == sTypename && obj.IsCollection; });
                        }
                    }
                    else
                    {
                        sTypename = tObjType.AssemblyQualifiedName;
                        oConfigFile = m_oConfigFiles.Find(delegate(ConfigFile obj) { return obj.Typename == sTypename && !obj.IsCollection; });
                    }

                    if (oConfigFile != null)
                        oRetval = (T)oConfigFile.ConfigObject;
                }
                else //no config files in m_oConfigFiles - config files not loaded
                {
                    Logger.Write("No config files loaded. Check config service configuration file 'Config.xml'.", LogLevel.Error, CONFIGSERVICE);
                }
            }
            catch (Exception exp)
            {
                //LOG: error
                Debug.WriteLine("Error getting config object for type '" + tObjType.FullName + "': " + exp.Message, "ConfigManager.GetConfig<T>");
                Logger.Write("Error getting config object for type '" + tObjType.FullName + "': " + exp.Message, LogLevel.Error, CONFIGSERVICE);
            }

            return oRetval;
        }

        /// <summary>
        /// Dummy method for forcing a preload of all config files.
        /// </summary>
        public static void Init()
        {
        }

        /// <summary>
        /// Reloads the service config and all config files.
        /// </summary>
        public static void ReloadConfig()
        {
            Debug.WriteLine("Reloading config files.", "ConfigManager.ReloadConfig");
            Logger.Write("Reloading config files.", LogLevel.Information, CONFIGSERVICE);

            try
            {
                lock (_monitor)
                {
                    m_oConfigFiles = null;
                    LoadServiceConfig();
                    LoadAllConfigFiles(); //maybe wrap this call with a null check?
                }
            }
            catch (Exception exp)
            {
                //LOG: error
                Debug.WriteLine("Exception error while reloading config files: " + exp.Message, "ConfigManager.ReloadConfig");
                Logger.Write("Exception error while reloading config files: " + exp.Message, LogLevel.Error, CONFIGSERVICE);
            }
        }

        /// <summary>
        /// Loads the service main config.
        /// </summary>
        private static void LoadServiceConfig()
        {
            Debug.WriteLine("Loading ConfigService config.", "ConfigManager.LoadServiceConfig");
            Logger.Write("Loading ConfigService config.", LogLevel.Information, CONFIGSERVICE);

            try
            {
                m_oConfigFiles = XMLSerializer.DeserializeCollectionFromFile<List<ConfigFile>>(m_sServiceConfigFile, "Config");

                if (m_oConfigFiles == null)
                {
                    Debug.WriteLine("Error loading ConfigService config file '" + m_sServiceConfigFile + "': Deserialized object was NULL - Possible error in XML file.");
                    Logger.Write("Error loading ConfigService config file '" + m_sServiceConfigFile + "': Deserialized object was NULL - Possible error in XML file.", LogLevel.Error, CONFIGSERVICE);
                }
            }
            catch (Exception exp)
            {
                //LOG: error
                Debug.WriteLine("Error loading ConfigService config file '" + m_sServiceConfigFile + "': " + exp.Message);
                Logger.Write("Error loading ConfigService config file '" + m_sServiceConfigFile + "': " + exp.Message, LogLevel.Error, CONFIGSERVICE);
            }
        }

        /// <summary>
        /// Loops through the list of config files described in 
        /// the service main config file Config.xml
        /// </summary>
        private static void LoadAllConfigFiles()
        {
            Debug.WriteLine("Loading all config files.", "ConfigManager.LoadAllConfigFiles");
            Logger.Write("Loading all config files.", LogLevel.Information, CONFIGSERVICE);

            try
            {
                foreach (ConfigFile oConfigFile in m_oConfigFiles)
                {
                    LoadSingleConfigFile(oConfigFile);
                }
            }
            catch (Exception exp)
            {
                //LOG: error
                Debug.WriteLine("Error loading all config files: " + exp.Message, "ConfigManager.LoadAllConfigFiles");
                Logger.Write("Error loading all config files: " + exp.Message, LogLevel.Error, CONFIGSERVICE);
            }
        }

        /// <summary>
        /// Loads a single config object from it's config file.
        /// </summary>
        /// <param name="oConfigFile">The config object containing information about the object to load.</param>
        private static void LoadSingleConfigFile(ConfigFile oConfigFile)
        {
            string sFilename = "";

            Debug.WriteLine("Loading config file '" + oConfigFile.Filename + "'.", "ConfigManager.LoadSingleConfigFile");
            Logger.Write("Loading config file '" + oConfigFile.Filename + "'.", LogLevel.Information, CONFIGSERVICE);

            if (oConfigFile!=null)
                sFilename = oConfigFile.Filename;

            if (!System.IO.Path.IsPathRooted(sFilename)) //then add root path to filename
                sFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sFilename);

            try
            {
                if (oConfigFile.IsCollection)
                {
                    Type oType = Type.GetType("System.Collections.Generic.List`1[[" + oConfigFile.Typename + "]]");
                    object oConfigObject = XMLSerializer.DeserializeCollectionFromFile(oType, sFilename, oConfigFile.CollectionRootElement);
                    oConfigFile.ConfigObject = oConfigObject;
                }
                else
                {
                    Type oType = Type.GetType(oConfigFile.Typename);
                    object oConfigObject = XMLSerializer.DeserializeObjectFromFile(oType, sFilename);
                    oConfigFile.ConfigObject = oConfigObject;
                }

                if (oConfigFile.ConfigObject == null)
                {
                    //LOG: config object was null, possible error in xml file
                    Debug.WriteLine("Error loading config file '" + sFilename + "': Deserialized object was NULL - Possible error in XML file.");
                    Logger.Write("Error loading config file '" + sFilename + "': Deserialized object was NULL - Possible error in XML file.", LogLevel.Error, CONFIGSERVICE);
                }
            }
            catch (Exception exp)
            {
                //LOG: error
                Debug.WriteLine("Error loading config file '" + sFilename + "': " + exp.Message, "ConfigManager.LoadSingleConfigFile");
                Logger.Write("Error loading config file '" + sFilename + "': " + exp.Message, LogLevel.Error, CONFIGSERVICE);
            }
        }

    }//class
}//ns
