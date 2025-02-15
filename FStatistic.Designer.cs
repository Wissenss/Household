namespace Household
{
	partial class FStatistic
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			ChartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)ChartMain).BeginInit();
			SuspendLayout();
			// 
			// ChartMain
			// 
			chartArea1.AxisX.LabelStyle.ForeColor = SystemColors.ControlDark;
			chartArea1.AxisX.LineColor = SystemColors.ControlDark;
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisX.MajorGrid.LineColor = SystemColors.ControlDark;
			chartArea1.AxisX.MajorTickMark.LineColor = SystemColors.ControlDark;
			chartArea1.AxisY.LabelStyle.ForeColor = SystemColors.ControlDark;
			chartArea1.AxisY.LineColor = SystemColors.ControlDark;
			chartArea1.AxisY.MajorGrid.LineColor = SystemColors.ControlDark;
			chartArea1.AxisY.MajorTickMark.LineColor = SystemColors.ControlDark;
			chartArea1.AxisY.MinorGrid.LineColor = SystemColors.ControlDark;
			chartArea1.AxisY.MinorTickMark.LineColor = SystemColors.ControlDark;
			chartArea1.BorderColor = Color.Gainsboro;
			chartArea1.Name = "ChartArea1";
			ChartMain.ChartAreas.Add(chartArea1);
			ChartMain.Dock = DockStyle.Fill;
			ChartMain.Location = new Point(0, 0);
			ChartMain.Name = "ChartMain";
			ChartMain.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
			series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			ChartMain.Series.Add(series1);
			ChartMain.Size = new Size(617, 261);
			ChartMain.TabIndex = 0;
			ChartMain.Text = "Accumulated";
			// 
			// FStatistic
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(617, 261);
			Controls.Add(ChartMain);
			Name = "FStatistic";
			ShowIcon = false;
			Text = "Stadistics - Accumulated";
			Load += FStatistic_Load;
			((System.ComponentModel.ISupportInitialize)ChartMain).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart ChartMain;
	}
}