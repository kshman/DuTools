namespace DuTools.CommandForm
{
	partial class DuGetBlogForm
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
            this.ContentText = new System.Windows.Forms.TextBox();
            this.TaskList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BookNameText = new System.Windows.Forms.TextBox();
            this.DoItButton = new Du.WinForms.BadakButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PagesLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SiteCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UrlText = new System.Windows.Forms.TextBox();
            this.BinbCheck = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.ContentText);
            this.panel1.Controls.Add(this.TaskList);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 551);
            this.panel1.TabIndex = 0;
            // 
            // ContentText
            // 
            this.ContentText.AcceptsReturn = true;
            this.ContentText.AcceptsTab = true;
            this.ContentText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ContentText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentText.ForeColor = System.Drawing.Color.White;
            this.ContentText.Location = new System.Drawing.Point(4, 470);
            this.ContentText.Multiline = true;
            this.ContentText.Name = "ContentText";
            this.ContentText.ReadOnly = true;
            this.ContentText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ContentText.Size = new System.Drawing.Size(618, 78);
            this.ContentText.TabIndex = 2;
            // 
            // TaskList
            // 
            this.TaskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskList.FormattingEnabled = true;
            this.TaskList.ItemHeight = 18;
            this.TaskList.Location = new System.Drawing.Point(4, 136);
            this.TaskList.Name = "TaskList";
            this.TaskList.Size = new System.Drawing.Size(618, 328);
            this.TaskList.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BookNameText);
            this.panel2.Controls.Add(this.DoItButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.UrlText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 130);
            this.panel2.TabIndex = 0;
            // 
            // BookNameText
            // 
            this.BookNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BookNameText.Location = new System.Drawing.Point(103, 33);
            this.BookNameText.Name = "BookNameText";
            this.BookNameText.Size = new System.Drawing.Size(402, 24);
            this.BookNameText.TabIndex = 5;
            // 
            // DoItButton
            // 
            this.DoItButton.ActiveColor = System.Drawing.Color.Aquamarine;
            this.DoItButton.ActiveStyle = true;
            this.DoItButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DoItButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.DoItButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.DoItButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoItButton.ForeColor = System.Drawing.Color.White;
            this.DoItButton.Location = new System.Drawing.Point(511, 2);
            this.DoItButton.Name = "DoItButton";
            this.DoItButton.Size = new System.Drawing.Size(110, 100);
            this.DoItButton.TabIndex = 3;
            this.DoItButton.Text = "해볼까요";
            this.DoItButton.UseVisualStyleBackColor = false;
            this.DoItButton.Click += new System.EventHandler(this.DoItButton_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.BinbCheck);
            this.panel3.Controls.Add(this.PagesLabel);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.SiteCombo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(3, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 60);
            this.panel3.TabIndex = 2;
            // 
            // PagesLabel
            // 
            this.PagesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PagesLabel.Location = new System.Drawing.Point(99, 32);
            this.PagesLabel.Name = "PagesLabel";
            this.PagesLabel.Size = new System.Drawing.Size(83, 24);
            this.PagesLabel.TabIndex = 4;
            this.PagesLabel.Text = "0";
            this.PagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "읽은 페이지";
            // 
            // SiteCombo
            // 
            this.SiteCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SiteCombo.Enabled = false;
            this.SiteCombo.FormattingEnabled = true;
            this.SiteCombo.Items.AddRange(new object[] {
            "[지원 안되는 곳이예요]",
            "티스토리 비오라트",
            "네이버 블로그 모바일",
            "(블로그스팟)"});
            this.SiteCombo.Location = new System.Drawing.Point(99, 3);
            this.SiteCombo.Name = "SiteCombo";
            this.SiteCombo.Size = new System.Drawing.Size(170, 26);
            this.SiteCombo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "지원 방식";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL 주소";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "저장할 책 이름";
            // 
            // UrlText
            // 
            this.UrlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlText.Location = new System.Drawing.Point(103, 3);
            this.UrlText.Name = "UrlText";
            this.UrlText.Size = new System.Drawing.Size(402, 24);
            this.UrlText.TabIndex = 0;
            this.UrlText.TextChanged += new System.EventHandler(this.UrlText_TextChanged);
            // 
            // BinbCheck
            // 
            this.BinbCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BinbCheck.AutoSize = true;
            this.BinbCheck.Location = new System.Drawing.Point(341, 5);
            this.BinbCheck.Name = "BinbCheck";
            this.BinbCheck.Size = new System.Drawing.Size(156, 22);
            this.BinbCheck.TabIndex = 5;
            this.BinbCheck.Text = "블로그 안 블로그 모드";
            this.BinbCheck.UseVisualStyleBackColor = true;
            // 
            // DuGetBlogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 551);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "DuGetBlogForm";
            this.Text = "DuGetBlogForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private TextBox ContentText;
		private ListBox TaskList;
		private Panel panel2;
		private BadakButton DoItButton;
		private Panel panel3;
		private Label PagesLabel;
		private Label label6;
		private ComboBox SiteCombo;
		private Label label4;
		private Label label3;
		private Label label1;
		private TextBox UrlText;
		private TextBox BookNameText;
        private CheckBox BinbCheck;
    }
}