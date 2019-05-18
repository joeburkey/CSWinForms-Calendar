namespace Calendar
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
            this.components = new System.ComponentModel.Container();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRecurringAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDisplayedDate = new System.Windows.Forms.Label();
            this.buttonNewAppt = new System.Windows.Forms.Button();
            this.buttonNewReccuringAppt = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDailyView = new System.Windows.Forms.Panel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.panelDailyView.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(12, 41);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.appointmentsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAppointmentToolStripMenuItem,
            this.newRecurringAppointmentToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // newAppointmentToolStripMenuItem
            // 
            this.newAppointmentToolStripMenuItem.Name = "newAppointmentToolStripMenuItem";
            this.newAppointmentToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.newAppointmentToolStripMenuItem.Text = "New Appointment...";
            this.newAppointmentToolStripMenuItem.Click += new System.EventHandler(this.newAppointmentToolStripMenuItem_Click);
            // 
            // newRecurringAppointmentToolStripMenuItem
            // 
            this.newRecurringAppointmentToolStripMenuItem.Name = "newRecurringAppointmentToolStripMenuItem";
            this.newRecurringAppointmentToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.newRecurringAppointmentToolStripMenuItem.Text = "New Recurring Appointment...";
            this.newRecurringAppointmentToolStripMenuItem.Click += new System.EventHandler(this.newRecurringAppointmentToolStripMenuItem_Click);
            // 
            // labelDisplayedDate
            // 
            this.labelDisplayedDate.AutoSize = true;
            this.labelDisplayedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayedDate.Location = new System.Drawing.Point(340, 41);
            this.labelDisplayedDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDisplayedDate.Name = "labelDisplayedDate";
            this.labelDisplayedDate.Size = new System.Drawing.Size(0, 20);
            this.labelDisplayedDate.TabIndex = 3;
            // 
            // buttonNewAppt
            // 
            this.buttonNewAppt.Location = new System.Drawing.Point(33, 262);
            this.buttonNewAppt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonNewAppt.Name = "buttonNewAppt";
            this.buttonNewAppt.Size = new System.Drawing.Size(203, 46);
            this.buttonNewAppt.TabIndex = 4;
            this.buttonNewAppt.Text = "New Appointment";
            this.buttonNewAppt.UseVisualStyleBackColor = true;
            this.buttonNewAppt.Click += new System.EventHandler(this.buttonNewAppt_Click);
            // 
            // buttonNewReccuringAppt
            // 
            this.buttonNewReccuringAppt.Location = new System.Drawing.Point(33, 315);
            this.buttonNewReccuringAppt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonNewReccuringAppt.Name = "buttonNewReccuringAppt";
            this.buttonNewReccuringAppt.Size = new System.Drawing.Size(203, 46);
            this.buttonNewReccuringAppt.TabIndex = 5;
            this.buttonNewReccuringAppt.Text = "New Recurring Appointment";
            this.buttonNewReccuringAppt.UseVisualStyleBackColor = true;
            this.buttonNewReccuringAppt.Click += new System.EventHandler(this.buttonNewReccuringAppt_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(123, 52);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit...";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panelDailyView
            // 
            this.panelDailyView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDailyView.BackColor = System.Drawing.SystemColors.Menu;
            this.panelDailyView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDailyView.Controls.Add(this.vScrollBar);
            this.panelDailyView.Location = new System.Drawing.Point(344, 82);
            this.panelDailyView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelDailyView.Name = "panelDailyView";
            this.panelDailyView.Size = new System.Drawing.Size(729, 468);
            this.panelDailyView.TabIndex = 2;
            this.panelDailyView.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDailyView_Paint);
            this.panelDailyView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDailyView_MouseClick);
            this.panelDailyView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelDailyView_MouseDoubleClick);
            this.panelDailyView.Resize += new System.EventHandler(this.panelDailyView_Resize);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.LargeChange = 1;
            this.vScrollBar.Location = new System.Drawing.Point(697, 0);
            this.vScrollBar.Maximum = 0;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(21, 471);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1104, 578);
            this.Controls.Add(this.buttonNewReccuringAppt);
            this.Controls.Add(this.buttonNewAppt);
            this.Controls.Add(this.panelDailyView);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.labelDisplayedDate);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Appointments Calendar";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.panelDailyView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelDailyView;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.Label labelDisplayedDate;
        private System.Windows.Forms.Button buttonNewAppt;
        private System.Windows.Forms.Button buttonNewReccuringAppt;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRecurringAppointmentToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

