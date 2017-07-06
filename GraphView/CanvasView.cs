using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GraphImplementation;
using System.Diagnostics;

namespace GraphView
{
    public class CanvasView:PictureBox
    {
        public CanvasView()
        {
            this.Resize += On_Resaize;
            this.Paint += On_Paint;
            this.MouseDown += On_Mouse_Down;
            this.MouseUp += On_Mouse_Up;
            this.MouseMove += On_Mouse_Move;
        }

        public List<IView> Views = new List<IView>();
        private Bitmap canvas = new Bitmap(1, 1);

        public void BringToFront(IView v)
        {
            for (int i = Views.Count - 1; i > 0; i--)
            {
                if (Views[i] == v)
                {
                    IView tmp = Views[i];
                    Views[i] = Views[i - 1];
                    Views[i - 1] = tmp;
                }
            }
            Refresh();
        }

        public VertexView FindViewByVertex(Vertex vertex)
        {
            foreach (VertexView v in Views.OfType<VertexView>())
            {
                if (v.Vertex == vertex) return v;
            }
            return null;
        }
        public EdgeView FindViewByEdge(Edge edge)
        {
            foreach (EdgeView v in Views.OfType<EdgeView>())
            {
                if (v.Edge == edge) return v;
            }
            return null;
        }

        public override void Refresh()
        {
            Graphics g = Graphics.FromImage(canvas);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.BackColor);

            foreach (IView v in Views.Reverse <IView>())
            {
                v.Draw(g);
            }
            this.Image = canvas;
        }

        private void On_Paint(Object sender, PaintEventArgs e)
        {

        }

        private void On_Resaize(Object sender, EventArgs e)
        {
            canvas = new Bitmap(this.Width, this.Height);
        }

        private void On_Mouse_Move(Object sender, MouseEventArgs e)
        {
            VertexView v_on_over = VertexHitTest(new Point(e.X, e.Y));
            EdgeView e_on_over = EdgeHitTest(new Point(e.X, e.Y));

            foreach (VertexView v in Views.OfType<VertexView>())
            {
                if (v_on_over != null && v == v_on_over)
                {
                    v_on_over.Raise_MouseEnter();
                    v_on_over.Raise_MouseMove();
                }
                else
                {
                    v.Raise_MouseLeave();
                }
            }

            foreach (EdgeView v in Views.OfType<EdgeView>())
                if (e_on_over != null && v == e_on_over)
                    e_on_over.Raise_MouseEnter();
                else
                    v.Raise_MouseLeave();



            Refresh();
        }

        private void On_Mouse_Up(Object sender, MouseEventArgs e)
        {
            try
                {
                foreach (VertexView v in Views.OfType<VertexView>())
                        v.Raise_MouseUp();
                Refresh();
            }catch(Exception)
            {

            }
           
        }

        private void On_Mouse_Down(Object sender, MouseEventArgs e)
        {
            foreach (VertexView v in Views.OfType<VertexView>())
                v.IsSelected = false;
            VertexView on_down = VertexHitTest(new Point(e.X,e.Y));
            if (on_down != null)
                on_down.Raise_MouseDown();

            EdgeView on_click = EdgeHitTest(new Point(e.X, e.Y));
            if (on_click != null)
                on_click.Raise_MouseClick();

            Refresh();
        }

        public VertexView VertexHitTest(Point point, params VertexView[] ignore)
        {
            foreach (VertexView v in Views.OfType<VertexView>())
            {
                bool flag = true;
                foreach (VertexView iv in ignore)
                {
                    if (iv == v)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag && Math.Sqrt((point.X - v.Location.X) * (point.X - v.Location.X) + (point.Y - v.Location.Y) * (point.Y - v.Location.Y)) <= v.Radius)
                    return v;

            }
            return null;
        }

        public EdgeView EdgeHitTest(Point point)
        {

            foreach (EdgeView e in Views.OfType<EdgeView>())
            {
                //Debug.WriteLine("Top: {0},  Bottom: {1},  Left: {2},  Right: {3} /n {4}", e.valR.Top, e.valR.Bottom, e.valR.Left, e.valR.Right, point.ToString());
                if (point.Y >= e.valR.Top && point.Y <= e.valR.Bottom && point.X >= e.valR.Left && point.X <= e.valR.Right)
                    return e;
            }

            return null;
        }
    }
}
