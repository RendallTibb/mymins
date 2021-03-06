﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Data.SQLite;

namespace mymins
{
    public partial class Form1 : Form
    {
        private byte conTypeLocale = 1;
        // TODO Make these user editable, and more integrated. collector should be connected to the first contact in the database.
        private String collector = "Self";
        private String acquTypePurchase = "Purchase";
        private String acquTypeSelfCollected = "Self Collected";
        private String nullMinName = "<unidentified>";
        private String nullConName = "<unknown>";
        
        // For selecting a duplicate in Contact ComboBoxes.
        private int cbxDupIndx;
        private bool cbxLeave = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check/Setup db;
            try
            {
                // Uncomment the line below when using SQLite. (see readme)
                //dbValidate();
            }
            catch
            {
                MessageBox.Show("There was a problem communicating with the database.\r\n\r\nConnection:\r\n" + Properties.Settings.Default.myminsConnectionString + "\r\n\r\nThe program will continue to load, but will be in an usable state.");
                throw;
            }

            // Load data into the DataSet.
            try
            {
                this.commentTableAdapter.Fill(this.myminsDataSet.Comment);
                this.specTableAdapter.Fill(this.myminsDataSet.Spec);
                this.minsTypesTableAdapter.Fill(this.myminsDataSet.MinsTypes);
                this.minsTableAdapter.Fill(this.myminsDataSet.Mins);
                //this.minsRelationsTableAdapter.Fill(this.myminsDataSet.MinsRelations);
                this.specMinsTableAdapter.Fill(this.myminsDataSet.SpecMins);
                //this.ImgsPathsTableAdapter.Fill(this.myminsDataSet.ImgsPaths);
                //this.SpecImgsTableAdapter.Fill(this.myminsDataSet.ImgsPaths);
                this.countryTableAdapter.Fill(this.myminsDataSet.Country);
                this.stateTableAdapter.Fill(this.myminsDataSet.State);
                this.countyTableAdapter.Fill(this.myminsDataSet.County);
                this.cityTableAdapter.Fill(this.myminsDataSet.City);
                this.contactTypeTableAdapter.Fill(this.myminsDataSet.ContactType);
                //this.timesTableAdapter.Fill(this.myminsDataSet.Times);
                //this.availabilityTableAdapter.Fill(this.myminsDataSet.Availability);
                //this.daysTableAdapter.Fill(this.myminsDataSet.Days);
                //this.openHoursTableAdapter.Fill(this.myminsDataSet.OpenHours);
                this.contactTableAdapter.Fill(this.myminsDataSet.Contact);
                //this.contactImgsTableAdapter.Fill(this.myminsDataSet.ContactImgs);
                this.exposureTableAdapter.Fill(this.myminsDataSet.Exposure);
                this.acquireTypeTableAdapter.Fill(this.myminsDataSet.AcquireType);
                this.acquisitionTableAdapter.Fill(this.myminsDataSet.Acquisition);
            }
            catch
            {
                MessageBox.Show("There is a problem with your mineral collection database's schema or data. This can be caused by file corruption or database changes made outside of MyMins.\r\n\r\nRecommended solutions: \r\n- If you made a backup of the database then restore it.\r\n- Accept the data loss and rename or delete the database. MyMins will create new database the next time it starts.\r\n- Use a third party SQLite tool to verify that the data is intact, and that it uses the same schema as a new MyMins database.\r\n\r\nThe program will continue to load, but will be in an unusable state.\r\n\r\n", "Database error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            // By default, you cannot leave a TextBox with an empty string if it is bound to a numeric field, even if the DataSource accepts nulls.
            minIDMaskedTextBox.DataBindings[0].NullValue = "";
            specMindatIDTextBox.DataBindings[0].NullValue = "";
            heightTextBox.DataBindings[0].NullValue = "";
            lengthTextBox.DataBindings[0].NullValue = "";
            widthTextBox.DataBindings[0].NullValue = "";
            weightTextBox.DataBindings[0].NullValue = "";
            appraisalTextBox.DataBindings[0].NullValue = "";
            raitingTextBox.DataBindings[0].NullValue = "";
            transparancyTextBox.DataBindings[0].NullValue = "";
            crystallizationTextBox.DataBindings[0].NullValue = "";
            gpsLatTextBox.DataBindings[0].NullValue = "";
            gpsLonTextBox.DataBindings[0].NullValue = "";
            phoneTextBox.DataBindings[0].NullValue = "";
            addressTextBox.DataBindings[0].NullValue = "";
            conMindatIDTextBox.DataBindings[0].NullValue = "";
            emailTextBox.DataBindings[0].NullValue = "";
            webTextBox.DataBindings[0].NullValue = "";
            expoDatePartsBox.DataBindings[0].NullValue = "";
            expoDatePartsBox.DataBindings[1].NullValue = "";
            expoDatePartsBox.DataBindings[2].NullValue = "";

            // acquDataGridView designer Note: Adjusting the form's height at design time may change the DataGrid's height of 97.
            // To change it back, the form height must be decreased to hide most of the DataGrid, and then the DataGrid size can be set to 97.
            // Then form's height can then be expanded again but not too far or else the size of the DataGrid will increase again.

            // Set PlusMinus label states.
            if (!(bool)LayoutSettings.Default["visPanelSpecDetails"])
            {
                labelSpecPlus.BorderStyle = BorderStyle.FixedSingle;
                labelSpecPlus.Text = "+";
            }
            if (!(bool)LayoutSettings.Default["visPanelFromContact"])
            {
                labelConPlus.BorderStyle = BorderStyle.FixedSingle;
                labelConPlus.Text = "+";
            }
            if (!(bool)LayoutSettings.Default["visFlowLayoutPanelMinEdit"])
            {
                labelMinPlus.BorderStyle = BorderStyle.FixedSingle;
                labelMinPlus.Text = "+";
            }

            // Set layoutTreeView location and set checked states.
            layoutTreeView.Size = new Size(180, 195);
            layoutTreeView.Location = new Point(117, 25);
            // Each node's Tag has the name of a corresponding LayoutSettings setting that is bound to a control's Visible property.
            treeNodeChecker(layoutTreeView.Nodes);
            
            // Changing a user setting for a control that is already hidden at program start will not change the bound control's Visible property.
            // So all these controls are directly made visible at program start. Afterwards, applying user settings will be effective.
            // Note: Changing a control's property directly does not work for controls that are hidden by other controls.
            panelSpecminID.Visible = true;
            panelMinMins.Visible = true;

            labelMinPlus.Visible = true;
            flowLayoutPanelMinEdit.Visible = true;
            panelMinEditAddDel.Visible = true;
            panelMinName.Visible = true;
            panelMinMember.Visible = true;
            panelMinMindatID.Visible = true;

            labelSpecPlus.Visible = true;
            panelSpecDetails.Visible = true;
            panelSpecHeight.Visible = true;
            panelSpecLength.Visible = true;
            panelSpecWidth.Visible = true;
            panelSpecUnits.Visible = true;
            panelSpecWeight.Visible = true;
            panelSpecwUnits.Visible = true;
            panelSpecRepair.Visible = true;
            panelSpecArtificial.Visible = true;
            panelSpecAppraisal.Visible = true;
            panelSpecRating.Visible = true;
            panelSpecTransparent.Visible = true;
            panelSpecCrystal.Visible = true;
            panelSpecComment.Visible = true;

            labelConPlus.Visible = true;
            panelFromContact.Visible = true;
            panelFromConAddDel.Visible = true;
            panelConName.Visible = true;
            panelConCountry.Visible = true;
            panelConState.Visible = true;
            panelConCounty.Visible = true;
            panelConCity.Visible = true;
            panelConAddress.Visible = true;
            panelConType.Visible = true;
            panelConGPSlat.Visible = true;
            panelConGPSlon.Visible = true;
            panelConPhone.Visible = true;
            panelConEmail.Visible = true;
            panelConWeb.Visible = true;
            panelConComment.Visible = true;
            panelConMindatID.Visible = true;
            flowLayoutPanelExpoEdit.Visible = true;
            expoDatePartsBox.Visible = true;

            panelAcquTo.Visible = true;
            acquDatePartsBox.Visible = true;
            panelAcquPrice.Visible = true;
            panelAcquType.Visible = true;
            panelAcquExposure.Visible = true;
            acquDataGridView.Visible = true;
            
            LayoutSettings.Default.Reload();
            // Sets initial state of contact's exposure and mindatID panels. Their Visible property is set manually.
            contactTypeComboBox_SelectedIndexChanged(contactTypeComboBox, null);

            // Make fromComboBox empty on program start. See also acquAddButton_Click. Setting the Text property using code doesn't actually set it, but selecting index -1 makes it empty.
            // As a result the contact row needs to be set to edit mode or else new input in one field is lost if navigating away from the contact.
            fromComboBox.SelectedIndex = -1;
            var currentConRow = (DataRowView)contactBindingSource.Current;
            currentConRow.BeginEdit();

        }


        #region App

        private void dbValidate()
        {
            bool newdb = false;
            string dbfile = "mymins.sqlite";
            string userdbDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyMins");
            string userdbPath = Path.Combine(userdbDirPath, dbfile);
            Properties.Settings.Default["myminsConnectionString"] = "Data Source=" + userdbPath + "; Version=3; FailIfMissing=True;";

            if (!Directory.Exists(userdbDirPath))
            {
                Directory.CreateDirectory(userdbDirPath);
            }
            if (!File.Exists(userdbPath))
            {
                MessageBox.Show("Creating a new mineral collection database file at " + userdbPath, "New mineral collection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLiteConnection.CreateFile(userdbPath);
                newdb = true;
            }
            
            using (var conn = new SQLiteConnection(Properties.Settings.Default["myminsConnectionString"].ToString()))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn))
                {
                    if (newdb)
                    {
                        cmd.CommandText = mymins.Properties.Resources.v1_0_0;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Check if the current user database is compatible with this verion of the program.
                        var ma = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
                        var mi = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                        var bu = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
                        cmd.CommandText = "SELECT MyMinsMajor, MyMinsMinor, MyMinsBuild FROM MyMinsCompatibleVersions WHERE MyMinsMajor = " + ma + " AND MyMinsMinor = " + mi + " AND MyMinsBuild = " + bu;
                        if (cmd.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Your mineral collection database is not compatible with this version(" + ma + "." + mi + "." + bu + ") of MyMins. Please install a later version of the program.", "Newer database detected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                conn.Close();
            }

        }
        
        // Adds Data from a ComboBox control(and optionally any specified related ComboBox controls) to the DataSet.
        // Note: ComboBoxes used here require DataSource, DisplayMember, and ValueMember properties to be set correctly.
        // Also, most but not all need auto-complete as well.
        private DataRow addData(ComboBox fieldComboBox, ComboBox[] relatedCombos = null)
        {
            var bS = (BindingSource)fieldComboBox.DataSource;
            String tbl = bS.DataMember;
            String tblfield = fieldComboBox.DisplayMember;
            String tblIDfield = fieldComboBox.ValueMember;
            var currentRow = (DataRowView)bS.Current;
            if ((currentRow == null) || (fieldComboBox.Text != currentRow[tblfield].ToString()))
            {
                String newItem = fieldComboBox.Text;
                var tblRowAdd = myminsDataSet.Tables[tbl].NewRow();
                tblRowAdd[tblfield] = newItem;
                if (relatedCombos != null)
                {
                    foreach (ComboBox combo in relatedCombos)
                    {
                        DataRow item = addData(combo);
                        tblRowAdd[combo.ValueMember] = item[combo.ValueMember];
                    }
                }
                myminsDataSet.Tables[tbl].Rows.Add(tblRowAdd);
                bS.Position = bS.Find(tblIDfield, tblRowAdd[tblIDfield]);
                currentRow = (DataRowView)bS.Current;
            }
            return currentRow.Row;
        }

        private void editComment(TextBox comTextBox, DataRowView sourceRow)
        {
            if (sourceRow["CommentID"] != DBNull.Value)
            {
                myminsDataSet.CommentRow currentComRow = myminsDataSet.Comment.FindByCommentID((int)sourceRow["CommentID"]);
                // Delete
                if (comTextBox.Text == "")
                {
                    currentComRow.Delete();
                }
                // Update
                else if (comTextBox.Text != currentComRow["Comment"].ToString())
                {
                    currentComRow["Comment"] = comTextBox.Text;
                }
            }
            // Add
            else if (comTextBox.Text != "")
            {
                myminsDataSet.CommentRow newComRow = myminsDataSet.Comment.NewCommentRow();
                newComRow.Comment = comTextBox.Text;
                myminsDataSet.Comment.AddCommentRow(newComRow);
                sourceRow["CommentID"] = newComRow["CommentID"];
            }
        }
        
        // Recursively checks tree nodes. Called only once, in From1_load.
        private void treeNodeChecker(TreeNodeCollection nds)
        {
            foreach (TreeNode nd in nds)
            {
                treeNodeChecker(nd.Nodes);
                if (nd.Tag != null)
                {
                    try
                    {
                        nd.Checked = (bool)LayoutSettings.Default[nd.Tag.ToString()];
                    }
                    catch
                    {
                        MessageBox.Show("Checking the node '" + nd.Text + "' will have no effect because the property '" + nd.Tag.ToString() + "' it refers to was not found in LayoutSettings.");
                        nd.Tag = null;
                    }
                }
            }

        }

        // Shows/Hides layoutTreeView and auto-sizes form.
        private void layoutCheckStateChanged(object sender, EventArgs e)
        {
            var layoutButton = (ToolStripButton)sender;
            if (layoutButton.Checked == true)
            {
                layoutTreeView.Visible = true;
            }
            else
            {
                // AutoSize: Auto-resizes form, but disallows manual re-size, so turn it off when done.
                // FlowDirecton: Makes the program more vertical on auto-re-size instead of using a lot of horizontal space. LeftToRight is used for manual-re-sizing. 
                // AutoSizeMode: GrowAndShrink is used for auto-re-size, but it prevents manual-re-size if it's not set back to GrowOnly, even if AutoSize is false.
                layoutTreeView.Visible = false;
                flowLayoutPanelMain1.FlowDirection = FlowDirection.TopDown;
                this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this.AutoSize = true;
                int wid = this.Width;
                int hei = this.Height;
                this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
                this.AutoSize = false;
                this.Width = wid;
                this.Height = hei;
                flowLayoutPanelMain1.FlowDirection = FlowDirection.LeftToRight;

            }

        }

        // Shows/Hides most controls, and related acquDataGridView columns.
        private void layoutTreeViewAfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                LayoutSettings.Default[e.Node.Tag.ToString()] = e.Node.Checked;
                switch (e.Node.Tag.ToString())
                {
                    case "visPanelAcquTo":
                        acquDataGridView.Columns["To"].Visible = (bool)LayoutSettings.Default["visPanelAcquTo"];
                        break;
                    case "visPanelAcquPrice":
                        acquDataGridView.Columns["Price"].Visible = (bool)LayoutSettings.Default["visPanelAcquPrice"];
                        break;
                    case "visPanelAcquType":
                        acquDataGridView.Columns["Type"].Visible = (bool)LayoutSettings.Default["visPanelAcquType"];
                        break;
                    case "visPanelAcquExposure":
                        acquDataGridView.Columns["Exposure"].Visible = (bool)LayoutSettings.Default["visPanelAcquExposure"];
                        // Update visibility of locale related panels.
                        contactTypeComboBox_SelectedIndexChanged(contactTypeComboBox, null);
                        break;
                    case "visFlowLayoutPanelExpoEdit":
                        contactTypeComboBox_SelectedIndexChanged(contactTypeComboBox, null);
                        break;
                    case "visPanelConMindatID":
                        contactTypeComboBox_SelectedIndexChanged(contactTypeComboBox, null);
                        break;
                }
            }

        }

