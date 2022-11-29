using System.Windows.Forms;

namespace EmptyStandbyList
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.intervalLbl = new System.Windows.Forms.Label();
            this.intervalTb = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // statusBtn
            // 
            this.statusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBtn.Location = new System.Drawing.Point(264, 12);
            this.statusBtn.Name = "statusBtn";
            this.statusBtn.Size = new System.Drawing.Size(169, 60);
            this.statusBtn.TabIndex = 0;
            this.statusBtn.Text = "status";
            this.statusBtn.UseVisualStyleBackColor = true;
            this.statusBtn.Click += new System.EventHandler(this.statusBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(12, 29);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(235, 32);
            this.statusLbl.TabIndex = 1;
            this.statusLbl.Text = "Auto-clear status:";
            // 
            // intervalLbl
            // 
            this.intervalLbl.AutoSize = true;
            this.intervalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalLbl.Location = new System.Drawing.Point(40, 96);
            this.intervalLbl.Name = "intervalLbl";
            this.intervalLbl.Size = new System.Drawing.Size(207, 32);
            this.intervalLbl.TabIndex = 2;
            this.intervalLbl.Text = "Interval (in ms):";
            // 
            // intervalTb
            // 
            this.intervalTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalTb.Location = new System.Drawing.Point(264, 89);
            this.intervalTb.Name = "intervalTb";
            this.intervalTb.Size = new System.Drawing.Size(169, 39);
            this.intervalTb.TabIndex = 3;
            this.intervalTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.intervalTb_KeyDown);
            this.intervalTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intervalTb_KeyPress);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenu = this.contextMenu1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "EmptyStandbyList";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.Exit);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.intervalTb);
            this.Controls.Add(this.intervalLbl);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.statusBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EmptyStandbyList";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button statusBtn;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label intervalLbl;
        private System.Windows.Forms.TextBox intervalTb;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
    }
}

