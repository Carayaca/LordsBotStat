namespace LordsBotStatView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLvl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLvl3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Перетащите JSON на таблицу";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPlayerName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 33);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Период отчета:";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(112, 4);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(127, 23);
            this.txtPlayerName.TabIndex = 1;
            this.txtPlayerName.TextChanged += new System.EventHandler(this.TxtPlayerName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фильтр по игроку";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 385);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlayer,
            this.colLvl2,
            this.colLvl3,
            this.colPaid,
            this.colScore,
            this.colRequired,
            this.colStatus,
            this.colDebt});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(800, 385);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataGridView1_DragEnter);
            // 
            // colPlayer
            // 
            this.colPlayer.DataPropertyName = "PlayerName";
            this.colPlayer.HeaderText = "PLAYER";
            this.colPlayer.MinimumWidth = 100;
            this.colPlayer.Name = "colPlayer";
            this.colPlayer.ReadOnly = true;
            this.colPlayer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPlayer.Width = 200;
            // 
            // colLvl2
            // 
            this.colLvl2.DataPropertyName = "Lvl2";
            this.colLvl2.HeaderText = "LEVEL 2";
            this.colLvl2.Name = "colLvl2";
            this.colLvl2.ReadOnly = true;
            this.colLvl2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colLvl3
            // 
            this.colLvl3.DataPropertyName = "Lvl3";
            this.colLvl3.HeaderText = "LEVEL 3+";
            this.colLvl3.Name = "colLvl3";
            this.colLvl3.ReadOnly = true;
            this.colLvl3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colPaid
            // 
            this.colPaid.DataPropertyName = "Paid";
            this.colPaid.HeaderText = "PAID";
            this.colPaid.Name = "colPaid";
            this.colPaid.ReadOnly = true;
            this.colPaid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colScore
            // 
            this.colScore.DataPropertyName = "Score";
            this.colScore.HeaderText = "SCORE";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
            this.colScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colRequired
            // 
            this.colRequired.HeaderText = "REQUIRED";
            this.colRequired.Name = "colRequired";
            this.colRequired.ReadOnly = true;
            this.colRequired.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "STATUS";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colDebt
            // 
            this.colDebt.DataPropertyName = "Debt";
            this.colDebt.HeaderText = "DEBT";
            this.colDebt.Name = "colDebt";
            this.colDebt.ReadOnly = true;
            this.colDebt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "LordsBotStat";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLvl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLvl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

