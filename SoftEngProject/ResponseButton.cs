using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngProject
{
    class ResponseButton
    {
        private int _id;
        private string _name;

        private Color _color = Color.WhiteSmoke;

        private int _x = 571;
        private int _y = 18;
        private int _width = 26;
        private int _height = 26;

        public void ButtonToAdd(Color color, string text, int x, int y, int width, int height)
        {
            this._color = color;
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }
        public Color Color { get { return _color; } }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    }
}
