namespace CSharpWithFirebase
{
	partial class ProspectListForm
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.buttonUpdateProspectList = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(13, 13);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(425, 536);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// buttonUpdateProspectList
			// 
			this.buttonUpdateProspectList.Location = new System.Drawing.Point(445, 13);
			this.buttonUpdateProspectList.Name = "buttonUpdateProspectList";
			this.buttonUpdateProspectList.Size = new System.Drawing.Size(123, 23);
			this.buttonUpdateProspectList.TabIndex = 1;
			this.buttonUpdateProspectList.Text = "Update prospect list";
			this.buttonUpdateProspectList.UseVisualStyleBackColor = true;
			this.buttonUpdateProspectList.Click += new System.EventHandler(this.buttonUpdateProspectList_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(444, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 26);
			this.label1.TabIndex = 2;
			this.label1.Text = "(Pulls a fresh version of the Prospect list\r\nfrom the remote database.)\r\n";
			// 
			// ProspectListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 561);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonUpdateProspectList);
			this.Controls.Add(this.listView1);
			this.Name = "ProspectListForm";
			this.Text = "ProspectListForm";
			this.Load += new System.EventHandler(this.ProspectListForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button buttonUpdateProspectList;
		private System.Windows.Forms.Label label1;
	}
}