using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class MessageModel
    {
        // These are static for the moment until I make an object to actually contain them.
        private List<String> messageList = new List<String>();
        private List<String> userList = new List<String>();

        private Object lockObject = new Object();

        private static MessageModel messageModel;

        private MessageModel()
        {

        }

        public MessageModel getInstance()
        {
            lock (lockObject)
            {
                if (messageModel == null)
                {
                    messageModel = new MessageModel();
                }
                return messageModel;
            }
        }


        public void addUser(String userName)
        {
            // Place a timer to remove them.
            userList.Add(userName);

        }

        public List<String> getMessages(int count)
        {
            // Grab the last COUNT of messages, from the last one up.
            return messageList.Skip(Math.Max(0, messageList.Count() - count)).ToList<String>();
        }


        public void addMessage(String message)
        {
            // Grab the last COUNT of messages, from the last one up.
            messageList.Add(message);
        }

    }
}
