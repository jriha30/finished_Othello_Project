
namespace Othello
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reset_button = new System.Windows.Forms.Button();
            this.turnLabel = new System.Windows.Forms.Label();
            this.button_load = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menu_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 517);
            this.panel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(16, 15);
            this.reset_button.Margin = new System.Windows.Forms.Padding(4);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(100, 28);
            this.reset_button.TabIndex = 2;
            this.reset_button.Text = "Reset Board";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // turnLabel
            // 
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.turnLabel.Location = new System.Drawing.Point(701, 11);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(428, 28);
            this.turnLabel.TabIndex = 3;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(304, 15);
            this.button_load.Margin = new System.Windows.Forms.Padding(4);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(201, 28);
            this.button_load.TabIndex = 4;
            this.button_load.Text = "Generate Default Questions";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Load Custom Questions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu_Button
            // 
            this.menu_Button.Location = new System.Drawing.Point(513, 13);
            this.menu_Button.Name = "menu_Button";
            this.menu_Button.Size = new System.Drawing.Size(180, 30);
            this.menu_Button.TabIndex = 6;
            this.menu_Button.Text = "Return to Menu";
            this.menu_Button.UseVisualStyleBackColor = true;
            this.menu_Button.Click += new System.EventHandler(this.menu_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 965);
            this.Controls.Add(this.menu_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button menu_Button;
    }
}
