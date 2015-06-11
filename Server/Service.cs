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
        // These are static for the moment until I make an object to actually contain them.
        private static List<String> list = new List<String>();
        private static List<String> userList = new List<String>();

        private MessageModel messageModel;

        public void LogIn(String userName, String password)
        {
            list.Add("User :" + userName + " has logged on.");
            userList.Add(userName);
        }

        public void LogOff(String userName, String password)
        {
            list.Add("User :" + userName + " has logged off.");
            userList.Remove(userName);
        }

        public void SendMessage(String message)
        {
            messageModel.getInstance();
            messageModel.addMessage(message);
        }

        public List<String> ReadMessages(int lines)
        {
            messageModel.getInstance();
            return messageModel.getMessages(lines);
        }
    }
}
