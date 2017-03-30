namespace TDSFrontend
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
            this.retrieveInput = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // retrieveInput
            // 
            this.retrieveInput.Location = new System.Drawing.Point(588, 100);
            this.retrieveInput.Name = "retrieveInput";
            this.retrieveInput.Size = new System.Drawing.Size(75, 23);
            this.retrieveInput.TabIndex = 0;
            this.retrieveInput.Text = "Search";
            this.retrieveInput.UseVisualStyleBackColor = true;
            this.retrieveInput.Click += new System.EventHandler(this.Search_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(282, 102);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(300, 20);
            this.inputText.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.retrieveInput);
            this.Name = "Form1";
            this.Text = "Text Document Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button retrieveInput;
        private System.Windows.Forms.TextBox inputText;
    }
}

