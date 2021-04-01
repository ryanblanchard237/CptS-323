namespace CSharpWithFirebase
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
			this.keyTextBox = new System.Windows.Forms.TextBox();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.label_key = new System.Windows.Forms.Label();
			this.label_value = new System.Windows.Forms.Label();
			this.buttonInsert = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.textBoxStudentName = new System.Windows.Forms.TextBox();
			this.textBoxStudentRollNo = new System.Windows.Forms.TextBox();
			this.textBoxStudentGrade = new System.Windows.Forms.TextBox();
			this.textBoxStudentSection = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonSet = new System.Windows.Forms.Button();
			this.buttonGet = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxProspectName = new System.Windows.Forms.TextBox();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.radioButton_Prospect_True = new System.Windows.Forms.RadioButton();
			this.radioButton_Prospect_False = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton_WhichObject_YouTut = new System.Windows.Forms.RadioButton();
			this.radioButton_WhichObject_KeyVal = new System.Windows.Forms.RadioButton();
			this.radioButton_WhichObject_Prospect = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// keyTextBox
			// 
			this.keyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.keyTextBox.Location = new System.Drawing.Point(444, 33);
			this.keyTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.keyTextBox.Name = "keyTextBox";
			this.keyTextBox.Size = new System.Drawing.Size(141, 23);
			this.keyTextBox.TabIndex = 0;
			// 
			// valueTextBox
			// 
			this.valueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.valueTextBox.Location = new System.Drawing.Point(444, 101);
			this.valueTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(141, 23);
			this.valueTextBox.TabIndex = 1;
			// 
			// label_key
			// 
			this.label_key.AutoSize = true;
			this.label_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_key.Location = new System.Drawing.Point(440, 8);
			this.label_key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_key.Name = "label_key";
			this.label_key.Size = new System.Drawing.Size(30, 17);
			this.label_key.TabIndex = 2;
			this.label_key.Text = "key";
			// 
			// label_value
			// 
			this.label_value.AutoSize = true;
			this.label_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_value.Location = new System.Drawing.Point(440, 72);
			this.label_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label_value.Name = "label_value";
			this.label_value.Size = new System.Drawing.Size(42, 17);
			this.label_value.TabIndex = 3;
			this.label_value.Text = "value";
			// 
			// buttonInsert
			// 
			this.buttonInsert.Location = new System.Drawing.Point(13, 456);
			this.buttonInsert.Margin = new System.Windows.Forms.Padding(4);
			this.buttonInsert.Name = "buttonInsert";
			this.buttonInsert.Size = new System.Drawing.Size(100, 28);
			this.buttonInsert.TabIndex = 4;
			this.buttonInsert.Text = "Insert";
			this.buttonInsert.UseVisualStyleBackColor = true;
			this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Location = new System.Drawing.Point(122, 456);
			this.buttonSelect.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(100, 28);
			this.buttonSelect.TabIndex = 5;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(13, 493);
			this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(100, 28);
			this.buttonUpdate.TabIndex = 6;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(122, 493);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(100, 28);
			this.buttonDelete.TabIndex = 7;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			// 
			// textBoxStudentName
			// 
			this.textBoxStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStudentName.Location = new System.Drawing.Point(104, 35);
			this.textBoxStudentName.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxStudentName.Name = "textBoxStudentName";
			this.textBoxStudentName.Size = new System.Drawing.Size(132, 23);
			this.textBoxStudentName.TabIndex = 8;
			// 
			// textBoxStudentRollNo
			// 
			this.textBoxStudentRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStudentRollNo.Location = new System.Drawing.Point(104, 67);
			this.textBoxStudentRollNo.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxStudentRollNo.Name = "textBoxStudentRollNo";
			this.textBoxStudentRollNo.Size = new System.Drawing.Size(132, 23);
			this.textBoxStudentRollNo.TabIndex = 9;
			// 
			// textBoxStudentGrade
			// 
			this.textBoxStudentGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStudentGrade.Location = new System.Drawing.Point(104, 99);
			this.textBoxStudentGrade.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxStudentGrade.Name = "textBoxStudentGrade";
			this.textBoxStudentGrade.Size = new System.Drawing.Size(132, 23);
			this.textBoxStudentGrade.TabIndex = 10;
			// 
			// textBoxStudentSection
			// 
			this.textBoxStudentSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStudentSection.Location = new System.Drawing.Point(104, 131);
			this.textBoxStudentSection.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxStudentSection.Name = "textBoxStudentSection";
			this.textBoxStudentSection.Size = new System.Drawing.Size(132, 23);
			this.textBoxStudentSection.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(13, 39);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 67);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 17);
			this.label2.TabIndex = 13;
			this.label2.Text = "Roll No";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(9, 99);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 17);
			this.label3.TabIndex = 14;
			this.label3.Text = "Grade";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(13, 131);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 17);
			this.label4.TabIndex = 15;
			this.label4.Text = "Section";
			// 
			// buttonSet
			// 
			this.buttonSet.Location = new System.Drawing.Point(424, 456);
			this.buttonSet.Name = "buttonSet";
			this.buttonSet.Size = new System.Drawing.Size(75, 23);
			this.buttonSet.TabIndex = 16;
			this.buttonSet.Text = "Set";
			this.buttonSet.UseVisualStyleBackColor = true;
			this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// buttonGet
			// 
			this.buttonGet.Location = new System.Drawing.Point(424, 486);
			this.buttonGet.Name = "buttonGet";
			this.buttonGet.Size = new System.Drawing.Size(75, 23);
			this.buttonGet.TabIndex = 17;
			this.buttonGet.Text = "Get";
			this.buttonGet.UseVisualStyleBackColor = true;
			this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(13, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(232, 17);
			this.label5.TabIndex = 18;
			this.label5.Text = "           From Youtube tutorial           ";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(13, 192);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(228, 17);
			this.label6.TabIndex = 19;
			this.label6.Text = "              Our Prospect class           ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 213);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 17);
			this.label7.TabIndex = 20;
			this.label7.Text = "Name";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 246);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 17);
			this.label8.TabIndex = 21;
			this.label8.Text = "Address";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(13, 280);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 17);
			this.label9.TabIndex = 22;
			this.label9.Text = "Accepted";
			// 
			// textBoxProspectName
			// 
			this.textBoxProspectName.Location = new System.Drawing.Point(104, 212);
			this.textBoxProspectName.Name = "textBoxProspectName";
			this.textBoxProspectName.Size = new System.Drawing.Size(160, 23);
			this.textBoxProspectName.TabIndex = 23;
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Location = new System.Drawing.Point(104, 241);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(160, 23);
			this.textBoxAddress.TabIndex = 24;
			// 
			// radioButton_Prospect_True
			// 
			this.radioButton_Prospect_True.AutoSize = true;
			this.radioButton_Prospect_True.Location = new System.Drawing.Point(104, 276);
			this.radioButton_Prospect_True.Name = "radioButton_Prospect_True";
			this.radioButton_Prospect_True.Size = new System.Drawing.Size(51, 21);
			this.radioButton_Prospect_True.TabIndex = 25;
			this.radioButton_Prospect_True.TabStop = true;
			this.radioButton_Prospect_True.Text = "true";
			this.radioButton_Prospect_True.UseVisualStyleBackColor = true;
			// 
			// radioButton_Prospect_False
			// 
			this.radioButton_Prospect_False.AutoSize = true;
			this.radioButton_Prospect_False.Location = new System.Drawing.Point(161, 276);
			this.radioButton_Prospect_False.Name = "radioButton_Prospect_False";
			this.radioButton_Prospect_False.Size = new System.Drawing.Size(56, 21);
			this.radioButton_Prospect_False.TabIndex = 27;
			this.radioButton_Prospect_False.TabStop = true;
			this.radioButton_Prospect_False.Text = "false";
			this.radioButton_Prospect_False.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton_WhichObject_Prospect);
			this.groupBox1.Controls.Add(this.radioButton_WhichObject_KeyVal);
			this.groupBox1.Controls.Add(this.radioButton_WhichObject_YouTut);
			this.groupBox1.Location = new System.Drawing.Point(229, 407);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(189, 115);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "object to upload/download";
			// 
			// radioButton_WhichObject_YouTut
			// 
			this.radioButton_WhichObject_YouTut.AutoSize = true;
			this.radioButton_WhichObject_YouTut.Location = new System.Drawing.Point(7, 23);
			this.radioButton_WhichObject_YouTut.Name = "radioButton_WhichObject_YouTut";
			this.radioButton_WhichObject_YouTut.Size = new System.Drawing.Size(124, 21);
			this.radioButton_WhichObject_YouTut.TabIndex = 0;
			this.radioButton_WhichObject_YouTut.TabStop = true;
			this.radioButton_WhichObject_YouTut.Text = "youtube tutorial";
			this.radioButton_WhichObject_YouTut.UseVisualStyleBackColor = true;
			// 
			// radioButton_WhichObject_KeyVal
			// 
			this.radioButton_WhichObject_KeyVal.AutoSize = true;
			this.radioButton_WhichObject_KeyVal.Location = new System.Drawing.Point(7, 51);
			this.radioButton_WhichObject_KeyVal.Name = "radioButton_WhichObject_KeyVal";
			this.radioButton_WhichObject_KeyVal.Size = new System.Drawing.Size(114, 21);
			this.radioButton_WhichObject_KeyVal.TabIndex = 1;
			this.radioButton_WhichObject_KeyVal.TabStop = true;
			this.radioButton_WhichObject_KeyVal.Text = "key and value";
			this.radioButton_WhichObject_KeyVal.UseVisualStyleBackColor = true;
			// 
			// radioButton_WhichObject_Prospect
			// 
			this.radioButton_WhichObject_Prospect.AutoSize = true;
			this.radioButton_WhichObject_Prospect.Location = new System.Drawing.Point(7, 79);
			this.radioButton_WhichObject_Prospect.Name = "radioButton_WhichObject_Prospect";
			this.radioButton_WhichObject_Prospect.Size = new System.Drawing.Size(81, 21);
			this.radioButton_WhichObject_Prospect.TabIndex = 2;
			this.radioButton_WhichObject_Prospect.TabStop = true;
			this.radioButton_WhichObject_Prospect.Text = "prospect";
			this.radioButton_WhichObject_Prospect.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 534);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.radioButton_Prospect_True);
			this.Controls.Add(this.radioButton_Prospect_False);
			this.Controls.Add(this.textBoxAddress);
			this.Controls.Add(this.textBoxProspectName);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonGet);
			this.Controls.Add(this.buttonSet);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxStudentSection);
			this.Controls.Add(this.textBoxStudentGrade);
			this.Controls.Add(this.textBoxStudentRollNo);
			this.Controls.Add(this.textBoxStudentName);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonInsert);
			this.Controls.Add(this.label_value);
			this.Controls.Add(this.label_key);
			this.Controls.Add(this.valueTextBox);
			this.Controls.Add(this.keyTextBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox keyTextBox;
		private System.Windows.Forms.TextBox valueTextBox;
		private System.Windows.Forms.Label label_key;
		private System.Windows.Forms.Label label_value;
		private System.Windows.Forms.Button buttonInsert;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.TextBox textBoxStudentName;
		private System.Windows.Forms.TextBox textBoxStudentRollNo;
		private System.Windows.Forms.TextBox textBoxStudentGrade;
		private System.Windows.Forms.TextBox textBoxStudentSection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonSet;
		private System.Windows.Forms.Button buttonGet;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxProspectName;
		private System.Windows.Forms.TextBox textBoxAddress;
		private System.Windows.Forms.RadioButton radioButton_Prospect_True;
		private System.Windows.Forms.RadioButton radioButton_Prospect_False;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton_WhichObject_Prospect;
		private System.Windows.Forms.RadioButton radioButton_WhichObject_KeyVal;
		private System.Windows.Forms.RadioButton radioButton_WhichObject_YouTut;
	}
}