        private void labelPlusMinus_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            Panel pnl = panelSpecDetails;
            if (lbl.Equals(labelConPlus))
            {
                pnl = panelFromContact;
            }
            if (lbl.Equals(labelMinPlus))
            {
                pnl = flowLayoutPanelMinEdit;
            }
            if (pnl.Visible)
            {
                pnl.Visible = false;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Text = "+";
            }
            else
            {
                pnl.Visible = true;
                lbl.BorderStyle = BorderStyle.Fixed3D;
                lbl.Text = "-";
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            LayoutSettings.Default.Save();
            DataSet datachanges = myminsDataSet.GetChanges();
            if (datachanges != null)
            {
                int count = 0;
                foreach (DataTable t in datachanges.Tables)
                {
                    count += t.Rows.Count;
                }
                var msboxresult = DialogResult.Yes;
                msboxresult = MessageBox.Show("Save any unsaved changes?\nEstimated: " + count,
                                              "Unsaved changes.",
                                              MessageBoxButtons.YesNoCancel,
                                              MessageBoxIcon.Information);
                if (msboxresult == DialogResult.No)
                {

                }
                else if (msboxresult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    specBindingNavigatorSaveItem.PerformClick();
                }

            }
        }

        #endregion App


        #region Specimen ID and Minerals


