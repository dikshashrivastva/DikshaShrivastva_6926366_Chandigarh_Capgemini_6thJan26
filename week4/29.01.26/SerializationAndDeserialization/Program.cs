using System.Xml.Serialization;
namespace SerializationAndDeserialization;

internal class Program
{
    static void Main(string[] args)
    {
        Student s = new Student { Id = 101, Name = "John Doe" };

        //step 2: Create a file stream
        FileStream fs = new FileStream("student.xml", FileMode.Create);

        //step 3: Create Serializer
        XmlSerializer serializer=new XmlSerializer(typeof(Student));
        serializer.Serialize(fs, s);
        fs.Close();
    }
}
