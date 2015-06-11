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
        Boolean LogIn(String userName, String password);

        [OperationContract]
        Boolean LogOff(String userName, String password);

        [OperationContract]
        Boolean SendMessage(String message);

        [OperationContract]
        List<String> ReadMessages(int Lines);
    }
}
