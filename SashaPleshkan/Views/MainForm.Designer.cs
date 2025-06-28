namespace FurnitureAccounting.Views
{
    partial class MainForm
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
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.navigationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.furnitureButton = new System.Windows.Forms.Button();
            this.departmentsButton = new System.Windows.Forms.Button();
            this.assignmentButton = new System.Windows.Forms.Button();
            this.writeOffButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.logsButton = new System.Windows.Forms.Button();
            this.dividerLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.userStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.dashboardPanel = new System.Windows.Forms.Panel();
            this.dashboardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.totalFurnitureCard = new System.Windows.Forms.Panel();
            this.totalFurnitureIconLabel = new System.Windows.Forms.Label();
            this.totalFurnitureTitleLabel = new System.Windows.Forms.Label();
            this.totalFurnitureValueLabel = new System.Windows.Forms.Label();
            this.activeFurnitureCard = new System.Windows.Forms.Panel();
            this.activeFurnitureIconLabel = new System.Windows.Forms.Label();
            this.activeFurnitureTitleLabel = new System.Windows.Forms.Label();
            this.activeFurnitureValueLabel = new System.Windows.Forms.Label();
            this.departmentsCard = new System.Windows.Forms.Panel();
            this.departmentsIconLabel = new System.Windows.Forms.Label();
            this.departmentsTitleLabel = new System.Windows.Forms.Label();
            this.departmentsValueLabel = new System.Windows.Forms.Label();
            this.totalValueCard = new System.Windows.Forms.Panel();
            this.totalValueIconLabel = new System.Windows.Forms.Label();
            this.totalValueTitleLabel = new System.Windows.Forms.Label();
            this.totalValueValueLabel = new System.Windows.Forms.Label();
            this.recentActionsPanel = new System.Windows.Forms.Panel();
            this.recentActionsTitleLabel = new System.Windows.Forms.Label();
            this.recentActionsDataGridView = new System.Windows.Forms.DataGridView();
            this.sidebarPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.dashboardPanel.SuspendLayout();
            this.dashboardLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.totalFurnitureCard.SuspendLayout();
            this.activeFurnitureCard.SuspendLayout();
            this.departmentsCard.SuspendLayout();
            this.totalValueCard.SuspendLayout();
            this.recentActionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentActionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.sidebarPanel.Controls.Add(this.logoPanel);
            this.sidebarPanel.Controls.Add(this.navigationPanel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(250, 928);
            this.sidebarPanel.TabIndex = 0;
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 60);
            this.logoPanel.TabIndex = 0;
            // 
            // logoLabel
            // 
            this.logoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(0, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(250, 60);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "🪑 Учет мебели";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.dashboardButton);
            this.navigationPanel.Controls.Add(this.furnitureButton);
            this.navigationPanel.Controls.Add(this.departmentsButton);
            this.navigationPanel.Controls.Add(this.assignmentButton);
            this.navigationPanel.Controls.Add(this.writeOffButton);
            this.navigationPanel.Controls.Add(this.reportsButton);
            this.navigationPanel.Controls.Add(this.logsButton);
            this.navigationPanel.Controls.Add(this.dividerLabel);
            this.navigationPanel.Controls.Add(this.logoutButton);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.navigationPanel.Location = new System.Drawing.Point(0, 60);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(250, 828);
            this.navigationPanel.TabIndex = 1;
            // 
            // dashboardButton
            // 
            this.dashboardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.dashboardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dashboardButton.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.Location = new System.Drawing.Point(0, 0);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(0);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(250, 50);
            this.dashboardButton.TabIndex = 0;
            this.dashboardButton.Text = "    📊 Главная";
            this.dashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.dashboardButton.UseVisualStyleBackColor = false;
            // 
            // furnitureButton
            // 
            this.furnitureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.furnitureButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.furnitureButton.FlatAppearance.BorderSize = 0;
            this.furnitureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.furnitureButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.furnitureButton.ForeColor = System.Drawing.Color.White;
            this.furnitureButton.Location = new System.Drawing.Point(0, 50);
            this.furnitureButton.Margin = new System.Windows.Forms.Padding(0);
            this.furnitureButton.Name = "furnitureButton";
            this.furnitureButton.Size = new System.Drawing.Size(250, 50);
            this.furnitureButton.TabIndex = 1;
            this.furnitureButton.Text = "    🪑 Мебель";
            this.furnitureButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.furnitureButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.furnitureButton.UseVisualStyleBackColor = false;
            // 
            // departmentsButton
            // 
            this.departmentsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.departmentsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.departmentsButton.FlatAppearance.BorderSize = 0;
            this.departmentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.departmentsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.departmentsButton.ForeColor = System.Drawing.Color.White;
            this.departmentsButton.Location = new System.Drawing.Point(0, 100);
            this.departmentsButton.Margin = new System.Windows.Forms.Padding(0);
            this.departmentsButton.Name = "departmentsButton";
            this.departmentsButton.Size = new System.Drawing.Size(250, 50);
            this.departmentsButton.TabIndex = 2;
            this.departmentsButton.Text = "    🏢 Отделы";
            this.departmentsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.departmentsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.departmentsButton.UseVisualStyleBackColor = false;
            // 
            // assignmentButton
            // 
            this.assignmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.assignmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assignmentButton.FlatAppearance.BorderSize = 0;
            this.assignmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assignmentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.assignmentButton.ForeColor = System.Drawing.Color.White;
            this.assignmentButton.Location = new System.Drawing.Point(0, 150);
            this.assignmentButton.Margin = new System.Windows.Forms.Padding(0);
            this.assignmentButton.Name = "assignmentButton";
            this.assignmentButton.Size = new System.Drawing.Size(250, 50);
            this.assignmentButton.TabIndex = 3;
            this.assignmentButton.Text = "    📍 Назначение";
            this.assignmentButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assignmentButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.assignmentButton.UseVisualStyleBackColor = false;
            // 
            // writeOffButton
            // 
            this.writeOffButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.writeOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.writeOffButton.FlatAppearance.BorderSize = 0;
            this.writeOffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeOffButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.writeOffButton.ForeColor = System.Drawing.Color.White;
            this.writeOffButton.Location = new System.Drawing.Point(0, 200);
            this.writeOffButton.Margin = new System.Windows.Forms.Padding(0);
            this.writeOffButton.Name = "writeOffButton";
            this.writeOffButton.Size = new System.Drawing.Size(250, 50);
            this.writeOffButton.TabIndex = 4;
            this.writeOffButton.Text = "    ❌ Списание";
            this.writeOffButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.writeOffButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.writeOffButton.UseVisualStyleBackColor = false;
            // 
            // reportsButton
            // 
            this.reportsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.reportsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportsButton.FlatAppearance.BorderSize = 0;
            this.reportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reportsButton.ForeColor = System.Drawing.Color.White;
            this.reportsButton.Location = new System.Drawing.Point(0, 250);
            this.reportsButton.Margin = new System.Windows.Forms.Padding(0);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(250, 50);
            this.reportsButton.TabIndex = 5;
            this.reportsButton.Text = "    📈 Отчеты";
            this.reportsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.reportsButton.UseVisualStyleBackColor = false;
            // 
            // logsButton
            // 
            this.logsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.logsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logsButton.FlatAppearance.BorderSize = 0;
            this.logsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logsButton.ForeColor = System.Drawing.Color.White;
            this.logsButton.Location = new System.Drawing.Point(0, 300);
            this.logsButton.Margin = new System.Windows.Forms.Padding(0);
            this.logsButton.Name = "logsButton";
            this.logsButton.Size = new System.Drawing.Size(250, 50);
            this.logsButton.TabIndex = 6;
            this.logsButton.Text = "    📋 Журнал";
            this.logsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.logsButton.UseVisualStyleBackColor = false;
            // 
            // dividerLabel
            // 
            this.dividerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dividerLabel.Location = new System.Drawing.Point(3, 353);
            this.dividerLabel.Name = "dividerLabel";
            this.dividerLabel.Size = new System.Drawing.Size(244, 2);
            this.dividerLabel.TabIndex = 7;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.Location = new System.Drawing.Point(0, 358);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(250, 50);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "    🚪 Выход";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(250, 928);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1550, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // userStatusLabel
            // 
            this.userStatusLabel.Name = "userStatusLabel";
            this.userStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.userStatusLabel.Text = "Пользователь: Гость";
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.mainContentPanel.Controls.Add(this.dashboardPanel);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(250, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainContentPanel.Size = new System.Drawing.Size(1550, 928);
            this.mainContentPanel.TabIndex = 2;
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.Controls.Add(this.dashboardLayout);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardPanel.Location = new System.Drawing.Point(20, 20);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(1510, 888);
            this.dashboardPanel.TabIndex = 0;
            // 
            // dashboardLayout
            // 
            this.dashboardLayout.ColumnCount = 1;
            this.dashboardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dashboardLayout.Controls.Add(this.headerPanel, 0, 0);
            this.dashboardLayout.Controls.Add(this.statsPanel, 0, 1);
            this.dashboardLayout.Controls.Add(this.recentActionsPanel, 0, 2);
            this.dashboardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardLayout.Location = new System.Drawing.Point(0, 0);
            this.dashboardLayout.Name = "dashboardLayout";
            this.dashboardLayout.RowCount = 3;
            this.dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.dashboardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dashboardLayout.Size = new System.Drawing.Size(1510, 888);
            this.dashboardLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.welcomeLabel);
            this.headerPanel.Controls.Add(this.dateLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(3, 3);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1504, 74);
            this.headerPanel.TabIndex = 0;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.welcomeLabel.Location = new System.Drawing.Point(0, 10);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(317, 45);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Добро пожаловать!";
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.ForeColor = System.Drawing.Color.Gray;
            this.dateLabel.Location = new System.Drawing.Point(1204, 20);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(300, 25);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Дата";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.totalFurnitureCard);
            this.statsPanel.Controls.Add(this.activeFurnitureCard);
            this.statsPanel.Controls.Add(this.departmentsCard);
            this.statsPanel.Controls.Add(this.totalValueCard);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsPanel.Location = new System.Drawing.Point(3, 83);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(1504, 174);
            this.statsPanel.TabIndex = 1;
            // 
            // totalFurnitureCard
            // 
            this.totalFurnitureCard.BackColor = System.Drawing.Color.White;
            this.totalFurnitureCard.Controls.Add(this.totalFurnitureIconLabel);
            this.totalFurnitureCard.Controls.Add(this.totalFurnitureTitleLabel);
            this.totalFurnitureCard.Controls.Add(this.totalFurnitureValueLabel);
            this.totalFurnitureCard.Location = new System.Drawing.Point(3, 3);
            this.totalFurnitureCard.Name = "totalFurnitureCard";
            this.totalFurnitureCard.Size = new System.Drawing.Size(300, 150);
            this.totalFurnitureCard.TabIndex = 0;
            // 
            // totalFurnitureIconLabel
            // 
            this.totalFurnitureIconLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalFurnitureIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.totalFurnitureIconLabel.Location = new System.Drawing.Point(20, 20);
            this.totalFurnitureIconLabel.Name = "totalFurnitureIconLabel";
            this.totalFurnitureIconLabel.Size = new System.Drawing.Size(80, 80);
            this.totalFurnitureIconLabel.TabIndex = 0;
            this.totalFurnitureIconLabel.Text = "🪑";
            this.totalFurnitureIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalFurnitureTitleLabel
            // 
            this.totalFurnitureTitleLabel.AutoSize = true;
            this.totalFurnitureTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalFurnitureTitleLabel.ForeColor = System.Drawing.Color.Gray;
            this.totalFurnitureTitleLabel.Location = new System.Drawing.Point(120, 30);
            this.totalFurnitureTitleLabel.Name = "totalFurnitureTitleLabel";
            this.totalFurnitureTitleLabel.Size = new System.Drawing.Size(111, 21);
            this.totalFurnitureTitleLabel.TabIndex = 1;
            this.totalFurnitureTitleLabel.Text = "Всего мебели";
            // 
            // totalFurnitureValueLabel
            // 
            this.totalFurnitureValueLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalFurnitureValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalFurnitureValueLabel.Location = new System.Drawing.Point(120, 60);
            this.totalFurnitureValueLabel.Name = "totalFurnitureValueLabel";
            this.totalFurnitureValueLabel.Size = new System.Drawing.Size(160, 50);
            this.totalFurnitureValueLabel.TabIndex = 2;
            this.totalFurnitureValueLabel.Text = "0";
            // 
            // activeFurnitureCard
            // 
            this.activeFurnitureCard.BackColor = System.Drawing.Color.White;
            this.activeFurnitureCard.Controls.Add(this.activeFurnitureIconLabel);
            this.activeFurnitureCard.Controls.Add(this.activeFurnitureTitleLabel);
            this.activeFurnitureCard.Controls.Add(this.activeFurnitureValueLabel);
            this.activeFurnitureCard.Location = new System.Drawing.Point(309, 3);
            this.activeFurnitureCard.Name = "activeFurnitureCard";
            this.activeFurnitureCard.Size = new System.Drawing.Size(300, 150);
            this.activeFurnitureCard.TabIndex = 1;
            // 
            // activeFurnitureIconLabel
            // 
            this.activeFurnitureIconLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.activeFurnitureIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.activeFurnitureIconLabel.Location = new System.Drawing.Point(20, 20);
            this.activeFurnitureIconLabel.Name = "activeFurnitureIconLabel";
            this.activeFurnitureIconLabel.Size = new System.Drawing.Size(80, 80);
            this.activeFurnitureIconLabel.TabIndex = 0;
            this.activeFurnitureIconLabel.Text = "✅";
            this.activeFurnitureIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // activeFurnitureTitleLabel
            // 
            this.activeFurnitureTitleLabel.AutoSize = true;
            this.activeFurnitureTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.activeFurnitureTitleLabel.ForeColor = System.Drawing.Color.Gray;
            this.activeFurnitureTitleLabel.Location = new System.Drawing.Point(120, 30);
            this.activeFurnitureTitleLabel.Name = "activeFurnitureTitleLabel";
            this.activeFurnitureTitleLabel.Size = new System.Drawing.Size(146, 21);
            this.activeFurnitureTitleLabel.TabIndex = 1;
            this.activeFurnitureTitleLabel.Text = "Активная мебель";
            // 
            // activeFurnitureValueLabel
            // 
            this.activeFurnitureValueLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.activeFurnitureValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.activeFurnitureValueLabel.Location = new System.Drawing.Point(120, 60);
            this.activeFurnitureValueLabel.Name = "activeFurnitureValueLabel";
            this.activeFurnitureValueLabel.Size = new System.Drawing.Size(160, 50);
            this.activeFurnitureValueLabel.TabIndex = 2;
            this.activeFurnitureValueLabel.Text = "0";
            // 
            // departmentsCard
            // 
            this.departmentsCard.BackColor = System.Drawing.Color.White;
            this.departmentsCard.Controls.Add(this.departmentsIconLabel);
            this.departmentsCard.Controls.Add(this.departmentsTitleLabel);
            this.departmentsCard.Controls.Add(this.departmentsValueLabel);
            this.departmentsCard.Location = new System.Drawing.Point(615, 3);
            this.departmentsCard.Name = "departmentsCard";
            this.departmentsCard.Size = new System.Drawing.Size(300, 150);
            this.departmentsCard.TabIndex = 2;
            // 
            // departmentsIconLabel
            // 
            this.departmentsIconLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.departmentsIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.departmentsIconLabel.Location = new System.Drawing.Point(20, 20);
            this.departmentsIconLabel.Name = "departmentsIconLabel";
            this.departmentsIconLabel.Size = new System.Drawing.Size(80, 80);
            this.departmentsIconLabel.TabIndex = 0;
            this.departmentsIconLabel.Text = "🏢";
            this.departmentsIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // departmentsTitleLabel
            // 
            this.departmentsTitleLabel.AutoSize = true;
            this.departmentsTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.departmentsTitleLabel.ForeColor = System.Drawing.Color.Gray;
            this.departmentsTitleLabel.Location = new System.Drawing.Point(120, 30);
            this.departmentsTitleLabel.Name = "departmentsTitleLabel";
            this.departmentsTitleLabel.Size = new System.Drawing.Size(66, 21);
            this.departmentsTitleLabel.TabIndex = 1;
            this.departmentsTitleLabel.Text = "Отделы";
            // 
            // departmentsValueLabel
            // 
            this.departmentsValueLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.departmentsValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.departmentsValueLabel.Location = new System.Drawing.Point(120, 60);
            this.departmentsValueLabel.Name = "departmentsValueLabel";
            this.departmentsValueLabel.Size = new System.Drawing.Size(160, 50);
            this.departmentsValueLabel.TabIndex = 2;
            this.departmentsValueLabel.Text = "0";
            // 
            // totalValueCard
            // 
            this.totalValueCard.BackColor = System.Drawing.Color.White;
            this.totalValueCard.Controls.Add(this.totalValueIconLabel);
            this.totalValueCard.Controls.Add(this.totalValueTitleLabel);
            this.totalValueCard.Controls.Add(this.totalValueValueLabel);
            this.totalValueCard.Location = new System.Drawing.Point(921, 3);
            this.totalValueCard.Name = "totalValueCard";
            this.totalValueCard.Size = new System.Drawing.Size(300, 150);
            this.totalValueCard.TabIndex = 3;
            // 
            // totalValueIconLabel
            // 
            this.totalValueIconLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalValueIconLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.totalValueIconLabel.Location = new System.Drawing.Point(20, 20);
            this.totalValueIconLabel.Name = "totalValueIconLabel";
            this.totalValueIconLabel.Size = new System.Drawing.Size(80, 80);
            this.totalValueIconLabel.TabIndex = 0;
            this.totalValueIconLabel.Text = "💰";
            this.totalValueIconLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalValueTitleLabel
            // 
            this.totalValueTitleLabel.AutoSize = true;
            this.totalValueTitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalValueTitleLabel.ForeColor = System.Drawing.Color.Gray;
            this.totalValueTitleLabel.Location = new System.Drawing.Point(120, 30);
            this.totalValueTitleLabel.Name = "totalValueTitleLabel";
            this.totalValueTitleLabel.Size = new System.Drawing.Size(137, 21);
            this.totalValueTitleLabel.TabIndex = 1;
            this.totalValueTitleLabel.Text = "Общая стоимость";
            // 
            // totalValueValueLabel
            // 
            this.totalValueValueLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalValueValueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalValueValueLabel.Location = new System.Drawing.Point(120, 60);
            this.totalValueValueLabel.Name = "totalValueValueLabel";
            this.totalValueValueLabel.Size = new System.Drawing.Size(160, 50);
            this.totalValueValueLabel.TabIndex = 2;
            this.totalValueValueLabel.Text = "0 ₽";
            // 
            // recentActionsPanel
            // 
            this.recentActionsPanel.BackColor = System.Drawing.Color.White;
            this.recentActionsPanel.Controls.Add(this.recentActionsTitleLabel);
            this.recentActionsPanel.Controls.Add(this.recentActionsDataGridView);
            this.recentActionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentActionsPanel.Location = new System.Drawing.Point(3, 263);
            this.recentActionsPanel.Name = "recentActionsPanel";
            this.recentActionsPanel.Padding = new System.Windows.Forms.Padding(20);
            this.recentActionsPanel.Size = new System.Drawing.Size(1504, 622);
            this.recentActionsPanel.TabIndex = 2;
            // 
            // recentActionsTitleLabel
            // 
            this.recentActionsTitleLabel.AutoSize = true;
            this.recentActionsTitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.recentActionsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.recentActionsTitleLabel.Location = new System.Drawing.Point(20, 20);
            this.recentActionsTitleLabel.Name = "recentActionsTitleLabel";
            this.recentActionsTitleLabel.Size = new System.Drawing.Size(232, 30);
            this.recentActionsTitleLabel.TabIndex = 0;
            this.recentActionsTitleLabel.Text = "Последние действия";
            // 
            // recentActionsDataGridView
            // 
            this.recentActionsDataGridView.AllowUserToAddRows = false;
            this.recentActionsDataGridView.AllowUserToDeleteRows = false;
            this.recentActionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recentActionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.recentActionsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.recentActionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentActionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recentActionsDataGridView.Location = new System.Drawing.Point(20, 60);
            this.recentActionsDataGridView.Name = "recentActionsDataGridView";
            this.recentActionsDataGridView.ReadOnly = true;
            this.recentActionsDataGridView.RowTemplate.Height = 25;
            this.recentActionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recentActionsDataGridView.Size = new System.Drawing.Size(1464, 542);
            this.recentActionsDataGridView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.sidebarPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система учета мебели";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.sidebarPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.dashboardPanel.ResumeLayout(false);
            this.dashboardLayout.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.totalFurnitureCard.ResumeLayout(false);
            this.totalFurnitureCard.PerformLayout();
            this.activeFurnitureCard.ResumeLayout(false);
            this.activeFurnitureCard.PerformLayout();
            this.departmentsCard.ResumeLayout(false);
            this.departmentsCard.PerformLayout();
            this.totalValueCard.ResumeLayout(false);
            this.totalValueCard.PerformLayout();
            this.recentActionsPanel.ResumeLayout(false);
            this.recentActionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentActionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.FlowLayoutPanel navigationPanel;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button furnitureButton;
        private System.Windows.Forms.Button departmentsButton;
        private System.Windows.Forms.Button assignmentButton;
        private System.Windows.Forms.Button writeOffButton;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.Button logsButton;
        private System.Windows.Forms.Label dividerLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel userStatusLabel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Panel dashboardPanel;
        private System.Windows.Forms.TableLayoutPanel dashboardLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.FlowLayoutPanel statsPanel;
        private System.Windows.Forms.Panel totalFurnitureCard;
        private System.Windows.Forms.Label totalFurnitureIconLabel;
        private System.Windows.Forms.Label totalFurnitureTitleLabel;
        private System.Windows.Forms.Label totalFurnitureValueLabel;
        private System.Windows.Forms.Panel activeFurnitureCard;
        private System.Windows.Forms.Label activeFurnitureIconLabel;
        private System.Windows.Forms.Label activeFurnitureTitleLabel;
        private System.Windows.Forms.Label activeFurnitureValueLabel;
        private System.Windows.Forms.Panel departmentsCard;
        private System.Windows.Forms.Label departmentsIconLabel;
        private System.Windows.Forms.Label departmentsTitleLabel;
        private System.Windows.Forms.Label departmentsValueLabel;
        private System.Windows.Forms.Panel totalValueCard;
        private System.Windows.Forms.Label totalValueIconLabel;
        private System.Windows.Forms.Label totalValueTitleLabel;
        private System.Windows.Forms.Label totalValueValueLabel;
        private System.Windows.Forms.Panel recentActionsPanel;
        private System.Windows.Forms.Label recentActionsTitleLabel;
        private System.Windows.Forms.DataGridView recentActionsDataGridView;
    }
}