using CockShooter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CockShooter
{
    class CCock : CImageBase
    {//nothing

        private Rectangle _cockHotSpot = new Rectangle();

        public CCock()
            : base(Resources.cocksmall)
        {
            // intialize _cockHotSpot rectangle
            _cockHotSpot.X = Left + 20;
            _cockHotSpot.Y = Top - 1;
            _cockHotSpot.Width = 30;
            _cockHotSpot.Height = 40;
        }

        public void Update(int X, int Y)
        {
            Left = X;
            Top = Y;
            _cockHotSpot.X = Left + 20;
            _cockHotSpot.Y = Top - 1;
        }

        public bool Hit(int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1);
            if (_cockHotSpot.Contains(c))
            {
                return true;
            }
            return false;
        }
    }

}
