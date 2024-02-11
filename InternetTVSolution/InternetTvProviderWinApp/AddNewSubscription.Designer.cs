namespace InternetTvProviderWinApp
{
    partial class AddNewSubscription
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
            label1 = new Label();
            internetSpeedLabel = new Label();
            cancelButton = new Button();
            addSubButton = new Button();
            dropDownPackageInfo = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(51, 45);
            label1.Name = "label1";
            label1.Size = new Size(216, 25);
            label1.TabIndex = 1;
            label1.Text = "Add new subscription";
            // 
            // internetSpeedLabel
            // 
            internetSpeedLabel.AutoSize = true;
            internetSpeedLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedLabel.ForeColor = Color.DodgerBlue;
            internetSpeedLabel.Location = new Point(51, 124);
            internetSpeedLabel.Name = "internetSpeedLabel";
            internetSpeedLabel.Size = new Size(112, 20);
            internetSpeedLabel.TabIndex = 15;
            internetSpeedLabel.Text = "Choose Package";
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = Color.DodgerBlue;
            cancelButton.Location = new Point(185, 255);
            cancelButton.Margin = new Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 48);
            cancelButton.TabIndex = 24;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // addSubButton
            // 
            addSubButton.BackColor = Color.DeepSkyBlue;
            addSubButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addSubButton.ForeColor = Color.GhostWhite;
            addSubButton.Location = new Point(51, 255);
            addSubButton.Margin = new Padding(3, 2, 3, 2);
            addSubButton.Name = "addSubButton";
            addSubButton.Size = new Size(113, 48);
            addSubButton.TabIndex = 23;
            addSubButton.Text = "Add Subscription";
            addSubButton.UseVisualStyleBackColor = false;
            // 
            // dropDownPackageInfo
            // 
            dropDownPackageInfo.FormattingEnabled = true;
            dropDownPackageInfo.Location = new Point(51, 158);
            dropDownPackageInfo.Margin = new Padding(3, 2, 3, 2);
            dropDownPackageInfo.Name = "dropDownPackageInfo";
            dropDownPackageInfo.Size = new Size(246, 23);
            dropDownPackageInfo.TabIndex = 25;
            // 
            // AddNewSubscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 402);
            Controls.Add(dropDownPackageInfo);
            Controls.Add(cancelButton);
            Controls.Add(addSubButton);
            Controls.Add(internetSpeedLabel);
            Controls.Add(label1);
            Name = "AddNewSubscription";
            Text = "AddNewSubscription";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label internetSpeedLabel;
        private Button cancelButton;
        private Button addSubButton;
        private ComboBox dropDownPackageInfo;
    }
}