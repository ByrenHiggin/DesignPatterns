using DesignPatterns.interfaces;
using System.Collections.Generic;

namespace DesignPatterns.generic
{
    public class JournalEnum : IEnumerator<IData>
    {
        private List<JournalEntry> _entries;
        public JournalEnum(List<JournalEntry> entries)
        {
            _entries = entries;
        }
        int position = -1;
        public object Current
        {
            get { return _entries[position]; }
        }

        IData IEnumerator<IData>.Current
        {
            get
            {
                return _entries[position];
            }
        }
        public bool MoveNext()
        {
            position++;
            return (position < _entries.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            _entries.Clear();
        }
    }
}
