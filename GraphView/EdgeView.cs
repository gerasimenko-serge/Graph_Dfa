using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

using GraphImplementation;

namespace GraphView
{
    public class EdgeView:IView
    {
        public event MouseHandler MouseClick;
        private bool isOver = false;

        public void Raise_MouseClick()
        {
            MouseClick?.Invoke(this);
        }

        public void Raise_MouseEnter()
        {
            if (!isOver)
                isOver = true;
        }

        public void Raise_MouseLeave()
        {
            if (isOver)
                isOver = false;
        }



        void IView.Draw(System.Drawing.Graphics g)
        {

            Pen p = new Pen(color, width);
            GraphicsPath gp = new GraphicsPath();
            gp.AddLines(new Point[] { new Point(-2, -5), new Point(0, 0), new Point(2, -5) });
            CustomLineCap clp = new System.Drawing.Drawing2D.CustomLineCap(null, gp);
            clp.SetStrokeCaps(LineCap.Square, LineCap.Square);
            clp.WidthScale = 1;
            p.CustomStartCap = clp;


            Point T = new Point(point1.X, point1.Y);

            if (point1 != point2)
            {
                double ab = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
                double r = ab / Math.Sqrt(2);
                double b = Math.PI / 4 - Math.Atan2(point2.X - Point1.X, point2.Y - Point1.Y);
                Point O = new Point((int)(point1.X + r * Math.Cos(b) - r), (int)(point1.Y + r * Math.Sin(b) - r));
                int sa = (int)(180 + b * 180 / Math.PI);




                int a = 90 - (int)((Math.Acos((2 * r * r - radius * radius) / (2 * r * r)) * 180 / Math.PI) * 1.3);
                if ((int)r * 2 > 0)
                    g.DrawArc(p, O.X, O.Y, (int)r * 2, (int)r * 2, sa - a, a);




                T.X += (int)(r * 0.7 * Math.Cos(b + 70 * Math.PI / 180));
                T.Y += (int)(r * 0.7 * Math.Sin(b + 70 * Math.PI / 180)) - 15;

                


            }
            else
            {
                g.DrawArc(p, point1.X-60, point1.Y-30, 60, 60, 40,280);
                T.X -= 40;
            }

            SolidBrush Sel = new SolidBrush(Color.Silver);
            if (isOver)
                Sel.Color = Color.DarkTurquoise;

            g.DrawString(Val, new Font("Roboto Condensed", 18, FontStyle.Bold), Sel, T.X, T.Y, VertexView.stringFormat);

            valR.Size = g.MeasureString(Val, new Font("Roboto Condensed", 18, FontStyle.Bold));
            valR.Location = new Point(T.X - (int)valR.Size.Width / 2, T.Y - (int)valR.Size.Height / 2);
        }

        public RectangleF valR = new RectangleF();

        private String val = "x";

        public String Val
        {
            get { return val; }
            set
            {
                Edge.Value.Clear();
                val = value;
                if (val != "")
                {
                    val = val.Replace(" ", "");
                    string[] strs = val.Split(',');
                    val = "";
                    for (int i = 0; i < strs.Length - 1; i++)
                    {
                        val += strs[i] + ",";
                        Edge.Value.Add(strs[i]);
                    }
                    if (strs[strs.Length - 1] != "")
                    {
                        val += strs[strs.Length - 1];
                        Edge.Value.Add(strs[strs.Length - 1]);
                    }
                    else
                        val = val.Substring(0, val.Length - 1);
                }
                else
                {
                    val = "x";
                }
            }
        }

        private Point point1 = new Point(0, 0),point2 = new Point(0, 0);
        public Point Point1
        {
            get { return point1; }
            set { point1 = value; }
        }

        public Point Point2
        {
            get { return point2; }
            set { point2 = value; }
        }

        private Int32 width = 2;
        public Int32 Width
        {
            get { return width; }
            set { width = value; }
        }

        private Color color = Color.Gray;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private Int32 radius = 20;
        public Int32 Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Edge Edge;


    }
}
