namespace InternetTvProviderWinApp
{
    partial class AddNewPackageForm
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
            label2 = new Label();
            nameTextBox = new TextBox();
            label4 = new Label();
            priceNumericUpDown = new NumericUpDown();
            label5 = new Label();
            packageTypeComboBox = new ComboBox();
            internetSpeedLabel = new Label();
            numberOfChannelsLabel = new Label();
            numberOfChannelsNumericUpDown = new NumericUpDown();
            addPackageButton = new Button();
            cancelButton = new Button();
            internetSpeedTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numberOfChannelsNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(136, 45);
            label1.Name = "label1";
            label1.Size = new Size(250, 35);
            label1.TabIndex = 0;
            label1.Text = "Add new package";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DeepSkyBlue;
            label2.Location = new Point(85, 113);
            label2.Name = "label2";
            label2.Size = new Size(54, 24);
            label2.TabIndex = 1;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(85, 140);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(347, 27);
            nameTextBox.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(85, 186);
            label4.Name = "label4";
            label4.Size = new Size(49, 24);
            label4.TabIndex = 4;
            label4.Text = "Price";
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Location = new Point(85, 213);
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(347, 27);
            priceNumericUpDown.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(85, 263);
            label5.Name = "label5";
            label5.Size = new Size(119, 24);
            label5.TabIndex = 6;
            label5.Text = "Package Type";
            // 
            // packageTypeComboBox
            // 
            packageTypeComboBox.FormattingEnabled = true;
            packageTypeComboBox.Items.AddRange(new object[] { "TV package", "Internet package", "Combined package" });
            packageTypeComboBox.Location = new Point(85, 290);
            packageTypeComboBox.Name = "packageTypeComboBox";
            packageTypeComboBox.Size = new Size(347, 28);
            packageTypeComboBox.TabIndex = 7;
            // 
            // internetSpeedLabel
            // 
            internetSpeedLabel.AutoSize = true;
            internetSpeedLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedLabel.ForeColor = Color.DodgerBlue;
            internetSpeedLabel.Location = new Point(85, 433);
            internetSpeedLabel.Name = "internetSpeedLabel";
            internetSpeedLabel.Size = new Size(122, 24);
            internetSpeedLabel.TabIndex = 8;
            internetSpeedLabel.Text = "Internet Speed";
            // 
            // numberOfChannelsLabel
            // 
            numberOfChannelsLabel.AutoSize = true;
            numberOfChannelsLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numberOfChannelsLabel.ForeColor = Color.DodgerBlue;
            numberOfChannelsLabel.Location = new Point(85, 350);
            numberOfChannelsLabel.Name = "numberOfChannelsLabel";
            numberOfChannelsLabel.Size = new Size(172, 24);
            numberOfChannelsLabel.TabIndex = 10;
            numberOfChannelsLabel.Text = "Number Of Channels";
            // 
            // numberOfChannelsNumericUpDown
            // 
            numberOfChannelsNumericUpDown.Location = new Point(85, 377);
            numberOfChannelsNumericUpDown.Name = "numberOfChannelsNumericUpDown";
            numberOfChannelsNumericUpDown.Size = new Size(347, 27);
            numberOfChannelsNumericUpDown.TabIndex = 11;
            // 
            // addPackageButton
            // 
            addPackageButton.BackColor = Color.DeepSkyBlue;
            addPackageButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addPackageButton.ForeColor = Color.GhostWhite;
            addPackageButton.Location = new Point(85, 555);
            addPackageButton.Name = "addPackageButton";
            addPackageButton.Size = new Size(150, 48);
            addPackageButton.TabIndex = 12;
            addPackageButton.Text = "Add Package";
            addPackageButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = Color.DodgerBlue;
            cancelButton.Location = new Point(285, 555);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(147, 48);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // internetSpeedTextBox
            // 
            internetSpeedTextBox.Location = new Point(85, 470);
            internetSpeedTextBox.Name = "internetSpeedTextBox";
            internetSpeedTextBox.Size = new Size(347, 27);
            internetSpeedTextBox.TabIndex = 14;
            // 
            // AddNewPackageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(508, 652);
            Controls.Add(internetSpeedTextBox);
            Controls.Add(cancelButton);
            Controls.Add(addPackageButton);
            Controls.Add(numberOfChannelsNumericUpDown);
            Controls.Add(numberOfChannelsLabel);
            Controls.Add(internetSpeedLabel);
            Controls.Add(packageTypeComboBox);
            Controls.Add(label5);
            Controls.Add(priceNumericUpDown);
            Controls.Add(label4);
            Controls.Add(nameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.DodgerBlue;
            Name = "AddNewPackageForm";
            Text = "Add New Package";
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)numberOfChannelsNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox nameTextBox;
        private Label label4;
        private NumericUpDown priceNumericUpDown;
        private Label label5;
        private ComboBox packageTypeComboBox;
        private Label internetSpeedLabel;
        private Label numberOfChannelsLabel;
        private NumericUpDown numberOfChannelsNumericUpDown;
        private Button addPackageButton;
        private Button cancelButton;
        private TextBox internetSpeedTextBox;
    }
}