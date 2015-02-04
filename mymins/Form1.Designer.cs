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
            System.Windows.Forms.Label acquireDateLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.minsComboBox = new System.Windows.Forms.ComboBox();
            this.minsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myminsDataSet = new mymins.myminsDataSet();
            this.specMinsAddButton = new System.Windows.Forms.Button();
            this.specMinsDeleteButton = new System.Windows.Forms.Button();
            this.userSpecIDTextBox = new System.Windows.Forms.TextBox();
            this.specBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specMinsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specMinsMoveUpButton = new System.Windows.Forms.Button();
            this.specMinsMoveDownButton = new System.Windows.Forms.Button();
            this.specErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.minsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.contactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.acquAddButton = new System.Windows.Forms.Button();
            this.acquDeleteButton = new System.Windows.Forms.Button();
            this.acquireTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exposureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specImgsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagePathIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagePriorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquisitionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acquireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.countyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specTableAdapter = new mymins.myminsDataSetTableAdapters.SpecTableAdapter();
            this.minsTableAdapter = new mymins.myminsDataSetTableAdapters.MinsTableAdapter();
            this.specMinsTableAdapter = new mymins.myminsDataSetTableAdapters.SpecMinsTableAdapter();
            this.tableAdapterManager = new mymins.myminsDataSetTableAdapters.TableAdapterManager();
            this.acquisitionTableAdapter = new mymins.myminsDataSetTableAdapters.AcquisitionTableAdapter();
            this.contactTableAdapter = new mymins.myminsDataSetTableAdapters.ContactTableAdapter();
            this.contactTypeTableAdapter = new mymins.myminsDataSetTableAdapters.ContactTypeTableAdapter();
            this.minsTypesTableAdapter = new mymins.myminsDataSetTableAdapters.MinsTypesTableAdapter();
            this.specImgsTableAdapter = new mymins.myminsDataSetTableAdapters.SpecImgsTableAdapter();
            this.countryTableAdapter = new mymins.myminsDataSetTableAdapters.CountryTableAdapter();
            this.stateTableAdapter = new mymins.myminsDataSetTableAdapters.StateTableAdapter();
            this.countyTableAdapter = new mymins.myminsDataSetTableAdapters.CountyTableAdapter();
            this.cityTableAdapter = new mymins.myminsDataSetTableAdapters.CityTableAdapter();
            this.addressTableAdapter = new mymins.myminsDataSetTableAdapters.AddressTableAdapter();
            this.exposureTableAdapter = new mymins.myminsDataSetTableAdapters.ExposureTableAdapter();
            this.acquireTypeTableAdapter = new mymins.myminsDataSetTableAdapters.AcquireTypeTableAdapter();
            this.acquViewDataGridView = new System.Windows.Forms.DataGridView();
            specimenIDLabel = new System.Windows.Forms.Label();
            acquireDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myminsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specMinsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingNavigator)).BeginInit();
            this.specBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquireTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specImgsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquisitionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquViewDataGridView)).BeginInit();
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
            // acquireDateLabel
            // 
            acquireDateLabel.AutoSize = true;
            acquireDateLabel.Location = new System.Drawing.Point(179, 119);
            acquireDateLabel.Name = "acquireDateLabel";
            acquireDateLabel.Size = new System.Drawing.Size(72, 13);
            acquireDateLabel.TabIndex = 305;
            acquireDateLabel.Text = "Acquire Date:";
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
            this.specMinsAddButton.Location = new System.Drawing.Point(491, 2);
            this.specMinsAddButton.Name = "specMinsAddButton";
            this.specMinsAddButton.Size = new System.Drawing.Size(47, 23);
            this.specMinsAddButton.TabIndex = 6;
            this.specMinsAddButton.Text = "Add";
            this.specMinsAddButton.UseVisualStyleBackColor = true;
            this.specMinsAddButton.Click += new System.EventHandler(this.specMinsAddButton_Click);
            // 
            // specMinsDeleteButton
            // 
            this.specMinsDeleteButton.Location = new System.Drawing.Point(491, 28);
            this.specMinsDeleteButton.Name = "specMinsDeleteButton";
            this.specMinsDeleteButton.Size = new System.Drawing.Size(47, 23);
            this.specMinsDeleteButton.TabIndex = 7;
            this.specMinsDeleteButton.Text = "Delete";
            this.specMinsDeleteButton.UseVisualStyleBackColor = true;
            this.specMinsDeleteButton.Click += new System.EventHandler(this.specMinsDeleteButton_Click);
            // 
            // userSpecIDTextBox
            // 
            this.userSpecIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.specBindingSource, "UserSpecID", true));
            this.userSpecIDTextBox.Location = new System.Drawing.Point(88, 31);
            this.userSpecIDTextBox.Name = "userSpecIDTextBox";
            this.userSpecIDTextBox.Size = new System.Drawing.Size(104, 20);
            this.userSpecIDTextBox.TabIndex = 0;
            this.userSpecIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.specIDValidating);
            // 
            // specBindingSource
            // 
            this.specBindingSource.DataMember = "Spec";
            this.specBindingSource.DataSource = this.myminsDataSet;
            this.specBindingSource.PositionChanged += new System.EventHandler(this.specPositionChanged);
            // 
            // specMinsBindingSource
            // 
            this.specMinsBindingSource.DataMember = "FK_SpecMins_Spec";
            this.specMinsBindingSource.DataSource = this.specBindingSource;
            this.specMinsBindingSource.Sort = "MinsPriority";
            this.specMinsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.specMinsListChanged);
            // 
            // specMinsMoveUpButton
            // 
            this.specMinsMoveUpButton.Location = new System.Drawing.Point(491, 53);
            this.specMinsMoveUpButton.Name = "specMinsMoveUpButton";
            this.specMinsMoveUpButton.Size = new System.Drawing.Size(47, 23);
            this.specMinsMoveUpButton.TabIndex = 8;
            this.specMinsMoveUpButton.Text = "Up";
            this.specMinsMoveUpButton.UseVisualStyleBackColor = true;
            this.specMinsMoveUpButton.Click += new System.EventHandler(this.specMinsMoveUpButton_Click);
            // 
            // specMinsMoveDownButton
            // 
            this.specMinsMoveDownButton.Location = new System.Drawing.Point(491, 79);
            this.specMinsMoveDownButton.Name = "specMinsMoveDownButton";
            this.specMinsMoveDownButton.Size = new System.Drawing.Size(47, 23);
            this.specMinsMoveDownButton.TabIndex = 9;
            this.specMinsMoveDownButton.Text = "Down";
            this.specMinsMoveDownButton.UseVisualStyleBackColor = true;
            this.specMinsMoveDownButton.Click += new System.EventHandler(this.specMinsMoveDownButton_Click);
            // 
            // specErrorProvider
            // 
            this.specErrorProvider.ContainerControl = this;
            this.specErrorProvider.DataSource = this.specBindingSource;
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
            this.specBindingNavigator.Location = new System.Drawing.Point(-5, 2);
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
            // minsTypesBindingSource
            // 
            this.minsTypesBindingSource.DataMember = "MinsTypes";
            this.minsTypesBindingSource.DataSource = this.myminsDataSet;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 254;
            this.label6.Text = "From";
            // 
            // contactBindingSource
            // 
            this.contactBindingSource.DataMember = "Contact";
            this.contactBindingSource.DataSource = this.myminsDataSet;
            // 
            // fromComboBox
            // 
            this.fromComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.fromComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.fromComboBox.DataSource = this.contactBindingSource;
            this.fromComboBox.DisplayMember = "ContactName";
            this.fromComboBox.Location = new System.Drawing.Point(47, 116);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromComboBox.TabIndex = 24;
            this.fromComboBox.ValueMember = "ContactID";
            // 
            // acquAddButton
            // 
            this.acquAddButton.Location = new System.Drawing.Point(380, 119);
            this.acquAddButton.Name = "acquAddButton";
            this.acquAddButton.Size = new System.Drawing.Size(50, 23);
            this.acquAddButton.TabIndex = 46;
            this.acquAddButton.Text = "Add";
            this.acquAddButton.UseVisualStyleBackColor = true;
            this.acquAddButton.Click += new System.EventHandler(this.acquAddButton_Click);
            // 
            // acquDeleteButton
            // 
            this.acquDeleteButton.Location = new System.Drawing.Point(380, 148);
            this.acquDeleteButton.Name = "acquDeleteButton";
            this.acquDeleteButton.Size = new System.Drawing.Size(50, 23);
            this.acquDeleteButton.TabIndex = 47;
            this.acquDeleteButton.Text = "Delete";
            this.acquDeleteButton.UseVisualStyleBackColor = true;
            this.acquDeleteButton.Click += new System.EventHandler(this.acquDeleteButton_Click);
            // 
            // acquireTypeBindingSource
            // 
            this.acquireTypeBindingSource.DataMember = "AcquireType";
            this.acquireTypeBindingSource.DataSource = this.myminsDataSet;
            // 
            // cityBindingSource
            // 
            this.cityBindingSource.DataMember = "City";
            this.cityBindingSource.DataSource = this.myminsDataSet;
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataMember = "State";
            this.stateBindingSource.DataSource = this.myminsDataSet;
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataMember = "Country";
            this.countryBindingSource.DataSource = this.myminsDataSet;
            // 
            // exposureBindingSource
            // 
            this.exposureBindingSource.DataMember = "Exposure";
            this.exposureBindingSource.DataSource = this.myminsDataSet;
            // 
            // specImgsBindingSource
            // 
            this.specImgsBindingSource.DataMember = "FK_Imgs_Spec";
            this.specImgsBindingSource.DataSource = this.specBindingSource;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // specIDDataGridViewTextBoxColumn
            // 
            this.specIDDataGridViewTextBoxColumn.DataPropertyName = "SpecID";
            this.specIDDataGridViewTextBoxColumn.HeaderText = "SpecID";
            this.specIDDataGridViewTextBoxColumn.Name = "specIDDataGridViewTextBoxColumn";
            // 
            // imagePathIDDataGridViewTextBoxColumn
            // 
            this.imagePathIDDataGridViewTextBoxColumn.DataPropertyName = "ImagePathID";
            this.imagePathIDDataGridViewTextBoxColumn.HeaderText = "ImagePathID";
            this.imagePathIDDataGridViewTextBoxColumn.Name = "imagePathIDDataGridViewTextBoxColumn";
            // 
            // imageNameDataGridViewTextBoxColumn
            // 
            this.imageNameDataGridViewTextBoxColumn.DataPropertyName = "ImageName";
            this.imageNameDataGridViewTextBoxColumn.HeaderText = "ImageName";
            this.imageNameDataGridViewTextBoxColumn.Name = "imageNameDataGridViewTextBoxColumn";
            // 
            // imagePriorityDataGridViewTextBoxColumn
            // 
            this.imagePriorityDataGridViewTextBoxColumn.DataPropertyName = "ImagePriority";
            this.imagePriorityDataGridViewTextBoxColumn.HeaderText = "ImagePriority";
            this.imagePriorityDataGridViewTextBoxColumn.Name = "imagePriorityDataGridViewTextBoxColumn";
            // 
            // commentIDDataGridViewTextBoxColumn
            // 
            this.commentIDDataGridViewTextBoxColumn.DataPropertyName = "CommentID";
            this.commentIDDataGridViewTextBoxColumn.HeaderText = "CommentID";
            this.commentIDDataGridViewTextBoxColumn.Name = "commentIDDataGridViewTextBoxColumn";
            // 
            // acquisitionBindingSource
            // 
            this.acquisitionBindingSource.DataMember = "FK_Acquisition_Spec";
            this.acquisitionBindingSource.DataSource = this.specBindingSource;
            this.acquisitionBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.acquListChanged);
            // 
            // acquireDateDateTimePicker
            // 
            this.acquireDateDateTimePicker.CustomFormat = " ";
            this.acquireDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.acquireDateDateTimePicker.Location = new System.Drawing.Point(257, 115);
            this.acquireDateDateTimePicker.Name = "acquireDateDateTimePicker";
            this.acquireDateDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.acquireDateDateTimePicker.TabIndex = 306;
            this.acquireDateDateTimePicker.CloseUp += new System.EventHandler(this.acquireDateDateTimePickerCloseUp);
            this.acquireDateDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.acquireDateDateTimePickerKeyDown);
            // 
            // countyBindingSource
            // 
            this.countyBindingSource.DataMember = "County";
            this.countyBindingSource.DataSource = this.myminsDataSet;
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.DataMember = "Address";
            this.addressBindingSource.DataSource = this.myminsDataSet;
            // 
            // specTableAdapter
            // 
            this.specTableAdapter.ClearBeforeFill = true;
            // 
            // minsTableAdapter
            // 
            this.minsTableAdapter.ClearBeforeFill = true;
            // 
            // specMinsTableAdapter
            // 
            this.specMinsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AcquireTypeTableAdapter = null;
            this.tableAdapterManager.AcquisitionTableAdapter = this.acquisitionTableAdapter;
            this.tableAdapterManager.AddressTableAdapter = null;
            this.tableAdapterManager.AvailabilityTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CityTableAdapter = null;
            this.tableAdapterManager.CommentTableAdapter = null;
            this.tableAdapterManager.ContactImgsTableAdapter = null;
            this.tableAdapterManager.ContactMindatTableAdapter = null;
            this.tableAdapterManager.ContactTableAdapter = this.contactTableAdapter;
            this.tableAdapterManager.ContactTypeTableAdapter = this.contactTypeTableAdapter;
            this.tableAdapterManager.CountryTableAdapter = null;
            this.tableAdapterManager.CountyTableAdapter = null;
            this.tableAdapterManager.DaysTableAdapter = null;
            this.tableAdapterManager.ExposureTableAdapter = null;
            this.tableAdapterManager.ImgsPathsTableAdapter = null;
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
            // acquisitionTableAdapter
            // 
            this.acquisitionTableAdapter.ClearBeforeFill = true;
            // 
            // contactTableAdapter
            // 
            this.contactTableAdapter.ClearBeforeFill = true;
            // 
            // contactTypeTableAdapter
            // 
            this.contactTypeTableAdapter.ClearBeforeFill = true;
            // 
            // minsTypesTableAdapter
            // 
            this.minsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // specImgsTableAdapter
            // 
            this.specImgsTableAdapter.ClearBeforeFill = true;
            // 
            // countryTableAdapter
            // 
            this.countryTableAdapter.ClearBeforeFill = true;
            // 
            // stateTableAdapter
            // 
            this.stateTableAdapter.ClearBeforeFill = true;
            // 
            // countyTableAdapter
            // 
            this.countyTableAdapter.ClearBeforeFill = true;
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
            // 
            // addressTableAdapter
            // 
            this.addressTableAdapter.ClearBeforeFill = true;
            // 
            // exposureTableAdapter
            // 
            this.exposureTableAdapter.ClearBeforeFill = true;
            // 
            // acquireTypeTableAdapter
            // 
            this.acquireTypeTableAdapter.ClearBeforeFill = true;
            // 
            // acquViewDataGridView
            // 
            this.acquViewDataGridView.AllowUserToAddRows = false;
            this.acquViewDataGridView.AllowUserToDeleteRows = false;
            this.acquViewDataGridView.AllowUserToResizeRows = false;
            this.acquViewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.acquViewDataGridView.Location = new System.Drawing.Point(437, 119);
            this.acquViewDataGridView.MultiSelect = false;
            this.acquViewDataGridView.Name = "acquViewDataGridView";
            this.acquViewDataGridView.ReadOnly = true;
            this.acquViewDataGridView.RowHeadersVisible = false;
            this.acquViewDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.acquViewDataGridView.Size = new System.Drawing.Size(225, 127);
            this.acquViewDataGridView.TabIndex = 317;
            this.acquViewDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.acquViewCellEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 263);
            this.Controls.Add(this.acquViewDataGridView);
            this.Controls.Add(acquireDateLabel);
            this.Controls.Add(this.acquireDateDateTimePicker);
            this.Controls.Add(this.specMinsListView);
            this.Controls.Add(this.specBindingNavigator);
            this.Controls.Add(this.specMinsMoveDownButton);
            this.Controls.Add(this.specMinsMoveUpButton);
            this.Controls.Add(this.userSpecIDTextBox);
            this.Controls.Add(this.acquDeleteButton);
            this.Controls.Add(this.acquAddButton);
            this.Controls.Add(this.fromComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.specMinsDeleteButton);
            this.Controls.Add(this.specMinsAddButton);
            this.Controls.Add(this.minsComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(specimenIDLabel);
            this.Name = "Form1";
            this.Text = "mymins";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myminsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specMinsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specBindingNavigator)).EndInit();
            this.specBindingNavigator.ResumeLayout(false);
            this.specBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquireTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specImgsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquisitionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acquViewDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox userSpecIDTextBox;
        private System.Windows.Forms.BindingSource minsBindingSource;
        private System.Windows.Forms.BindingSource specMinsBindingSource;
        private myminsDataSetTableAdapters.SpecMinsTableAdapter specMinsTableAdapter;
        private System.Windows.Forms.Button specMinsMoveUpButton;
        private System.Windows.Forms.Button specMinsMoveDownButton;
        private System.Windows.Forms.ErrorProvider specErrorProvider;
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
        private System.Windows.Forms.Button acquDeleteButton;
        private System.Windows.Forms.Button acquAddButton;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource contactBindingSource;
        private myminsDataSetTableAdapters.ContactTableAdapter contactTableAdapter;
        private System.Windows.Forms.BindingSource specImgsBindingSource;
        private myminsDataSetTableAdapters.SpecImgsTableAdapter specImgsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn specIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagePathIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagePriorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource acquisitionBindingSource;
        private myminsDataSetTableAdapters.AcquisitionTableAdapter acquisitionTableAdapter;
        private myminsDataSetTableAdapters.ContactTypeTableAdapter contactTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DateTimePicker acquireDateDateTimePicker;
        private System.Windows.Forms.BindingSource minsTypesBindingSource;
        private myminsDataSetTableAdapters.CountryTableAdapter countryTableAdapter;
        private System.Windows.Forms.BindingSource countryBindingSource;
        private myminsDataSetTableAdapters.StateTableAdapter stateTableAdapter;
        private System.Windows.Forms.BindingSource stateBindingSource;
        private myminsDataSetTableAdapters.CountyTableAdapter countyTableAdapter;
        private System.Windows.Forms.BindingSource countyBindingSource;
        private myminsDataSetTableAdapters.CityTableAdapter cityTableAdapter;
        private System.Windows.Forms.BindingSource cityBindingSource;
        private myminsDataSetTableAdapters.AddressTableAdapter addressTableAdapter;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private System.Windows.Forms.BindingSource exposureBindingSource;
        private System.Windows.Forms.BindingSource acquireTypeBindingSource;
        private myminsDataSetTableAdapters.ExposureTableAdapter exposureTableAdapter;
        private myminsDataSetTableAdapters.AcquireTypeTableAdapter acquireTypeTableAdapter;
        private System.Windows.Forms.DataGridView acquViewDataGridView;

    }
}

