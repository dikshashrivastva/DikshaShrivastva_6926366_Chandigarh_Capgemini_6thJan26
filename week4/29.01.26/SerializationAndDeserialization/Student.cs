using System;
using System.Collections.Generic;
using System.Text;



namespace SerializationAndDeserialization
{
    [Serializable]
    //step 1: mark class as serializable
    internal class Student
    {
        public int Id;
        public string Name;
    }
}
