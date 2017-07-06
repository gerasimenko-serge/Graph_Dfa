namespace GraphView
{
    partial class GraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnRemoveNode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbNameNode = new System.Windows.Forms.Label();
            this.tbNameNode = new System.Windows.Forms.TextBox();
            this.cbFinalState = new System.Windows.Forms.CheckBox();
            this.cbStartState = new System.Windows.Forms.CheckBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbAlphabet = new System.Windows.Forms.TextBox();
            this.lbAlphabet = new System.Windows.Forms.Label();
            this.btnRemoveEdge = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tBarSpeed = new System.Windows.Forms.TrackBar();
            this.lbResult = new System.Windows.Forms.Label();
            this.canvasView1 = new GraphView.CanvasView();
            this.btnStep = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddNode);
            this.groupBox1.Controls.Add(this.btnRemoveNode);
            this.groupBox1.Location = new System.Drawing.Point(8, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(188, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование";
            // 
            // btnAddNode
            // 
            this.btnAddNode.BackgroundImage = global::GraphView.Properties.Resources.ADD;
            this.btnAddNode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNode.FlatAppearance.BorderSize = 0;
            this.btnAddNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAddNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNode.Location = new System.Drawing.Point(11, 31);
            this.btnAddNode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(52, 50);
            this.btnAddNode.TabIndex = 1;
            this.btnAddNode.TabStop = false;
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.BtnAddNode_Click);
            // 
            // btnRemoveNode
            // 
            this.btnRemoveNode.BackgroundImage = global::GraphView.Properties.Resources.REMOVE;
            this.btnRemoveNode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveNode.FlatAppearance.BorderSize = 0;
            this.btnRemoveNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRemoveNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveNode.Location = new System.Drawing.Point(74, 31);
            this.btnRemoveNode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveNode.Name = "btnRemoveNode";
            this.btnRemoveNode.Size = new System.Drawing.Size(52, 50);
            this.btnRemoveNode.TabIndex = 3;
            this.btnRemoveNode.TabStop = false;
            this.btnRemoveNode.UseVisualStyleBackColor = true;
            this.btnRemoveNode.Click += new System.EventHandler(this.BtnRemoveNode_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbNameNode);
            this.groupBox2.Controls.Add(this.tbNameNode);
            this.groupBox2.Controls.Add(this.cbFinalState);
            this.groupBox2.Controls.Add(this.cbStartState);
            this.groupBox2.Location = new System.Drawing.Point(8, 148);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(188, 174);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Свойства";
            // 
            // lbNameNode
            // 
            this.lbNameNode.AutoSize = true;
            this.lbNameNode.Location = new System.Drawing.Point(3, 30);
            this.lbNameNode.Name = "lbNameNode";
            this.lbNameNode.Size = new System.Drawing.Size(39, 18);
            this.lbNameNode.TabIndex = 7;
            this.lbNameNode.Text = "имя:";
            // 
            // tbNameNode
            // 
            this.tbNameNode.Location = new System.Drawing.Point(7, 52);
            this.tbNameNode.Name = "tbNameNode";
            this.tbNameNode.Size = new System.Drawing.Size(158, 24);
            this.tbNameNode.TabIndex = 7;
            this.tbNameNode.TextChanged += new System.EventHandler(this.TbNameNode_TextChange);
            // 
            // cbFinalState
            // 
            this.cbFinalState.AutoSize = true;
            this.cbFinalState.Location = new System.Drawing.Point(7, 115);
            this.cbFinalState.Name = "cbFinalState";
            this.cbFinalState.Size = new System.Drawing.Size(172, 22);
            this.cbFinalState.TabIndex = 7;
            this.cbFinalState.Text = "Конечное состояние";
            this.cbFinalState.UseVisualStyleBackColor = true;
            this.cbFinalState.CheckedChanged += new System.EventHandler(this.CbFinalState_CheckedChanged);
            // 
            // cbStartState
            // 
            this.cbStartState.AutoSize = true;
            this.cbStartState.Location = new System.Drawing.Point(7, 85);
            this.cbStartState.Margin = new System.Windows.Forms.Padding(4);
            this.cbStartState.Name = "cbStartState";
            this.cbStartState.Size = new System.Drawing.Size(181, 22);
            this.cbStartState.TabIndex = 7;
            this.cbStartState.Text = "Начальное состояние";
            this.cbStartState.UseVisualStyleBackColor = true;
            this.cbStartState.CheckedChanged += new System.EventHandler(this.CbStartState_CheckedChanged);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPath.ForeColor = System.Drawing.Color.DimGray;
            this.tbPath.Location = new System.Drawing.Point(210, 487);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(607, 29);
            this.tbPath.TabIndex = 7;
            this.tbPath.Visible = false;
            this.tbPath.TextChanged += new System.EventHandler(this.TbPath_TextChanged);
            this.tbPath.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TbPath_PreviewKeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tbAlphabet
            // 
            this.tbAlphabet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAlphabet.ForeColor = System.Drawing.Color.DimGray;
            this.tbAlphabet.Location = new System.Drawing.Point(8, 353);
            this.tbAlphabet.Name = "tbAlphabet";
            this.tbAlphabet.Size = new System.Drawing.Size(188, 29);
            this.tbAlphabet.TabIndex = 10;
            this.tbAlphabet.Text = "10";
            this.tbAlphabet.TextChanged += new System.EventHandler(this.LbAlphabet_TextChanged);
            // 
            // lbAlphabet
            // 
            this.lbAlphabet.AutoSize = true;
            this.lbAlphabet.Location = new System.Drawing.Point(6, 331);
            this.lbAlphabet.Name = "lbAlphabet";
            this.lbAlphabet.Size = new System.Drawing.Size(74, 18);
            this.lbAlphabet.TabIndex = 11;
            this.lbAlphabet.Text = "Алфавит:";
            // 
            // btnRemoveEdge
            // 
            this.btnRemoveEdge.BackColor = System.Drawing.Color.DimGray;
            this.btnRemoveEdge.BackgroundImage = global::GraphView.Properties.Resources.REMOVE;
            this.btnRemoveEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveEdge.FlatAppearance.BorderSize = 0;
            this.btnRemoveEdge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRemoveEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveEdge.Location = new System.Drawing.Point(10, 6);
            this.btnRemoveEdge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveEdge.Name = "btnRemoveEdge";
            this.btnRemoveEdge.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveEdge.TabIndex = 12;
            this.btnRemoveEdge.TabStop = false;
            this.btnRemoveEdge.UseVisualStyleBackColor = false;
            this.btnRemoveEdge.Visible = false;
            this.btnRemoveEdge.Click += new System.EventHandler(this.BtnRemoveEdge_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(203, 482);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 40);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::GraphView.Properties.Resources.Play;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(203, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(34, 34);
            this.btnStart.TabIndex = 8;
            this.btnStart.TabStop = false;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImage = global::GraphView.Properties.Resources.Pouse;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(203, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(34, 34);
            this.btnPause.TabIndex = 13;
            this.btnPause.TabStop = false;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::GraphView.Properties.Resources.Stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(243, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(34, 34);
            this.btnStop.TabIndex = 14;
            this.btnStop.TabStop = false;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click_1);
            // 
            // tBarSpeed
            // 
            this.tBarSpeed.AutoSize = false;
            this.tBarSpeed.Location = new System.Drawing.Point(347, 6);
            this.tBarSpeed.Maximum = 11;
            this.tBarSpeed.Minimum = 1;
            this.tBarSpeed.Name = "tBarSpeed";
            this.tBarSpeed.Size = new System.Drawing.Size(226, 32);
            this.tBarSpeed.TabIndex = 15;
            this.tBarSpeed.Value = 2;
            this.tBarSpeed.Scroll += new System.EventHandler(this.TBarSpeed_Scroll);
            // 
            // lbResult
            // 
            this.lbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResult.BackColor = System.Drawing.Color.DimGray;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbResult.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbResult.Location = new System.Drawing.Point(833, 482);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(140, 40);
            this.lbResult.TabIndex = 16;
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // canvasView1
            // 
            this.canvasView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvasView1.BackColor = System.Drawing.Color.DimGray;
            this.canvasView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasView1.Location = new System.Drawing.Point(203, 43);
            this.canvasView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canvasView1.Name = "canvasView1";
            this.canvasView1.Size = new System.Drawing.Size(770, 432);
            this.canvasView1.TabIndex = 0;
            this.canvasView1.TabStop = false;
            this.canvasView1.Click += new System.EventHandler(this.canvasView1_Click);
            this.canvasView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasView1_MouseUp);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(283, 6);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(63, 32);
            this.btnStep.TabIndex = 17;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.BtnStep_Click);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 531);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.tBarSpeed);
            this.Controls.Add(this.btnRemoveEdge);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbAlphabet);
            this.Controls.Add(this.tbAlphabet);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canvasView1);
            this.Controls.Add(this.btnPause);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GraphForm";
            this.Text = "GraphForm";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GraphForm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CanvasView canvasView1;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnRemoveNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbNameNode;
        private System.Windows.Forms.TextBox tbNameNode;
        private System.Windows.Forms.CheckBox cbFinalState;
        private System.Windows.Forms.CheckBox cbStartState;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbAlphabet;
        private System.Windows.Forms.Label lbAlphabet;
        private System.Windows.Forms.Button btnRemoveEdge;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar tBarSpeed;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnStep;
    }
}