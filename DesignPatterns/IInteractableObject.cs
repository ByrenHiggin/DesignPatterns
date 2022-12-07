using DesignPatterns.generic;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesignPatterns.interfaces
{
    public interface IInteractableObject : IEnumerable<IData>, ISerializable
    {
        void AddEntry(string v, Size size, Color color);
        void RemoveEntry(IData data);

        IData this[int index]
        {
            get;
            set;
        }
    }
}
