namespace Assignment_1
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
            this.purchase = new System.Windows.Forms.Button();
            this.Reports = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // purchase
            // 
            this.purchase.Location = new System.Drawing.Point(166, 102);
            this.purchase.Name = "purchase";
            this.purchase.Size = new System.Drawing.Size(149, 41);
            this.purchase.TabIndex = 0;
            this.purchase.Text = "Make Purchase";
            this.purchase.UseVisualStyleBackColor = true;
            this.purchase.Click += new System.EventHandler(this.MakePurchase);
            // 
            // Reports
            // 
            this.Reports.Location = new System.Drawing.Point(166, 377);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(149, 41);
            this.Reports.TabIndex = 2;
            this.Reports.Text = "View Reports";
            this.Reports.UseVisualStyleBackColor = true;
            this.Reports.Click += new System.EventHandler(this.ViewReports);
            // 
            // Inventory
            // 
            this.Inventory.Location = new System.Drawing.Point(166, 281);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(149, 41);
            this.Inventory.TabIndex = 3;
            this.Inventory.Text = "Manage Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            this.Inventory.Click += new System.EventHandler(this.ManageInventory);
            // 
            // Return
            // 
            this.Return.Location = new System.Drawing.Point(166, 181);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(149, 41);
            this.Return.TabIndex = 4;
            this.Return.Text = "Make return";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.MakeReturn);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Main Menu";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(528, 619);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.Reports);
            this.Controls.Add(this.purchase);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderTxt;
        private System.Windows.Forms.Button PurchaseBtn;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.Button InventoryBtn;
        private System.Windows.Forms.Button ReportBtn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Button purchase;
        private System.Windows.Forms.Button Reports;
        private System.Windows.Forms.Button Inventory;
        private System.Windows.Forms.Button Return;
        private System.Windows.Forms.Label label1;
    }
}

