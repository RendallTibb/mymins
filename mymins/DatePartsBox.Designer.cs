namespace mymins
{
    partial class DatePartsBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.otherComboBox = new System.Windows.Forms.ComboBox();
            this.otherLabel = new System.Windows.Forms.Label();
            this.otherCheckBox = new System.Windows.Forms.CheckBox();
            this.labelDateDivide2 = new System.Windows.Forms.Label();
            this.labelDateDivide1 = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.monthTextBox = new System.Windows.Forms.TextBox();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.otherPanel = new System.Windows.Forms.Panel();
            this.errProvSpacerPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.otherPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // otherComboBox
            // 
            this.otherComboBox.FormattingEnabled = true;
            this.otherComboBox.Location = new System.Drawing.Point(30, 6);
            this.otherComboBox.Name = "otherComboBox";
            this.otherComboBox.Size = new System.Drawing.Size(119, 21);
            this.otherComboBox.TabIndex = 6;
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Location = new System.Drawing.Point(-3, 6);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(33, 13);
            this.otherLabel.TabIndex = 263;
            this.otherLabel.Text = "Other";
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.AutoSize = true;
            this.otherCheckBox.Location = new System.Drawing.Point(136, 3);
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.Size = new System.Drawing.Size(15, 14);
            this.otherCheckBox.TabIndex = 5;
            this.otherCheckBox.UseVisualStyleBackColor = true;
            this.otherCheckBox.CheckedChanged += new System.EventHandler(this.otherCheckBoxCheckedChanged);
            // 
            // labelDateDivide2
            // 
            this.labelDateDivide2.BackColor = System.Drawing.SystemColors.Window;
            this.labelDateDivide2.Location = new System.Drawing.Point(79, 1);
            this.labelDateDivide2.Name = "labelDateDivide2";
            this.labelDateDivide2.Size = new System.Drawing.Size(8, 18);
            this.labelDateDivide2.TabIndex = 257;
            this.labelDateDivide2.Text = "/";
            this.labelDateDivide2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDateDivide1
            // 
            this.labelDateDivide1.BackColor = System.Drawing.SystemColors.Window;
            this.labelDateDivide1.Location = new System.Drawing.Point(57, 1);
            this.labelDateDivide1.Name = "labelDateDivide1";
            this.labelDateDivide1.Size = new System.Drawing.Size(8, 18);
            this.labelDateDivide1.TabIndex = 256;
            this.labelDateDivide1.Text = "/";
            this.labelDateDivide1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yearTextBox
            // 
            this.errorProvider1.SetIconPadding(this.yearTextBox, 18);
            this.yearTextBox.Location = new System.Drawing.Point(79, 0);
            this.yearTextBox.MaxLength = 4;
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(37, 20);
            this.yearTextBox.TabIndex = 3;
            this.yearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yearTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datesTextBox_KeyDown);
            this.yearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datesTextBox_KeyPress);
            this.yearTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.yearTextBoxValidating);
            // 
            // monthTextBox
            // 
            this.errorProvider1.SetIconPadding(this.monthTextBox, 74);
            this.monthTextBox.Location = new System.Drawing.Point(30, 0);
            this.monthTextBox.MaxLength = 3;
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.Size = new System.Drawing.Size(30, 20);
            this.monthTextBox.TabIndex = 1;
            this.monthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.monthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datesTextBox_KeyDown);
            this.monthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datesTextBox_KeyPress);
            this.monthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.monthTextBoxValidating);
            // 
            // dayTextBox
            // 
            this.errorProvider1.SetIconPadding(this.dayTextBox, 52);
            this.dayTextBox.Location = new System.Drawing.Point(58, 0);
            this.dayTextBox.MaxLength = 2;
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(24, 20);
            this.dayTextBox.TabIndex = 2;
            this.dayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dayTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datesTextBox_KeyDown);
            this.dayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datesTextBox_KeyPress);
            this.dayTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.dayTextBoxValidating);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(16, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1ValueChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(-3, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(30, 13);
            this.dateLabel.TabIndex = 255;
            this.dateLabel.Text = "Date";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // otherPanel
            // 
            this.otherPanel.Controls.Add(this.otherLabel);
            this.otherPanel.Controls.Add(this.otherComboBox);
            this.otherPanel.Location = new System.Drawing.Point(0, 20);
            this.otherPanel.Name = "otherPanel";
            this.otherPanel.Size = new System.Drawing.Size(150, 27);
            this.otherPanel.TabIndex = 264;
            this.otherPanel.Visible = false;
            // 
            // errProvSpacerPanel
            // 
            this.errProvSpacerPanel.Location = new System.Drawing.Point(133, 3);
            this.errProvSpacerPanel.Name = "errProvSpacerPanel";
            this.errProvSpacerPanel.Size = new System.Drawing.Size(15, 14);
            this.errProvSpacerPanel.TabIndex = 265;
            // 
            // DatePartsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.otherPanel);
            this.Controls.Add(this.labelDateDivide2);
            this.Controls.Add(this.labelDateDivide1);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(this.otherCheckBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.monthTextBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.errProvSpacerPanel);
            this.Name = "DatePartsBox";
            this.Size = new System.Drawing.Size(151, 47);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.otherPanel.ResumeLayout(false);
            this.otherPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox otherComboBox;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.CheckBox otherCheckBox;
        private System.Windows.Forms.Label labelDateDivide2;
        private System.Windows.Forms.Label labelDateDivide1;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel otherPanel;
        private System.Windows.Forms.Panel errProvSpacerPanel;
    }
}
