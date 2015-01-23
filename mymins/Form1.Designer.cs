namespace mymins
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
            System.Windows.Forms.Label specimenIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.minsComboBox = new System.Windows.Forms.ComboBox();
            this.minsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myminsDataSet = new mymins.myminsDataSet();
            this.specMinsAddButton = new System.Windows.Forms.Button();
            this.specMinsDeleteButton = new System.Windows.Forms.Button();
            this.specBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specTableAdapter = new mymins.myminsDataSetTableAdapters.SpecTableAdapter();
            this.minsTableAdapter = new mymins.myminsDataSetTableAdapters.MinsTableAdapter();
            this.specIDTextBox = new System.Windows.Forms.TextBox();
            this.specMinsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specMinsTableAdapter = new mymins.myminsDataSetTableAdapters.SpecMinsTableAdapter();
            this.specMinsMoveUpButton = new System.Windows.Forms.Button();
            this.specMinsMoveDownButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.specBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.specBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.specMinsListView = new System.Windows.Forms.ListView();
            this.tableAdapterManager = new mymins.myminsDataSetTableAdapters.TableAdapterManager();
            this.minsTypesTableAdapter = new mymins.myminsDataSetTableAdapters.MinsTypesTableAdapter();
            specimenIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myminsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specMinsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingNavigator)).BeginInit();
            this.specBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // specimenIDLabel
            // 
            specimenIDLabel.AutoSize = true;
            specimenIDLabel.Location = new System.Drawing.Point(7, 37);
            specimenIDLabel.Name = "specimenIDLabel";
            specimenIDLabel.Size = new System.Drawing.Size(71, 13);
            specimenIDLabel.TabIndex = 1;
            specimenIDLabel.Text = "Specimen ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 240;
            this.label1.Text = "Mineral";
            // 
            // minsComboBox
            // 
            this.minsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.minsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.minsComboBox.DataSource = this.minsBindingSource;
            this.minsComboBox.DisplayMember = "MinsName";
            this.minsComboBox.FormattingEnabled = true;
            this.minsComboBox.Location = new System.Drawing.Point(261, 34);
            this.minsComboBox.Name = "minsComboBox";
            this.minsComboBox.Size = new System.Drawing.Size(121, 21);
            this.minsComboBox.TabIndex = 2;
            this.minsComboBox.ValueMember = "MinsID";
            this.minsComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.minsComboBoxKeyDown);
            // 
            // minsBindingSource
            // 
            this.minsBindingSource.DataMember = "Mins";
            this.minsBindingSource.DataSource = this.myminsDataSet;
            // 
            // myminsDataSet
            // 
            this.myminsDataSet.DataSetName = "myminsDataSet";
            this.myminsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // specMinsAddButton
            // 
            this.specMinsAddButton.Location = new System.Drawing.Point(479, 2);
            this.specMinsAddButton.Name = "specMinsAddButton";
            this.specMinsAddButton.Size = new System.Drawing.Size(59, 23);
            this.specMinsAddButton.TabIndex = 6;
            this.specMinsAddButton.Text = "Add";
            this.specMinsAddButton.UseVisualStyleBackColor = true;
            this.specMinsAddButton.Click += new System.EventHandler(this.specMinsAddButton_Click);
            // 
            // specMinsDeleteButton
            // 
            this.specMinsDeleteButton.Location = new System.Drawing.Point(479, 28);
            this.specMinsDeleteButton.Name = "specMinsDeleteButton";
            this.specMinsDeleteButton.Size = new System.Drawing.Size(59, 23);
            this.specMinsDeleteButton.TabIndex = 7;
            this.specMinsDeleteButton.Text = "Delete";
            this.specMinsDeleteButton.UseVisualStyleBackColor = true;
            this.specMinsDeleteButton.Click += new System.EventHandler(this.specMinsDeleteButton_Click);
            // 
            // specBindingSource
            // 
            this.specBindingSource.DataMember = "Spec";
            this.specBindingSource.DataSource = this.myminsDataSet;
            this.specBindingSource.PositionChanged += new System.EventHandler(this.specPositionChanged);
            // 
            // specTableAdapter
            // 
            this.specTableAdapter.ClearBeforeFill = true;
            // 
            // minsTableAdapter
            // 
            this.minsTableAdapter.ClearBeforeFill = true;
            // 
            // specIDTextBox
            // 
            this.specIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specBindingSource, "SpecID", true));
            this.specIDTextBox.Location = new System.Drawing.Point(88, 31);
            this.specIDTextBox.Name = "specIDTextBox";
            this.specIDTextBox.Size = new System.Drawing.Size(104, 20);
            this.specIDTextBox.TabIndex = 0;
            this.specIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.specIDValidating);
            // 
            // specMinsBindingSource
            // 
            this.specMinsBindingSource.DataMember = "FK_SpecMins_Spec";
            this.specMinsBindingSource.DataSource = this.specBindingSource;
            this.specMinsBindingSource.Sort = "MinsPriority";
            this.specMinsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.specMinsListChanged);
            // 
            // specMinsTableAdapter
            // 
            this.specMinsTableAdapter.ClearBeforeFill = true;
            // 
            // specMinsMoveUpButton
            // 
            this.specMinsMoveUpButton.Location = new System.Drawing.Point(479, 53);
            this.specMinsMoveUpButton.Name = "specMinsMoveUpButton";
            this.specMinsMoveUpButton.Size = new System.Drawing.Size(59, 23);
            this.specMinsMoveUpButton.TabIndex = 8;
            this.specMinsMoveUpButton.Text = "UP";
            this.specMinsMoveUpButton.UseVisualStyleBackColor = true;
            this.specMinsMoveUpButton.Click += new System.EventHandler(this.specMinsMoveUpButton_Click);
            // 
            // specMinsMoveDownButton
            // 
            this.specMinsMoveDownButton.Location = new System.Drawing.Point(479, 79);
            this.specMinsMoveDownButton.Name = "specMinsMoveDownButton";
            this.specMinsMoveDownButton.Size = new System.Drawing.Size(59, 23);
            this.specMinsMoveDownButton.TabIndex = 9;
            this.specMinsMoveDownButton.Text = "DOWN";
            this.specMinsMoveDownButton.UseVisualStyleBackColor = true;
            this.specMinsMoveDownButton.Click += new System.EventHandler(this.specMinsMoveDownButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.specBindingSource;
            // 
            // specBindingNavigator
            // 
            this.specBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.specBindingNavigator.BindingSource = this.specBindingSource;
            this.specBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.specBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.specBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.specBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.specBindingNavigatorSaveItem});
            this.specBindingNavigator.Location = new System.Drawing.Point(4, 2);
            this.specBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.specBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.specBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.specBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.specBindingNavigator.Name = "specBindingNavigator";
            this.specBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.specBindingNavigator.Size = new System.Drawing.Size(278, 25);
            this.specBindingNavigator.TabIndex = 51;
            this.specBindingNavigator.Text = "specBindingNavigator";
            this.specBindingNavigator.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.specBindingNavItemClicked);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // specBindingNavigatorSaveItem
            // 
            this.specBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.specBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("specBindingNavigatorSaveItem.Image")));
            this.specBindingNavigatorSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.specBindingNavigatorSaveItem.Name = "specBindingNavigatorSaveItem";
            this.specBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.specBindingNavigatorSaveItem.Text = "specBindingNavigatorSaveItem";
            this.specBindingNavigatorSaveItem.Click += new System.EventHandler(this.specBindingNavigatorSaveItem_Click);
            // 
            // specMinsListView
            // 
            this.specMinsListView.HideSelection = false;
            this.specMinsListView.Location = new System.Drawing.Point(544, 2);
            this.specMinsListView.MultiSelect = false;
            this.specMinsListView.Name = "specMinsListView";
            this.specMinsListView.Size = new System.Drawing.Size(108, 97);
            this.specMinsListView.TabIndex = 10;
            this.specMinsListView.UseCompatibleStateImageBehavior = false;
            this.specMinsListView.View = System.Windows.Forms.View.SmallIcon;
            this.specMinsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.specMinsItemSelectionChanged);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AcquireTypeTableAdapter = null;
            this.tableAdapterManager.AcquisitionTableAdapter = null;
            this.tableAdapterManager.AddressTableAdapter = null;
            this.tableAdapterManager.AvailabilityTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CityTableAdapter = null;
            this.tableAdapterManager.CommentTableAdapter = null;
            this.tableAdapterManager.ContactImgsTableAdapter = null;
            this.tableAdapterManager.ContactMindatTableAdapter = null;
            this.tableAdapterManager.ContactTableAdapter = null;
            this.tableAdapterManager.ContactTypeTableAdapter = null;
            this.tableAdapterManager.CountryTableAdapter = null;
            this.tableAdapterManager.CountyTableAdapter = null;
            this.tableAdapterManager.DatesTableAdapter = null;
            this.tableAdapterManager.DaysTableAdapter = null;
            this.tableAdapterManager.ImgsPathsTableAdapter = null;
            this.tableAdapterManager.MineralExposureTableAdapter = null;
            this.tableAdapterManager.MinsRelationsTableAdapter = null;
            this.tableAdapterManager.MinsTableAdapter = this.minsTableAdapter;
            this.tableAdapterManager.MinsTypesTableAdapter = this.minsTypesTableAdapter;
            this.tableAdapterManager.OpenHoursTableAdapter = null;
            this.tableAdapterManager.SpecImgsTableAdapter = null;
            this.tableAdapterManager.SpecMinsTableAdapter = this.specMinsTableAdapter;
            this.tableAdapterManager.SpecTableAdapter = this.specTableAdapter;
            this.tableAdapterManager.StateTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = mymins.myminsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // minsTypesTableAdapter
            // 
            this.minsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 113);
            this.Controls.Add(this.specMinsListView);
            this.Controls.Add(this.specBindingNavigator);
            this.Controls.Add(this.specMinsMoveDownButton);
            this.Controls.Add(this.specMinsMoveUpButton);
            this.Controls.Add(this.specIDTextBox);
            this.Controls.Add(this.specMinsDeleteButton);
            this.Controls.Add(this.specMinsAddButton);
            this.Controls.Add(this.minsComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(specimenIDLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myminsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specMinsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingNavigator)).EndInit();
            this.specBindingNavigator.ResumeLayout(false);
            this.specBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox minsComboBox;
        private System.Windows.Forms.Button specMinsAddButton;
        private System.Windows.Forms.Button specMinsDeleteButton;
        private myminsDataSet myminsDataSet;
        private System.Windows.Forms.BindingSource specBindingSource;
        private myminsDataSetTableAdapters.SpecTableAdapter specTableAdapter;
        private myminsDataSetTableAdapters.MinsTableAdapter minsTableAdapter;
        private System.Windows.Forms.TextBox specIDTextBox;
        private System.Windows.Forms.BindingSource minsBindingSource;
        private System.Windows.Forms.BindingSource specMinsBindingSource;
        private myminsDataSetTableAdapters.SpecMinsTableAdapter specMinsTableAdapter;
        private System.Windows.Forms.Button specMinsMoveUpButton;
        private System.Windows.Forms.Button specMinsMoveDownButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingNavigator specBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton specBindingNavigatorSaveItem;
        private System.Windows.Forms.ListView specMinsListView;
        private myminsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private myminsDataSetTableAdapters.MinsTypesTableAdapter minsTypesTableAdapter;

    }
}