        // Deletes Comment if Specimen is deleted. Sets some acquisition values from the last specimen. Saves Unit ComboBox values. Focuses userSpecIDTextBox.
        private void specBindingNavItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            if (e.ClickedItem.Equals(bindingNavigatorDeleteItem))
            {
                specCommentTextBox.Text = "";
            }
            if ((e.ClickedItem.Equals(bindingNavigatorAddNewItem)) && (acquDataGridView.RowCount > 0))
            {
                if ((String)acquDataGridView.Rows[0].Cells["From"].Value == "")
                {
                    fromComboBox.SelectedIndex = -1;
                    var currentConRow = (DataRowView)contactBindingSource.Current;
                    currentConRow.BeginEdit();
                }
                else
                { 
                    fromComboBox.Text = (String)acquDataGridView.Rows[0].Cells["From"].Value;
                }

                if ((String)acquDataGridView.Rows[0].Cells["To"].Value == "")
                {
                    toComboBox.SelectedIndex = -1;
                }
                else
                {
                    toComboBox.SelectedIndex = 0;
                    toComboBox.Text = (String)acquDataGridView.Rows[0].Cells["To"].Value;
                }
                
            }
            editComment(specCommentTextBox, currentRow);
            if (Convert.ToBoolean(currentRow["Units"]) != Convert.ToBoolean(unitsComboBox.SelectedIndex))
            {
                currentRow["Units"] = Convert.ToBoolean(unitsComboBox.SelectedIndex);
            }
            if (Convert.ToBoolean(currentRow["WeightUnits"]) != Convert.ToBoolean(weightUnitsComboBox.SelectedIndex))
            {
                currentRow["WeightUnits"] = Convert.ToBoolean(weightUnitsComboBox.SelectedIndex);
            }
            userSpecIDTextBox.Focus();
        }

