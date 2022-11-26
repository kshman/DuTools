namespace DuTools.CommandForm
{
	partial class DuConsoleForm
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
			this.ScriptInfoText = new System.Windows.Forms.TextBox();
			this.OutputText = new System.Windows.Forms.RichTextBox();
			this.DoItButton = new Du.WinForms.BadakButton();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.panel1.Controls.Add(this.ScriptInfoText);
			this.panel1.Controls.Add(this.OutputText);
			this.panel1.Controls.Add(this.DoItButton);
			this.panel1.Controls.Add(this.TitleLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(634, 384);
			this.panel1.TabIndex = 0;
			// 
			// ScriptInfoText
			// 
			this.ScriptInfoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScriptInfoText.BackColor = System.Drawing.Color.Thistle;
			this.ScriptInfoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ScriptInfoText.Location = new System.Drawing.Point(4, 46);
			this.ScriptInfoText.Name = "ScriptInfoText";
			this.ScriptInfoText.ReadOnly = true;
			this.ScriptInfoText.Size = new System.Drawing.Size(627, 24);
			this.ScriptInfoText.TabIndex = 3;
			// 
			// OutputText
			// 
			this.OutputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputText.BackColor = System.Drawing.Color.FloralWhite;
			this.OutputText.Location = new System.Drawing.Point(4, 71);
			this.OutputText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.OutputText.Name = "OutputText";
			this.OutputText.ReadOnly = true;
			this.OutputText.Size = new System.Drawing.Size(627, 310);
			this.OutputText.TabIndex = 2;
			this.OutputText.Text = "";
			// 
			// DoItButton
			// 
			this.DoItButton.ActiveColor = System.Drawing.Color.Aquamarine;
			this.DoItButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DoItButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.DoItButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.DoItButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DoItButton.ForeColor = System.Drawing.Color.White;
			this.DoItButton.Location = new System.Drawing.Point(541, 3);
			this.DoItButton.Name = "DoItButton";
			this.DoItButton.Size = new System.Drawing.Size(90, 40);
			this.DoItButton.TabIndex = 1;
			this.DoItButton.Text = "열기";
			this.DoItButton.UseVisualStyleBackColor = false;
			this.DoItButton.Click += new System.EventHandler(this.DoItButton_Click);
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TitleLabel.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TitleLabel.Location = new System.Drawing.Point(4, 4);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(260, 39);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "(스크립트가 없어여)";
			// 
			// DuConsoleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 384);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Name = "DuConsoleForm";
			this.Text = "DuConsoleForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private BadakButton DoItButton;
		private Label TitleLabel;
		private RichTextBox OutputText;
		private TextBox ScriptInfoText;
	}
}