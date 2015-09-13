using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    public class ConfigFile
    {
        private string m_sFilename;
        private string m_sTypename;
        private bool m_bIsCollection;
        private string m_sCollectionRootElement;
        private object m_oConfigObject;

        public string Filename
        {
            get { return m_sFilename; }
            set { m_sFilename = value; }
        }

        public string Typename
        {
            get { return m_sTypename; }
            set { m_sTypename = value; }
        }

        public bool IsCollection
        {
            get { return m_bIsCollection; }
            set { m_bIsCollection = value; }
        }

        public string CollectionRootElement
        {
            get { return m_sCollectionRootElement; }
            set { m_sCollectionRootElement = value; }
        }

        public object ConfigObject
        {
            get { return m_oConfigObject; }
            set { m_oConfigObject = value; }
        }
    }
}
