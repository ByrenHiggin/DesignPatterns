using SOLIDPrinciples.interfaces;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SOLIDPrinciples.persistence
{
    //So we have a seperate class to handle the "persistance" of the data.
    public class Persistence : IPersistence
    {

        public ISerializable OpenFromFile(string FileName)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream s = new FileStream(FileName, FileMode.Open);
            ISerializable t = (ISerializable)formatter.Deserialize(s);
            return t;
        }

        public void SaveToFile(ISerializable SerializableObject, string FileName, bool Overwrite = false)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream s = new FileStream(FileName, FileMode.Create);
            formatter.Serialize(s, SerializableObject);
            s.Close();
        }
    }
}
