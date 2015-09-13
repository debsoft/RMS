using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    public class LogSources
    {
        public const string None = "None";
        public const string GatewayReciever = "GatewayReciever";
        public const string GatewaySender = "GatewaySender";
        public const string CellBazzarService = "CellBazzarService";
        public const string ConfigService = "ConfigService";
        public const string DataAccess = "DataAccess";
        public const string DataAccessQuery = "DataAccessQuery";
        public const string SystemEngine = "SystemEngine";
    }//LogSources


    namespace Common
    {
        public enum MessageType
        {
            ASCII = 1,
            RingTone = 2,
            Logo = 3,
            Unkown = 4
        }

    }//ns
}//ns
