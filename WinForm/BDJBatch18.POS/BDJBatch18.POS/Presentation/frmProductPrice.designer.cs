namespace BDJBatch18.POS.Presentation
{
    partial class frmProductPrice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProductPrice = new BDJBatch18.POS.Presentation.MyControls.MyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtSearch.Size = new System.Drawing.Size(225, 22);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(244, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSearch.Size = new System.Drawing.Size(77, 34);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(708, 26);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnNew.Size = new System.Drawing.Size(77, 34);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(791, 26);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnEdit.Size = new System.Drawing.Size(77, 34);
            this.btnEdit.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(873, 26);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDelete.Size = new System.Drawing.Size(77, 34);
            this.btnDelete.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnPrint.Size = new System.Drawing.Size(77, 34);
            this.btnPrint.TabIndex = 5;
            // 
            // dgvProductPrice
            // 
            this.dgvProductPrice.AllowUserToAddRows = false;
            this.dgvProductPrice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            this.dgvProductPrice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductPrice.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductPrice.Location = new System.Drawing.Point(12, 90);
            this.dgvProductPrice.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductPrice.Name = "dgvProductPrice";
            this.dgvProductPrice.ReadOnly = true;
            this.dgvProductPrice.RowTemplate.Height = 28;
            this.dgvProductPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductPrice.Size = new System.Drawing.Size(1021, 495);
            this.dgvProductPrice.TabIndex = 6;
            // 
            // frmProductPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1047, 599);
            this.Controls.Add(this.dgvProductPrice);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmProductPrice";
            this.Text = "Product Price";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.dgvProductPrice, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControls.MyGrid dgvProductPrice;
    }
}
