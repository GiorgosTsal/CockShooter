//#define My_Debug


using CockShooter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CockShooter
{
    public partial class CockShooter : Form
    {
        const int FrameNum = 2;
        const int SplatNum = 3;
        bool splat = false;

        int _splatTime = 0;
        int _gameFrame = 0;

        int _hits = 0;
        int _misses = 0;
        int _totalShots = 0;
        double _averageHits = 0;

#if My_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif
        CCock _cock;
        CSplat _splat;
        CSign _sign;
        CScoreFrame _scoreframe;

        public CockShooter()
        {
            InitializeComponent();

            //creation of scope
            Bitmap b = new Bitmap(Resources.target);
            this.Cursor = CustomeCursor.CreateCursor(b, b.Height / 2, b.Width / 2);

            
            _cock = new CCock() { Left = 10, Top = 450  };
            _scoreframe = new CScoreFrame() { Left = 10, Top = 40 };
            _sign = new CSign() { Left = 580, Top = 172 };
            _splat = new CSplat();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timerLoop_Tick(object sender, EventArgs e)
        {
            
            if (_gameFrame >= FrameNum)
            {
                UpdateCock();
                _gameFrame = 0;
            }
            if (splat)
            {
                if (_splatTime >= SplatNum)
                {
                    splat = false;
                    _splatTime = 0;
                    UpdateCock();
                }
                _splatTime++;
            }
            _gameFrame++;
            this.Refresh();
            }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            if (splat)
            {
                _splat.DrawImage(dc);
            }
            else
            {
                _cock.DrawImage(dc);
            }
         
#if My_Debug

            TextFormatFlags flag = TextFormatFlags.Left | TextFormatFlags.EndEllipsis; // aligns text on the screen
            Font _fontt = new System.Drawing.Font("Stencil", 12, FontStyle.Regular); // font that we use
            TextRenderer.DrawText(dc, "X = " + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(),
                _fontt, new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flag); //where to boot the text

#endif
            _cock.DrawImage(dc);
            _scoreframe.DrawImage(dc);
            _sign.DrawImage(dc);

            //Put score on screen
            TextFormatFlags flags = TextFormatFlags.Left;
            Font _font = new System.Drawing.Font("Stencil", 14, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, "Shots :" + _totalShots.ToString(), _font, new Rectangle(85, 112, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Misses :" + _misses.ToString(), _font, new Rectangle(85, 142, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Hits :" + _hits.ToString(), _font, new Rectangle(85, 172, 120, 20), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Avg :" + _averageHits.ToString("F0") + "%", _font, new Rectangle(85, 202, 120, 20), SystemColors.ControlText, flags);

            base.OnPaint(e);
        }

        //UpdateCock() method will update cock position randomly
        private void UpdateCock()
        {
            Random rnd = new Random();
            _cock.Update(rnd.Next(Resources.cocksmall.Width, this.Width - Resources.cocksmall.Width),
                         rnd.Next(this.Height / 2, this.Height - Resources.cocksmall.Height * 2)
                         );
        }


        private void CockShooter_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            _cursX = e.X;
            _cursY = e.Y; // assing mouse cordinates 
#endif
            this.Refresh(); //update x and y wherever the mouse is
        }

        private void CockShooter_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.X > 663 && e.X < 699 && e.Y > 223 && e.Y < 234)
            {
                timerLoop.Start();
            }

            else if (e.X > 663 && e.X < 699 && e.Y > 242 && e.Y < 250)
            {
                timerLoop.Stop();
            }

            else if (e.X > 663 && e.X < 699 && e.Y > 258 && e.Y < 270)
            {
                splat = false;
                timerLoop.Stop();
                _hits = 0;
                _misses = 0;
                _totalShots = 0;
                _averageHits = 0;
                _cock.Left = 300;
                _cock.Top = 450;
            }

            else if (e.X > 663 && e.X < 699 && e.Y > 277 && e.Y < 288)
            {
                timerLoop.Stop();
                DialogResult result = MessageBox.Show(this, " Do you really want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
          
                if (_cock.Hit(e.X, e.Y))
                {
                    splat = true;
                    _splat.Left = _cock.Left - Resources.splat.Width /2;
                    _splat.Top = _cock.Top - Resources.splat.Height /2;
                    _hits++;
                }
                else { _misses++; }

                _totalShots = _hits + _misses;
                _averageHits = (double)_hits / (double)_totalShots * 100.0;
            }
            // Call FireGun() method to create Gun sound
            FireGun();
        }

        public void FireGun()
        {
            SoundPlayer simpleSound = new SoundPlayer(Resources.gun_sound);
            simpleSound.Play();
        }
    }
}