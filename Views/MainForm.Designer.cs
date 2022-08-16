namespace TextProcessor
{
    partial class MainForm
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
            this.SetDictionaryButton = new System.Windows.Forms.Button();
            this.UpdateDictionaryButton = new System.Windows.Forms.Button();
            this.DeleteDictionaryButton = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.SuggestedWordsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SetDictionaryButton
            // 
            this.SetDictionaryButton.Location = new System.Drawing.Point(24, 21);
            this.SetDictionaryButton.Name = "SetDictionaryButton";
            this.SetDictionaryButton.Size = new System.Drawing.Size(150, 30);
            this.SetDictionaryButton.TabIndex = 0;
            this.SetDictionaryButton.Text = "Назначить словарь";
            this.SetDictionaryButton.UseVisualStyleBackColor = true;
            this.SetDictionaryButton.Click += new System.EventHandler(this.SetDictionaryButton_Click);
            // 
            // UpdateDictionaryButton
            // 
            this.UpdateDictionaryButton.Location = new System.Drawing.Point(180, 21);
            this.UpdateDictionaryButton.Name = "UpdateDictionaryButton";
            this.UpdateDictionaryButton.Size = new System.Drawing.Size(150, 30);
            this.UpdateDictionaryButton.TabIndex = 1;
            this.UpdateDictionaryButton.Text = "Обновить словарь";
            this.UpdateDictionaryButton.UseVisualStyleBackColor = true;
            this.UpdateDictionaryButton.Click += new System.EventHandler(this.UpdateDictionaryButton_Click);
            // 
            // DeleteDictionaryButton
            // 
            this.DeleteDictionaryButton.Location = new System.Drawing.Point(336, 21);
            this.DeleteDictionaryButton.Name = "DeleteDictionaryButton";
            this.DeleteDictionaryButton.Size = new System.Drawing.Size(150, 30);
            this.DeleteDictionaryButton.TabIndex = 2;
            this.DeleteDictionaryButton.Text = "Удалить словарь";
            this.DeleteDictionaryButton.UseVisualStyleBackColor = true;
            this.DeleteDictionaryButton.Click += new System.EventHandler(this.DeleteDictionaryButton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.InputTextBox.Location = new System.Drawing.Point(24, 103);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(534, 309);
            this.InputTextBox.TabIndex = 3;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // SuggestedWordsList
            // 
            this.SuggestedWordsList.FormattingEnabled = true;
            this.SuggestedWordsList.IntegralHeight = false;
            this.SuggestedWordsList.ItemHeight = 15;
            this.SuggestedWordsList.Location = new System.Drawing.Point(582, 74);
            this.SuggestedWordsList.Name = "SuggestedWordsList";
            this.SuggestedWordsList.Size = new System.Drawing.Size(206, 109);
            this.SuggestedWordsList.TabIndex = 4;
            this.SuggestedWordsList.Visible = false;
            this.SuggestedWordsList.SelectedIndexChanged += new System.EventHandler(this.SuggestedWordsList_SelectedWord);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SuggestedWordsList);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.DeleteDictionaryButton);
            this.Controls.Add(this.UpdateDictionaryButton);
            this.Controls.Add(this.SetDictionaryButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SetDictionaryButton;
        private Button UpdateDictionaryButton;
        private Button DeleteDictionaryButton;
        private TextBox InputTextBox;
        public ListBox SuggestedWordsList;
    }
}