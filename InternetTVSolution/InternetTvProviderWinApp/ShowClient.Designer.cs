namespace InternetTvProviderWinApp
{
    partial class ShowClient
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
            label3 = new Label();
            label4 = new Label();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label5 = new Label();
            addNewSubscriptionButton = new Button();
            undoButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(46, 26);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 0;
            label1.Text = "FirstName:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(46, 52);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 1;
            label2.Text = "LastName:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkCyan;
            label3.Location = new Point(46, 79);
            label3.Name = "label3";
            label3.Size = new Size(80, 19);
            label3.TabIndex = 2;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkCyan;
            label4.Location = new Point(46, 112);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 4;
            label4.Text = "Client subscriptions:";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Location = new Point(46, 134);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(398, 119);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Package name";
            columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Price";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status";
            columnHeader3.Width = 200;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Firebrick;
            label5.Location = new Point(461, 26);
            label5.Name = "label5";
            label5.Size = new Size(45, 21);
            label5.TabIndex = 6;
            label5.Text = "Total:";
            // 
            // addNewSubscriptionButton
            // 
            addNewSubscriptionButton.BackColor = Color.DarkCyan;
            addNewSubscriptionButton.FlatStyle = FlatStyle.Popup;
            addNewSubscriptionButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addNewSubscriptionButton.ForeColor = Color.LightCyan;
            addNewSubscriptionButton.Location = new Point(461, 230);
            addNewSubscriptionButton.Margin = new Padding(3, 2, 3, 2);
            addNewSubscriptionButton.Name = "addNewSubscriptionButton";
            addNewSubscriptionButton.Size = new Size(147, 22);
            addNewSubscriptionButton.TabIndex = 7;
            addNewSubscriptionButton.Text = "Add new Subscription";
            addNewSubscriptionButton.UseVisualStyleBackColor = false;
            addNewSubscriptionButton.Click += addNewSubscriptionButton_Click;
            // 
            // undoButton
            // 
            undoButton.BackColor = Color.DarkCyan;
            undoButton.FlatStyle = FlatStyle.Popup;
            undoButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            undoButton.ForeColor = Color.LightCyan;
            undoButton.Location = new Point(361, 256);
            undoButton.Margin = new Padding(3, 2, 3, 2);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(82, 22);
            undoButton.TabIndex = 8;
            undoButton.Text = "Undo ";
            undoButton.UseVisualStyleBackColor = false;
            // 
            // ShowClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(626, 287);
            Controls.Add(undoButton);
            Controls.Add(addNewSubscriptionButton);
            Controls.Add(label5);
            Controls.Add(listView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ShowClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShowClient";
            Load += ShowClient_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label label5;
        private Button addNewSubscriptionButton;
        private Button undoButton;
    }
}