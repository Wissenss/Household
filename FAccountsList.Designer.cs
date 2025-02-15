namespace Household
{
	partial class FAccountsList
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
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			toolStrip1 = new ToolStrip();
			BAdd = new ToolStripButton();
			GridAccounts = new DataGridView();
			id = new DataGridViewTextBoxColumn();
			name = new DataGridViewTextBoxColumn();
			balance = new DataGridViewTextBoxColumn();
			BEdit = new ToolStripButton();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)GridAccounts).BeginInit();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.BackColor = SystemColors.Control;
			toolStrip1.GripMargin = new Padding(0);
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAdd, BEdit });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Padding = new Padding(5, 3, 5, 0);
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(334, 26);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			// 
			// BAdd
			// 
			BAdd.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_32;
			BAdd.ImageTransparentColor = Color.Magenta;
			BAdd.Name = "BAdd";
			BAdd.Size = new Size(49, 20);
			BAdd.Text = "Add";
			BAdd.Click += BAdd_Click;
			// 
			// GridAccounts
			// 
			GridAccounts.AllowUserToAddRows = false;
			GridAccounts.AllowUserToDeleteRows = false;
			GridAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			GridAccounts.BackgroundColor = SystemColors.Control;
			GridAccounts.BorderStyle = BorderStyle.Fixed3D;
			GridAccounts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = SystemColors.Control;
			dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
			GridAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			GridAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			GridAccounts.Columns.AddRange(new DataGridViewColumn[] { id, name, balance });
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = SystemColors.Window;
			dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle9.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle9.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
			GridAccounts.DefaultCellStyle = dataGridViewCellStyle9;
			GridAccounts.EnableHeadersVisualStyles = false;
			GridAccounts.Location = new Point(5, 31);
			GridAccounts.Margin = new Padding(0);
			GridAccounts.MultiSelect = false;
			GridAccounts.Name = "GridAccounts";
			GridAccounts.ReadOnly = true;
			GridAccounts.RowHeadersVisible = false;
			GridAccounts.RowTemplate.Height = 20;
			GridAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			GridAccounts.ShowEditingIcon = false;
			GridAccounts.Size = new Size(324, 278);
			GridAccounts.TabIndex = 1;
			GridAccounts.CellFormatting += GridAccounts_CellFormatting;
			// 
			// id
			// 
			id.DataPropertyName = "id";
			id.HeaderText = "Id";
			id.Name = "id";
			id.ReadOnly = true;
			id.Visible = false;
			// 
			// name
			// 
			name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			name.DataPropertyName = "name";
			name.FillWeight = 98.47716F;
			name.HeaderText = "Name";
			name.Name = "name";
			name.ReadOnly = true;
			// 
			// balance
			// 
			balance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			balance.DataPropertyName = "balance";
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "C2";
			dataGridViewCellStyle8.NullValue = "0.00";
			balance.DefaultCellStyle = dataGridViewCellStyle8;
			balance.FillWeight = 101.522842F;
			balance.HeaderText = "Balance";
			balance.Name = "balance";
			balance.ReadOnly = true;
			// 
			// BEdit
			// 
			BEdit.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEdit.ImageTransparentColor = Color.Magenta;
			BEdit.Name = "BEdit";
			BEdit.Size = new Size(47, 20);
			BEdit.Text = "Edit";
			BEdit.Click += BEdit_Click;
			// 
			// FAccountsList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(334, 314);
			Controls.Add(GridAccounts);
			Controls.Add(toolStrip1);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FAccountsList";
			ShowIcon = false;
			Text = "Accounts";
			Load += FAccountsList_Load;
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)GridAccounts).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
		private ToolStripButton BAdd;
		private DataGridView GridAccounts;
		private DataGridViewTextBoxColumn id;
		private DataGridViewTextBoxColumn name;
		private DataGridViewTextBoxColumn balance;
		private ToolStripButton BEdit;
	}
}