using DuTools.Properties;

namespace DuTools.CommandForm;

public partial class ConvertS1Form : Form
{
	private ConvTextMode _conv_text_mode = ConvTextMode.DuEnc;

	public ConvertS1Form()
	{
		InitializeComponent();

		NumDecText.Text = 0.ToString();

		DuEncRadio.Tag = ConvTextMode.DuEnc;
		DuDecRadio.Tag = ConvTextMode.DuDec;
		B64EncRadio.Tag = ConvTextMode.B64Enc;
		B64DecRadio.Tag = ConvTextMode.B64Dec;
		DuCmprRadio.Tag = ConvTextMode.DuCmpr;
		DuDcmprRadio.Tag = ConvTextMode.DuDcmpr;
		DuEncRadio.Checked = true;
	}

	private bool _num_changing;

	private void NumText_TextChanged(object sender, EventArgs e)
	{
		if (_num_changing)
			return;

		var ctrl = (TextBox)sender;
		if (ctrl.TextLength == 0)
			return;

		_num_changing = true;

		try
		{
			if (ctrl == NumDecText)
			{
				var dec = Convert.ToInt64(ctrl.Text);
				NumHexText.Text = Convert.ToString(dec, 16).ToUpper();
				NumOctText.Text = Convert.ToString(dec, 8);
				NumBinText.Text = Convert.ToString(dec, 2);
			}
			else if (ctrl == NumHexText)
			{
				var hex = Convert.ToInt64(ctrl.Text, 16);
				NumDecText.Text = hex.ToString();
				NumOctText.Text = Convert.ToString(hex, 8);
				NumBinText.Text = Convert.ToString(hex, 2);
			}
			else if (ctrl == NumOctText)
			{
				var oct = Convert.ToInt64(ctrl.Text, 8);
				NumDecText.Text = oct.ToString();
				NumHexText.Text = Convert.ToString(oct, 16).ToUpper();
				NumBinText.Text = Convert.ToString(oct, 2);
			}
			else if (ctrl == NumBinText)
			{
				var bin = Convert.ToInt64(ctrl.Text, 2);
				NumDecText.Text = bin.ToString();
				NumHexText.Text = Convert.ToString(bin, 16).ToUpper();
				NumOctText.Text = Convert.ToString(bin, 8);
			}
		}
		catch (FormatException)
		{
			// 아니 이건 그냥 나는거지
		}
		finally
		{
			_num_changing = false;
		}
	}

	private void NumText_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == Convert.ToChar(Keys.Back))
			return;

		var ctrl = (TextBox)sender;
		if (ctrl == NumDecText)
		{
			if (!char.IsBetween(e.KeyChar, '0', '9'))
				e.Handled = true;
		}
		else if (ctrl == NumHexText)
		{
			if (!char.IsAsciiHexDigit(e.KeyChar))
				e.Handled = true;
		}
		else if (ctrl == NumOctText)
		{
			if (!char.IsBetween(e.KeyChar, '0', '7'))
				e.Handled = true;
		}
		else if (ctrl == NumBinText)
		{
			if (!char.IsBetween(e.KeyChar, '0', '1'))
				e.Handled = true;
		}
	}

	private void TextBox_Click(object sender, EventArgs e)
	{
		if (!ClickToSelectCheck.Checked)
			return;

		if (sender is not TextBox ctrl)
			return;

		ctrl.SelectAll();
	}

	private void TextBox_DoubleClick(object sender, EventArgs e)
	{
		if (sender is not TextBox ctrl)
			return;

		try
		{
			Clipboard.SetText(ctrl.Text);
		}
		catch
		{
			// 처리 안함
		}
	}

	private void ConvFromText_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != Convert.ToChar(Keys.Enter))
			return;

		e.Handled = true;
		InternalConvText();
	}

	private void ConvTextRadio_CheckedChanged(object sender, EventArgs e)
	{
		var button = (RadioButton)sender;
		if (button.Tag == null) return;
		_conv_text_mode = (ConvTextMode)button.Tag;
		InternalConvText();
	}

	private static string? InternalConvText(ConvTextMode mode, string o)
	{
		try
		{
			var s = mode switch
			{
				ConvTextMode.DuEnc => Converter.EncodingString(o),
				ConvTextMode.DuDec => Converter.DecodingString(o),
				ConvTextMode.B64Enc => Converter.EncodingBase64(o),
				ConvTextMode.B64Dec => Converter.DecodingBase64(o),
				ConvTextMode.DuCmpr => Converter.CompressString(o),
				ConvTextMode.DuDcmpr => Converter.DecompressString(o),
				_ => null,
			};
			return s;
		}
		catch
		{
			return null;
		}
	}

	private void InternalConvText()
	{
		var o = ConvFromText.Text;
		if (o.Length == 0) return;

		var s = InternalConvText(_conv_text_mode, o);
		ConvToText.Text = s ?? Resources.CheckInputCannotConvert;
	}

	private void ConvSwapButton_Click(object sender, EventArgs e)
	{
		var o = ConvFromText.Text;
		if (o.Length == 0) return;

		var mode = (int)_conv_text_mode;
		var new_mode = (ConvTextMode)(mode % 2 == 0 ? mode + 1 : mode - 1);

		var s = InternalConvText(_conv_text_mode, o);
		if (s == null)
		{
			ConvToText.Text = Resources.CheckInputCannotConvert;
			return;
		}

		ConvFromText.Text = s;
		//ConvToText.Text = o;

		switch (new_mode)
		{
			case ConvTextMode.DuEnc:
				DuEncRadio.Checked = true;
				break;
			case ConvTextMode.DuDec:
				DuDecRadio.Checked = true;
				break;
			case ConvTextMode.B64Enc:
				B64EncRadio.Checked = true;
				break;
			case ConvTextMode.B64Dec:
				B64DecRadio.Checked = true;
				break;
			case ConvTextMode.DuCmpr:
				DuCmprRadio.Checked = true;
				break;
			case ConvTextMode.DuDcmpr:
				DuDcmprRadio.Checked = true;
				break;
		}
	}
}

internal enum ConvTextMode
{
	DuEnc = 0,
	DuDec = 1,
	B64Enc = 2,
	B64Dec = 3,
	DuCmpr = 4,
	DuDcmpr = 5,
}
