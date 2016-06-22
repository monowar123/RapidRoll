using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RapidRoll
{
    class RoundButton: Button
    {
        private Color _startcolor = Color.White;
        private Color _endcolor = Color.Red;
        private Color _textcolor = Color.Black;
        private bool _swap = false;
        //default constructor
        public RoundButton(){}
        public RoundButton(Color startcolor, Color endcolor)
        {
            _startcolor = startcolor;
            _endcolor = endcolor;
        }
        public Color Startcolor
        {
            get { return _startcolor;}
            set { _startcolor = value;}
        }
        public Color Endcolor
        {
            get { return _endcolor; }
            set { _endcolor = value; }
        }
        public Color Textcolor
        {
            get { return _textcolor; }
            set { _textcolor = value; }
        }
        private void DoDraw(Graphics G, bool sw) //sw does the color swap, quicker than a swap routine!
        {
            Brush textBr = new SolidBrush(_textcolor);
            Rectangle R = new Rectangle(0, 0, this.Width, this.Height);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;
            G.SmoothingMode = SmoothingMode.HighQuality; // change??????
            //G.InterpolationMode = InterpolationMode.NearestNeighbor;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;// change??????
            //Rectangle R2 = R;
            //R2.Inflate(-2, -2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(R);
            this.Region = new Region(path);
            R.Inflate(1, 1);
            //R.Inflate(R.Size);
            LinearGradientBrush linBr;
            //if (sw)
                //linBr = new LinearGradientBrush(new Point(R.Left, R.Top), new Point(R.Right, R.Bottom), _endcolor, _startcolor);
            //else
                linBr = new LinearGradientBrush(new Point(R.Left, R.Top), new Point(R.Right, R.Bottom), _startcolor, _endcolor);
            
            //////////////
            //R.Inflate(-1, -1);
            //Pen pen = new Pen(_startcolor);
            //pen.Width = 1f;
            //G.DrawEllipse(pen, R);
            //R.Inflate(1, 1);

            G.FillEllipse(linBr, R);
            R.Inflate(-5, -5);
            LinearGradientBrush linBrBack;
            if (sw)
                linBrBack = new LinearGradientBrush(new Point(R.Left, R.Top), new Point(R.Right, R.Bottom), _startcolor, _endcolor);
            else
                linBrBack = new LinearGradientBrush(new Point(R.Left, R.Top), new Point(R.Right, R.Bottom), _endcolor, _startcolor);
            //G.FillEllipse(linBrBack, R);
            //G.DrawString(this.Text, this.Font, textBr, R, strFormat);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            DoDraw(pevent.Graphics, _swap);
        }
        protected override void OnMouseHover(EventArgs e) // not needed really, but nice to have
        {
            //Graphics g = this.CreateGraphics();
            //_swap = true;
            //DoDraw(g, _swap);
            //_swap = false;
            //g.Dispose();
            //base.OnMouseHover(e);
        }
       
    }
}