        private void specBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Mins Edit and Exposure Edit DataSet saves are called by the focus change on the navigator click above.
            this.Validate();
            this.specBindingSource.EndEdit();
            fromComboBoxEnter(fromComboBox, null);
            contactBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myminsDataSet);

        }

        // Avoids extra code for checking for an empty BindingSource and prevents data loss when a user enters data before clicking the add new button.
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (specBindingSource.Count == 0)
            {
                myminsDataSet.Spec.Rows.Add(null, 1);
            }
        }

        // Load Units and Comment values.
        private void specCurrentChanged(object sender, EventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            if (currentRow != null)
            {
                unitsComboBox.SelectedIndex = Convert.ToInt32(currentRow["Units"]);
                weightUnitsComboBox.SelectedIndex = Convert.ToInt32(currentRow["WeightUnits"]);
                if (currentRow["CommentID"] == DBNull.Value)
                {
                    specCommentTextBox.Text = "";
                }
                else
                {
                    myminsDataSet.CommentRow currentComRow = myminsDataSet.Comment.FindByCommentID((int)currentRow["CommentID"]);
                    specCommentTextBox.Text = currentComRow["Comment"].ToString();
                }
                /* TODO Auto-increment suggest here.
                if (currentRow.IsNew)
                {
                    userSpecIDTextBox.SelectAll();
                }*/
                
            }

        }

        private void specIDValidating(object sender, CancelEventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            var msboxresult = DialogResult.None;
            if ((currentRow.Row.RowState == DataRowState.Detached) || (userSpecIDTextBox.Text != (currentRow["UserSpecID"].ToString())))
            {
                var query = myminsDataSet.Spec.Where(row => (row.RowState != DataRowState.Deleted) && (row.Field<string>("UserSpecID") == userSpecIDTextBox.Text));
                if (query.Any())
                {
                    msboxresult = MessageBox.Show("WARNNING: A specimen with the ID " + userSpecIDTextBox.Text + " already exists. Press OK to use it anyway, or Cancel to change it.",
                                                  "Specimen ID already used.",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Information);
                }
                else if (userSpecIDTextBox.Text == "")
                {
                    msboxresult = MessageBox.Show("WARNNING: A specimen ID has not been entered.",
                                                  "Specimen ID blank.",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Information);
                }
            }
            if (msboxresult == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                // Add row immediately to avoid dealing with detached records any further. If BeginEdit is not called and data is entered into one specimen field, the data is lost if a navigation button is clicked.
                specBindingSource.EndEdit();
                currentRow.BeginEdit();
                /* If using a bindingsource.sort and the current item will change position, the bindingsource will go to that position, and then to the position after that.
                if (!currentRow.Equals((DataRowView)specBindingSource.Current))
                {
                    specBindingSource.Position--;
                }*/
            }
        }

        private void minIDMasekdTextBoxValidating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(minIDMaskedTextBox, "");
            if (minIDMaskedTextBox.Text.Contains(' '))
            {
                e.Cancel = true;
                errorProvider.SetError(minIDMaskedTextBox, "Please finish or remove the minID.");
            }
            // TODO: A minID cannot contain certain characters such as O. This is to eliminate possible confusion, like when using the letter 'O' or number '0'.
        }

        // Pressing Enter while in the ComboBox adds the mineral to the specimen.
        private void minsComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                specMinsAddButton_Click(specMinsAddButton, null);
            }
        }

        // Add a mineral if it's new. Then add a mineral to the specimen.
        private void specMinsAddButton_Click(object sender, EventArgs e)
        {
            if (minsComboBox.Text == "")
            {
                minsComboBox.Text = this.nullMinName;
            }
            DataRow minsRow = addData(minsComboBox, new ComboBox[] { minsTypeComboBox });
            
            var currentRow = (DataRowView)specBindingSource.Current;
            var specMinsRowAdd = myminsDataSet.SpecMins.NewSpecMinsRow();
            specMinsRowAdd.MinsID = (int)minsRow["MinsID"];
            specMinsRowAdd.SpecID = (int)currentRow["SpecID"];
            // The following if/else is auto-increment for priority.
            if (specMinsBindingSource.Position == -1)
            {
                specMinsRowAdd.MinsPriority = 1;
            }
            else
            {
                specMinsBindingSource.MoveLast();
                var currentSpecMinsRow = (DataRowView)specMinsBindingSource.Current;
                specMinsRowAdd.MinsPriority = (short)((short)currentSpecMinsRow["MinsPriority"] + 1);
            }
            myminsDataSet.SpecMins.AddSpecMinsRow(specMinsRowAdd);
            specMinsBindingSource.MoveLast();
            specMinsListView.Items[specMinsBindingSource.Position].Selected = true;
            minsComboBox.SelectAll();
            minsComboBox.Focus();
        }

        // Deletes a mineral from the specimen and moves all of the minerals bellow it up one priority.
        private void specMinsDeleteButton_Click(object sender, EventArgs e)
        {
            var pos = specMinsBindingSource.Position;
            if (pos > -1)
            {
                specMinsBindingSource.RemoveCurrent();
                if (specMinsBindingSource.Position > -1)
                {
                    for (var i = pos; i != specMinsBindingSource.Count; i++)
                    {
                        var currentRow = (DataRowView)specMinsBindingSource.Current;
                        currentRow["MinsPriority"] = (short)currentRow["MinsPriority"] - 1;
                        currentRow.EndEdit();
                        specMinsBindingSource.MoveNext();
                    }
                    specMinsBindingSource.Position = pos;
                    specMinsListView.Items[specMinsBindingSource.Position].Selected = true;
                    specMinsListView.Focus();
                }
            }
        }

        private void specMinsMoveUpButton_Click(object sender, EventArgs e)
        {
            var pos = specMinsBindingSource.Position;
            if (pos > 0)
            {
                PropertyDescriptorCollection pdc = specMinsBindingSource.CurrencyManager.GetItemProperties();
                var currentRow = (DataRowView)specMinsBindingSource.Current;
                var moveupid = (int)currentRow["Id"];
                --specMinsBindingSource.Position;
                currentRow = (DataRowView)specMinsBindingSource.Current;
                currentRow["MinsPriority"] = (short)currentRow["MinsPriority"] + 1;
                currentRow.EndEdit();
                specMinsBindingSource.Position = specMinsBindingSource.Find(pdc["Id"], moveupid);
                currentRow = (DataRowView)specMinsBindingSource.Current;
                currentRow["MinsPriority"] = (short)currentRow["MinsPriority"] - 1;
                currentRow.EndEdit();
                specMinsListView.Items[specMinsBindingSource.Position].Selected = true;
                specMinsListView.Focus();
            }
        }

        private void specMinsMoveDownButton_Click(object sender, EventArgs e)
        {
            var pos = specMinsBindingSource.Position;
            if ((pos > -1) && (pos < (specMinsBindingSource.Count - 1)))
            {
                PropertyDescriptorCollection pdc = specMinsBindingSource.CurrencyManager.GetItemProperties();
                var currentRow = (DataRowView)specMinsBindingSource.Current;
                var movedownid = (int)currentRow["Id"];
                ++specMinsBindingSource.Position;
                currentRow = (DataRowView)specMinsBindingSource.Current;
                currentRow["MinsPriority"] = (short)currentRow["MinsPriority"] - 1;
                currentRow.EndEdit();
                specMinsBindingSource.Position = specMinsBindingSource.Find(pdc["Id"], movedownid);
                currentRow = (DataRowView)specMinsBindingSource.Current;
                currentRow["MinsPriority"] = (short)currentRow["MinsPriority"] + 1;
                currentRow.EndEdit();
                specMinsListView.Items[specMinsBindingSource.Position].Selected = true;
                specMinsListView.Focus();
            }
        }

        // Change BindingSource position to selected item in ListView.
        private void specMinsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (specMinsListView.SelectedIndices.Count > 0)
            {
                specMinsBindingSource.Position = specMinsListView.SelectedIndices[0];
            }
        }

        // Fill ListView with info(mineral names/types) from Mins table joined with specMinsBindingSoure which has a list of minerals per specimen sorted by priority.
        private void specMinsListChanged(object sender, ListChangedEventArgs e)
        {
            specMinsListView.Clear();
            var query = from specmin in specMinsBindingSource.List.OfType<DataRowView>().ToList()
                        join min in myminsDataSet.Mins.Where(r => r.RowState != DataRowState.Deleted)
                        on specmin.Row["MinsId"]
                        equals min.Field<int>("MinsID")
                        select new
                        {
                            min.MinsID,
                            min.MinsName,
                            min.MinsTypeID
                        };
            foreach (var minsrow in query)
            {
                specMinsListView.Items.Add(minsrow.MinsID.ToString(), minsrow.MinsName, minsrow.MinsTypeID);
            }
        }

        // Delete: Update mineral priorities for every specimen that uses the mineral about to be deleted. Add: Save any changes to the current mineral first.
        private void minsBindingNavItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Equals(minsBindingNavigatorDeleteItem))
            {
                var currentrow = (DataRowView)minsBindingSource.Current;
                if (currentrow == null)
                {
                    return;
                }
                var query = from specmin in myminsDataSet.SpecMins.Where(r => r.MinsID == (int)currentrow["MinsID"])
                            select new
                            {
                                specmin.SpecID
                            };
                var affectedSpecs = query.Distinct().ToList();
                var msgresult = MessageBox.Show("This mineral is used by " + affectedSpecs.Count.ToString() + " specimens. Are you sure you want to delete it?", "Delete mineral?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgresult == DialogResult.No)
                {
                    return;
                }
                foreach (var spec in affectedSpecs)
                {
                    var specMinList = from specmin in myminsDataSet.SpecMins
                                 where specmin.SpecID == spec.SpecID
                                 orderby specmin.MinsPriority
                                 select specmin;
                    short count = 0;
                    foreach (var row in specMinList)
                    {
                        if (row.MinsID != (int)currentrow["MinsID"])
                        {
                            count++;
                            if (row.MinsPriority != count)
                            {
                                row.MinsPriority = count;
                            }
                        }
                    }
                }
            }
            else
            {
                minsEdit_Leave(minsComboBox, null);
            }
        }

        private void minsBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            minsNameTextBox.Focus();
        }

        private void minsBindingSourceCurrentChanged(object sender, EventArgs e)
        {
            if (minsBindingSource.Count != 0)
            {
                var currentMinsRow = (DataRowView)minsBindingSource.Current;
                minsTypeComboBox.SelectedValue = currentMinsRow["MinsTypeID"];
            }
            else
            {
                myminsDataSet.Mins.Rows.Add(null, null, nullMinName, 4);
                minsBindingSource.ResetBindings(false);
            }

        }

        // Save changes to a mineral.
        private void minsEdit_Leave(object sender, EventArgs e)
        {
            this.Validate();
            var currentRow = (DataRowView)minsBindingSource.Current;
            if (currentRow["MinsTypeID"] != minsTypeComboBox.SelectedValue)
            {
                currentRow["MinsTypeID"] = minsTypeComboBox.SelectedValue;
            }
            minsBindingSource.EndEdit();
        }

        private void minsNameTextBoxValidating(object sender, CancelEventArgs e)
        {
            {
                var currentRow = (DataRowView)minsBindingSource.Current;
                var msboxresult = DialogResult.None;
                if (minsNameTextBox.Text == "")
                {
                    minsNameTextBox.Text = this.nullMinName;
                }
                if ((currentRow.Row.RowState == DataRowState.Detached) || (minsNameTextBox.Text != (currentRow["MinsName"].ToString())))
                {
                    var query = myminsDataSet.Mins.Where(row => (row.RowState != DataRowState.Deleted) && (row.Field<string>("MinsName") == minsNameTextBox.Text));
                    if (query.Any())
                    {
                        msboxresult = MessageBox.Show("A mineral with the name '" + minsNameTextBox.Text + "' already exists. Please use a unique name.",
                                                      "Mineral name already used.",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Error);
                    }
                    else if (minsNameTextBox.Text == "")
                    {
                        msboxresult = MessageBox.Show("WARNNING: A mineral name has not been entered.",
                                                      "Mineral name blank.",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Error);
                    }
                }
                if (msboxresult != DialogResult.None)
                {
                    e.Cancel = true;
                }
                else
                {
                    minsBindingSource.EndEdit();
                    currentRow.BeginEdit();
                    specMinsListChanged(specMinsListView, null);
                    // See specIDValidating if considering adding sorting.
                }

            }

        }

        #endregion Specimen ID and Minerals


        #region Spec Details

        // Validates Height, Width, Length, and Weight TextBoxs.
        private void measurementValidating(object sender, CancelEventArgs e)
        {
            var mTextBox = (TextBox)sender;
            errorProvider.SetError(mTextBox, "");
            float mFloatValue;
            if (float.TryParse(mTextBox.Text, out mFloatValue))
            {
                mTextBox.Text = Math.Abs(mFloatValue).ToString();

            }
            else if (mTextBox.Text != "")
            {
                errorProvider.SetError(mTextBox, mTextBox.Text + " cannot be converted to a number. Please remove any letters or other non-numeric characters.");
            }
        }

        // Validates Appraisal and Acquisition price. Accepts currency formatting. Turns negative to positive. Rounds down. 
        private void priceValidating(object sender, CancelEventArgs e)
        {
            var pTextBox = (TextBox)sender;
            errorProvider.SetError(pTextBox, "");
            decimal pDecValue;
            if (decimal.TryParse(pTextBox.Text, System.Globalization.NumberStyles.Currency, null, out pDecValue))
            {
                pDecValue = Math.Abs(pDecValue);
                pDecValue = ((decimal)(int)(pDecValue * 100)) / 100;
                pTextBox.Text = pDecValue.ToString();
            }
            else if (pTextBox.Text != "")
            {
                e.Cancel = true;
                errorProvider.SetError(pTextBox, pTextBox.Text + " cannot be converted to a price. Please remove any letters or other non-numeric characters.");
            }

        }

        // Validates Rating, Transparency, and Crystallization. Range 0-10 with with two possible decimals.  
        private void ratingValidating(object sender, CancelEventArgs e)
        {
            var rTextBox = (TextBox)sender;
            errorProvider.SetError(rTextBox, "");
            decimal rDecValue;
            if (decimal.TryParse(rTextBox.Text, out rDecValue))
            {
                if (rDecValue > 10)
                {
                    rTextBox.Text = (10).ToString();
                }
                else if (rDecValue < 0)
                {
                    rTextBox.Text = (0).ToString();
                }
                else
                {
                    rDecValue = ((decimal)(int)(rDecValue * 100)) / 100;
                    rTextBox.Text = rDecValue.ToString();
                }
            }
            else if (rTextBox.Text != "")
            {
                errorProvider.SetError(rTextBox, rTextBox.Text + " is not a valid rating. Please remove any letters or other non-numeric characters, and enter a value from 0 to 10.");
            }

        }

        #endregion Spec Details


        #region Contact

        // Save Exposure, delete a Contact's Comment if the Contact is deleted, save ComboBox values.
        private void contactBindingNavigatorItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            flowLayoutPanelExpoEditLeave(flowLayoutPanelExpoEdit, null);
            if (e.ClickedItem.Equals(fromContactBindingNavigatorDeleteItem))
            {
                contactCommentTextBox.Text = "";
            }
            fromComboBoxEnter(fromComboBox, null);
        }

        private void fromContactBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            contactNameTextBox.Focus();
        }

        private void contactNameTextBoxValidating(object sender, CancelEventArgs e)
        {
            var currentRow = (DataRowView)contactBindingSource.Current;
            var msboxresult = DialogResult.None;
            if (contactNameTextBox.Text == "")
            {
                contactNameTextBox.Text = this.nullConName;
            }
            if ((currentRow.Row.RowState == DataRowState.Detached) || (contactNameTextBox.Text != (currentRow["ContactName"].ToString())))
            {
                var query = myminsDataSet.Contact.Where(row => (row.RowState != DataRowState.Deleted) && (row.Field<string>("ContactName") == contactNameTextBox.Text));
                if (query.Any())
                {
                    msboxresult = MessageBox.Show("WARNNING: A contact with the name '" + contactNameTextBox.Text + "' already exists. Press OK to use it anyway, or Cancel to change it.",
                                                  "Contact name already used.",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Information);
                }
                else if (contactNameTextBox.Text == "")
                {
                    msboxresult = MessageBox.Show("WARNNING: A contact name has not been entered.",
                                                  "Contact name blank.",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Information);
                }
            }
            if (msboxresult == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                contactBindingSource.EndEdit();
                currentRow.BeginEdit();
                // See specIDValidating if considering adding sorting.
            }

        }

        private void gpsValidating(object sender, CancelEventArgs e)
        {
            var gTextBox = (TextBox)sender;
            errorProvider.SetError(gTextBox, "");
            float gFloatValue;
            if (float.TryParse(gTextBox.Text, out gFloatValue))
            {
                if (gTextBox.Name == "gpsLatTextBox")
                {
                    if (gFloatValue > 90)
                    {
                        errorProvider.SetError(gTextBox, "Latitude cannot be greater than 90.");
                        e.Cancel = true;
                    }
                    else if (gFloatValue < -90)
                    {
                        errorProvider.SetError(gTextBox, "Latitude cannot be less than -90.");
                        e.Cancel = true;
                    }
                    else
                    {
                        gTextBox.Text = gFloatValue.ToString();
                    }
                }
                else
                {
                    if (gFloatValue > 180)
                    {
                        errorProvider.SetError(gTextBox, "Longitude cannot be greater than 180.");
                        e.Cancel = true;
                    }
                    else if (gFloatValue < -180)
                    {
                        errorProvider.SetError(gTextBox, "Longitude cannot be less than -180.");
                        e.Cancel = true;
                    }
                    else
                    {
                        gTextBox.Text = gFloatValue.ToString();
                    }
                }
            }
            else if (gTextBox.Text != "")
            {
                errorProvider.SetError(gTextBox, "Only decimal GPS format is supported.");
            }

        }

        private void phoneValidating(object sender, CancelEventArgs e)
        {
            var phTextBox = (TextBox)sender;
            errorProvider.SetError(phTextBox, "");
            int phIntValue;
            if (int.TryParse(phTextBox.Text, out phIntValue))
            {
                phTextBox.Text = Math.Abs(phIntValue).ToString();
            }
            else if (phTextBox.Text != "")
            {
                errorProvider.SetError(phTextBox, "Could not accept " + phTextBox.Text + " as a valid phone number. Please use only numbers.");
            }

        }

        private void mindatValidating(object sender, CancelEventArgs e)
        {
            var miTextBox = (TextBox)sender;
            int miIntValue;
            errorProvider.SetError(miTextBox, "");
            var bS = (BindingSource)miTextBox.DataBindings[0].DataSource;
            var currentRow = (DataRowView)bS.Current;
            if (int.TryParse(miTextBox.Text, out miIntValue))
            {
                miIntValue = Math.Abs(miIntValue);
                if ((currentRow["MindatID"] == DBNull.Value) || (miIntValue != (int)currentRow["MindatID"]))
                {
                    var query = myminsDataSet.Tables[bS.DataMember].AsEnumerable().Where(row => (row.RowState != DataRowState.Deleted) && (!row.IsNull("MindatID") && (row.Field<int>("MindatID") == miIntValue)));
                    if (query.Any())
                    {
                        errorProvider.SetError(miTextBox, "The MindatID " + miIntValue.ToString() + " is already in use.");
                        e.Cancel = true;
                    }
                    else
                    {
                        miTextBox.Text = Math.Abs(miIntValue).ToString();
                    }
                }
            }
            else if (miTextBox.Text != "")
            {
                errorProvider.SetError(miTextBox, "MindatID must be a whole number.");
                e.Cancel = true;
            }

        }

        // Controls visibility of Locale related controls.
        private void contactTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((byte?)contactTypeComboBox.SelectedValue == conTypeLocale)
            {
                if ((bool)LayoutSettings.Default["visFlowLayoutPanelExpoEdit"])
                {
                    flowLayoutPanelExpoEdit.Visible = true;
                }
                if ((bool)LayoutSettings.Default["visPanelConMindatID"])
                {
                    panelConMindatID.Visible = true;
                }
                if ((bool)LayoutSettings.Default["visPanelAcquExposure"])
                {
                    panelAcquExposure.Visible = true;
                }
            }
            else
            {
                flowLayoutPanelExpoEdit.Visible = false;
                panelConMindatID.Visible = false;
                panelAcquExposure.Visible = false;
            }
        }

        private void flowLayoutPanelExpoEditEnter(object sender, EventArgs e)
        {
            if (exposureBindingSource.Position < 0)
            {
                expoBindingNavigatorAddNewItem.PerformClick();
            }
        }

        private void flowLayoutPanelExpoEditLeave(object sender, EventArgs e)
        {
            var currentRow = (DataRowView)exposureBindingSource.Current;
            if (expoNameTextBox.Text != "")
            {
                this.Validate();
                exposureBindingSource.EndEdit();
            }
            else
            {
                exposureBindingSource.CancelEdit();
            }

        }

        // Disallow blank exposure names.
        private void expoBindingNavigatorItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var currentRow = (DataRowView)exposureBindingSource.Current;
            if (currentRow != null)
            {
                if (expoNameTextBox.Text == "")
                {
                    expoNameTextBox.DataBindings[0].ReadValue();
                    if (expoNameTextBox.Text == "")
                    {
                        currentRow.CancelEdit();
                    }
                }
            }
        }

        #endregion Contact


        #region Acquisitions

        // Save current Contact's values, also adding data to related tables if necessary.
        private void fromComboBoxEnter(object sender, EventArgs e)
        {
            var currentRow = (DataRowView)contactBindingSource.Current;
            
            if (countryComboBox.Text != "")
            {
                addData(countryComboBox);
                if (currentRow["CountryID"] != countryComboBox.SelectedValue)
                {
                    currentRow["CountryID"] = countryComboBox.SelectedValue;
                }
            }
            else if (currentRow["CountryID"] != DBNull.Value)
            {
                currentRow["CountryID"] = DBNull.Value;
            }
            
            if (stateComboBox.Text != "")
            {
                addData(stateComboBox);
                if (currentRow["StateID"] != stateComboBox.SelectedValue)
                {
                    currentRow["StateID"] = stateComboBox.SelectedValue;
                }
            }
            else if (currentRow["StateID"] != DBNull.Value)
            {
                currentRow["StateID"] = DBNull.Value;
            }
            
            if (countyComboBox.Text != "")
            {
                addData(countyComboBox);
                if (currentRow["CountyID"] != countyComboBox.SelectedValue)
                {
                    currentRow["CountyID"] = countyComboBox.SelectedValue;
                }
            }
            else if (currentRow["CountyID"] != DBNull.Value)
            {
                currentRow["CountyID"] = DBNull.Value;
            }
            
            if (cityComboBox.Text != "")
            {
                addData(cityComboBox);
                if (currentRow["CityID"] != cityComboBox.SelectedValue)
                {
                    currentRow["CityID"] = cityComboBox.SelectedValue;
                }
            }
            else if (currentRow["CityID"] != DBNull.Value)
            {
                currentRow["CityID"] = DBNull.Value;
            }

            if (currentRow["ContactTypeID"] != contactTypeComboBox.SelectedValue)
            {
                currentRow["ContactTypeID"] = contactTypeComboBox.SelectedValue;
            }
            editComment(contactCommentTextBox, currentRow);
            
        }

        // Gets a manually selected item before auto-complete changes it in the case of duplicate items.
        private void contactComboBoxLeave(object sender, EventArgs e)
        {
            var cbx = (ComboBox)sender;
            cbxDupIndx = cbx.SelectedIndex;
            cbxLeave = true;
        }

        // Allows adding a new Contact, and adding a null Contact to the Acquisitions.
        private void contactComboBoxValidating(object sender, CancelEventArgs e)
        {
            var cbx = (ComboBox)sender;
            if (cbxLeave)
            {
                cbx.SelectedIndex = cbxDupIndx;
                cbxLeave = false;
            }
            var cbxBs = (BindingSource)cbx.DataSource;
            var currentRow = (DataRowView)cbxBs.Current;
            var msboxresult = DialogResult.None;
            if (cbx.Text != "")
            {
                if ((cbx.Text != currentRow["ContactName"].ToString()))
                {

                    msboxresult = MessageBox.Show("Create new contact '" + cbx.Text + "'?",
                                   "New contact",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Question);
                }
                if (msboxresult == DialogResult.OK)
                {
                    String newContact = cbx.Text;
                    contactTypeBindingSource.Position = contactTypeBindingSource.Find("ContactTypeID", conTypeLocale);
                    DataRow newRow = addData(cbx, new ComboBox[] { contactTypeComboBox });
                    cbxBs.Position = cbxBs.Find("ContactID", newRow["ContactID"]);
                }
                else if (msboxresult == DialogResult.Cancel)
                {
                    cbx.Text = currentRow["ContactName"].ToString();
                }
             
            }
        }
 
        // Load current Contact's values.
        private void contactBindingSourceCurrentChanged(object sender, EventArgs e)
        {
            var currentRow = (DataRowView)contactBindingSource.Current;
            if (currentRow != null)
            {
                countryComboBox.SelectedValue = currentRow["CountryID"];
                stateComboBox.SelectedValue = currentRow["StateID"];
                countyComboBox.SelectedValue = currentRow["CountyID"];
                cityComboBox.SelectedValue = currentRow["CityID"];
                contactTypeComboBox.SelectedValue = currentRow["ContactTypeID"];
                if (currentRow["CommentID"] == DBNull.Value)
                {
                    contactCommentTextBox.Text = "";
                }
                else
                {
                    myminsDataSet.CommentRow currentComRow = myminsDataSet.Comment.FindByCommentID((int)currentRow["CommentID"]);
                    contactCommentTextBox.Text = currentComRow["Comment"].ToString();
                }
            }
            else if (contactBindingSource.Count == 0)
            {
                myminsDataSet.Contact.Rows.Add(null, collector, 4);
                contactBindingSource.ResetBindings(false);
            }
        }
        
        // Auto-suggests a Acquisition type.
        private void acquireTypeComboBoxEnter(object sender, EventArgs e)
        {
            if (acquirePriceTextBox.Text != "")
            {
                acquireTypeComboBox.Text = this.acquTypePurchase;
            }
            var currentFromRow = (DataRowView)contactBindingSource.Current;
            var currentToRow = (DataRowView)toContactBindingSource.Current;
            if ((currentFromRow != null) && (currentToRow != null) && (currentFromRow["ContactName"].ToString() == fromComboBox.Text) && (currentToRow["ContactName"].ToString() == toComboBox.Text))
            {
                // if fromContact is a locale and toContact is 'Self' then acquireType is 'Self Collected'.
                if (((byte)currentFromRow["ContactTypeID"] == conTypeLocale) && (currentToRow["ContactName"].ToString() == this.collector))
                {
                    acquireTypeComboBox.Text = this.acquTypeSelfCollected;
                }
            }
            acquireTypeComboBox.SelectAll();
        }

        private void acquAddButton_Click(object sender, EventArgs e)
        {
            fromComboBoxEnter(fromComboBox, null);
            var acquisitionRowAdd = myminsDataSet.Acquisition.NewAcquisitionRow();
            var currentSpecRow = (DataRowView)specBindingSource.Current;
            acquisitionRowAdd.SpecID = (int)currentSpecRow["SpecID"];
            var currentFromConRow = (DataRowView)contactBindingSource.Current;
            if (fromComboBox.Text != "")
            {
                acquisitionRowAdd.FromContactID = (int)currentFromConRow["ContactID"];
                // Process Exposure now since the selected fromContact may change later.
                if (exposureNameComboBox.Text != "")
                {
                    var currentExpoRow = (DataRowView)exposureBindingSource.Current;
                    if ((currentExpoRow == null) || (exposureNameComboBox.Text != currentExpoRow["ExposureName"].ToString()))
                    {
                        PropertyDescriptorCollection pdc = exposureBindingSource.CurrencyManager.GetItemProperties();
                        var newExpoRow = myminsDataSet.Exposure.NewExposureRow();
                        newExpoRow["ContactID"] = currentFromConRow["ContactID"];
                        newExpoRow["ExposureName"] = exposureNameComboBox.Text;
                        myminsDataSet.Exposure.AddExposureRow(newExpoRow);
                        exposureBindingSource.Position = exposureBindingSource.Find(pdc["ExposureID"], newExpoRow["ExposureID"]);
                        currentExpoRow = (DataRowView)exposureBindingSource.Current;
                    }
                    acquisitionRowAdd.ExposureID = (int)currentExpoRow["ExposureID"];
                    exposureNameComboBox.Text = "";
                }
            }
            // fromComboBox.SelectedIndex was set to -1 in Form1_load. The following sets it to 0 to allow contactBindingSource.position to be changed in the next block.
            if (fromComboBox.SelectedIndex == -1)
            {
                fromComboBox.SelectedIndex = 0;
            }
            if (toComboBox.Text != "")
            {
                var currentToConRow = (DataRowView)toContactBindingSource.Current;
                acquisitionRowAdd.ToContactID = (int)currentToConRow["ContactID"];
                contactBindingSource.Position = contactBindingSource.Find("ContactID", (int)currentToConRow["ContactID"]);
                toComboBox.Text = "";
            }
            if (acquDatePartsBox.TextMonth != "")
            {
                acquisitionRowAdd["AcquireMonth"] = short.Parse(acquDatePartsBox.TextMonth);
                acquDatePartsBox.TextMonth = "";
            }
            if (acquDatePartsBox.TextDay != "")
            {
                acquisitionRowAdd["AcquireDay"] = short.Parse(acquDatePartsBox.TextDay);
                acquDatePartsBox.TextDay = "";
            }
            if (acquDatePartsBox.TextYear != "")
            {
                acquisitionRowAdd["AcquireYear"] = short.Parse(acquDatePartsBox.TextYear);
                acquDatePartsBox.TextYear = "";
            }
            if (acquirePriceTextBox.Text != "")
            {
                acquisitionRowAdd.AcquirePrice = decimal.Parse(acquirePriceTextBox.Text, System.Globalization.NumberStyles.Currency);
                acquirePriceTextBox.Text = "";
            }
            if (acquireTypeComboBox.Text != "")
            {
                DataRow typeRow = addData(acquireTypeComboBox);
                acquisitionRowAdd.AcquireTypeID = (int)typeRow["AcquireTypeID"];
                acquireTypeComboBox.Text = "";
            }
            myminsDataSet.Acquisition.AddAcquisitionRow(acquisitionRowAdd);
            acquisitionBindingSource.MoveLast();
            acquDataGridView.Rows[acquisitionBindingSource.Position].Selected = true;
            if (!acquDataGridView.Rows[acquisitionBindingSource.Position].Displayed)
            {
                acquDataGridView.FirstDisplayedScrollingRowIndex = acquisitionBindingSource.Position;
            } 
            fromComboBox.SelectAll();
            fromComboBox.Focus();

        }

        private void acquDeleteButton_Click(object sender, EventArgs e)
        {
            if (acquisitionBindingSource.Position > -1)
            {
                acquisitionBindingSource.RemoveCurrent();
                if (acquisitionBindingSource.Position > -1)
                {
                    acquDataGridView.Rows[acquisitionBindingSource.Position].Selected = true;
                    if (!acquDataGridView.Rows[acquisitionBindingSource.Position].Displayed)
                    {
                        acquDataGridView.FirstDisplayedScrollingRowIndex = acquisitionBindingSource.Position;
                    }
                }
            }

        }

        private void acquListChanged(object sender, ListChangedEventArgs e)
        {
            var query = from acqu in acquisitionBindingSource.List.OfType<DataRowView>().ToList()
                        join fcon in myminsDataSet.Contact.Where(r => r.RowState != DataRowState.Deleted)
                        on acqu.Row["FromContactID"]
                        equals fcon.Field<int>("ContactID") into fcongrp
                        from fcon in fcongrp.DefaultIfEmpty()
                        join tcon in myminsDataSet.Contact.Where(r => r.RowState != DataRowState.Deleted)
                        on acqu.Row["ToContactID"]
                        equals tcon.Field<int>("ContactID") into tcongrp
                        from tcon in tcongrp.DefaultIfEmpty()
                        join acqutype in myminsDataSet.AcquireType.Where(r => r.RowState != DataRowState.Deleted)
                        on acqu.Row["AcquireTypeID"]
                        equals acqutype.Field<int>("AcquireTypeID") into acqutypegrp
                        from acqutype in acqutypegrp.DefaultIfEmpty()
                        join expo in myminsDataSet.Exposure.Where(r => r.RowState != DataRowState.Deleted)
                        on acqu.Row["ExposureID"]
                        equals expo.Field<int>("ExposureID") into expogrp
                        from expo in expogrp.DefaultIfEmpty()
                        select new
                        {
                            From = (fcon == null ? String.Empty : fcon.ContactName),
                            To = (tcon == null ? String.Empty : tcon.ContactName),
                            Date =  ((acqu.Row["AcquireMonth"] == DBNull.Value) ? "__" : acqu.Row["AcquireMonth"].ToString()) + "/" +
                                    ((acqu.Row["AcquireDay"] == DBNull.Value) ? "__" : acqu.Row["AcquireDay"].ToString()) + "/" +
                                    ((acqu.Row["AcquireYear"] == DBNull.Value) ? "____" : acqu.Row["AcquireYear"].ToString()),
                            Price = acqu.Row["AcquirePrice"],
                            Type = (acqutype == null ? String.Empty : acqutype.AcquireTypeName),
                            Exposure = (expo == null ? String.Empty : expo.ExposureName),
                        };
            acquDataGridView.DataSource = query.ToList();
            if (query.Any(r => r.Exposure != String.Empty))
            {
                acquDataGridView.Columns["Exposure"].Visible = true;
            }
            else
            {
                acquDataGridView.Columns["Exposure"].Visible = false;
            }
        }

        private void acquViewCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (acquDataGridView.SelectedRows.Count > 0)
            {
                acquisitionBindingSource.Position = acquDataGridView.CurrentCell.RowIndex;
            }

        }

        #endregion Acquisitions

    }
}
