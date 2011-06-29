namespace MyFitnessPalApp
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnUpdateValues = new System.Windows.Forms.Button();
            this.btnShowValues = new System.Windows.Forms.Button();
            this.btnDeSerialize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(651, 186);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Serialize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(296, 248);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(350, 20);
            this.textBox2.TabIndex = 2;
            // 
            // btnUpdateValues
            // 
            this.btnUpdateValues.Location = new System.Drawing.Point(180, 276);
            this.btnUpdateValues.Name = "btnUpdateValues";
            this.btnUpdateValues.Size = new System.Drawing.Size(125, 23);
            this.btnUpdateValues.TabIndex = 3;
            this.btnUpdateValues.Text = "Update Values";
            this.btnUpdateValues.UseVisualStyleBackColor = true;
            this.btnUpdateValues.Click += new System.EventHandler(this.btnUpdateValues_Click);
            // 
            // btnShowValues
            // 
            this.btnShowValues.Location = new System.Drawing.Point(180, 306);
            this.btnShowValues.Name = "btnShowValues";
            this.btnShowValues.Size = new System.Drawing.Size(75, 23);
            this.btnShowValues.TabIndex = 4;
            this.btnShowValues.Text = "ShowValues";
            this.btnShowValues.UseVisualStyleBackColor = true;
            this.btnShowValues.Click += new System.EventHandler(this.btnShowValues_Click);
            // 
            // btnDeSerialize
            // 
            this.btnDeSerialize.Location = new System.Drawing.Point(180, 336);
            this.btnDeSerialize.Name = "btnDeSerialize";
            this.btnDeSerialize.Size = new System.Drawing.Size(75, 23);
            this.btnDeSerialize.TabIndex = 5;
            this.btnDeSerialize.Text = "DeSerialize";
            this.btnDeSerialize.UseVisualStyleBackColor = true;
            this.btnDeSerialize.Click += new System.EventHandler(this.btnDeSerialize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 582);
            this.Controls.Add(this.btnDeSerialize);
            this.Controls.Add(this.btnShowValues);
            this.Controls.Add(this.btnUpdateValues);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnUpdateValues;
        private System.Windows.Forms.Button btnShowValues;
        private System.Windows.Forms.Button btnDeSerialize;
    }
}

