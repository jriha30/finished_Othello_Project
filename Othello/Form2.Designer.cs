
namespace Othello
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_correct = new System.Windows.Forms.Button();
            this.button_incorrect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 254);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_correct
            // 
            this.button_correct.Location = new System.Drawing.Point(107, 147);
            this.button_correct.Name = "button_correct";
            this.button_correct.Size = new System.Drawing.Size(92, 64);
            this.button_correct.TabIndex = 1;
            this.button_correct.Text = "Correct";
            this.button_correct.UseVisualStyleBackColor = true;
            this.button_correct.Click += new System.EventHandler(this.button_correct_Click);
            // 
            // button_incorrect
            // 
            this.button_incorrect.Location = new System.Drawing.Point(247, 147);
            this.button_incorrect.Name = "button_incorrect";
            this.button_incorrect.Size = new System.Drawing.Size(92, 64);
            this.button_incorrect.TabIndex = 2;
            this.button_incorrect.Text = "Incorrect";
            this.button_incorrect.UseVisualStyleBackColor = true;
            this.button_incorrect.Click += new System.EventHandler(this.button_incorrect_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 254);
            this.Controls.Add(this.button_incorrect);
            this.Controls.Add(this.button_correct);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_correct;
        private System.Windows.Forms.Button button_incorrect;
    }
}