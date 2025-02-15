namespace Household
{
	partial class FTransactionData
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
			label1 = new Label();
			TextBoxAmount = new TextBox();
			ComboBoxAccount = new ComboBox();
			label2 = new Label();
			label3 = new Label();
			ComboBoxCategory = new ComboBox();
			BAccept = new Button();
			BCancel = new Button();
			DatePickerTransactionDate = new DateTimePicker();
			label4 = new Label();
			label5 = new Label();
			TextBoxDescription = new TextBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 14);
			label1.Name = "label1";
			label1.Size = new Size(52, 15);
			label1.TabIndex = 0;
			label1.Text = "Account";
			// 
			// TextBoxAmount
			// 
			TextBoxAmount.Location = new Point(85, 98);
			TextBoxAmount.Name = "TextBoxAmount";
			TextBoxAmount.Size = new Size(251, 23);
			TextBoxAmount.TabIndex = 3;
			// 
			// ComboBoxAccount
			// 
			ComboBoxAccount.FormattingEnabled = true;
			ComboBoxAccount.Location = new Point(85, 11);
			ComboBoxAccount.Margin = new Padding(0);
			ComboBoxAccount.Name = "ComboBoxAccount";
			ComboBoxAccount.Size = new Size(251, 23);
			ComboBoxAccount.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 101);
			label2.Name = "label2";
			label2.Size = new Size(51, 15);
			label2.TabIndex = 3;
			label2.Text = "Amount";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 43);
			label3.Name = "label3";
			label3.Size = new Size(55, 15);
			label3.TabIndex = 4;
			label3.Text = "Category";
			// 
			// ComboBoxCategory
			// 
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(85, 40);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(251, 23);
			ComboBoxCategory.TabIndex = 1;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(180, 175);
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
			BCancel.Location = new Point(261, 176);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 6;
			BCancel.Text = "&Cancel";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// DatePickerTransactionDate
			// 
			DatePickerTransactionDate.Location = new Point(85, 69);
			DatePickerTransactionDate.Name = "DatePickerTransactionDate";
			DatePickerTransactionDate.Size = new Size(251, 23);
			DatePickerTransactionDate.TabIndex = 2;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(12, 73);
			label4.Name = "label4";
			label4.Size = new Size(31, 15);
			label4.TabIndex = 9;
			label4.Text = "Date";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 130);
			label5.Name = "label5";
			label5.Size = new Size(67, 15);
			label5.TabIndex = 11;
			label5.Text = "Description";
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Location = new Point(85, 127);
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(251, 23);
			TextBoxDescription.TabIndex = 4;
			// 
			// FTransactionData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(348, 211);
			ControlBox = false;
			Controls.Add(label5);
			Controls.Add(TextBoxDescription);
			Controls.Add(label4);
			Controls.Add(DatePickerTransactionDate);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Controls.Add(ComboBoxCategory);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(ComboBoxAccount);
			Controls.Add(TextBoxAmount);
			Controls.Add(label1);
			Name = "FTransactionData";
			ShowIcon = false;
			Text = "Transaction";
			Load += FTransactionData_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox TextBoxAmount;
		private ComboBox ComboBoxAccount;
		private Label label2;
		private Label label3;
		private ComboBox ComboBoxCategory;
		private Button BAccept;
		private Button BCancel;
		private DateTimePicker DatePickerTransactionDate;
		private Label label4;
		private Label label5;
		private TextBox TextBoxDescription;
	}
}