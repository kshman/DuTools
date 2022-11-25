namespace DuTools.CommandForm
{
	partial class OhNoForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.RepoUrlLabel = new System.Windows.Forms.LinkLabel();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 450);
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.RepoUrlLabel, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(83, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(634, 270);
			this.label1.TabIndex = 0;
			this.label1.Text = "두 툴즈";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RepoUrlLabel
			// 
			this.RepoUrlLabel.AutoSize = true;
			this.RepoUrlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RepoUrlLabel.Location = new System.Drawing.Point(83, 360);
			this.RepoUrlLabel.Name = "RepoUrlLabel";
			this.RepoUrlLabel.Size = new System.Drawing.Size(634, 90);
			this.RepoUrlLabel.TabIndex = 1;
			this.RepoUrlLabel.TabStop = true;
			this.RepoUrlLabel.Text = "저장소로 가봅니다";
			this.RepoUrlLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.RepoUrlLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RepoUrlLabel_LinkClicked);
			// 
			// OhNoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Indigo;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "OhNoForm";
			this.Text = "OhNoForm";
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private LinkLabel RepoUrlLabel;
	}
}