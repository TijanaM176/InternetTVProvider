using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.StrategyPattern;
namespace InternetTvProviderWinApp
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            providerPanel = new Panel();
            providerName = new Label();
            clientsPanel = new Panel();
            showAllClientsListBox = new ListBox();
            clientsLabel = new Label();
            addNewClientButton = new Button();
            packetsPanel = new Panel();
            pictureBox1 = new PictureBox();
            deleteSelectedPackage = new Button();
            addNewPackageButton = new Button();
            showAllInternetPacketsGrid = new DataGridView();
            nameInternet = new DataGridViewTextBoxColumn();
            descriptionInternet = new DataGridViewTextBoxColumn();
            priceInternet = new DataGridViewTextBoxColumn();
            internetSpeed = new DataGridViewTextBoxColumn();
            showAllCombinedPacketsGrid = new DataGridView();
            nameCombined = new DataGridViewTextBoxColumn();
            priceCombined = new DataGridViewTextBoxColumn();
            descriptionCombined = new DataGridViewTextBoxColumn();
            showAllTvPacketsGrid = new DataGridView();
            nameTV = new DataGridViewTextBoxColumn();
            descriptionTV = new DataGridViewTextBoxColumn();
            priceTV = new DataGridViewTextBoxColumn();
            numberOfChannelsTV = new DataGridViewTextBoxColumn();
            combinePacketsLabel = new Label();
            internetPacketsLabel = new Label();
            tvPacketsLabel = new Label();
            providerPanel.SuspendLayout();
            clientsPanel.SuspendLayout();
            packetsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showAllInternetPacketsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showAllCombinedPacketsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showAllTvPacketsGrid).BeginInit();
            SuspendLayout();
            // 
            // providerPanel
            // 
            providerPanel.BackColor = Color.DarkCyan;
            providerPanel.Controls.Add(providerName);
            providerPanel.Location = new Point(6, 4);
            providerPanel.Margin = new Padding(3, 2, 3, 2);
            providerPanel.Name = "providerPanel";
            providerPanel.Size = new Size(971, 38);
            providerPanel.TabIndex = 0;
            // 
            // providerName
            // 
            providerName.AccessibleDescription = "";
            providerName.AccessibleName = "";
            providerName.AutoSize = true;
            providerName.BackColor = Color.DarkCyan;
            providerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            providerName.ForeColor = Color.LightCyan;
            providerName.Location = new Point(448, 10);
            providerName.Name = "providerName";
            providerName.Size = new Size(91, 15);
            providerName.TabIndex = 0;
            providerName.Text = "provider Name";
            providerName.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientsPanel
            // 
            clientsPanel.BackColor = Color.LightCyan;
            clientsPanel.Controls.Add(showAllClientsListBox);
            clientsPanel.Controls.Add(clientsLabel);
            clientsPanel.Controls.Add(addNewClientButton);
            clientsPanel.Location = new Point(6, 40);
            clientsPanel.Margin = new Padding(3, 2, 3, 2);
            clientsPanel.Name = "clientsPanel";
            clientsPanel.Size = new Size(160, 431);
            clientsPanel.TabIndex = 2;
            // 
            // showAllClientsListBox
            // 
            showAllClientsListBox.BackColor = Color.LightCyan;
            showAllClientsListBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            showAllClientsListBox.ForeColor = Color.DarkCyan;
            showAllClientsListBox.FormattingEnabled = true;
            showAllClientsListBox.ItemHeight = 15;
            showAllClientsListBox.Location = new Point(16, 70);
            showAllClientsListBox.Margin = new Padding(3, 2, 3, 2);
            showAllClientsListBox.Name = "showAllClientsListBox";
            showAllClientsListBox.Size = new Size(123, 349);
            showAllClientsListBox.TabIndex = 1;
            // 
            // clientsLabel
            // 
            clientsLabel.AutoSize = true;
            clientsLabel.BackColor = Color.LightCyan;
            clientsLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            clientsLabel.ForeColor = Color.DarkCyan;
            clientsLabel.Location = new Point(16, 6);
            clientsLabel.Name = "clientsLabel";
            clientsLabel.Size = new Size(76, 28);
            clientsLabel.TabIndex = 0;
            clientsLabel.Text = "Clients";
            clientsLabel.Click += clientsLabel_Click;
            // 
            // addNewClientButton
            // 
            addNewClientButton.BackColor = Color.DarkCyan;
            addNewClientButton.FlatStyle = FlatStyle.Popup;
            addNewClientButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addNewClientButton.ForeColor = Color.LightCyan;
            addNewClientButton.Location = new Point(16, 44);
            addNewClientButton.Margin = new Padding(3, 2, 3, 2);
            addNewClientButton.Name = "addNewClientButton";
            addNewClientButton.Size = new Size(108, 22);
            addNewClientButton.TabIndex = 6;
            addNewClientButton.Text = "Add new Client";
            addNewClientButton.UseVisualStyleBackColor = false;
            addNewClientButton.Click += addNewClientButton_Click;
            // 
            // packetsPanel
            // 
            packetsPanel.BackColor = Color.LightCyan;
            packetsPanel.Controls.Add(pictureBox1);
            packetsPanel.Controls.Add(deleteSelectedPackage);
            packetsPanel.Controls.Add(addNewPackageButton);
            packetsPanel.Controls.Add(showAllInternetPacketsGrid);
            packetsPanel.Controls.Add(showAllCombinedPacketsGrid);
            packetsPanel.Controls.Add(showAllTvPacketsGrid);
            packetsPanel.Controls.Add(combinePacketsLabel);
            packetsPanel.Controls.Add(internetPacketsLabel);
            packetsPanel.Controls.Add(tvPacketsLabel);
            packetsPanel.Location = new Point(165, 40);
            packetsPanel.Margin = new Padding(3, 2, 3, 2);
            packetsPanel.Name = "packetsPanel";
            packetsPanel.Size = new Size(812, 431);
            packetsPanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(617, 251);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 167);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // deleteSelectedPackage
            // 
            deleteSelectedPackage.BackColor = Color.DarkCyan;
            deleteSelectedPackage.FlatStyle = FlatStyle.Popup;
            deleteSelectedPackage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            deleteSelectedPackage.ForeColor = Color.LightCyan;
            deleteSelectedPackage.Location = new Point(413, 342);
            deleteSelectedPackage.Margin = new Padding(3, 2, 3, 2);
            deleteSelectedPackage.Name = "deleteSelectedPackage";
            deleteSelectedPackage.Size = new Size(156, 22);
            deleteSelectedPackage.TabIndex = 11;
            deleteSelectedPackage.Text = "Delete selected Package";
            deleteSelectedPackage.UseVisualStyleBackColor = false;
            deleteSelectedPackage.Click += deleteSelectedPackage_Click;
            // 
            // addNewPackageButton
            // 
            addNewPackageButton.BackColor = Color.DarkCyan;
            addNewPackageButton.FlatStyle = FlatStyle.Popup;
            addNewPackageButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addNewPackageButton.ForeColor = Color.LightCyan;
            addNewPackageButton.Location = new Point(413, 300);
            addNewPackageButton.Margin = new Padding(3, 2, 3, 2);
            addNewPackageButton.Name = "addNewPackageButton";
            addNewPackageButton.Size = new Size(156, 22);
            addNewPackageButton.TabIndex = 7;
            addNewPackageButton.Text = "Add new Package";
            addNewPackageButton.UseVisualStyleBackColor = false;
            addNewPackageButton.Click += addNewPackageButton_Click;
            // 
            // showAllInternetPacketsGrid
            // 
            showAllInternetPacketsGrid.BackgroundColor = Color.LightCyan;
            showAllInternetPacketsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            showAllInternetPacketsGrid.Columns.AddRange(new DataGridViewColumn[] { nameInternet, descriptionInternet, priceInternet, internetSpeed });
            showAllInternetPacketsGrid.Location = new Point(16, 256);
            showAllInternetPacketsGrid.Margin = new Padding(3, 2, 3, 2);
            showAllInternetPacketsGrid.Name = "showAllInternetPacketsGrid";
            showAllInternetPacketsGrid.RowHeadersWidth = 51;
            showAllInternetPacketsGrid.RowTemplate.Height = 29;
            showAllInternetPacketsGrid.Size = new Size(368, 162);
            showAllInternetPacketsGrid.TabIndex = 5;
            // 
            // nameInternet
            // 
            nameInternet.HeaderText = "name";
            nameInternet.MinimumWidth = 6;
            nameInternet.Name = "nameInternet";
            nameInternet.Width = 125;
            // 
            // descriptionInternet
            // 
            descriptionInternet.HeaderText = "description";
            descriptionInternet.MinimumWidth = 6;
            descriptionInternet.Name = "descriptionInternet";
            descriptionInternet.Width = 125;
            // 
            // priceInternet
            // 
            priceInternet.HeaderText = "price";
            priceInternet.MinimumWidth = 6;
            priceInternet.Name = "priceInternet";
            priceInternet.Width = 125;
            // 
            // internetSpeed
            // 
            internetSpeed.HeaderText = "internet speed";
            internetSpeed.MinimumWidth = 6;
            internetSpeed.Name = "internetSpeed";
            internetSpeed.Width = 125;
            // 
            // showAllCombinedPacketsGrid
            // 
            showAllCombinedPacketsGrid.BackgroundColor = Color.LightCyan;
            showAllCombinedPacketsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            showAllCombinedPacketsGrid.Columns.AddRange(new DataGridViewColumn[] { nameCombined, priceCombined, descriptionCombined });
            showAllCombinedPacketsGrid.Location = new Point(413, 46);
            showAllCombinedPacketsGrid.Margin = new Padding(3, 2, 3, 2);
            showAllCombinedPacketsGrid.Name = "showAllCombinedPacketsGrid";
            showAllCombinedPacketsGrid.RowHeadersWidth = 51;
            showAllCombinedPacketsGrid.RowTemplate.Height = 29;
            showAllCombinedPacketsGrid.Size = new Size(386, 162);
            showAllCombinedPacketsGrid.TabIndex = 4;
            // 
            // nameCombined
            // 
            nameCombined.HeaderText = "name";
            nameCombined.MinimumWidth = 6;
            nameCombined.Name = "nameCombined";
            nameCombined.Width = 125;
            // 
            // priceCombined
            // 
            priceCombined.HeaderText = "price";
            priceCombined.MinimumWidth = 6;
            priceCombined.Name = "priceCombined";
            priceCombined.Width = 125;
            // 
            // descriptionCombined
            // 
            descriptionCombined.HeaderText = "description";
            descriptionCombined.MinimumWidth = 6;
            descriptionCombined.Name = "descriptionCombined";
            descriptionCombined.Width = 125;
            // 
            // showAllTvPacketsGrid
            // 
            showAllTvPacketsGrid.BackgroundColor = Color.LightCyan;
            showAllTvPacketsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            showAllTvPacketsGrid.Columns.AddRange(new DataGridViewColumn[] { nameTV, descriptionTV, priceTV, numberOfChannelsTV });
            showAllTvPacketsGrid.GridColor = Color.DarkGray;
            showAllTvPacketsGrid.Location = new Point(16, 46);
            showAllTvPacketsGrid.Margin = new Padding(3, 2, 3, 2);
            showAllTvPacketsGrid.Name = "showAllTvPacketsGrid";
            showAllTvPacketsGrid.RowHeadersWidth = 51;
            showAllTvPacketsGrid.RowTemplate.Height = 29;
            showAllTvPacketsGrid.Size = new Size(368, 162);
            showAllTvPacketsGrid.TabIndex = 3;
            // 
            // nameTV
            // 
            nameTV.HeaderText = "name";
            nameTV.MinimumWidth = 6;
            nameTV.Name = "nameTV";
            nameTV.Width = 125;
            // 
            // descriptionTV
            // 
            descriptionTV.HeaderText = "description";
            descriptionTV.MinimumWidth = 6;
            descriptionTV.Name = "descriptionTV";
            descriptionTV.Width = 120;
            // 
            // priceTV
            // 
            priceTV.HeaderText = "price";
            priceTV.MinimumWidth = 6;
            priceTV.Name = "priceTV";
            priceTV.Width = 125;
            // 
            // numberOfChannelsTV
            // 
            numberOfChannelsTV.HeaderText = "number of channels";
            numberOfChannelsTV.MinimumWidth = 6;
            numberOfChannelsTV.Name = "numberOfChannelsTV";
            numberOfChannelsTV.Width = 125;
            // 
            // combinePacketsLabel
            // 
            combinePacketsLabel.AutoSize = true;
            combinePacketsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            combinePacketsLabel.ForeColor = Color.DarkCyan;
            combinePacketsLabel.Location = new Point(413, 17);
            combinePacketsLabel.Name = "combinePacketsLabel";
            combinePacketsLabel.Size = new Size(109, 15);
            combinePacketsLabel.TabIndex = 2;
            combinePacketsLabel.Text = "Combined packets";
            // 
            // internetPacketsLabel
            // 
            internetPacketsLabel.AutoSize = true;
            internetPacketsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            internetPacketsLabel.ForeColor = Color.DarkCyan;
            internetPacketsLabel.Location = new Point(16, 226);
            internetPacketsLabel.Name = "internetPacketsLabel";
            internetPacketsLabel.Size = new Size(100, 15);
            internetPacketsLabel.TabIndex = 1;
            internetPacketsLabel.Text = "Internet packets";
            // 
            // tvPacketsLabel
            // 
            tvPacketsLabel.AutoSize = true;
            tvPacketsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tvPacketsLabel.ForeColor = Color.DarkCyan;
            tvPacketsLabel.Location = new Point(16, 17);
            tvPacketsLabel.Name = "tvPacketsLabel";
            tvPacketsLabel.Size = new Size(68, 15);
            tvPacketsLabel.TabIndex = 0;
            tvPacketsLabel.Text = "TV packets";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 472);
            Controls.Add(packetsPanel);
            Controls.Add(clientsPanel);
            Controls.Add(providerPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PocetnaStrana";
            providerPanel.ResumeLayout(false);
            providerPanel.PerformLayout();
            clientsPanel.ResumeLayout(false);
            clientsPanel.PerformLayout();
            packetsPanel.ResumeLayout(false);
            packetsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)showAllInternetPacketsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)showAllCombinedPacketsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)showAllTvPacketsGrid).EndInit();
            ResumeLayout(false);
        }

        private void LoadAllTables(object sender, EventArgs e)
        {
            showAllClientsInList();
            showAllTVPackagesTable();
            showAllInternetPackagesTable();
            showAllCombinedPackagesTable();
        }

        #endregion

        private Panel providerPanel;
        private Panel clientsPanel;
        private Label providerName;
        private Panel packetsPanel;
        private Label clientsLabel;
        private Label tvPacketsLabel;
        private ListBox showAllClientsListBox;
        private Label combinePacketsLabel;
        private Label internetPacketsLabel;
        private DataGridView showAllTvPacketsGrid;
        private DataGridView showAllInternetPacketsGrid;
        private DataGridView showAllCombinedPacketsGrid;
        private DataGridViewTextBoxColumn nameInternet;
        private DataGridViewTextBoxColumn descriptionInternet;
        private DataGridViewTextBoxColumn priceInternet;
        private DataGridViewTextBoxColumn internetSpeed;
        private DataGridViewTextBoxColumn nameCombined;
        private DataGridViewTextBoxColumn priceCombined;
        private DataGridViewTextBoxColumn descriptionCombined;
        private DataGridViewTextBoxColumn nameTV;
        private DataGridViewTextBoxColumn descriptionTV;
        private DataGridViewTextBoxColumn priceTV;
        private DataGridViewTextBoxColumn numberOfChannelsTV;
        private Button deleteSelectedPackage;
        private PictureBox pictureBox1;
    }
}
