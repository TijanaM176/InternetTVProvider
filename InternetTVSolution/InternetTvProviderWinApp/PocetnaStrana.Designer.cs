using InternetTVProviderLibrary.Models;
namespace InternetTvProviderWinApp
{
    partial class PocetnaStrana
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
            providerPanel = new Panel();
            providerName = new Label();
            customerRegisterPanel = new Panel();
            reqisterClientLabel = new Label();
            registerButton = new Button();
            lastName = new TextBox();
            firstName = new TextBox();
            usernameBox = new TextBox();
            clientsPanel = new Panel();
            clientsListBox = new ListBox();
            clientsLabel = new Label();
            packetsPanel = new Panel();
            dataGridView1 = new DataGridView();
            nameColumn = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            combinePacketsLabel = new Label();
            internetPacketsLabel = new Label();
            tvPacketsLabel = new Label();
            providerPanel.SuspendLayout();
            customerRegisterPanel.SuspendLayout();
            clientsPanel.SuspendLayout();
            packetsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // providerPanel
            // 
            providerPanel.Controls.Add(providerName);
            providerPanel.Location = new Point(7, 5);
            providerPanel.Name = "providerPanel";
            providerPanel.Size = new Size(1110, 34);
            providerPanel.TabIndex = 0;
            // 
            // providerName
            // 
            providerName.AccessibleDescription = "";
            providerName.AccessibleName = "";
            providerName.AutoSize = true;
            providerName.Location = new Point(345, 4);
            providerName.Name = "providerName";
            providerName.Size = new Size(105, 20);
            providerName.TabIndex = 0;
            providerName.Text = "providerName";
            providerName.TextAlign = ContentAlignment.TopCenter;
            // 
            // customerRegisterPanel
            // 
            customerRegisterPanel.Controls.Add(reqisterClientLabel);
            customerRegisterPanel.Controls.Add(registerButton);
            customerRegisterPanel.Controls.Add(lastName);
            customerRegisterPanel.Controls.Add(firstName);
            customerRegisterPanel.Controls.Add(usernameBox);
            customerRegisterPanel.Location = new Point(7, 35);
            customerRegisterPanel.Name = "customerRegisterPanel";
            customerRegisterPanel.Size = new Size(1110, 66);
            customerRegisterPanel.TabIndex = 1;
            // 
            // reqisterClientLabel
            // 
            reqisterClientLabel.AutoSize = true;
            reqisterClientLabel.Location = new Point(21, 7);
            reqisterClientLabel.Name = "reqisterClientLabel";
            reqisterClientLabel.Size = new Size(134, 20);
            reqisterClientLabel.TabIndex = 0;
            reqisterClientLabel.Text = "Register new client";
            // 
            // registerButton
            // 
            registerButton.Location = new Point(565, 31);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(94, 28);
            registerButton.TabIndex = 3;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            // 
            // lastName
            // 
            lastName.Location = new Point(389, 32);
            lastName.Name = "lastName";
            lastName.Size = new Size(170, 27);
            lastName.TabIndex = 2;
            // 
            // firstName
            // 
            firstName.Location = new Point(209, 31);
            firstName.Name = "firstName";
            firstName.Size = new Size(172, 27);
            firstName.TabIndex = 1;
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(21, 30);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(182, 27);
            usernameBox.TabIndex = 0;
            // 
            // clientsPanel
            // 
            clientsPanel.Controls.Add(clientsListBox);
            clientsPanel.Controls.Add(clientsLabel);
            clientsPanel.Location = new Point(7, 100);
            clientsPanel.Name = "clientsPanel";
            clientsPanel.Size = new Size(183, 514);
            clientsPanel.TabIndex = 2;
            // 
            // clientsListBox
            // 
            clientsListBox.FormattingEnabled = true;
            clientsListBox.ItemHeight = 20;
            clientsListBox.Location = new Point(21, 46);
            clientsListBox.Name = "clientsListBox";
            clientsListBox.Size = new Size(140, 444);
            clientsListBox.TabIndex = 1;
            // 
            // clientsLabel
            // 
            clientsLabel.AutoSize = true;
            clientsLabel.Location = new Point(18, 23);
            clientsLabel.Name = "clientsLabel";
            clientsLabel.Size = new Size(53, 20);
            clientsLabel.TabIndex = 0;
            clientsLabel.Text = "Clients";
            // 
            // packetsPanel
            // 
            packetsPanel.Controls.Add(dataGridView1);
            packetsPanel.Controls.Add(combinePacketsLabel);
            packetsPanel.Controls.Add(internetPacketsLabel);
            packetsPanel.Controls.Add(tvPacketsLabel);
            packetsPanel.Location = new Point(189, 100);
            packetsPanel.Name = "packetsPanel";
            packetsPanel.Size = new Size(928, 517);
            packetsPanel.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameColumn, description, price });
            dataGridView1.Location = new Point(18, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(421, 165);
            dataGridView1.TabIndex = 3;
            // 
            // nameColumn
            // 
            nameColumn.HeaderText = "name";
            nameColumn.MinimumWidth = 6;
            nameColumn.Name = "nameColumn";
            nameColumn.Width = 125;
            // 
            // description
            // 
            description.HeaderText = "descriptionColumn";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.Width = 120;
            // 
            // price
            // 
            price.HeaderText = "priceColumn";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.Width = 125;
            // 
            // combinePacketsLabel
            // 
            combinePacketsLabel.AutoSize = true;
            combinePacketsLabel.Location = new Point(452, 23);
            combinePacketsLabel.Name = "combinePacketsLabel";
            combinePacketsLabel.Size = new Size(123, 20);
            combinePacketsLabel.TabIndex = 2;
            combinePacketsLabel.Text = "Combine packets";
            // 
            // internetPacketsLabel
            // 
            internetPacketsLabel.AutoSize = true;
            internetPacketsLabel.Location = new Point(18, 248);
            internetPacketsLabel.Name = "internetPacketsLabel";
            internetPacketsLabel.Size = new Size(114, 20);
            internetPacketsLabel.TabIndex = 1;
            internetPacketsLabel.Text = "Internet packets";
            // 
            // tvPacketsLabel
            // 
            tvPacketsLabel.AutoSize = true;
            tvPacketsLabel.Location = new Point(18, 23);
            tvPacketsLabel.Name = "tvPacketsLabel";
            tvPacketsLabel.Size = new Size(80, 20);
            tvPacketsLabel.TabIndex = 0;
            tvPacketsLabel.Text = "TV packets";
            // 
            // PocetnaStrana
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 629);
            Controls.Add(packetsPanel);
            Controls.Add(clientsPanel);
            Controls.Add(customerRegisterPanel);
            Controls.Add(providerPanel);
            Name = "PocetnaStrana";
            Text = "PocetnaStrana";
            providerPanel.ResumeLayout(false);
            providerPanel.PerformLayout();
            customerRegisterPanel.ResumeLayout(false);
            customerRegisterPanel.PerformLayout();
            clientsPanel.ResumeLayout(false);
            clientsPanel.PerformLayout();
            packetsPanel.ResumeLayout(false);
            packetsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel providerPanel;
        private Panel customerRegisterPanel;
        private Panel clientsPanel;
        private Label providerName;
        private Panel packetsPanel;
        private TextBox usernameBox;


        private void usernameBox_Enter(object sender, EventArgs e)
        {
            if (usernameBox.Text == "Username")
            {
                usernameBox.Text = "";
                usernameBox.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void usernameBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameBox.Text))
            {
                usernameBox.Text = "Username";
                usernameBox.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private Button registerButton;
        private TextBox lastName;
        private TextBox firstName;
        private Label reqisterClientLabel;
        private Label clientsLabel;
        private Label tvPacketsLabel;
        private ListBox clientsListBox;
        private Label combinePacketsLabel;
        private Label internetPacketsLabel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn price;
    }
}
