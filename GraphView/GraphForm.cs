using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using GraphImplementation;

namespace GraphView
{
    public delegate void EventSelectedChange(VertexView v);
  
    public partial class GraphForm : Form
    {
        Graph graph = new Graph();
        public event EventSelectedChange OnSelectedChange;
        VertexView Selected = null;
        bool isFindWay = false;
        public GraphForm()
        {
            InitializeComponent();

            graph.OnEdgeAdded += On_EdgeAdded;
            graph.OnEdgeRemoved += On_EdgeRemoved;
            graph.OnVertexRemoved += On_VertexRemoved;
            graph.OnVertexAdded += On_VertexAdded;
            this.OnSelectedChange += GraphForm_OnSelectedChange;
            canvasView1.MouseMove += On_MouseMove;
        }

        void GraphForm_OnSelectedChange(VertexView v)
        {
            Selected = v;
        }

        public void On_VertexRemoved(Graph sender, Vertex vertex)
        {
            VertexView v = canvasView1.FindViewByVertex(vertex);
            if (v != null){ 
                v.MouseDown -= On_MouseDown;
                v.MouseUp -= On_MouseUp;
                v.MouseLeave -= On_MouseLeave;
                v.MouseEnter -= On_MouseEnter;
                canvasView1.Views.Remove(v);
            }
            v = null;
            canvasView1.Refresh();
        }
        public void On_VertexAdded(Graph sender, Vertex vertex)
        {
            canvasView1.Views.Add(VertexAdd(vertex));
            canvasView1.Refresh();
        }
        Random r = new Random();
        private VertexView VertexAdd(Vertex vertex)
        {
            VertexView v = new VertexView();
            v.Vertex = vertex;
            v.Location = new Point(r.Next(v.Radius, canvasView1.Width - v.Radius), r.Next(v.Radius, canvasView1.Height - v.Radius));
            v.MouseDown += On_MouseDown;
            v.MouseUp += On_MouseUp;
            v.MouseLeave += On_MouseLeave;
            v.MouseEnter += On_MouseEnter; 
            return v;
        }

        private VertexView VertexAdd(Vertex vertex, Point location)
        {
            VertexView v = new VertexView();
            v.Vertex = vertex;
            v.Location = location;
            v.MouseDown += On_MouseDown;
            v.MouseUp += On_MouseUp;
            v.MouseLeave += On_MouseLeave;
            v.MouseEnter += On_MouseEnter;
            return v;
        }

        public void On_EdgeRemoved(Graph sender, Edge edge)
        {
            EdgeView e = canvasView1.FindViewByEdge(edge);
            if (e != null) canvasView1.Views.Remove(e);
            canvasView1.Refresh();
        }

        public void On_EdgeAdded(Graph sender, Edge edge)
        {
            EdgeView e = new EdgeView();
            e.Edge = edge;
            e.Point1 = canvasView1.FindViewByVertex(edge.Vertex1).Location;
            e.Point2 = canvasView1.FindViewByVertex(edge.Vertex2).Location;
            canvasView1.Views.Add(e);
            e.MouseClick += On_MouseClick;
            canvasView1.Refresh();
        }

        public TextBox EdgeEdit = new TextBox();
        private EdgeView SelectedEdge;

        void On_MouseClick(IView sender)
        {
            SelectedEdge = sender as EdgeView;
            EdgeEdit.Top = (int)(sender as EdgeView).valR.Top + canvasView1.Top;
            EdgeEdit.Left = (int)(sender as EdgeView).valR.Left + canvasView1.Left;
            EdgeEdit.Text = (sender as EdgeView).Val;
            EdgeEdit.Visible = true;
            btnRemoveEdge.Top = EdgeEdit.Top;
            btnRemoveEdge.Left = EdgeEdit.Left - EdgeEdit.Height;
            btnRemoveEdge.Width = EdgeEdit.Height;
            btnRemoveEdge.Height = EdgeEdit.Height;
            btnRemoveEdge.Visible = true;
            EdgeEdit.BringToFront();
            EdgeEdit.Focus();
            EdgeEdit.SelectAll();
        }

        private void On_TextChanged(object sender, EventArgs e)
        {

        }

