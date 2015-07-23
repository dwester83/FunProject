using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Messaging
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IMessageCallbackService" in both code and config file together.
    public class MessageCallbackService : IMessageCallbackService
    {
        private List<String> listOfMessageRecieved = new List<String>();

        public void NewMessage(string message)
        {
            listOfMessageRecieved.Add(message);
        }
    }
}
