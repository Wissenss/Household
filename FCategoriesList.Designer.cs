namespace Household
{
	partial class FCategoriesList
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			GridCategories = new DataGridView();
			toolStrip1 = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			id = new DataGridViewTextBoxColumn();
			name = new DataGridViewTextBoxColumn();
			Color = new DataGridViewTextBoxColumn();
			ColorDisplay = new DataGridViewTextBoxColumn();
			UseColor = new DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)GridCategories).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// GridCategories
			// 
			GridCategories.AllowUserToAddRows = false;
			GridCategories.AllowUserToDeleteRows = false;
			GridCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			GridCategories.BackgroundColor = SystemColors.Control;
			GridCategories.BorderStyle = BorderStyle.Fixed3D;
			GridCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
			GridCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			GridCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			GridCategories.Columns.AddRange(new DataGridViewColumn[] { id, name, Color, ColorDisplay, UseColor });
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			GridCategories.DefaultCellStyle = dataGridViewCellStyle2;
			GridCategories.EnableHeadersVisualStyles = false;
			GridCategories.Location = new Point(5, 32);
			GridCategories.Margin = new Padding(0);
			GridCategories.MultiSelect = false;
			GridCategories.Name = "GridCategories";
			GridCategories.ReadOnly = true;
			GridCategories.RowHeadersVisible = false;
			GridCategories.RowTemplate.Height = 20;
			GridCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			GridCategories.ShowEditingIcon = false;
			GridCategories.Size = new Size(284, 274);
			GridCategories.TabIndex = 3;
			GridCategories.CellFormatting += GridCategories_CellFormatting;
			// 
			// toolStrip1
			// 
			toolStrip1.BackColor = SystemColors.ControlLightLight;
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAdd, BEdit });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(294, 25);
			toolStrip1.TabIndex = 2;
			toolStrip1.Text = "toolStrip1";
			// 
			// BAdd
			// 
			BAdd.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAdd.Name = "BAdd";
			BAdd.Size = new Size(49, 22);
			BAdd.Text = "Add";
			BAdd.Click += BAdd_Click;
			// 
			// BEdit
			// 
			BEdit.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEdit.Name = "BEdit";
			BEdit.Size = new Size(47, 22);
			BEdit.Text = "Edit";
			BEdit.Click += BEdit_Click;
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
			// colColor
			// 
			Color.DataPropertyName = "color";
			Color.HeaderText = "Color";
			Color.Name = "Color";
			Color.ReadOnly = true;
			Color.Visible = false;
			// 
			// ColorDisplay
			// 
			ColorDisplay.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			ColorDisplay.HeaderText = "Color";
			ColorDisplay.Name = "ColorDisplay";
			ColorDisplay.ReadOnly = true;
			// 
			// UseColor
			// 
			UseColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			UseColor.DataPropertyName = "use_color";
			UseColor.HeaderText = "Use color";
			UseColor.Name = "UseColor";
			UseColor.ReadOnly = true;
			UseColor.Resizable = DataGridViewTriState.True;
			UseColor.SortMode = DataGridViewColumnSortMode.Automatic;
			UseColor.Width = 65;
			// 
			// FCategoriesList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(294, 311);
			Controls.Add(GridCategories);
			Controls.Add(toolStrip1);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FCategoriesList";
			ShowIcon = false;
			Text = "Categories";
			((System.ComponentModel.ISupportInitialize)GridCategories).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView GridCategories;
		private ToolStrip toolStrip1;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private DataGridViewTextBoxColumn id;
		private DataGridViewTextBoxColumn name;
		private DataGridViewTextBoxColumn Color;
		private DataGridViewTextBoxColumn ColorDisplay;
		private DataGridViewCheckBoxColumn UseColor;
	}
}