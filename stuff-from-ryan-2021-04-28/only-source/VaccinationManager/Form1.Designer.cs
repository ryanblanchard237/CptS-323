namespace VaccinationManager
{
	partial class Form1
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
			this.prospect_list = new System.Windows.Forms.ListView();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// prospect_list
			// 
			this.prospect_list.HideSelection = false;
			this.prospect_list.Location = new System.Drawing.Point(12, 12);
			this.prospect_list.Name = "prospect_list";
			this.prospect_list.Size = new System.Drawing.Size(352, 399);
			this.prospect_list.TabIndex = 0;
			this.prospect_list.UseCompatibleStateImageBehavior = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(370, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Update prospect list";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(371, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 26);
			this.label1.TabIndex = 2;
			this.label1.Text = "(Pulls a fresh version of the Prospect list\r\nfrom the remote database.)\r\n";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 569);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.prospect_list);
			this.Name = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView prospect_list;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}

