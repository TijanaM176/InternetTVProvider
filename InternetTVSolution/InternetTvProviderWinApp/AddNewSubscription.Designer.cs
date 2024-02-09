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
            PackageIDTextBox = new TextBox();
            internetSpeedLabel = new Label();
            NameTextBox = new TextBox();
            label3 = new Label();
            priceNumericUpDown = new NumericUpDown();
            label4 = new Label();
            packageTypeTextBox = new TextBox();
            label5 = new Label();
            cancelButton = new Button();
            addSubButton = new Button();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
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
            // PackageIDTextBox
            // 
            PackageIDTextBox.Location = new Point(55, 171);
            PackageIDTextBox.Name = "PackageIDTextBox";
            PackageIDTextBox.Size = new Size(284, 27);
            PackageIDTextBox.TabIndex = 16;
            // 
            // internetSpeedLabel
            // 
            internetSpeedLabel.AutoSize = true;
            internetSpeedLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedLabel.ForeColor = Color.DodgerBlue;
            internetSpeedLabel.Location = new Point(53, 144);
            internetSpeedLabel.Name = "internetSpeedLabel";
            internetSpeedLabel.Size = new Size(97, 24);
            internetSpeedLabel.TabIndex = 15;
            internetSpeedLabel.Text = "Package ID";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(55, 242);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(284, 27);
            NameTextBox.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(55, 215);
            label3.Name = "label3";
            label3.Size = new Size(54, 24);
            label3.TabIndex = 17;
            label3.Text = "Name";
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Location = new Point(56, 307);
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(283, 27);
            priceNumericUpDown.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(55, 280);
            label4.Name = "label4";
            label4.Size = new Size(49, 24);
            label4.TabIndex = 19;
            label4.Text = "Price";
            // 
            // packageTypeTextBox
            // 
            packageTypeTextBox.Location = new Point(53, 379);
            packageTypeTextBox.Name = "packageTypeTextBox";
            packageTypeTextBox.Size = new Size(284, 27);
            packageTypeTextBox.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(53, 352);
            label5.Name = "label5";
            label5.Size = new Size(114, 24);
            label5.TabIndex = 21;
            label5.Text = "PackageType";
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = Color.DodgerBlue;
            cancelButton.Location = new Point(211, 442);
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
            addSubButton.Location = new Point(53, 442);
            addSubButton.Name = "addSubButton";
            addSubButton.Size = new Size(129, 64);
            addSubButton.TabIndex = 23;
            addSubButton.Text = "Add Subscription";
            addSubButton.UseVisualStyleBackColor = false;
            // 
            // AddNewSubscription
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 536);
            Controls.Add(cancelButton);
            Controls.Add(addSubButton);
            Controls.Add(packageTypeTextBox);
            Controls.Add(label5);
            Controls.Add(priceNumericUpDown);
            Controls.Add(label4);
            Controls.Add(NameTextBox);
            Controls.Add(label3);
            Controls.Add(PackageIDTextBox);
            Controls.Add(internetSpeedLabel);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddNewSubscription";
            Text = "AddNewSubscription";
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox PackageIDTextBox;
        private Label internetSpeedLabel;
        private TextBox NameTextBox;
        private Label label3;
        private NumericUpDown priceNumericUpDown;
        private Label label4;
        private TextBox packageTypeTextBox;
        private Label label5;
        private Button cancelButton;
        private Button addSubButton;
    }
}