using System;
using System.Collections.Generic;
using System.Text;

namespace MessageQueueDemo
{
    //Attribute must be added for mesioning class can be serialize
    [Serializable]
    public class RequestInformation
    {
        public RequestInformation()
        {

        }
        //one can add number of variables or inforation in this class 
        //like address, MobileNumber.
        public string Name;
    
        public string Message;
    }
}
