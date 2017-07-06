using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using GraphImplementation;
using System.Windows.Forms;


namespace GraphView
{
    public class VertexView:IView
    {
        public static System.Drawing.StringFormat stringFormat; 

        public VertexView()
        {
            if (VertexView.stringFormat == null)
            {
                VertexView.stringFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
            }
        }
        
        public event MouseHandler MouseDown;
        public event MouseHandler MouseUp;
        public event MouseHandler MouseEnter;
        public event MouseHandler MouseLeave;
        public event MouseHandler MouseMove;

        public void Raise_MouseDown()
        {
            if (MouseDown != null)
            {
                MouseDown(this);
                isDown = true;
            }
        }

        public Boolean IsHighLighted
        {
            get { return isHighLighted; }
            set { isHighLighted = value;  }
        }

        public void Raise_MouseUp()
        {
            if (MouseUp != null && isDown)
            {
                MouseUp(this);
                isDown = false;
            }
        }

        public void Raise_MouseEnter()
        {
            if (MouseEnter != null && !isOver) 
            { 
                MouseEnter(this);
                isOver = true;
            }
        }

        public void Raise_MouseLeave()
        {
            if (MouseLeave != null && isOver) 
            { 
                MouseLeave(this);
                isOver = false;
            }
        }

        public void Raise_MouseMove()
        {
            if (MouseMove != null && isOver)
            {
                MouseMove(this);
            }
        }

        public Boolean IsSelected = false;
        

        private Color backColor = Color.DimGray;
        private Color selectedColor = Color.DarkGray;
        private Color borderColor = Color.Gray;
        private Color highLightColor = Color.DarkTurquoise;
        private Vertex vertex;
        private Point location = new Point(0, 0);
        private Int32 radius = 20;

        private Boolean isDown = false;
        private Boolean isOver = false;
        private Boolean isHighLighted = false;
        void IView.Draw(Graphics g)
        {
            if (Vertex.IsStart)
            {
                g.FillPolygon(new SolidBrush(Color.DarkTurquoise), new Point[] { 
                    new Point(location.X - radius/2, location.Y - radius - radius/2 ), 
                    new Point(location.X + radius/2, location.Y - radius - radius/2), 
                    new Point(location.X ,   location.Y - radius)
                });
            }
            if (Vertex.IsFinish)
            {
                g.FillPolygon(new SolidBrush(Color.Tomato), new Point[] { 
                    new Point(location.X - radius/2, location.Y + radius), 
                    new Point(location.X + radius/2, location.Y + radius), 
                    new Point(location.X ,   location.Y + radius*2 - radius/2)
                });
            }
            if(IsSelected)
            {
                g.FillEllipse(new SolidBrush(selectedColor), location.X - radius, location.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(new Pen(borderColor, 4), location.X - radius, location.Y - radius, radius * 2, radius * 2);
            }
            else
            {
                g.FillEllipse(new SolidBrush(backColor), location.X - radius, location.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(new Pen(borderColor, 2), location.X - radius, location.Y - radius, radius * 2, radius * 2);
            }
            if (IsHighLighted)
            {
                g.DrawEllipse(new Pen(highLightColor, 4), location.X - radius, location.Y - radius, radius * 2, radius * 2);
            }
            g.DrawString(vertex.Value, new Font("Roboto Condensed", 14), Brushes.White, location.X, location.Y+1, VertexView.stringFormat);
            /*TextRenderer.DrawText(g, vertex.Info, new Font("Times New Roman",10), new Rectangle(location.X - radius, location.Y - radius, radius * 2, radius * 2), Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordEllipsis);*/
        }

        
        public Vertex Vertex
        {
            get { return vertex; }
            set { vertex = value; }
        }
       
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        
        public Int32 Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }
        public Color HighLightColor
        {
            get { return highLightColor; }
            set { highLightColor = value; }
        }
    }
}
