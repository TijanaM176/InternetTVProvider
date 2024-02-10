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
            packageInfoLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(58, 60);
            label1.Name = "label1";
            label1.Size = new Size(281, 32);
            label1.TabIndex = 1;
            label1.Text = "Add new subscription";
            // 
            // internetSpeedLabel
            // 
            internetSpeedLabel.AutoSize = true;
            internetSpeedLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedLabel.ForeColor = Color.DodgerBlue;
            internetSpeedLabel.Location = new Point(58, 159);
            internetSpeedLabel.Name = "internetSpeedLabel";
            internetSpeedLabel.Size = new Size(110, 24);
            internetSpeedLabel.TabIndex = 15;
            internetSpeedLabel.Text = "Package Info";
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = Color.DodgerBlue;
            cancelButton.Location = new Point(211, 340);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(128, 64);
            cancelButton.TabIndex = 24;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // addSubButton
            // 
            addSubButton.BackColor = Color.DeepSkyBlue;
            addSubButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addSubButton.ForeColor = Color.GhostWhite;
            addSubButton.Location = new Point(58, 340);
            addSubButton.Name = "addSubButton";
            addSubButton.Size = new Size(129, 64);
            addSubButton.TabIndex = 23;
            addSubButton.Text = "Add Subscription";
            addSubButton.UseVisualStyleBackColor = false;
            // 
            // dropDownPackageInfo
            // 
            dropDownPackageInfo.FormattingEnabled = true;
            dropDownPackageInfo.Location = new Point(58, 216);
            dropDownPackageInfo.Name = "dropDownPackageInfo";
            dropDownPackageInfo.Size = new Size(281, 28);
            dropDownPackageInfo.TabIndex = 25;
            // 
            // packageInfoLabel
            // 
            packageInfoLabel.AutoSize = true;
            packageInfoLabel.ForeColor = SystemColors.ControlDarkDark;
            packageInfoLabel.Location = new Point(56, 183);
            packageInfoLabel.Name = "packageInfoLabel";
            packageInfoLabel.Size = new Size(112, 20);
            packageInfoLabel.TabIndex = 26;
            packageInfoLabel.Text = "(type, name, id)";
            // 
            // AddNewSubscription
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 536);
            Controls.Add(packageInfoLabel);
            Controls.Add(dropDownPackageInfo);
            Controls.Add(cancelButton);
            Controls.Add(addSubButton);
            Controls.Add(internetSpeedLabel);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Label packageInfoLabel;
    }
}