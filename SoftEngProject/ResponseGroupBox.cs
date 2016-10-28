using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SoftEngProject
{
    public class ResponseGroupBox
    {
        private int _id;
        private string _name;


        private Color _color = Color.Gray;

        private string _text = "New Response";
        private int _x = 0;
        private int _y = 0;
        private int _width = 571;
        private int _height = 117;

        public void GroupBoxToAdd(Color color, string text, int x, int y, int width, int height)
        {
            this._color = color;
            this._text = text;
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        public Color Color { get { return _color; } }
        public string Text { get { return _text; } }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    }
}
