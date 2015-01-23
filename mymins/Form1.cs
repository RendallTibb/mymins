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

        private void specBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.specBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myminsDataSet);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myminsDataSet.Spec' table. You can move, or remove it, as needed.
            this.specTableAdapter.Fill(this.myminsDataSet.Spec);
            // TODO: This line of code loads data into the 'myminsDataSet.Mins' table. You can move, or remove it, as needed.
            this.minsTableAdapter.Fill(this.myminsDataSet.Mins);
            // TODO: This line of code loads data into the 'myminsDataSet.SpecMins' table. You can move, or remove it, as needed.
            this.specMinsTableAdapter.Fill(this.myminsDataSet.SpecMins);
            // TODO: This line of code loads data into the 'myminsDataSet.SpecMins' table. You can move, or remove it, as needed.
            this.minsTypesTableAdapter.Fill(this.myminsDataSet.MinsTypes);
            if (myminsDataSet.Spec.Count == 0)
            {
                myminsDataSet.Spec.Rows.Add(1);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (myminsDataSet.Spec.Count == 0)
            {
                // Avoids extra code checking for an empty BindingSource, and extra code for handling when a user enters data before clicking the add button.
                myminsDataSet.Spec.Rows.Add(1);
            }
        }

        private void specBindingNavItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Causes validation of SpecID before it can be saved to the DataSet.
            specIDTextBox.Focus();
        }

        private void specPositionChanged(object sender, EventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            if ((currentRow != null) && currentRow.IsNew)
            {
                // Suggests an auto-incremented SpecID for a new specimen.
                specIDTextBox.Text = (myminsDataSet.Spec[specBindingSource.Position - 1].SpecID + 1).ToString();
                specIDTextBox.SelectAll();
            }
        }

        private void specIDValidating(object sender, CancelEventArgs e)
        {
            var currentRow = (DataRowView)specBindingSource.Current;
            var msboxresult = DialogResult.None;
            int specidnum;
            if (!int.TryParse(specIDTextBox.Text, out specidnum))
            {
                msboxresult = MessageBox.Show("Please enter a numeric specimen ID.",
                                               "Specimen ID error",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Question);
            }
            else if (!currentRow.IsNew && (specidnum == myminsDataSet.Spec[specBindingSource.Position].SpecID))
            {
                // SpecID is technically unchanged, but convert it in case someone put 002 for 2.
                specIDTextBox.Text = specidnum.ToString();
                return;
            }
            else if (myminsDataSet.Spec.FindBySpecID(specidnum) != null)
            {
                msboxresult = MessageBox.Show("A specimen with the ID " + specidnum + " already exists. Please try a different ID.",
                                               "Specimen ID error",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Question);
            }
            if (msboxresult == DialogResult.OK)
            {
                // Invalid SpecID. Prevents access to other controls until this is valid or cancel pressed.
                e.Cancel = true;
            }
            else if (msboxresult == DialogResult.Cancel)
            {
                // If new, delete row, otherwise reverse changes.
                if (currentRow.IsNew)
                {
                    currentRow.Delete();
                }
                else
                {
                    specIDTextBox.Text = myminsDataSet.Spec[specBindingSource.Position].SpecID.ToString();
                }
            }
            else
            {
                specIDTextBox.Text = specidnum.ToString();
                // Add row immediately to avoid dealing with new records any further.
                if (currentRow.IsNew)
                {
                    specBindingSource.EndEdit();
                }
                /* Valid changed SpecID rows are here. Currently they are updated.
                 * TODO: Implement Message box to handle all possible user intentions listed below.
                 * Change this specimen's ID to the new one. Update related tables.
                 * Leave this specimen, and create a new specimen using the new ID. Option to use original specimen as a template.
                 * Undo the new ID for this specimen, using the original ID.
                 * Delete the original specimen, and use it's ID for a new specimen. Add an extra warning.
                 */
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
            /* Add a mineral if new and get MinsID. */
            // TODO: Configure a non-empty database(see bindingNavigatorDeleteItem_Click), removing/moving this if statement and minspos == -1 check by using "" as a default selecting "Unidentified".
            if (minsComboBox.Text == "")
            {
                minsComboBox.Text = "Unidentified";
            }
            var minspos = minsBindingSource.Position;
            if ((minspos == -1) || (minsComboBox.Text != myminsDataSet.Mins[minspos].MinsName))
            {
                // If nothing in ComboBox was selected, or the selected item doesn't match the ComboBox text, then it's a new mineral.
                var newmin = minsComboBox.Text;
                var minsRowAdd = myminsDataSet.Mins.NewMinsRow();
                minsRowAdd.MinsName = newmin;
                minsRowAdd.MinsTypeID = 1; // TODO: Default value for now.
                myminsDataSet.Mins.AddMinsRow(minsRowAdd);
                minsTableAdapter.Update(myminsDataSet.Mins);
                // Updating ComboBox.text will auto-select a matchign value and update minsbindingSource.position.
                minsComboBox.Text = newmin;
            }
            minspos = minsBindingSource.Position;

            /* Add Mineral to Specimen */
            var specMinsRowAdd = myminsDataSet.SpecMins.NewSpecMinsRow();
            specMinsRowAdd.MinsID = myminsDataSet.Mins[minspos].MinsID;
            specMinsRowAdd.SpecID = myminsDataSet.Spec[specBindingSource.Position].SpecID;
            // The following if/else is auto-increment for priority
            if (specMinsBindingSource.Position == -1)
            {
                specMinsRowAdd.MinsPriority = 1;
            }
            else
            {
                specMinsBindingSource.MoveLast();
                var currentRow = (DataRowView)specMinsBindingSource.Current;
                specMinsRowAdd.MinsPriority = (short)((short)currentRow["MinsPriority"] + 1);
            }
            myminsDataSet.SpecMins.AddSpecMinsRow(specMinsRowAdd);
            specMinsBindingSource.MoveLast();
            specMinsListView.Items[specMinsBindingSource.Position].Selected = true;
            // TODO: Consider adding a user preference to set if the ComboBox should be cleared after adding a new mineral.
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
                    // Moves all minerals bellow deleted miner up one priority.
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
            // TODO: This is not an ideal event to use since it is called often.
            // TODO: Assign images to MinsTypeID. 
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
    }
}
