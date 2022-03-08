namespace LegalPlotter
{
    partial class LegalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegalForm));
            this.ParcelName = new System.Windows.Forms.TextBox();
            this.LabelParcelName = new System.Windows.Forms.Label();
            this.LegalDescription = new System.Windows.Forms.TextBox();
            this.LabelLegalDescription = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ParcelName
            // 
            this.ParcelName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ParcelName.Location = new System.Drawing.Point(110, 12);
            this.ParcelName.Name = "ParcelName";
            this.ParcelName.Size = new System.Drawing.Size(374, 20);
            this.ParcelName.TabIndex = 1;
            this.ParcelName.Text = "H-3-2-3-2126";
            this.ParcelName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LabelParcelName
            // 
            this.LabelParcelName.AutoSize = true;
            this.LabelParcelName.Location = new System.Drawing.Point(33, 15);
            this.LabelParcelName.Name = "LabelParcelName";
            this.LabelParcelName.Size = new System.Drawing.Size(71, 13);
            this.LabelParcelName.TabIndex = 0;
            this.LabelParcelName.Text = "Parcel Name:";
            this.LabelParcelName.Click += new System.EventHandler(this.label1_Click);
            // 
            // LegalDescription
            // 
            this.LegalDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LegalDescription.Location = new System.Drawing.Point(110, 38);
            this.LegalDescription.Multiline = true;
            this.LegalDescription.Name = "LegalDescription";
            this.LegalDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LegalDescription.Size = new System.Drawing.Size(374, 158);
            this.LegalDescription.TabIndex = 4;
            this.LegalDescription.Text = resources.GetString("LegalDescription.Text");
            this.LegalDescription.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // LabelLegalDescription
            // 
            this.LabelLegalDescription.AutoSize = true;
            this.LabelLegalDescription.Location = new System.Drawing.Point(12, 41);
            this.LabelLegalDescription.Name = "LabelLegalDescription";
            this.LabelLegalDescription.Size = new System.Drawing.Size(92, 13);
            this.LabelLegalDescription.TabIndex = 3;
            this.LabelLegalDescription.Text = "Legal Description:";
            this.LabelLegalDescription.Click += new System.EventHandler(this.label2_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SubmitButton.Location = new System.Drawing.Point(0, 202);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(496, 23);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // LegalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 225);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.LabelLegalDescription);
            this.Controls.Add(this.LegalDescription);
            this.Controls.Add(this.LabelParcelName);
            this.Controls.Add(this.ParcelName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LegalForm";
            this.Text = "Legal Plotter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LegalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ParcelName;
        private System.Windows.Forms.Label LabelParcelName;
        private System.Windows.Forms.TextBox LegalDescription;
        private System.Windows.Forms.Label LabelLegalDescription;
        private System.Windows.Forms.Button SubmitButton;
    }
}