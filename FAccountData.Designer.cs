namespace Household
{
	partial class FAccountData
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
			TextBoxName = new TextBox();
			LName = new Label();
			BCancel = new Button();
			BAccept = new Button();
			CheckBoxUseColor = new CheckBox();
			PanelColor = new Panel();
			ColorDialog = new ColorDialog();
			SuspendLayout();
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(57, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(252, 23);
			TextBoxName.TabIndex = 0;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(12, 15);
			LName.Name = "LName";
			LName.Size = new Size(39, 15);
			LName.TabIndex = 1;
			LName.Text = "Name";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(227, 148);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 2;
			BCancel.Text = "&Cancel";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(146, 147);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
			BAccept.Text = "&Accept";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// CheckBoxUseColor
			// 
			CheckBoxUseColor.AutoSize = true;
			CheckBoxUseColor.Location = new Point(12, 41);
			CheckBoxUseColor.Name = "CheckBoxUseColor";
			CheckBoxUseColor.Size = new Size(75, 19);
			CheckBoxUseColor.TabIndex = 11;
			CheckBoxUseColor.Text = "Use color";
			CheckBoxUseColor.UseVisualStyleBackColor = true;
			// 
			// PanelColor
			// 
			PanelColor.BorderStyle = BorderStyle.FixedSingle;
			PanelColor.Cursor = Cursors.Cross;
			PanelColor.Location = new Point(12, 66);
			PanelColor.Name = "PanelColor";
			PanelColor.Size = new Size(297, 70);
			PanelColor.TabIndex = 10;
			PanelColor.Click += PanelColor_Click;
			// 
			// FAccountData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(314, 183);
			Controls.Add(CheckBoxUseColor);
			Controls.Add(PanelColor);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Controls.Add(LName);
			Controls.Add(TextBoxName);
			Name = "FAccountData";
			ShowIcon = false;
			Text = "Account - Account Name";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox TextBoxName;
		private Label LName;
		private Button BCancel;
		private Button BAccept;
		private CheckBox CheckBoxUseColor;
		private Panel PanelColor;
		private ColorDialog ColorDialog;
	}
}