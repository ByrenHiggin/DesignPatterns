using System.Runtime.Serialization;

namespace DesignPatterns.interfaces
{
    internal interface IPersistence
    {
        ISerializable OpenFromFile(string v);
        void SaveToFile(ISerializable SerializableObject, string FileName, bool Overwrite = false);
    }
}
