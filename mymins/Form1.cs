using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mymins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myminsDataSet.Acquisition' table. You can move, or remove it, as needed.
            this.acquisitionTableAdapter.Fill(this.myminsDataSet.Acquisition);
            // TODO: This line of code loads data into the 'myminsDataSet.SpecImgs' table. You can move, or remove it, as needed.
            this.specImgsTableAdapter.Fill(this.myminsDataSet.SpecImgs);
            // TODO: This line of code loads data into the 'myminsDataSet.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter.Fill(this.myminsDataSet.Contact);
            // TODO: This line of code loads data into the 'myminsDataSet.Spec' table. You can move, or remove it, as needed.
            this.specTableAdapter.Fill(this.myminsDataSet.Spec);
            // TODO: This line of code loads data into the 'myminsDataSet.Mins' table. You can move, or remove it, as needed.
            this.minsTableAdapter.Fill(this.myminsDataSet.Mins);
            // TODO: This line of code loads data into the 'myminsDataSet.SpecMins' table. You can move, or remove it, as needed.
            this.specMinsTableAdapter.Fill(this.myminsDataSet.SpecMins);
            // TODO: This line of code loads data into the 'myminsDataSet.SpecMins' table. You can move, or remove it, as needed.
            this.minsTypesTableAdapter.Fill(this.myminsDataSet.MinsTypes);
            // TODO: This line of code loads data into the 'myminsDataSet.SpecMins' table. You can move, or remove it, as needed.
            this.contactTypeTableAdapter.Fill(this.myminsDataSet.ContactType);
            if (myminsDataSet.Spec.Count == 0)
            {
                myminsDataSet.Spec.Rows.Add(null, 1);
            }
            acquViewDataGridView.Columns["Date"].DefaultCellStyle.Format = "d";
            /* TODO: Add sorting Specimens. Could also let the user move record positions but this would be manually maintained by the user.
             * Sorting UserSpecID sorts by the first character so 10 is after 1 and before 2.
             * specBindingSource.Sort = "UserSpecID asc";
             * 
             * Another option is to sort by a created column in the DataSet with expression "Convert(UserSpecID, 'System.Int32')".
             * This works well as long as there are only numeric characters in the string.
             * 
             * Another option is to use a column that is created or already created that already contains the int representations of the strings.
             */
        }

        private void specBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.specBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myminsDataSet);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (specBindingSource.Count == 0)
            {
                // Avoids extra code for checking for an empty BindingSource and prevents data loss when a user enters data before clicking the add new button.
                myminsDataSet.Spec.Rows.Add(null, 1);
            }
        }

        private void specBindingNavItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Requires the SpecID to be valid before doing anything else.
            userSpecIDTextBox.Focus();
        }

        private void specPositionChanged(object sender, EventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            if ((currentRow != null) && currentRow.IsNew)
            {
                // Suggests an auto-incremented SpecID for a new specimen.
                // Note: This will fail if even one row is not int convertible.
                // TODO: Optional
                DataRow[] maxRow = myminsDataSet.Spec.Select("UserSpecID = MAX(UserSpecID)");
                int num;
                if (int.TryParse(maxRow[0]["UserSpecID"].ToString(), out num))
                {
                    userSpecIDTextBox.Text = (num + 1).ToString();
                    userSpecIDTextBox.SelectAll();
                }
                // TODO: Else add increment for text. 
            }
        }

        private void specIDValidating(object sender, CancelEventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            var msboxresult = DialogResult.None;

            // TODO: Optional: Warn about using an existing ID.
            if ((currentRow.Row.RowState == DataRowState.Detached) || (userSpecIDTextBox.Text != (currentRow["UserSpecID"].ToString())))
            {
                var query = myminsDataSet.Spec
                            .Where(row => row.RowState != DataRowState.Deleted && row.Field<string>("UserSpecID") == userSpecIDTextBox.Text);
                if (query.Any())
                {
                    msboxresult = MessageBox.Show("WARNNING: A specimen with the ID " + userSpecIDTextBox.Text + " already exists. Press OK to use it anyway, or Cancel to change it.",
                                                  "Specimen ID already used.",
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
                // Add row immediately to avoid dealing with detached records any further.
                specBindingSource.EndEdit();
                /* If using a bindingsource.sort and the current item will change position, the bindingsource will go to that position, and then to the position after that.
                if (!currentRow.Equals((DataRowView)specBindingSource.Current))
                {
                    specBindingSource.Position--;
                }*/
            }
        }


        private void minsComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                specMinsAddButton.PerformClick();
            }
        }

        private void specMinsAddButton_Click(object sender, EventArgs e)
        {
            /* Add a mineral if new. */
            if (minsComboBox.Text == "")
            {
                minsComboBox.Text = "<unidentified>";
            }
            var currentMinsRow = (DataRowView)minsBindingSource.Current;
            if ((currentMinsRow == null) || (minsComboBox.Text != currentMinsRow["MinsName"].ToString()))
            {
                // If nothing in ComboBox was selected, or the selected item doesn't match the ComboBox text, then it's a new mineral.
                var newmin = minsComboBox.Text;
                var minsRowAdd = myminsDataSet.Mins.NewMinsRow();
                minsRowAdd.MinsName = newmin;
                minsRowAdd.MinsTypeID = 1; // TODO: Default value for now.
                myminsDataSet.Mins.AddMinsRow(minsRowAdd);
                minsTableAdapter.Update(myminsDataSet.Mins);
                // Updating ComboBox.text will auto-select a matching value and update minsBindingSource.position.
                minsComboBox.Text = newmin;
                currentMinsRow = (DataRowView)minsBindingSource.Current;
            }

            /* Add Mineral to Specimen */
            var currentSpecRow = (DataRowView)specBindingSource.Current;
            var specMinsRowAdd = myminsDataSet.SpecMins.NewSpecMinsRow();
            specMinsRowAdd.MinsID = (int)currentMinsRow["MinsID"];
            specMinsRowAdd.SpecID = (int)currentSpecRow["SpecID"];
            // The following if/else is auto-increment for priority
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
            // TODO: Optional: Clear ComboBox after adding a new mineral.
            //minsComboBox.Text = "";
            minsComboBox.SelectAll();
            minsComboBox.Focus();
        }

        private void specMinsDeleteButton_Click(object sender, EventArgs e)
        {
            var pos = specMinsBindingSource.Position;
            if (pos > -1)
            {
                specMinsBindingSource.RemoveCurrent();
                if (specMinsBindingSource.Position > -1)
                {
                    // Moves all minerals bellow deleted mineral up one priority.
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

        private void specMinsListChanged(object sender, ListChangedEventArgs e)
        {
            // Fill ListView with info(mineral names/types) from Mins table joined with specMinsBindingSoure which has a list of minerals per specimen sorted by priority.
            // TODO: Assign images/icons to MinsTypeID.
            specMinsListView.Clear();
            var query = from specmin in specMinsBindingSource.List.OfType<DataRowView>().ToList()
                        join min in myminsDataSet.Mins
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

        // DateTimePicker allows nulls by having it's Format property set to custom with customFormat value of " ".
        // This also clears the display in the control to indicate no date is selected.
        private void acquireDateDateTimePickerKeyDown(object sender, KeyEventArgs e)
        {
            acquireDateDateTimePicker.Format = DateTimePickerFormat.Short;
            if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                acquireDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            }
        }

        private void acquireDateDateTimePickerCloseUp(object sender, EventArgs e)
        {
            acquireDateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void acquAddButton_Click(object sender, EventArgs e)
        {
            /* Add a Locale if new and get ContactID. */
            if (fromComboBox.Text == "")
            {
                fromComboBox.Text = "<unknown>";
            }
            var currentConRow = (DataRowView)contactBindingSource.Current;
            if ((currentConRow == null) || (fromComboBox.Text != currentConRow["ContactName"].ToString()))
            {
                var newcon = fromComboBox.Text;
                var conRowAdd = myminsDataSet.Contact.NewContactRow();
                conRowAdd.ContactName = newcon;
                conRowAdd.ContactTypeID = 1; // TODO: Default value for now.
                myminsDataSet.Contact.AddContactRow(conRowAdd);
                contactTableAdapter.Update(myminsDataSet.Contact);
                fromComboBox.Text = newcon;
                currentConRow = (DataRowView)contactBindingSource.Current;
            }

            /* Add Contact to Aquisition for this Specimen */
            var currentSpecRow = (DataRowView)specBindingSource.Current;
            var acquisitionRowAdd = myminsDataSet.Acquisition.NewAcquisitionRow();
            acquisitionRowAdd.SpecID = (int)currentSpecRow["SpecID"];
            acquisitionRowAdd.FromContactID = (int)currentConRow["ContactID"];
            if (acquireDateDateTimePicker.Format != DateTimePickerFormat.Custom)
            {
                acquisitionRowAdd.AcquireDate = acquireDateDateTimePicker.Value.Date;
            }
            myminsDataSet.Acquisition.AddAcquisitionRow(acquisitionRowAdd);
            acquisitionBindingSource.MoveLast();
            acquViewDataGridView.Rows[acquisitionBindingSource.Position].Selected = true;
            // TODO: Consider adding a user preference to set if the fields should be cleared after adding.
            //fromComboBox.Text = "";
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
                    acquViewDataGridView.Rows[acquisitionBindingSource.Position].Selected = true;
                }
            }

        }

        private void acquListChanged(object sender, ListChangedEventArgs e)
        {
            var query = from acqu in acquisitionBindingSource.List.OfType<DataRowView>().ToList()
                        join fcon in myminsDataSet.Contact
                        on acqu.Row["FromContactID"]
                        equals fcon.Field<int>("ContactID") into fcongrp
                        from fcon in fcongrp.DefaultIfEmpty()
                        select new
                        {
                            From = (fcon == null ? String.Empty : fcon.ContactName),
                            Date = acqu.Row["AcquireDate"],
                        };
            acquViewDataGridView.DataSource = query.ToList();
            acquViewDataGridView.ClearSelection();
        }

        private void acquViewCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!(acquViewDataGridView.SelectedRows.Count < 1))
            {
                acquisitionBindingSource.Position = acquViewDataGridView.SelectedRows[0].Index;
            }

        }

    }
}


// TODO LATER: Mineral editor. Provide warning for deleting a mineral since it will delete the related specimen entries.