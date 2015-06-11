using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MessageService : IMessageService
    {
        #region Private Properties

        // Try this as a readonly property
        private MessageModel MessageModel
        {
            get { return MessageModel.getInstance(); }
        }

        #endregion

        public void LogIn(String userName, String password)
        {
            MessageModel.addUser(userName);
        }

        public void LogOff(String userName, String password)
        {
            MessageModel.removeUser(userName);
        }

        public void SendMessage(String message)
        {
            MessageModel.addMessage(message);
        }

        public List<String> ReadMessages(int lines)
        {
            return MessageModel.getMessages(lines);
        }
    }
}
