using SOLIDPrinciples.interfaces;
using System;

namespace SOLIDPrinciples.generic
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large
    }
    [Serializable]
    public class JournalEntry : IData
    {
        private string _text;
        private Size _size;
        private Color _color;
        public JournalEntry(string text, Size size, Color color)
        {
            Text = text;
            Size = size;
            Color = color;
        }

        public string Text { get => _text; set => _text = value; }
        public Size Size { get => _size; set => _size = value; }
        public Color Color { get => _color; set => _color = value; }

        Color IData.Color()
        {
            return Color;
        }

        Size IData.Size()
        {
            return Size;
        }
    }
}
