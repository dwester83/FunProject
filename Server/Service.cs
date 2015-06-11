using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private static List<String> list = new List<string>();

        public Boolean LogIn(String userName, String password)
        {
            return true;
        }

        public Boolean LogOff(String userName, String password)
        {
            return true;
        }

        public Boolean SendMessage(String message)
        {
            list.Add(message);
            return true;
        }

        public List<String> ReadMessages(int Lines)
        {
            return list;
        }
    }
}
