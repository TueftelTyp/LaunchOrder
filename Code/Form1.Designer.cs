namespace LaunchOrder
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.btnUp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDown = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetAutostart = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelAutostart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.btnMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.menStrip5btn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDataFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInfo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.destroyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDesroyYes = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowDrop = true;
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToResizeColumns = false;
            this.dgvOrder.AllowUserToResizeRows = false;
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(5, 66);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOrder.Size = new System.Drawing.Size(542, 318);
            this.dgvOrder.TabIndex = 4;
            this.dgvOrder.TabStop = false;
            this.dgvOrder.SelectionChanged += new System.EventHandler(this.dgvOrder_SelectionChanged);
            this.dgvOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvOrder_DragDrop);
            this.dgvOrder.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvOrder_DragOver);
            this.dgvOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvOrder_MouseDown);
            this.dgvOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvOrder_MouseMove);
            this.dgvOrder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvOrder_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add});
            this.menuStrip1.Location = new System.Drawing.Point(9, 39);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(65, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Add
            // 
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnAddDelay,
            this.btnImport});
            this.Add.Image = global::LaunchOrder.Properties.Resources.add;
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(28, 20);
            this.Add.Text = "Add";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::LaunchOrder.Properties.Resources.program;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 22);
            this.btnAdd.Text = "Program";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddDelay
            // 
            this.btnAddDelay.Image = global::LaunchOrder.Properties.Resources.time;
            this.btnAddDelay.Name = "btnAddDelay";
            this.btnAddDelay.Size = new System.Drawing.Size(120, 22);
            this.btnAddDelay.Text = "Delay";
            this.btnAddDelay.Click += new System.EventHandler(this.btnAddDelay_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Control;
            this.btnImport.Image = global::LaunchOrder.Properties.Resources.load;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 22);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUp,
            this.btnDown,
            this.btnDelete});
            this.menuStrip2.Location = new System.Drawing.Point(74, 39);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(104, 21);
            this.menuStrip2.Stretch = false;
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // btnUp
            // 
            this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUp.Image = global::LaunchOrder.Properties.Resources.up;
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 17);
            this.btnUp.Text = "UP";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDown.Image = global::LaunchOrder.Properties.Resources.down;
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 17);
            this.btnDown.Text = "DOWN";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::LaunchOrder.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 17);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // menuStrip3
            // 
            this.menuStrip3.AutoSize = false;
            this.menuStrip3.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSetAutostart,
            this.btnDelAutostart});
            this.menuStrip3.Location = new System.Drawing.Point(196, 39);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(65, 21);
            this.menuStrip3.Stretch = false;
            this.menuStrip3.TabIndex = 12;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::LaunchOrder.Properties.Resources.save;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(28, 17);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSetAutostart
            // 
            this.btnSetAutostart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetAutostart.Image = global::LaunchOrder.Properties.Resources.on;
            this.btnSetAutostart.Name = "btnSetAutostart";
            this.btnSetAutostart.Size = new System.Drawing.Size(28, 17);
            this.btnSetAutostart.Text = "Autostart";
            this.btnSetAutostart.Click += new System.EventHandler(this.btnSetAutostart_Click);
            // 
            // btnDelAutostart
            // 
            this.btnDelAutostart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelAutostart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelAutostart.Image = global::LaunchOrder.Properties.Resources.off;
            this.btnDelAutostart.Name = "btnDelAutostart";
            this.btnDelAutostart.Size = new System.Drawing.Size(28, 17);
            this.btnDelAutostart.Text = "Autostart";
            this.btnDelAutostart.Click += new System.EventHandler(this.btnDelAutostart_Click);
            // 
            // menuStrip4
            // 
            this.menuStrip4.AutoSize = false;
            this.menuStrip4.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMinimize,
            this.btnClose,
            this.toolStripMenuItem3});
            this.menuStrip4.Location = new System.Drawing.Point(482, 1);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(65, 21);
            this.menuStrip4.Stretch = false;
            this.menuStrip4.TabIndex = 14;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // btnMinimize
            // 
            this.btnMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMinimize.Image = global::LaunchOrder.Properties.Resources.mini;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 17);
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::LaunchOrder.Properties.Resources.close;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 17);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem3.Image = global::LaunchOrder.Properties.Resources.off;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(28, 17);
            this.toolStripMenuItem3.Text = "Autostart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Launch Order";
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.BackgroundImage = global::LaunchOrder.Properties.Resources.logo;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Location = new System.Drawing.Point(5, 1);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(29, 28);
            this.btnInfo.TabIndex = 13;
            this.btnInfo.TabStop = false;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LaunchOrder";
            this.notifyIcon1.Visible = true;
            // 
            // menuStrip5
            // 
            this.menuStrip5.AutoSize = false;
            this.menuStrip5.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menStrip5btn});
            this.menuStrip5.Location = new System.Drawing.Point(300, 39);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Size = new System.Drawing.Size(48, 21);
            this.menuStrip5.Stretch = false;
            this.menuStrip5.TabIndex = 16;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // menStrip5btn
            // 
            this.menStrip5btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menStrip5btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartFolder,
            this.btnDataFolder,
            this.toolStripSeparator2,
            this.btnInfo2,
            this.toolStripSeparator1,
            this.destroyToolStripMenuItem});
            this.menStrip5btn.Image = ((System.Drawing.Image)(resources.GetObject("menStrip5btn.Image")));
            this.menStrip5btn.Name = "menStrip5btn";
            this.menStrip5btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menStrip5btn.Size = new System.Drawing.Size(28, 17);
            this.menStrip5btn.Text = "plus";
            // 
            // btnStartFolder
            // 
            this.btnStartFolder.Image = global::LaunchOrder.Properties.Resources.folder;
            this.btnStartFolder.Name = "btnStartFolder";
            this.btnStartFolder.Size = new System.Drawing.Size(180, 22);
            this.btnStartFolder.Text = "open Autostart";
            this.btnStartFolder.Click += new System.EventHandler(this.btnStartFolder_Click);
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Image = global::LaunchOrder.Properties.Resources.folder;
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(180, 22);
            this.btnDataFolder.Text = "open Data";
            this.btnDataFolder.Click += new System.EventHandler(this.btnDataFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // btnInfo2
            // 
            this.btnInfo2.Image = global::LaunchOrder.Properties.Resources.info;
            this.btnInfo2.Name = "btnInfo2";
            this.btnInfo2.Size = new System.Drawing.Size(180, 22);
            this.btnInfo2.Text = "Info";
            this.btnInfo2.Click += new System.EventHandler(this.btnInfo2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // destroyToolStripMenuItem
            // 
            this.destroyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reallyToolStripMenuItem});
            this.destroyToolStripMenuItem.Image = global::LaunchOrder.Properties.Resources.bomb;
            this.destroyToolStripMenuItem.Name = "destroyToolStripMenuItem";
            this.destroyToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.destroyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.destroyToolStripMenuItem.Text = "Deinstall";
            // 
            // reallyToolStripMenuItem
            // 
            this.reallyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDesroyYes});
            this.reallyToolStripMenuItem.Image = global::LaunchOrder.Properties.Resources.question;
            this.reallyToolStripMenuItem.Name = "reallyToolStripMenuItem";
            this.reallyToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.reallyToolStripMenuItem.Text = "Really?";
            // 
            // btnDesroyYes
            // 
            this.btnDesroyYes.Image = global::LaunchOrder.Properties.Resources.check;
            this.btnDesroyYes.Name = "btnDesroyYes";
            this.btnDesroyYes.Size = new System.Drawing.Size(91, 22);
            this.btnDesroyYes.Text = "Yes";
            this.btnDesroyYes.Click += new System.EventHandler(this.btnDesroyYes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(552, 390);
            this.Controls.Add(this.menuStrip5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip4);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvOrder);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launch Order";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnUp;
        private System.Windows.Forms.ToolStripMenuItem btnDown;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnSetAutostart;
        private System.Windows.Forms.ToolStripMenuItem btnDelAutostart;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.ToolStripMenuItem btnAddDelay;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem btnMinimize;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem btnImport;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.ToolStripMenuItem menStrip5btn;
        private System.Windows.Forms.ToolStripMenuItem destroyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDesroyYes;
        private System.Windows.Forms.ToolStripMenuItem btnStartFolder;
        private System.Windows.Forms.ToolStripMenuItem btnDataFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnInfo2;
    }
}