        private void On_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRemoveEdge.Visible = false;
                EdgeEdit.Visible = false;
                SelectedEdge.Val = EdgeEdit.Text;
            }
        }


        private void BtnAddNode_Click(object sender, EventArgs e)
        {
            graph.AddVertex();
        }

        VertexView moving = null;
        VertexView VPreview = new VertexView();
        VertexView Over = null;
        EdgeView EPreview = new EdgeView();
        Point StartPoint;
        Point OldPoint;

        Boolean isAdding = false;
        private void On_MouseDown(IView sender)
        {
            if(MouseButtons == MouseButtons.Left)
            {
                    foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                    {
                        v.IsSelected = false;
                    }
                    (sender as VertexView).IsSelected = true;


                    tbNameNode.Text = (sender as VertexView).Vertex.Value;
                    tbNameNode.Focus();
                    tbNameNode.SelectAll();
                    cbStartState.Checked = (sender as VertexView).Vertex.IsStart;
                    cbFinalState.Checked = (sender as VertexView).Vertex.IsFinish;

                    if (OnSelectedChange != null) OnSelectedChange(sender as VertexView);
                    canvasView1.BringToFront(sender);
                    moving = (VertexView)sender;

            }
            else
            {
                
                VPreview.Location = (sender as VertexView).Location;
                VPreview.Vertex = new Vertex("");
                canvasView1.Views.Add(VPreview);

                EPreview.Edge = new Edge((sender as VertexView).Vertex, VPreview.Vertex);
                EPreview.Point1 = canvasView1.FindViewByVertex(EPreview.Edge.Vertex1).Location;
                EPreview.Point2 = canvasView1.FindViewByVertex(EPreview.Edge.Vertex2).Location;
                canvasView1.Views.Add(EPreview);
                canvasView1.BringToFront(VPreview);
                isAdding = true;
                Over = (sender as VertexView);
            }
            OldPoint = (sender as VertexView).Location;
            StartPoint = MousePosition;
        }


        private void On_MouseMove(Object sender, MouseEventArgs e)
        {
            if (moving != null)
            {
                moving.Location = new Point(OldPoint.X + (MousePosition.X - StartPoint.X), OldPoint.Y + (MousePosition.Y - StartPoint.Y));
                foreach (Edge ed in graph.NeihbourEdges(moving.Vertex))
                {

                    if (canvasView1.FindViewByEdge(ed).Edge.Vertex1 == moving.Vertex)
                    {
                        if (canvasView1.FindViewByEdge(ed).Edge.Vertex2 == moving.Vertex)
                        {
                            canvasView1.FindViewByEdge(ed).Point1 = moving.Location;
                            canvasView1.FindViewByEdge(ed).Point2 = moving.Location;
                        }else
                            canvasView1.FindViewByEdge(ed).Point1 = moving.Location;
                    }
                    else
                    {
                        canvasView1.FindViewByEdge(ed).Point2 = moving.Location;
                    }

                }
            }
            if (isAdding)
            {
                VertexView hitTest = canvasView1.VertexHitTest(new Point(e.X, e.Y), VPreview);//, VPreview);
                if (hitTest != null)
                {
                    VPreview.Location = hitTest.Location;
                    Over = hitTest;
                }
                else
                {
                    VPreview.Location = new Point(OldPoint.X + (MousePosition.X - StartPoint.X), OldPoint.Y + (MousePosition.Y - StartPoint.Y));
                    Over = null;
                }
                EPreview.Point2 = canvasView1.FindViewByVertex(EPreview.Edge.Vertex2).Location;
            }
        }

        private void On_MouseUp(IView sender)
        {
           if (moving != null)
               moving = null;
           if(isAdding)
           {
               isAdding = false;

               if (Over != null)
               {
                   if (Equals(EPreview.Edge.Vertex1, Over.Vertex))
                       this.Text = "";
                   graph.AddEdge(EPreview.Edge.Vertex1, Over.Vertex);
               }
               else
               {
                       graph.AddVertex();
                       (canvasView1.Views[canvasView1.Views.Count - 1] as VertexView).Location = VPreview.Location;
                       graph.AddEdge(EPreview.Edge.Vertex1, (canvasView1.Views[canvasView1.Views.Count - 1] as VertexView).Vertex);
               }
               canvasView1.Views.Remove(VPreview);
               canvasView1.Views.Remove(EPreview);
           }
           canvasView1.Refresh();
          
        }
        
        private void On_MouseEnter(IView sender)
        {
           (sender as VertexView).BackColor = Color.Gray;
        }

        private void On_MouseLeave(IView sender)
        {
           (sender as VertexView).BackColor = Color.DimGray;
        }
        

        private void BtnRemoveNode_Click(object sender, EventArgs e)
        {
            List<Vertex> ToRemove = new List<Vertex>();
            foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
            {
                if (v.IsSelected)
                {
                    ToRemove.Add(v.Vertex);
                }
            }
            foreach (Vertex v in ToRemove)
            {
                graph.RemoveVertex(v);
            }
        }
     
        private void canvasView1_MouseUp(object sender, MouseEventArgs e)
        {

            if (canvasView1.VertexHitTest(new Point(e.X,e.Y)) == null && e.Button == MouseButtons.Right)
            {
                graph.AddVertex();
                (canvasView1.Views[canvasView1.Views.Count - 1] as VertexView).Location = new Point(e.X, e.Y);
            }

        }

        private void GraphForm_Load(object sender, EventArgs e)
        {
            EdgeEdit.Visible = false;
            btnRemoveEdge.Visible = false;
            EdgeEdit.BackColor = Color.White;
            EdgeEdit.ForeColor = Color.DimGray;
            
            EdgeEdit.Width = 150;
            EdgeEdit.BorderStyle = BorderStyle.FixedSingle;
            EdgeEdit.Font = new Font("Roboto Condensed", 18, FontStyle.Bold);
            EdgeEdit.TextChanged += On_TextChanged;
            EdgeEdit.PreviewKeyDown += On_PreviewKeyDown;
            this.Controls.Add(EdgeEdit);
        }

        private void canvasView1_Click(object sender, EventArgs e)
        {
            EdgeEdit.Visible = false;
            btnRemoveEdge.Visible = false;
            if(canvasView1.Views.OfType<VertexView>().Where(a=>a.IsSelected==true).Count() == 0)
            {
                tbNameNode.Text = "";
                cbStartState.Checked = false;
                cbFinalState.Checked = false;
            }
            
        }

        private void GraphForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<Vertex> ToRemove = new List<Vertex>();
                foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                {
                    if (v.IsSelected)
                    {
                        ToRemove.Add(v.Vertex);
                    }
                }
                foreach (Vertex v in ToRemove)
                {
                    graph.RemoveVertex(v);
                }
            }
        }

        private void TbNameNode_TextChange(object sender, EventArgs e)
        {
            foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                if (v.IsSelected)
                    v.Vertex.Value = tbNameNode.Text;
            canvasView1.Refresh();
        }

        private void CbStartState_CheckedChanged(object sender, EventArgs e)
        {
            if(cbStartState.Checked){
            foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                if (v.IsSelected)
                    v.Vertex.IsStart = true;
                else
                    v.Vertex.IsStart = false;
            }else{
                foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                    if (v.IsSelected)
                        v.Vertex.IsStart = false;
            }
            canvasView1.Refresh();
        }

        private void CbFinalState_CheckedChanged(object sender, EventArgs e)
        {
            foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                if (v.IsSelected)
                    v.Vertex.IsFinish = cbFinalState.Checked;
            canvasView1.Refresh();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnPause.Visible = false;
            btnStart.Visible = true;
            if (isPause)
                timer1.Start();
            else
                StartDFA();
            isPause = false;
        }

        VertexView currentVV = null;
        List<String> strip = new List<String>();
        int stripPointer = 0;
        public void StartDFA()
        {
            
            foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
            {
                if (v.Vertex.IsStart)
                    currentVV = v;
                v.IsHighLighted = false;
            }
            if (currentVV != null)
            {
                strip.Clear();
                foreach (char c in tbPath.Text)
                    strip.Add(c.ToString());
                stripPointer = 0;

                currentVV.IsHighLighted = true;
                
                canvasView1.Refresh();
                timer1.Start();
                btnStart.Visible = false;
                btnPause.Visible = true;
            }
            else
            {
                //ERROR
            }
        }

        public void StepDFA()
        {
            if (stripPointer < strip.Count)
            {
                foreach (Edge e in graph.IncidentedEdges(currentVV.Vertex))
                {
                    if (e.Value.Contains(strip[stripPointer]))
                    {
                        currentVV.IsHighLighted = false;
                        currentVV = canvasView1.FindViewByVertex(e.Vertex2);
                        currentVV.IsHighLighted = true;
                        break;
                    }
                }
                stripPointer += 1;
                canvasView1.Refresh();
                StripRedraw();
            }
            else
            {
                timer1.Stop();
                stripPointer = 0;
                isPause = false;
                currentVV.IsHighLighted = false;
                if (currentVV.Vertex.IsFinish)
                {
                    lbResult.ForeColor = Color.GreenYellow;
                    lbResult.Text = "Accepted";
                }
                else
                {
                    lbResult.ForeColor = Color.Tomato;
                    lbResult.Text = "Rejected";
                }
                btnStart.Visible = true;
                btnPause.Visible = false;
                StripRedraw();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            StepDFA();
        }

        private void TbPath_TextChanged(object sender, EventArgs e)
        {
            if (tbPath.Text.Length > 0 && tbAlphabet.Text.Length > 0)
            {
                if (!tbAlphabet.Text.Contains(tbPath.Text[tbPath.Text.Length - 1]))
                {
                    tbPath.Text = tbPath.Text.Substring(0, tbPath.Text.Length - 1);
                    tbPath.Select(tbPath.Text.Length,0);
                }
            }
            lbResult.Text = "";
        }

        private void LbAlphabet_TextChanged(object sender, EventArgs e)
        {
            if (tbAlphabet.Text.Length > 0)
            {
                if (tbAlphabet.Text.Substring(0, tbAlphabet.Text.Length - 1).Contains(tbAlphabet.Text[tbAlphabet.Text.Length - 1]))
                {
                    tbAlphabet.Text = tbAlphabet.Text.Substring(0, tbAlphabet.Text.Length - 1);
                    tbAlphabet.Select(tbAlphabet.Text.Length, 0);
                }
            }
        }

        private void TbPath_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                strip.Clear();
                foreach (char c in tbPath.Text)
                    strip.Add(c.ToString());
                stripPointer = 0;
                tbPath.Visible = false;
                StripRedraw();
            }
        }

        void StripRedraw()
        {
            Bitmap bs = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bs);
            g.Clear(pictureBox1.BackColor);

            for (int i = 0; i < strip.Count; i++ )
            {
                if(i == stripPointer)
                {
                    g.DrawRectangle(new Pen(Color.DarkTurquoise, 2), 5 + i * 35, 5, 30, 30);
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.Gray, 2), 5 + i*35, 5, 30, 30);
                }
                g.DrawString(strip[i], new Font("Roboto Condensed", 18), Brushes.White, 6 + i * 35 , 6);
            }
            
            pictureBox1.Image = bs;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbPath.Visible = true;
            tbPath.Focus();
            tbPath.Select(tbAlphabet.Text.Length, 0);
        }
        bool isPause = false;
        private void BtnRemoveEdge_Click(object sender, EventArgs e)
        {
            graph.edges.Remove(SelectedEdge.Edge);
            canvasView1.Views.Remove(SelectedEdge);
            canvasView1.Refresh();
            EdgeEdit.Visible = false;
            btnRemoveEdge.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            isPause = true;
            btnPause.Visible = false;
            btnStart.Visible = true;
        }

        private void BtnStop_Click_1(object sender, EventArgs e)
        {
            try
            {
                isPause = false;
                btnStart.Visible = true;
                btnPause.Visible = false;
                timer1.Stop();
                stripPointer = 0;
                currentVV.IsHighLighted = false;
                canvasView1.Refresh();
                StripRedraw();
            }
            catch { }
            
        }

        private void TBarSpeed_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / tBarSpeed.Value;
            if (tBarSpeed.Value == 11)
                timer1.Interval = 1;
        }

        private void TbPath_Leave(object sender, EventArgs e)
        {
            tbPath.Visible = false;
        }

        private void BtnStep_Click(object sender, EventArgs e)
        {
            if(isPause)
                StepDFA();
            else
            {
                foreach (VertexView v in canvasView1.Views.OfType<VertexView>())
                {
                    if (v.Vertex.IsStart)
                        currentVV = v;
                    v.IsHighLighted = false;
                }
                if (currentVV != null)
                {
                    strip.Clear();
                    foreach (char c in tbPath.Text)
                        strip.Add(c.ToString());
                    stripPointer = 0;

                    currentVV.IsHighLighted = true;

                    canvasView1.Refresh();
                }
                else
                {
                    //ERROR
                }
            }
        }

    }
}
