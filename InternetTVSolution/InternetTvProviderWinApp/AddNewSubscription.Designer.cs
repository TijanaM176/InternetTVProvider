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
            ClientIDTextBox = new TextBox();
            label2 = new Label();
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
            label1.Location = new Point(80, 30);
            label1.Name = "label1";
            label1.Size = new Size(216, 25);
            label1.TabIndex = 1;
            label1.Text = "Add new subscription";
            // 
            // ClientIDTextBox
            // 
            ClientIDTextBox.Location = new Point(48, 110);
            ClientIDTextBox.Margin = new Padding(3, 2, 3, 2);
            ClientIDTextBox.Name = "ClientIDTextBox";
            ClientIDTextBox.Size = new Size(249, 23);
            ClientIDTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(48, 89);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 3;
            label2.Text = "Client ID";
            // 
            // PackageIDTextBox
            // 
            PackageIDTextBox.Location = new Point(48, 162);
            PackageIDTextBox.Margin = new Padding(3, 2, 3, 2);
            PackageIDTextBox.Name = "PackageIDTextBox";
            PackageIDTextBox.Size = new Size(249, 23);
            PackageIDTextBox.TabIndex = 16;
            // 
            // internetSpeedLabel
            // 
            internetSpeedLabel.AutoSize = true;
            internetSpeedLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            internetSpeedLabel.ForeColor = Color.DodgerBlue;
            internetSpeedLabel.Location = new Point(48, 142);
            internetSpeedLabel.Name = "internetSpeedLabel";
            internetSpeedLabel.Size = new Size(78, 20);
            internetSpeedLabel.TabIndex = 15;
            internetSpeedLabel.Text = "Package ID";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(46, 217);
            NameTextBox.Margin = new Padding(3, 2, 3, 2);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(249, 23);
            NameTextBox.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(46, 197);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 17;
            label3.Text = "Name";
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Location = new Point(46, 274);
            priceNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(248, 23);
            priceNumericUpDown.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DodgerBlue;
            label4.Location = new Point(46, 254);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 19;
            label4.Text = "Price";
            // 
            // packageTypeTextBox
            // 
            packageTypeTextBox.Location = new Point(48, 336);
            packageTypeTextBox.Margin = new Padding(3, 2, 3, 2);
            packageTypeTextBox.Name = "packageTypeTextBox";
            packageTypeTextBox.Size = new Size(249, 23);
            packageTypeTextBox.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(48, 316);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 21;
            label5.Text = "PackageType";
            // 
            // cancelButton
            // 
            cancelButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = Color.DodgerBlue;
            cancelButton.Location = new Point(196, 390);
            cancelButton.Margin = new Padding(3, 2, 3, 2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 36);
            cancelButton.TabIndex = 24;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // addSubButton
            // 
            addSubButton.BackColor = Color.DeepSkyBlue;
            addSubButton.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addSubButton.ForeColor = Color.GhostWhite;
            addSubButton.Location = new Point(34, 390);
            addSubButton.Margin = new Padding(3, 2, 3, 2);
            addSubButton.Name = "addSubButton";
            addSubButton.Size = new Size(130, 36);
            addSubButton.TabIndex = 23;
            addSubButton.Text = "Add Subscription";
            addSubButton.UseVisualStyleBackColor = false;
            // 
            // AddNewSubscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 450);
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
            Controls.Add(ClientIDTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddNewSubscription";
            Text = "AddNewSubscription";
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ClientIDTextBox;
        private Label label2;
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