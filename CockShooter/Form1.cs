//#define My_Debug


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CockShooter
{
    public partial class CockShooter : Form
    {
#if My_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif
        public CockShooter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timerLoop_Tick(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;


#if My_Debug

            TextFormatFlags flag = TextFormatFlags.Left | TextFormatFlags.EndEllipsis; // aligns text on the screen
            Font _fontt = new System.Drawing.Font("Stencil", 12, FontStyle.Regular); // font that we use
            TextRenderer.DrawText(dc, "X = " + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(),
                _fontt, new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flag); //where to boot the text

#endif


            base.OnPaint(e);
        }

        private void CockShooter_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            _cursX = e.X;
            _cursY = e.Y; // assing mouse cordinates 
#endif
            this.Refresh(); //update x and y wherever the mouse is
        }
    }
}