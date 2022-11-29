namespace DuTools.CommandForm
{
	partial class ConvertS1Form
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
			this.ClickToSelectCheck = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ConvSwapButton = new Du.WinForms.BadakButton();
			this.ConvToText = new System.Windows.Forms.TextBox();
			this.DuDcmprRadio = new System.Windows.Forms.RadioButton();
			this.DuCmprRadio = new System.Windows.Forms.RadioButton();
			this.B64DecRadio = new System.Windows.Forms.RadioButton();
			this.B64EncRadio = new System.Windows.Forms.RadioButton();
			this.DuDecRadio = new System.Windows.Forms.RadioButton();
			this.ConvFromText = new System.Windows.Forms.TextBox();
			this.DuEncRadio = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.NumDecText = new System.Windows.Forms.TextBox();
			this.NumHexText = new System.Windows.Forms.TextBox();
			this.NumOctText = new System.Windows.Forms.TextBox();
			this.NumBinText = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.ClickToSelectCheck);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(604, 461);
			this.panel1.TabIndex = 0;
			// 
			// ClickToSelectCheck
			// 
			this.ClickToSelectCheck.AutoSize = true;
			this.ClickToSelectCheck.Checked = true;
			this.ClickToSelectCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ClickToSelectCheck.Location = new System.Drawing.Point(3, 3);
			this.ClickToSelectCheck.Name = "ClickToSelectCheck";
			this.ClickToSelectCheck.Size = new System.Drawing.Size(139, 22);
			this.ClickToSelectCheck.TabIndex = 2;
			this.ClickToSelectCheck.Text = "클릭으로 선택 모드";
			this.ClickToSelectCheck.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Thistle;
			this.label5.Location = new System.Drawing.Point(333, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(266, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "※ 각 항목은더블 클릭으로 복사할 수 있어요!";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.ConvSwapButton);
			this.groupBox2.Controls.Add(this.ConvToText);
			this.groupBox2.Controls.Add(this.DuDcmprRadio);
			this.groupBox2.Controls.Add(this.DuCmprRadio);
			this.groupBox2.Controls.Add(this.B64DecRadio);
			this.groupBox2.Controls.Add(this.B64EncRadio);
			this.groupBox2.Controls.Add(this.DuDecRadio);
			this.groupBox2.Controls.Add(this.ConvFromText);
			this.groupBox2.Controls.Add(this.DuEncRadio);
			this.groupBox2.Location = new System.Drawing.Point(3, 125);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(598, 141);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "문자열 변환";
			// 
			// ConvSwapButton
			// 
			this.ConvSwapButton.ActiveColor = System.Drawing.Color.Aquamarine;
			this.ConvSwapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ConvSwapButton.BackColor = System.Drawing.Color.Transparent;
			this.ConvSwapButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
			this.ConvSwapButton.FlatAppearance.BorderSize = 0;
			this.ConvSwapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.ConvSwapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConvSwapButton.ForeColor = System.Drawing.Color.White;
			this.ConvSwapButton.Image = global::DuTools.Properties.Resources.icon_swap_arrow;
			this.ConvSwapButton.Location = new System.Drawing.Point(513, 53);
			this.ConvSwapButton.Name = "ConvSwapButton";
			this.ConvSwapButton.Size = new System.Drawing.Size(75, 50);
			this.ConvSwapButton.TabIndex = 8;
			this.ConvSwapButton.UseVisualStyleBackColor = false;
			this.ConvSwapButton.Click += new System.EventHandler(this.ConvSwapButton_Click);
			// 
			// ConvToText
			// 
			this.ConvToText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConvToText.BackColor = System.Drawing.Color.LavenderBlush;
			this.ConvToText.Location = new System.Drawing.Point(6, 109);
			this.ConvToText.Name = "ConvToText";
			this.ConvToText.ReadOnly = true;
			this.ConvToText.Size = new System.Drawing.Size(586, 24);
			this.ConvToText.TabIndex = 7;
			this.ConvToText.Click += new System.EventHandler(this.TextBox_Click);
			this.ConvToText.DoubleClick += new System.EventHandler(this.TextBox_DoubleClick);
			// 
			// DuDcmprRadio
			// 
			this.DuDcmprRadio.AutoSize = true;
			this.DuDcmprRadio.ForeColor = System.Drawing.Color.LightSalmon;
			this.DuDcmprRadio.Location = new System.Drawing.Point(252, 81);
			this.DuDcmprRadio.Name = "DuDcmprRadio";
			this.DuDcmprRadio.Size = new System.Drawing.Size(95, 22);
			this.DuDcmprRadio.TabIndex = 6;
			this.DuDcmprRadio.TabStop = true;
			this.DuDcmprRadio.Text = "압축 디코딩";
			this.DuDcmprRadio.UseVisualStyleBackColor = true;
			this.DuDcmprRadio.CheckedChanged += new System.EventHandler(this.ConvTextRadio_CheckedChanged);
			// 
			// DuCmprRadio
			// 
			this.DuCmprRadio.AutoSize = true;
			this.DuCmprRadio.ForeColor = System.Drawing.Color.LightSalmon;
			this.DuCmprRadio.Location = new System.Drawing.Point(252, 53);
			this.DuCmprRadio.Name = "DuCmprRadio";
			this.DuCmprRadio.Size = new System.Drawing.Size(95, 22);
			this.DuCmprRadio.TabIndex = 5;
			this.DuCmprRadio.TabStop = true;
			this.DuCmprRadio.Text = "압축 인코딩";
			this.DuCmprRadio.UseVisualStyleBackColor = true;
			this.DuCmprRadio.CheckedChanged += new System.EventHandler(this.ConvTextRadio_CheckedChanged);
			// 
			// B64DecRadio
			// 
			this.B64DecRadio.AutoSize = true;
			this.B64DecRadio.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.B64DecRadio.Location = new System.Drawing.Point(113, 81);
			this.B64DecRadio.Name = "B64DecRadio";
			this.B64DecRadio.Size = new System.Drawing.Size(124, 22);
			this.B64DecRadio.TabIndex = 4;
			this.B64DecRadio.TabStop = true;
			this.B64DecRadio.Text = "BASE64 디코딩";
			this.B64DecRadio.UseVisualStyleBackColor = true;
			this.B64DecRadio.CheckedChanged += new System.EventHandler(this.ConvTextRadio_CheckedChanged);
			// 
			// B64EncRadio
			// 
			this.B64EncRadio.AutoSize = true;
			this.B64EncRadio.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.B64EncRadio.Location = new System.Drawing.Point(113, 53);
			this.B64EncRadio.Name = "B64EncRadio";
			this.B64EncRadio.Size = new System.Drawing.Size(124, 22);
			this.B64EncRadio.TabIndex = 3;
			this.B64EncRadio.TabStop = true;
			this.B64EncRadio.Text = "BASE64 인코딩";
			this.B64EncRadio.UseVisualStyleBackColor = true;
			this.B64EncRadio.CheckedChanged += new System.EventHandler(this.ConvTextRadio_CheckedChanged);
			// 
			// DuDecRadio
			// 
			this.DuDecRadio.AutoSize = true;
			this.DuDecRadio.ForeColor = System.Drawing.Color.LightGreen;
			this.DuDecRadio.Location = new System.Drawing.Point(6, 81);
			this.DuDecRadio.Name = "DuDecRadio";
			this.DuDecRadio.Size = new System.Drawing.Size(95, 22);
			this.DuDecRadio.TabIndex = 2;
			this.DuDecRadio.TabStop = true;
			this.DuDecRadio.Text = "기본 디코딩";
			this.DuDecRadio.UseVisualStyleBackColor = true;
			this.DuDecRadio.CheckedChanged += new System.EventHandler(this.ConvTextRadio_CheckedChanged);
			// 
			// ConvFromText
			// 
			this.ConvFromText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConvFromText.Location = new System.Drawing.Point(6, 23);
			this.ConvFromText.Name = "ConvFromText";
			this.ConvFromText.Size = new System.Drawing.Size(586, 24);
			this.ConvFromText.TabIndex = 1;
			this.ConvFromText.Click += new System.EventHandler(this.TextBox_Click);
			this.ConvFromText.DoubleClick += new System.EventHandler(this.TextBox_DoubleClick);
			this.ConvFromText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConvFromText_KeyPress);
			// 
			// DuEncRadio
			// 
			this.DuEncRadio.AutoSize = true;
			this.DuEncRadio.ForeColor = System.Drawing.Color.LightGreen;
			this.DuEncRadio.Location = new System.Drawing.Point(6, 53);
			this.DuEncRadio.Name = "DuEncRadio";
			this.DuEncRadio.Size = new System.Drawing.Size(95, 22);
			this.DuEncRadio.TabIndex = 0;
			this.DuEncRadio.TabStop = true;
			this.DuEncRadio.Text = "기본 인코딩";
			this.DuEncRadio.UseVisualStyleBackColor = true;
			this.DuEncRadio.CheckedChanged += new System.EventHandler(this.ConvTextRadio_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(3, 26);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(598, 93);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "숫자 변환";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.NumDecText, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.NumHexText, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.NumOctText, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.NumBinText, 3, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 23);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 62);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.ForeColor = System.Drawing.Color.PaleTurquoise;
			this.label1.Location = new System.Drawing.Point(4, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "10진수";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.ForeColor = System.Drawing.Color.Violet;
			this.label2.Location = new System.Drawing.Point(121, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "16진수";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.ForeColor = System.Drawing.Color.Yellow;
			this.label3.Location = new System.Drawing.Point(238, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 29);
			this.label3.TabIndex = 2;
			this.label3.Text = "8진수";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label4.Location = new System.Drawing.Point(355, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(227, 29);
			this.label4.TabIndex = 3;
			this.label4.Text = "2진수";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NumDecText
			// 
			this.NumDecText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumDecText.Location = new System.Drawing.Point(4, 34);
			this.NumDecText.Name = "NumDecText";
			this.NumDecText.Size = new System.Drawing.Size(110, 24);
			this.NumDecText.TabIndex = 4;
			this.NumDecText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumDecText.Click += new System.EventHandler(this.TextBox_Click);
			this.NumDecText.TextChanged += new System.EventHandler(this.NumText_TextChanged);
			this.NumDecText.DoubleClick += new System.EventHandler(this.TextBox_DoubleClick);
			this.NumDecText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumText_KeyPress);
			// 
			// NumHexText
			// 
			this.NumHexText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumHexText.Location = new System.Drawing.Point(121, 34);
			this.NumHexText.Name = "NumHexText";
			this.NumHexText.Size = new System.Drawing.Size(110, 24);
			this.NumHexText.TabIndex = 5;
			this.NumHexText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumHexText.Click += new System.EventHandler(this.TextBox_Click);
			this.NumHexText.TextChanged += new System.EventHandler(this.NumText_TextChanged);
			this.NumHexText.DoubleClick += new System.EventHandler(this.TextBox_DoubleClick);
			this.NumHexText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumText_KeyPress);
			// 
			// NumOctText
			// 
			this.NumOctText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumOctText.Location = new System.Drawing.Point(238, 34);
			this.NumOctText.Name = "NumOctText";
			this.NumOctText.Size = new System.Drawing.Size(110, 24);
			this.NumOctText.TabIndex = 6;
			this.NumOctText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumOctText.Click += new System.EventHandler(this.TextBox_Click);
			this.NumOctText.TextChanged += new System.EventHandler(this.NumText_TextChanged);
			this.NumOctText.DoubleClick += new System.EventHandler(this.TextBox_DoubleClick);
			this.NumOctText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumText_KeyPress);
			// 
			// NumBinText
			// 
			this.NumBinText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumBinText.Location = new System.Drawing.Point(355, 34);
			this.NumBinText.Name = "NumBinText";
			this.NumBinText.Size = new System.Drawing.Size(227, 24);
			this.NumBinText.TabIndex = 7;
			this.NumBinText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.NumBinText.Click += new System.EventHandler(this.TextBox_Click);
			this.NumBinText.TextChanged += new System.EventHandler(this.NumText_TextChanged);
			this.NumBinText.DoubleClick += new System.EventHandler(this.TextBox_DoubleClick);
			this.NumBinText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumText_KeyPress);
			// 
			// ConvertS1Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(604, 461);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.SystemColors.Control;
			this.Name = "ConvertS1Form";
			this.Text = "ConvertS1";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private GroupBox groupBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBox NumDecText;
		private TextBox NumHexText;
		private TextBox NumOctText;
		private TextBox NumBinText;
		private Label label5;
		private GroupBox groupBox2;
		private RadioButton DuEncRadio;
		private TextBox ConvFromText;
		private TextBox ConvToText;
		private RadioButton DuDcmprRadio;
		private RadioButton DuCmprRadio;
		private RadioButton B64DecRadio;
		private RadioButton B64EncRadio;
		private RadioButton DuDecRadio;
		private CheckBox ClickToSelectCheck;
		private BadakButton ConvSwapButton;
	}
}