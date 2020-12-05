namespace 请假管理系统
{
    partial class infor_stu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(infor_stu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.apply_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apply_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apply_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_tutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_instructor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 113);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文新魏", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(474, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "学生请假记录";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::请假管理系统.Properties.Resources.boarding_pass_96px;
            this.pictureBox5.Location = new System.Drawing.Point(390, 23);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apply_time,
            this.reason,
            this.apply_start,
            this.apply_end,
            this.check_tutor,
            this.check_instructor,
            this.tips});
            this.dataGridView1.Location = new System.Drawing.Point(6, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1148, 424);
            this.dataGridView1.TabIndex = 1;
            // 
            // apply_time
            // 
            this.apply_time.HeaderText = "请假时间";
            this.apply_time.MinimumWidth = 6;
            this.apply_time.Name = "apply_time";
            this.apply_time.ReadOnly = true;
            this.apply_time.Width = 150;
            // 
            // reason
            // 
            this.reason.HeaderText = "申请事由";
            this.reason.MinimumWidth = 6;
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            this.reason.Width = 150;
            // 
            // apply_start
            // 
            this.apply_start.HeaderText = "开始时间";
            this.apply_start.MinimumWidth = 6;
            this.apply_start.Name = "apply_start";
            this.apply_start.ReadOnly = true;
            this.apply_start.Width = 150;
            // 
            // apply_end
            // 
            this.apply_end.HeaderText = "结束时间";
            this.apply_end.MinimumWidth = 6;
            this.apply_end.Name = "apply_end";
            this.apply_end.ReadOnly = true;
            this.apply_end.Width = 150;
            // 
            // check_tutor
            // 
            this.check_tutor.HeaderText = "班导师审批";
            this.check_tutor.MinimumWidth = 6;
            this.check_tutor.Name = "check_tutor";
            this.check_tutor.ReadOnly = true;
            this.check_tutor.Width = 125;
            // 
            // check_instructor
            // 
            this.check_instructor.HeaderText = "辅导员审批";
            this.check_instructor.MinimumWidth = 6;
            this.check_instructor.Name = "check_instructor";
            this.check_instructor.ReadOnly = true;
            this.check_instructor.Width = 125;
            // 
            // tips
            // 
            this.tips.HeaderText = "备注";
            this.tips.MinimumWidth = 6;
            this.tips.Name = "tips";
            this.tips.ReadOnly = true;
            this.tips.Width = 180;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::请假管理系统.Properties.Resources.回退白;
            this.pictureBox1.Location = new System.Drawing.Point(38, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // infor_stu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 578);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "infor_stu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "学生请假记录";
            this.Load += new System.EventHandler(this.imfor_stu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apply_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn apply_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn apply_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_tutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_instructor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tips;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}