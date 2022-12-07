using SOLIDPrinciples.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOLIDPrinciples.generic
{
    [Serializable]
    public class Journal : IInteractableObject
    {
        private readonly List<JournalEntry> _entries = new List<JournalEntry>();

        IData IInteractableObject.this[int index] { 
            get => _entries[index];
            set => _entries[index] = (JournalEntry)value;
        }

        public Journal()
        {

        }
        public Journal(SerializationInfo info, StreamingContext context)
        {
            _entries = (List<JournalEntry>)info.GetValue("entries", typeof(List<JournalEntry>));
        }

        void IInteractableObject.AddEntry(string v, Size size, Color color)
        {
            _entries.Add(new JournalEntry($"{_entries.Count}: {v}", size, color));
        }

        public void RemoveEntry(IData data)
        {
            _entries.Remove((JournalEntry)data);
        }

        public override string ToString()
        {
            var l = new List<String>();
            foreach(JournalEntry entry in _entries)
            {
                l.Add($"{entry.Text}, {entry.Size}, {entry.Color}");
            }
            return String.Join(Environment.NewLine, l);
        }

        public int Count()
        {
            return _entries.Count;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("entries", _entries, typeof(List<string>));
        }

        IEnumerator<IData> IEnumerable<IData>.GetEnumerator()
        {
            return (IEnumerator<IData>)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new JournalEnum(_entries);
        }

        //Here we break the single responsibility principle. Our "Journal" shouldnt have to think about saving           
        public void save(string filename)
        {

        }

    }
}
