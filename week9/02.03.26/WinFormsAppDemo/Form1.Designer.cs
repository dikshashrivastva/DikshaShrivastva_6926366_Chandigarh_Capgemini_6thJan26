namespace WinFormsAppDemo
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			this.txtEmpName = new Label();
			this.txtEmpDesig = new Label();
			this.txtEmpDOJ = new Label();
			this.txtEmpSal = new Label();
			this.txtEmpId = new Label();
			txtDeptNo = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(334, 274);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 0;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			// 
			// txtEmpName
			// 
			this.txtEmpName.AutoSize = true;
			this.txtEmpName.Location = new Point(62, 66);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new Size(83, 20);
			this.txtEmpName.TabIndex = 1;
			this.txtEmpName.Text = "Emp Name";
			this.txtEmpName.Click += this.label1_Click;
			// 
			// txtEmpDesig
			// 
			this.txtEmpDesig.AutoSize = true;
			this.txtEmpDesig.Location = new Point(62, 105);
			this.txtEmpDesig.Name = "txtEmpDesig";
			this.txtEmpDesig.Size = new Size(89, 20);
			this.txtEmpDesig.TabIndex = 2;
			this.txtEmpDesig.Text = "Designation";
			// 
			// txtEmpDOJ
			// 
			this.txtEmpDOJ.AutoSize = true;
			this.txtEmpDOJ.Location = new Point(62, 145);
			this.txtEmpDOJ.Name = "txtEmpDOJ";
			this.txtEmpDOJ.Size = new Size(36, 20);
			this.txtEmpDOJ.TabIndex = 3;
			this.txtEmpDOJ.Text = "DOJ";
			// 
			// txtEmpSal
			// 
			this.txtEmpSal.AutoSize = true;
			this.txtEmpSal.Location = new Point(62, 191);
			this.txtEmpSal.Name = "txtEmpSal";
			this.txtEmpSal.Size = new Size(49, 20);
			this.txtEmpSal.TabIndex = 4;
			this.txtEmpSal.Text = "Salary";
			// 
			// txtEmpId
			// 
			this.txtEmpId.AutoSize = true;
			this.txtEmpId.Location = new Point(62, 29);
			this.txtEmpId.Name = "txtEmpId";
			this.txtEmpId.Size = new Size(54, 20);
			this.txtEmpId.TabIndex = 5;
			this.txtEmpId.Text = "EmpID";
			this.txtEmpId.Click += this.label5_Click;
			// 
			// txtDeptNo
			// 
			txtDeptNo.AutoSize = true;
			txtDeptNo.Location = new Point(62, 239);
			txtDeptNo.Name = "txtDeptNo";
			txtDeptNo.Size = new Size(66, 20);
			txtDeptNo.TabIndex = 6;
			txtDeptNo.Text = "Dept No";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(txtDeptNo);
			Controls.Add(this.txtEmpId);
			Controls.Add(this.txtEmpSal);
			Controls.Add(this.txtEmpDOJ);
			Controls.Add(this.txtEmpDesig);
			Controls.Add(this.txtEmpName);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label txtDeptNo;
	}
}
