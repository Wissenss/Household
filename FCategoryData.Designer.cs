namespace Household
{
	partial class FCategoryData
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
			BAccept = new Button();
			BCancel = new Button();
			LName = new Label();
			TextBoxName = new TextBox();
			ColorDialog = new ColorDialog();
			PanelColor = new Panel();
			CheckBoxUseColor = new CheckBox();
			CheckBoxUsePercentage = new CheckBox();
			label1 = new Label();
			NumericPercentage = new NumericUpDown();
			label2 = new Label();
			ComboBoxCondition = new ComboBox();
			((System.ComponentModel.ISupportInitialize)NumericPercentage).BeginInit();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(146, 237);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 5;
			BAccept.Text = "&Accept";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(227, 238);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 4;
			BCancel.Text = "&Cancel";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(5, 15);
			LName.Name = "LName";
			LName.Size = new Size(39, 15);
			LName.TabIndex = 7;
			LName.Text = "Name";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(86, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(216, 23);
			TextBoxName.TabIndex = 6;
			// 
			// PanelColor
			// 
			PanelColor.BorderStyle = BorderStyle.FixedSingle;
			PanelColor.Cursor = Cursors.Cross;
			PanelColor.Location = new Point(5, 66);
			PanelColor.Name = "PanelColor";
			PanelColor.Size = new Size(297, 70);
			PanelColor.TabIndex = 8;
			PanelColor.Click += PanelColor_Click;
			// 
			// CheckBoxUseColor
			// 
			CheckBoxUseColor.AutoSize = true;
			CheckBoxUseColor.Location = new Point(5, 41);
			CheckBoxUseColor.Name = "CheckBoxUseColor";
			CheckBoxUseColor.Size = new Size(75, 19);
			CheckBoxUseColor.TabIndex = 9;
			CheckBoxUseColor.Text = "Use color";
			CheckBoxUseColor.UseVisualStyleBackColor = true;
			CheckBoxUseColor.CheckedChanged += CheckBoxUseColor_CheckedChanged;
			// 
			// CheckBoxUsePercentage
			// 
			CheckBoxUsePercentage.AutoSize = true;
			CheckBoxUsePercentage.Location = new Point(5, 147);
			CheckBoxUsePercentage.Name = "CheckBoxUsePercentage";
			CheckBoxUsePercentage.Size = new Size(161, 19);
			CheckBoxUsePercentage.TabIndex = 10;
			CheckBoxUsePercentage.Text = "Use percentage condition";
			CheckBoxUsePercentage.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(5, 174);
			label1.Name = "label1";
			label1.Size = new Size(66, 15);
			label1.TabIndex = 11;
			label1.Text = "Percentage";
			// 
			// NumericPercentage
			// 
			NumericPercentage.DecimalPlaces = 2;
			NumericPercentage.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			NumericPercentage.Location = new Point(86, 172);
			NumericPercentage.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
			NumericPercentage.Name = "NumericPercentage";
			NumericPercentage.Size = new Size(80, 23);
			NumericPercentage.TabIndex = 12;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(5, 204);
			label2.Name = "label2";
			label2.Size = new Size(60, 15);
			label2.TabIndex = 13;
			label2.Text = "Condition";
			// 
			// ComboBoxCondition
			// 
			ComboBoxCondition.FormattingEnabled = true;
			ComboBoxCondition.Location = new Point(86, 201);
			ComboBoxCondition.Name = "ComboBoxCondition";
			ComboBoxCondition.Size = new Size(216, 23);
			ComboBoxCondition.TabIndex = 14;
			// 
			// FCategoryData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(314, 273);
			ControlBox = false;
			Controls.Add(ComboBoxCondition);
			Controls.Add(label2);
			Controls.Add(NumericPercentage);
			Controls.Add(label1);
			Controls.Add(CheckBoxUsePercentage);
			Controls.Add(CheckBoxUseColor);
			Controls.Add(PanelColor);
			Controls.Add(LName);
			Controls.Add(TextBoxName);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Name = "FCategoryData";
			ShowIcon = false;
			Text = "Category";
			((System.ComponentModel.ISupportInitialize)NumericPercentage).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button BAccept;
		private Button BCancel;
		private Label LName;
		private TextBox TextBoxName;
		private ColorDialog ColorDialog;
		private Panel PanelColor;
		private CheckBox CheckBoxUseColor;
		private CheckBox CheckBoxUsePercentage;
		private Label label1;
		private NumericUpDown NumericPercentage;
		private Label label2;
		private ComboBox ComboBoxCondition;
	}
}