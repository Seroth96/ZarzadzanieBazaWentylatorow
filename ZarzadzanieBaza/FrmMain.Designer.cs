namespace ZarzadzanieBaza
{
    partial class FrmMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnSearch;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxPowerFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDane = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxPowerTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxRevolutionTo = new System.Windows.Forms.TextBox();
            this.tbxRevolutionFrom = new System.Windows.Forms.TextBox();
            this.tbxPressureFrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxNature = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.bgwBrowser = new System.ComponentModel.BackgroundWorker();
            this.tbxAirMassFlow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            btnSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            btnSearch.Location = new System.Drawing.Point(73, 303);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(102, 32);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Szukaj";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(333, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1113, 673);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nazwa:";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxName.Location = new System.Drawing.Point(108, 72);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(194, 26);
            this.tbxName.TabIndex = 3;
            // 
            // tbxPowerFrom
            // 
            this.tbxPowerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxPowerFrom.Location = new System.Drawing.Point(108, 104);
            this.tbxPowerFrom.Name = "tbxPowerFrom";
            this.tbxPowerFrom.Size = new System.Drawing.Size(85, 26);
            this.tbxPowerFrom.TabIndex = 5;
            this.tbxPowerFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Moc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Obroty:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ciśnienie:";
            // 
            // lbDane
            // 
            this.lbDane.AutoSize = true;
            this.lbDane.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDane.Location = new System.Drawing.Point(68, 12);
            this.lbDane.Name = "lbDane";
            this.lbDane.Size = new System.Drawing.Size(201, 25);
            this.lbDane.TabIndex = 10;
            this.lbDane.Text = "Dane wyszukiwania";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 691);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1458, 46);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnAdd.Location = new System.Drawing.Point(30, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(190, 32);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Dodaj nowy wentylator";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxPowerTo
            // 
            this.tbxPowerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxPowerTo.Location = new System.Drawing.Point(212, 104);
            this.tbxPowerTo.Name = "tbxPowerTo";
            this.tbxPowerTo.Size = new System.Drawing.Size(90, 26);
            this.tbxPowerTo.TabIndex = 12;
            this.tbxPowerTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(196, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(196, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "-";
            // 
            // tbxRevolutionTo
            // 
            this.tbxRevolutionTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxRevolutionTo.Location = new System.Drawing.Point(212, 137);
            this.tbxRevolutionTo.Name = "tbxRevolutionTo";
            this.tbxRevolutionTo.Size = new System.Drawing.Size(90, 26);
            this.tbxRevolutionTo.TabIndex = 15;
            this.tbxRevolutionTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // tbxRevolutionFrom
            // 
            this.tbxRevolutionFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxRevolutionFrom.Location = new System.Drawing.Point(108, 137);
            this.tbxRevolutionFrom.Name = "tbxRevolutionFrom";
            this.tbxRevolutionFrom.Size = new System.Drawing.Size(85, 26);
            this.tbxRevolutionFrom.TabIndex = 14;
            this.tbxRevolutionFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // tbxPressureFrom
            // 
            this.tbxPressureFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxPressureFrom.Location = new System.Drawing.Point(108, 205);
            this.tbxPressureFrom.Name = "tbxPressureFrom";
            this.tbxPressureFrom.Size = new System.Drawing.Size(194, 26);
            this.tbxPressureFrom.TabIndex = 17;
            this.tbxPressureFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(12, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Typ:";
            // 
            // cbxNature
            // 
            this.cbxNature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbxNature.Location = new System.Drawing.Point(108, 242);
            this.cbxNature.Name = "cbxNature";
            this.cbxNature.Size = new System.Drawing.Size(194, 28);
            this.cbxNature.TabIndex = 21;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightCoral;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnClear.Location = new System.Drawing.Point(212, 303);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 32);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Wyczyść";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // bgwBrowser
            // 
            this.bgwBrowser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBrowser_DoWork);
            this.bgwBrowser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBrowser_RunWorkerCompleted);
            // 
            // tbxAirMassFlow
            // 
            this.tbxAirMassFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxAirMassFlow.Location = new System.Drawing.Point(108, 170);
            this.tbxAirMassFlow.Name = "tbxAirMassFlow";
            this.tbxAirMassFlow.Size = new System.Drawing.Size(194, 26);
            this.tbxAirMassFlow.TabIndex = 24;
            this.tbxAirMassFlow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericTextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Wydajność:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 737);
            this.Controls.Add(this.tbxAirMassFlow);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbxNature);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxPressureFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxRevolutionTo);
            this.Controls.Add(this.tbxRevolutionFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxPowerTo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbDane);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxPowerFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmMain";
            this.Text = "Zarządzanie bazą wentylatorów";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxPowerFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDane;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxPowerTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxRevolutionTo;
        private System.Windows.Forms.TextBox tbxRevolutionFrom;
        private System.Windows.Forms.TextBox tbxPressureFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxNature;
        private System.Windows.Forms.Button btnClear;
        private System.ComponentModel.BackgroundWorker bgwBrowser;
        private System.Windows.Forms.TextBox tbxAirMassFlow;
        private System.Windows.Forms.Label label7;
    }
}

