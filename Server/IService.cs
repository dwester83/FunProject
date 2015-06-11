using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void LogIn(String userName, String password);

        [OperationContract]
        void LogOff(String userName, String password);

        [OperationContract]
        void SendMessage(String message);

        [OperationContract]
        List<String> ReadMessages(int lines);
    }
}
