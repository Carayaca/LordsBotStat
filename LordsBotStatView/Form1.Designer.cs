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
            this.colPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLvl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLvl3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlayer,
            this.colLvl2,
            this.colLvl3,
            this.colPaid,
            this.colScore,
            this.colStatus,
            this.colDebt});
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(776, 405);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Перетащите JSON на таблицу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "LordsBotStat";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLvl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLvl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebt;
        private System.Windows.Forms.Label label1;
    }
}

