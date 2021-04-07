namespace CSharpWithFirebase
{
	partial class MapForm
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
			this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
			this.buttonStartFirebaseForm = new System.Windows.Forms.Button();
			this.buttonProspectListForm = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// gMapControl1
			// 
			this.gMapControl1.Bearing = 0F;
			this.gMapControl1.CanDragMap = true;
			this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
			this.gMapControl1.GrayScaleMode = false;
			this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gMapControl1.LevelsKeepInMemmory = 5;
			this.gMapControl1.Location = new System.Drawing.Point(12, 12);
			this.gMapControl1.MarkersEnabled = true;
			this.gMapControl1.MaxZoom = 18;
			this.gMapControl1.MinZoom = 2;
			this.gMapControl1.MouseWheelZoomEnabled = true;
			this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gMapControl1.Name = "gMapControl1";
			this.gMapControl1.NegativeMode = false;
			this.gMapControl1.PolygonsEnabled = true;
			this.gMapControl1.RetryLoadTile = 0;
			this.gMapControl1.RoutesEnabled = true;
			this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gMapControl1.ShowTileGridLines = false;
			this.gMapControl1.Size = new System.Drawing.Size(450, 450);
			this.gMapControl1.TabIndex = 0;
			this.gMapControl1.Zoom = 12D;
			this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
			// 
			// buttonStartFirebaseForm
			// 
			this.buttonStartFirebaseForm.Location = new System.Drawing.Point(468, 12);
			this.buttonStartFirebaseForm.Name = "buttonStartFirebaseForm";
			this.buttonStartFirebaseForm.Size = new System.Drawing.Size(136, 23);
			this.buttonStartFirebaseForm.TabIndex = 1;
			this.buttonStartFirebaseForm.Text = "TalkToFirebaseForm";
			this.buttonStartFirebaseForm.UseVisualStyleBackColor = true;
			this.buttonStartFirebaseForm.Click += new System.EventHandler(this.buttonStartForm2_Click);
			// 
			// buttonProspectListForm
			// 
			this.buttonProspectListForm.Location = new System.Drawing.Point(468, 41);
			this.buttonProspectListForm.Name = "buttonProspectListForm";
			this.buttonProspectListForm.Size = new System.Drawing.Size(136, 23);
			this.buttonProspectListForm.TabIndex = 2;
			this.buttonProspectListForm.Text = "ProspectListForm";
			this.buttonProspectListForm.UseVisualStyleBackColor = true;
			this.buttonProspectListForm.Click += new System.EventHandler(this.buttonProspectListForm_Click);
			// 
			// MapForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 511);
			this.Controls.Add(this.buttonProspectListForm);
			this.Controls.Add(this.buttonStartFirebaseForm);
			this.Controls.Add(this.gMapControl1);
			this.Name = "MapForm";
			this.Text = "Map Form";
			this.ResumeLayout(false);

		}

		#endregion

		private GMap.NET.WindowsForms.GMapControl gMapControl1;
		private System.Windows.Forms.Button buttonStartFirebaseForm;
		private System.Windows.Forms.Button buttonProspectListForm;
	}
}