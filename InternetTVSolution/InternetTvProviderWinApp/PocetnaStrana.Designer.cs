using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.StrategyPattern;
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
            clientsPanel = new Panel();
            showAllClientsListBox = new ListBox();
            clientsLabel = new Label();
            packetsPanel = new Panel();
            deleteCombinedPackageButton = new Button();
            deleteInternetPackageButton = new Button();
            deleteTVPackageButton = new Button();
            addNewPackageButton = new Button();
            addNewClientButton = new Button();
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
            ((System.ComponentModel.ISupportInitialize)showAllInternetPacketsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showAllCombinedPacketsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)showAllTvPacketsGrid).BeginInit();
            SuspendLayout();
            // 
            // providerPanel
            // 
            providerPanel.BackColor = SystemColors.ControlLightLight;
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
            providerName.BackColor = SystemColors.ControlLight;
            providerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            providerName.ForeColor = SystemColors.Highlight;
            providerName.Location = new Point(448, 10);
            providerName.Name = "providerName";
            providerName.Size = new Size(91, 15);
            providerName.TabIndex = 0;
            providerName.Text = "provider Name";
            providerName.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientsPanel
            // 
            clientsPanel.BackColor = SystemColors.ControlLightLight;
            clientsPanel.Controls.Add(showAllClientsListBox);
            clientsPanel.Controls.Add(clientsLabel);
            clientsPanel.Location = new Point(6, 40);
            clientsPanel.Margin = new Padding(3, 2, 3, 2);
            clientsPanel.Name = "clientsPanel";
            clientsPanel.Size = new Size(160, 431);
            clientsPanel.TabIndex = 2;
            // 
            // showAllClientsListBox
            // 
            showAllClientsListBox.FormattingEnabled = true;
            showAllClientsListBox.ItemHeight = 15;
            showAllClientsListBox.Location = new Point(16, 40);
            showAllClientsListBox.Margin = new Padding(3, 2, 3, 2);
            showAllClientsListBox.Name = "showAllClientsListBox";
            showAllClientsListBox.Size = new Size(123, 379);
            showAllClientsListBox.TabIndex = 1;
            // 
            // clientsLabel
            // 
            clientsLabel.AutoSize = true;
            clientsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clientsLabel.ForeColor = Color.Navy;
            clientsLabel.Location = new Point(16, 17);
            clientsLabel.Name = "clientsLabel";
            clientsLabel.Size = new Size(44, 15);
            clientsLabel.TabIndex = 0;
            clientsLabel.Text = "Clients";
            // 
            // packetsPanel
            // 
            packetsPanel.BackColor = SystemColors.ControlLightLight;
            packetsPanel.Controls.Add(deleteCombinedPackageButton);
            packetsPanel.Controls.Add(deleteInternetPackageButton);
            packetsPanel.Controls.Add(deleteTVPackageButton);
            packetsPanel.Controls.Add(addNewPackageButton);
            packetsPanel.Controls.Add(addNewClientButton);
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
            packetsPanel.Paint += packetsPanel_Paint;
            // 
            // deleteCombinedPackageButton
            // 
            deleteCombinedPackageButton.BackColor = SystemColors.GradientActiveCaption;
            deleteCombinedPackageButton.ForeColor = SystemColors.HotTrack;
            deleteCombinedPackageButton.Location = new Point(641, 13);
            deleteCombinedPackageButton.Margin = new Padding(3, 2, 3, 2);
            deleteCombinedPackageButton.Name = "deleteCombinedPackageButton";
            deleteCombinedPackageButton.Size = new Size(158, 22);
            deleteCombinedPackageButton.TabIndex = 10;
            deleteCombinedPackageButton.Text = "Delete Combined Package";
            deleteCombinedPackageButton.UseVisualStyleBackColor = false;
            deleteCombinedPackageButton.Click += deleteCombinedPackageButton_Click_1;
            // 
            // deleteInternetPackageButton
            // 
            deleteInternetPackageButton.BackColor = SystemColors.GradientActiveCaption;
            deleteInternetPackageButton.ForeColor = SystemColors.HotTrack;
            deleteInternetPackageButton.Location = new Point(239, 226);
            deleteInternetPackageButton.Margin = new Padding(3, 2, 3, 2);
            deleteInternetPackageButton.Name = "deleteInternetPackageButton";
            deleteInternetPackageButton.Size = new Size(145, 22);
            deleteInternetPackageButton.TabIndex = 9;
            deleteInternetPackageButton.Text = "Delete Internet Package";
            deleteInternetPackageButton.UseVisualStyleBackColor = false;
            deleteInternetPackageButton.Click += deleteInternetPackageButton_Click_1;
            // 
            // deleteTVPackageButton
            // 
            deleteTVPackageButton.BackColor = SystemColors.GradientActiveCaption;
            deleteTVPackageButton.ForeColor = SystemColors.HotTrack;
            deleteTVPackageButton.Location = new Point(259, 13);
            deleteTVPackageButton.Margin = new Padding(3, 2, 3, 2);
            deleteTVPackageButton.Name = "deleteTVPackageButton";
            deleteTVPackageButton.Size = new Size(121, 22);
            deleteTVPackageButton.TabIndex = 8;
            deleteTVPackageButton.Text = "Delete TV Package";
            deleteTVPackageButton.UseVisualStyleBackColor = false;
            deleteTVPackageButton.Click += deleteTVPackageButton_Click;
            // 
            // addNewPackageButton
            // 
            addNewPackageButton.BackColor = SystemColors.GradientActiveCaption;
            addNewPackageButton.ForeColor = SystemColors.HotTrack;
            addNewPackageButton.Location = new Point(497, 315);
            addNewPackageButton.Margin = new Padding(3, 2, 3, 2);
            addNewPackageButton.Name = "addNewPackageButton";
            addNewPackageButton.Size = new Size(211, 22);
            addNewPackageButton.TabIndex = 7;
            addNewPackageButton.Text = "Add new Package";
            addNewPackageButton.UseVisualStyleBackColor = false;
            addNewPackageButton.Click += addNewPackageButton_Click;
            // 
            // addNewClientButton
            // 
            addNewClientButton.BackColor = SystemColors.GradientActiveCaption;
            addNewClientButton.ForeColor = SystemColors.HotTrack;
            addNewClientButton.Location = new Point(497, 275);
            addNewClientButton.Margin = new Padding(3, 2, 3, 2);
            addNewClientButton.Name = "addNewClientButton";
            addNewClientButton.Size = new Size(211, 22);
            addNewClientButton.TabIndex = 6;
            addNewClientButton.Text = "Add new Client";
            addNewClientButton.UseVisualStyleBackColor = false;
            addNewClientButton.Click += addNewClientButton_Click;
            // 
            // showAllInternetPacketsGrid
            // 
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
            showAllTvPacketsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            showAllTvPacketsGrid.Columns.AddRange(new DataGridViewColumn[] { nameTV, descriptionTV, priceTV, numberOfChannelsTV });
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
            combinePacketsLabel.ForeColor = Color.IndianRed;
            combinePacketsLabel.Location = new Point(413, 17);
            combinePacketsLabel.Name = "combinePacketsLabel";
            combinePacketsLabel.Size = new Size(102, 15);
            combinePacketsLabel.TabIndex = 2;
            combinePacketsLabel.Text = "Combine packets";
            // 
            // internetPacketsLabel
            // 
            internetPacketsLabel.AutoSize = true;
            internetPacketsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            internetPacketsLabel.ForeColor = Color.IndianRed;
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
            tvPacketsLabel.ForeColor = Color.IndianRed;
            tvPacketsLabel.Location = new Point(16, 17);
            tvPacketsLabel.Name = "tvPacketsLabel";
            tvPacketsLabel.Size = new Size(68, 15);
            tvPacketsLabel.TabIndex = 0;
            tvPacketsLabel.Text = "TV packets";
            // 
            // PocetnaStrana
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 472);
            Controls.Add(packetsPanel);
            Controls.Add(clientsPanel);
            Controls.Add(providerPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PocetnaStrana";
            Text = "PocetnaStrana";
            providerPanel.ResumeLayout(false);
            providerPanel.PerformLayout();
            clientsPanel.ResumeLayout(false);
            clientsPanel.PerformLayout();
            packetsPanel.ResumeLayout(false);
            packetsPanel.PerformLayout();
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
        private Button deleteInternetPackageButton;
        private Button deleteCombinedPackageButton;
    }
}
