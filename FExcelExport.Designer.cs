namespace Household
{
	partial class FExcelExport
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
			SaveFileDialog = new SaveFileDialog();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(192, 67);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 5;
			BAccept.Text = "&Accept";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(273, 68);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 4;
			BCancel.Text = "&Cancel";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// FExcelExport
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(360, 103);
			ControlBox = false;
			Controls.Add(BAccept);
			Controls.Add(BCancel);
			Name = "FExcelExport";
			Text = "Export";
			ResumeLayout(false);
		}

		#endregion

		private Button BAccept;
		private Button BCancel;
		private SaveFileDialog SaveFileDialog;
	}
}