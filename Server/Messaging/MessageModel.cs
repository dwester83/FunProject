using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class MessageModel
    {
        // The singleton
        private static MessageModel messageModel;

        private Object lockObject = new Object();
        private List<String> messageList = new List<String>();
        private List<String> userList = new List<String>();

        private MessageModel()
        {

        }

        public MessageModel getInstance()
        {
            lock (lockObject) // Locking for the moment, will probably remove.
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
            if (!userList.Contains(userName))
                userList.Add(userName);
        }

        public void removeUser(String userName)
        {
            if (userList.Contains(userName))
                userList.Remove(userName);
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
