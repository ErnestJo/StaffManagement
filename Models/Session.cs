using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MystaffTool.Models
{
    public class Session
    {
        private string _sessionName;
        private string _sessionId;
        private string _sessionStaffId;
     

        public static string MySessionName;
        public static string MySessionId;
        public static string MySessionStaffId;

        public string SessionName
        {
            get
            {
                return _sessionName;
            }
            set
            {
                if (value is null)
                    throw new System.ArgumentNullException("SessionName");
                _sessionName = value;
            }
        }

        public string SessionId
        {
            get
            {
                return _sessionId;
            }
            set
            {
                if (value is null)
                    throw new System.ArgumentNullException("_sessionId");
                _sessionId = value;
            }
        }

        public string SessionStaffId
        {
            get
            {
                return _sessionStaffId;
             }

            set
            {
                if (value is null)
                    throw new System.ArgumentNullException("_sessionStaffId");
                _sessionStaffId = value;
            }
        }


        public Session(string sessionName, string id, string staffId)
        {
            SessionName = sessionName;
            SessionId = id;
            SessionStaffId = staffId;
        }
    }
}
