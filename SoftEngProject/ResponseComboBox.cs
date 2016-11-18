using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftEngProject
{
    public class ResponseComboBox
    {
        private int _id;
        private string _name;

        private Color _color = Color.White;
        
        private int _x = 7;
        private int _y = 20;
        private int _width = 121;
        private int _height = 21;

        public void ComboBoxtoAdd(Color color, string text, int x, int y, int width, int height)
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
