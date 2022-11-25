namespace DuTools
{
	partial class FrontForm
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
			this.TopPanel = new System.Windows.Forms.Panel();
			this.SystemButton = new Du.WinForms.BadakSystemButton();
			this.WorkPanel = new System.Windows.Forms.Panel();
			this.TempButton = new System.Windows.Forms.Button();
			this.MainMenu = new Du.WinForms.BadakMenuStrip();
			this.명령을고르세요ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CalculatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.DuConsoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DuGetBlogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Converter1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RunAsLabel = new System.Windows.Forms.Label();
			this.TopPanel.SuspendLayout();
			this.MainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.TopPanel.Controls.Add(this.RunAsLabel);
			this.TopPanel.Controls.Add(this.TempButton);
			this.TopPanel.Controls.Add(this.SystemButton);
			this.TopPanel.Controls.Add(this.MainMenu);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Margin = new System.Windows.Forms.Padding(4);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(650, 80);
			this.TopPanel.TabIndex = 0;
			this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
			this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
			this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
			// 
			// SystemButton
			// 
			this.SystemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SystemButton.BackColor = System.Drawing.Color.Transparent;
			this.SystemButton.Form = null;
			this.SystemButton.Location = new System.Drawing.Point(500, 0);
			this.SystemButton.Margin = new System.Windows.Forms.Padding(0);
			this.SystemButton.MaximumSize = new System.Drawing.Size(150, 30);
			this.SystemButton.MinimumSize = new System.Drawing.Size(150, 30);
			this.SystemButton.Name = "SystemButton";
			this.SystemButton.ShowClose = true;
			this.SystemButton.ShowMaximize = true;
			this.SystemButton.ShowMinimize = true;
			this.SystemButton.Size = new System.Drawing.Size(150, 30);
			this.SystemButton.TabIndex = 0;
			this.SystemButton.TabStop = false;
			this.SystemButton.CloseOrder += new System.EventHandler(this.SystemButton_CloseOrder);
			// 
			// WorkPanel
			// 
			this.WorkPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WorkPanel.Location = new System.Drawing.Point(0, 83);
			this.WorkPanel.Name = "WorkPanel";
			this.WorkPanel.Size = new System.Drawing.Size(650, 356);
			this.WorkPanel.TabIndex = 1;
			// 
			// TempButton
			// 
			this.TempButton.Location = new System.Drawing.Point(12, 12);
			this.TempButton.Name = "TempButton";
			this.TempButton.Size = new System.Drawing.Size(80, 60);
			this.TempButton.TabIndex = 2;
			this.TempButton.Text = "button1";
			this.TempButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.TempButton.UseVisualStyleBackColor = true;
			this.TempButton.Visible = false;
			// 
			// MainMenu
			// 
			this.MainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.명령을고르세요ToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(527, 30);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(123, 24);
			this.MainMenu.TabIndex = 3;
			this.MainMenu.Text = "badakMenuStrip1";
			// 
			// 명령을고르세요ToolStripMenuItem
			// 
			this.명령을고르세요ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CalculatorMenuItem,
            this.Converter1MenuItem,
            this.toolStripSeparator1,
            this.DuConsoleMenuItem,
            this.toolStripSeparator2,
            this.DuGetBlogMenuItem});
			this.명령을고르세요ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.명령을고르세요ToolStripMenuItem.Name = "명령을고르세요ToolStripMenuItem";
			this.명령을고르세요ToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
			this.명령을고르세요ToolStripMenuItem.Text = "[명령을 고르세요]";
			// 
			// CalculatorMenuItem
			// 
			this.CalculatorMenuItem.ForeColor = System.Drawing.Color.White;
			this.CalculatorMenuItem.Name = "CalculatorMenuItem";
			this.CalculatorMenuItem.Size = new System.Drawing.Size(180, 22);
			this.CalculatorMenuItem.Text = "계산기(&C)";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// DuConsoleMenuItem
			// 
			this.DuConsoleMenuItem.ForeColor = System.Drawing.Color.White;
			this.DuConsoleMenuItem.Name = "DuConsoleMenuItem";
			this.DuConsoleMenuItem.Size = new System.Drawing.Size(180, 22);
			this.DuConsoleMenuItem.Text = "콘솔 스크립트 실행";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// DuGetBlogMenuItem
			// 
			this.DuGetBlogMenuItem.ForeColor = System.Drawing.Color.White;
			this.DuGetBlogMenuItem.Name = "DuGetBlogMenuItem";
			this.DuGetBlogMenuItem.Size = new System.Drawing.Size(180, 22);
			this.DuGetBlogMenuItem.Text = "블로그 스크랩";
			// 
			// Converter1MenuItem
			// 
			this.Converter1MenuItem.ForeColor = System.Drawing.Color.White;
			this.Converter1MenuItem.Name = "Converter1MenuItem";
			this.Converter1MenuItem.Size = new System.Drawing.Size(180, 22);
			this.Converter1MenuItem.Text = "컨버터";
			// 
			// RunAsLabel
			// 
			this.RunAsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RunAsLabel.AutoSize = true;
			this.RunAsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RunAsLabel.ForeColor = System.Drawing.Color.Red;
			this.RunAsLabel.Location = new System.Drawing.Point(585, 57);
			this.RunAsLabel.Name = "RunAsLabel";
			this.RunAsLabel.Size = new System.Drawing.Size(62, 20);
			this.RunAsLabel.TabIndex = 4;
			this.RunAsLabel.Text = "RUNAS";
			this.RunAsLabel.Visible = false;
			// 
			// FrontForm
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.ClientSize = new System.Drawing.Size(650, 440);
			this.Controls.Add(this.WorkPanel);
			this.Controls.Add(this.TopPanel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MainMenuStrip = this.MainMenu;
			this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.MinimumSize = new System.Drawing.Size(400, 410);
			this.Name = "FrontForm";
			this.Text = "DuTools";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrontForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrontForm_FormClosed);
			this.Load += new System.EventHandler(this.FrontForm_Load);
			this.TopPanel.ResumeLayout(false);
			this.TopPanel.PerformLayout();
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel TopPanel;
		private Du.WinForms.BadakSystemButton SystemButton;
		private Panel WorkPanel;
		private Button TempButton;
		private Du.WinForms.BadakMenuStrip MainMenu;
		private ToolStripMenuItem 명령을고르세요ToolStripMenuItem;
		private ToolStripMenuItem CalculatorMenuItem;
		private ToolStripMenuItem Converter1MenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem DuConsoleMenuItem;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem DuGetBlogMenuItem;
		private Label RunAsLabel;
	}
}