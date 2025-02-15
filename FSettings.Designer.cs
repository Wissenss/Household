namespace Household
{
	partial class FSettings
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
			TabControlSettings = new TabControl();
			TabPageFinanceSettings = new TabPage();
			GroupBoxMainDisplay = new GroupBox();
			CheckBoxHighlightTransactionsPeroCategory = new CheckBox();
			label1 = new Label();
			ComboBoxAnalysisPeriod = new ComboBox();
			CheckBoxHighlightSelectedAccountTransactions = new CheckBox();
			TabControlSettings.SuspendLayout();
			TabPageFinanceSettings.SuspendLayout();
			GroupBoxMainDisplay.SuspendLayout();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(196, 218);
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
			BCancel.Location = new Point(277, 219);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 4;
			BCancel.Text = "&Cancel";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// TabControlSettings
			// 
			TabControlSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlSettings.Controls.Add(TabPageFinanceSettings);
			TabControlSettings.Location = new Point(0, 0);
			TabControlSettings.Name = "TabControlSettings";
			TabControlSettings.SelectedIndex = 0;
			TabControlSettings.Size = new Size(362, 213);
			TabControlSettings.TabIndex = 6;
			// 
			// TabPageFinanceSettings
			// 
			TabPageFinanceSettings.Controls.Add(GroupBoxMainDisplay);
			TabPageFinanceSettings.Location = new Point(4, 24);
			TabPageFinanceSettings.Name = "TabPageFinanceSettings";
			TabPageFinanceSettings.Padding = new Padding(3);
			TabPageFinanceSettings.Size = new Size(354, 185);
			TabPageFinanceSettings.TabIndex = 0;
			TabPageFinanceSettings.Text = "Finance";
			TabPageFinanceSettings.UseVisualStyleBackColor = true;
			// 
			// GroupBoxMainDisplay
			// 
			GroupBoxMainDisplay.Controls.Add(CheckBoxHighlightSelectedAccountTransactions);
			GroupBoxMainDisplay.Controls.Add(CheckBoxHighlightTransactionsPeroCategory);
			GroupBoxMainDisplay.Controls.Add(label1);
			GroupBoxMainDisplay.Controls.Add(ComboBoxAnalysisPeriod);
			GroupBoxMainDisplay.Location = new Point(8, 6);
			GroupBoxMainDisplay.Name = "GroupBoxMainDisplay";
			GroupBoxMainDisplay.Size = new Size(340, 173);
			GroupBoxMainDisplay.TabIndex = 0;
			GroupBoxMainDisplay.TabStop = false;
			GroupBoxMainDisplay.Text = "Main display";
			// 
			// CheckBoxHighlightTransactionsPeroCategory
			// 
			CheckBoxHighlightTransactionsPeroCategory.AutoSize = true;
			CheckBoxHighlightTransactionsPeroCategory.Location = new Point(6, 22);
			CheckBoxHighlightTransactionsPeroCategory.Name = "CheckBoxHighlightTransactionsPeroCategory";
			CheckBoxHighlightTransactionsPeroCategory.Size = new Size(238, 19);
			CheckBoxHighlightTransactionsPeroCategory.TabIndex = 2;
			CheckBoxHighlightTransactionsPeroCategory.Text = "Highlight selected category transactions";
			CheckBoxHighlightTransactionsPeroCategory.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 75);
			label1.Name = "label1";
			label1.Size = new Size(87, 15);
			label1.TabIndex = 1;
			label1.Text = "Analysis period";
			// 
			// ComboBoxAnalysisPeriod
			// 
			ComboBoxAnalysisPeriod.FormattingEnabled = true;
			ComboBoxAnalysisPeriod.Location = new Point(99, 72);
			ComboBoxAnalysisPeriod.Name = "ComboBoxAnalysisPeriod";
			ComboBoxAnalysisPeriod.Size = new Size(235, 23);
			ComboBoxAnalysisPeriod.TabIndex = 0;
			ComboBoxAnalysisPeriod.SelectedIndexChanged += ComboBoxAnalysisPeriod_SelectedIndexChanged;
			// 
			// CheckBoxHighlightSelectedAccountTransactions
			// 
			CheckBoxHighlightSelectedAccountTransactions.AutoSize = true;
			CheckBoxHighlightSelectedAccountTransactions.Location = new Point(6, 47);
			CheckBoxHighlightSelectedAccountTransactions.Name = "CheckBoxHighlightSelectedAccountTransactions";
			CheckBoxHighlightSelectedAccountTransactions.Size = new Size(235, 19);
			CheckBoxHighlightSelectedAccountTransactions.TabIndex = 3;
			CheckBoxHighlightSelectedAccountTransactions.Text = "Highlight selected account transactions";
			CheckBoxHighlightSelectedAccountTransactions.UseVisualStyleBackColor = true;
			// 
			// FSettings
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(364, 254);
			ControlBox = false;
			Controls.Add(TabControlSettings);
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Name = "FSettings";
			ShowIcon = false;
			Text = "Settings";
			Load += FSettings_Load;
			TabControlSettings.ResumeLayout(false);
			TabPageFinanceSettings.ResumeLayout(false);
			GroupBoxMainDisplay.ResumeLayout(false);
			GroupBoxMainDisplay.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button BAccept;
		private Button BCancel;
		private TabControl TabControlSettings;
		private TabPage TabPageFinanceSettings;
		private GroupBox GroupBoxMainDisplay;
		private Label label1;
		private ComboBox ComboBoxAnalysisPeriod;
		private CheckBox CheckBoxHighlightTransactionsPeroCategory;
		private CheckBox CheckBoxHighlightSelectedAccountTransactions;
	}
}