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
            internetSpeedForInternetPackageLabel = new Label();
            internetSpeedForInternetPackageTextBox = new TextBox();
            TVPackageComboBox = new ComboBox();
            TVPackageLabel = new Label();
            InternetPackageLabel = new Label();
            InternetPackageComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numberOfChannelsNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(72, 22);
            label1.Name = "label1";
            label1.Size = new Size(182, 25);
            label1.TabIndex = 0;
            label1.Text = "Add new package";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DeepSkyBlue;
            label2.Location = new Point(43, 65);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 1;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(43, 86);
            nameTextBox.Margin = new Padding(3, 2, 3, 2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(249, 23);
            nameTextBox.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(43, 121);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 4;
            label4.Text = "Price";
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Location = new Point(43, 141);
            priceNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(248, 23);
            priceNumericUpDown.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(43, 178);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 6;
            label5.Text = "Package Type";
            // 
            // packageTypeComboBox
            // 
            packageTypeComboBox.FormattingEnabled = true;
            packageTypeComboBox.Items.AddRange(new object[] { "TV package", "Internet package", "Combined package" });
            packageTypeComboBox.Location = new Point(43, 198);
            packageTypeComboBox.Margin = new Padding(3, 2, 3, 2);
            packageTypeComboBox.Name = "packageTypeComboBox";
            packageTypeComboBox.Size = new Size(249, 23);
            packageTypeComboBox.TabIndex = 7;
            // 
            // internetSpeedLabel
            // 
            internetSpeedLabel.AutoSize = true;
            internetSpeedLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedLabel.ForeColor = Color.DodgerBlue;
            internetSpeedLabel.Location = new Point(43, 290);
            internetSpeedLabel.Name = "internetSpeedLabel";
            internetSpeedLabel.Size = new Size(99, 20);
            internetSpeedLabel.TabIndex = 8;
            internetSpeedLabel.Text = "Internet Speed";
            // 
            // numberOfChannelsLabel
            // 
            numberOfChannelsLabel.AutoSize = true;
            numberOfChannelsLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numberOfChannelsLabel.ForeColor = Color.DodgerBlue;
            numberOfChannelsLabel.Location = new Point(43, 232);
            numberOfChannelsLabel.Name = "numberOfChannelsLabel";
            numberOfChannelsLabel.Size = new Size(138, 20);
            numberOfChannelsLabel.TabIndex = 10;
            numberOfChannelsLabel.Text = "Number Of Channels";
            // 
            // numberOfChannelsNumericUpDown
            // 
            numberOfChannelsNumericUpDown.Location = new Point(43, 254);
            numberOfChannelsNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            numberOfChannelsNumericUpDown.Name = "numberOfChannelsNumericUpDown";
            numberOfChannelsNumericUpDown.Size = new Size(248, 23);
            numberOfChannelsNumericUpDown.TabIndex = 11;
            // 
            // addPackageButton
            // 
            addPackageButton.BackColor = Color.DeepSkyBlue;
            addPackageButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addPackageButton.ForeColor = Color.GhostWhite;
            addPackageButton.Location = new Point(43, 357);
            addPackageButton.Margin = new Padding(3, 2, 3, 2);
            addPackageButton.Name = "addPackageButton";
            addPackageButton.Size = new Size(107, 36);
            addPackageButton.TabIndex = 12;
            addPackageButton.Text = "Add Package";
            addPackageButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = Color.DodgerBlue;
            cancelButton.Location = new Point(179, 357);
            cancelButton.Margin = new Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 36);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // internetSpeedTextBox
            // 
            internetSpeedTextBox.Location = new Point(43, 310);
            internetSpeedTextBox.Margin = new Padding(3, 2, 3, 2);
            internetSpeedTextBox.Name = "internetSpeedTextBox";
            internetSpeedTextBox.Size = new Size(249, 23);
            internetSpeedTextBox.TabIndex = 14;
            // 
            // internetSpeedForInternetPackageLabel
            // 
            internetSpeedForInternetPackageLabel.AutoSize = true;
            internetSpeedForInternetPackageLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedForInternetPackageLabel.Location = new Point(43, 232);
            internetSpeedForInternetPackageLabel.Name = "internetSpeedForInternetPackageLabel";
            internetSpeedForInternetPackageLabel.Size = new Size(99, 20);
            internetSpeedForInternetPackageLabel.TabIndex = 15;
            internetSpeedForInternetPackageLabel.Text = "Internet Speed";
            // 
            // internetSpeedForInternetPackageTextBox
            // 
            internetSpeedForInternetPackageTextBox.Location = new Point(43, 253);
            internetSpeedForInternetPackageTextBox.Margin = new Padding(3, 2, 3, 2);
            internetSpeedForInternetPackageTextBox.Name = "internetSpeedForInternetPackageTextBox";
            internetSpeedForInternetPackageTextBox.Size = new Size(249, 23);
            internetSpeedForInternetPackageTextBox.TabIndex = 16;
            // 
            // TVPackageComboBox
            // 
            TVPackageComboBox.FormattingEnabled = true;
            TVPackageComboBox.Location = new Point(43, 253);
            TVPackageComboBox.Name = "TVPackageComboBox";
            TVPackageComboBox.Size = new Size(248, 23);
            TVPackageComboBox.TabIndex = 17;
            // 
            // TVPackageLabel
            // 
            TVPackageLabel.AutoSize = true;
            TVPackageLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TVPackageLabel.Location = new Point(43, 232);
            TVPackageLabel.Name = "TVPackageLabel";
            TVPackageLabel.Size = new Size(82, 20);
            TVPackageLabel.TabIndex = 18;
            TVPackageLabel.Text = "TV Package";
            // 
            // InternetPackageLabel
            // 
            InternetPackageLabel.AutoSize = true;
            InternetPackageLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            InternetPackageLabel.Location = new Point(43, 290);
            InternetPackageLabel.Name = "InternetPackageLabel";
            InternetPackageLabel.Size = new Size(112, 20);
            InternetPackageLabel.TabIndex = 19;
            InternetPackageLabel.Text = "Internet Package";
            // 
            // InternetPackageComboBox
            // 
            InternetPackageComboBox.FormattingEnabled = true;
            InternetPackageComboBox.Location = new Point(43, 310);
            InternetPackageComboBox.Name = "InternetPackageComboBox";
            InternetPackageComboBox.Size = new Size(248, 23);
            InternetPackageComboBox.TabIndex = 20;
            // 
            // AddNewPackageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(333, 406);
            Controls.Add(InternetPackageComboBox);
            Controls.Add(InternetPackageLabel);
            Controls.Add(TVPackageLabel);
            Controls.Add(TVPackageComboBox);
            Controls.Add(internetSpeedForInternetPackageTextBox);
            Controls.Add(internetSpeedForInternetPackageLabel);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddNewPackageForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Label internetSpeedForInternetPackageLabel;
        private TextBox internetSpeedForInternetPackageTextBox;
        private ComboBox TVPackageComboBox;
        private Label TVPackageLabel;
        private Label InternetPackageLabel;
        private ComboBox InternetPackageComboBox;
    }
}