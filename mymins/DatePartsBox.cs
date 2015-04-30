using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mymins
{
    public partial class DatePartsBox : UserControl, INotifyPropertyChanged
    {

        public DatePartsBox()
        {
            InitializeComponent();
        }

        [Bindable(true)]
        public string TextMonth
        {
            get { return monthTextBox.Text; }
            set { monthTextBox.Text = value; }
        }

        [Bindable(true)]
        public string TextDay
        {
            get { return dayTextBox.Text; }
            set { dayTextBox.Text = value; }
        }

        [Bindable(true)]
        public string TextYear
        {
            get { return yearTextBox.Text; }
            set { yearTextBox.Text = value; }
        }

        public bool CheckedOther
        {
            get { return otherCheckBox.Checked; }
            set { otherCheckBox.Checked = value; }
        }

        public bool VisibleOther
        {
            get { return otherCheckBox.Visible; }
            set { otherCheckBox.Visible = value; }
        }

        // Causes a binded custom property of a control to be saved to the current row after the control is validated. Needed for a BindingSource using a Forein Key.
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void dateTimePicker1ValueChanged(object sender, EventArgs e)
        {
            monthTextBox.Text = dateTimePicker1.Value.Month.ToString();
            dayTextBox.Text = dateTimePicker1.Value.Day.ToString();
            yearTextBox.Text = dateTimePicker1.Value.Year.ToString();
            monthTextBoxValidating(monthTextBox, null);
            dayTextBoxValidating(dayTextBox, null);
            yearTextBoxValidating(yearTextBox, null);
        }

        private void otherCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            otherPanel.Visible = !otherPanel.Visible;
        }

        private void monthTextBoxValidating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(monthTextBox, "");
            if (monthTextBox.Text != "")
            {
                int dday = (dayTextBox.Text == "" ? 1 : int.Parse(dayTextBox.Text));
                int dyear = (yearTextBox.Text == "" ? 2016 : int.Parse(yearTextBox.Text));
                DateTime testdate;
                if (DateTime.TryParse(monthTextBox.Text + "/" + dday.ToString() + "/" + dyear.ToString(), out testdate))
                {
                    monthTextBox.Text = testdate.Month.ToString();
                    OnPropertyChanged("TextMonth");
                }
                else
                {
                    errorProvider1.SetError(monthTextBox, "The Month must be a number between 1 and 12, and be correct for the Day and Year if entered.");
                    e.Cancel = true;
                }
            }
            else
            {
                OnPropertyChanged("TextMonth");
            }
        }

        private void dayTextBoxValidating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(dayTextBox, "");
            if (dayTextBox.Text != "")
            {
                int dmonth = (monthTextBox.Text == "" ? 1 : int.Parse(monthTextBox.Text));
                int dyear = (yearTextBox.Text == "" ? 2016 : int.Parse(yearTextBox.Text));
                DateTime testdate;
                if (DateTime.TryParse(dmonth.ToString() + "/" + dayTextBox.Text + "/" + dyear.ToString(), out testdate))
                {
                    dayTextBox.Text = testdate.Day.ToString();
                    OnPropertyChanged("TextDay");
                }
                else
                {
                    errorProvider1.SetError(dayTextBox, "The Day must be a number between 1 and 31, and exist in the Month and Year if entered.");
                    e.Cancel = true;
                }
            }
            else
            {
                OnPropertyChanged("TextDay");
            }
        }

        private void yearTextBoxValidating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(yearTextBox, "");
            if (yearTextBox.Text != "")
            {
                int dday = (dayTextBox.Text == "" ? 1 : int.Parse(dayTextBox.Text));
                int dmonth = (monthTextBox.Text == "" ? 1 : int.Parse(monthTextBox.Text));
                DateTime testdate;
                if (DateTime.TryParse(dmonth.ToString() + "/" + dday.ToString() + "/" + yearTextBox.Text, out testdate))
                {
                    yearTextBox.Text = testdate.Year.ToString();
                    OnPropertyChanged("TextYear");
                }
                else
                {
                    errorProvider1.SetError(yearTextBox, "The Year must be a two or four digit number, and be correct for the Month and Day if entered.");
                    e.Cancel = true;
                }
            }
            else
            {
                OnPropertyChanged("TextYear");
            }
        }

        // Delete or Backspace in an empty control will move focus to the previous one. Arrow keys move the cursor to the control it is next to.
        private void datesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var tbx = (TextBox)sender;
            if ((e.KeyData == Keys.Delete) || (e.KeyData == Keys.Back))
            {
                if ((tbx.Text.Length == 0) && (tbx.Name != "monthTextBox"))
                {
                    tbx.Parent.SelectNextControl(tbx, false, true, true, true);
                }
            }
            else if (e.KeyData == Keys.Right)
            {
                if ((tbx.SelectionLength == 0) && (tbx.SelectionStart == tbx.Text.Length) && (tbx.Name != "yearTextBox"))
                {
                    tbx.Parent.SelectNextControl(tbx, true, true, true, true);
                }
            }
            else if (e.KeyData == Keys.Left)
            {
                if ((tbx.SelectionLength == 0) && (tbx.SelectionStart == 0) && (tbx.Name != "monthTextBox"))
                {
                    tbx.Parent.SelectNextControl(tbx, false, true, true, true);
                }
            }
        }

        // Some common date divider keys will move focuse to the next control.
        private void datesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tbx = (TextBox)sender;
            if ((e.KeyChar == '/') || (e.KeyChar == '-') || (e.KeyChar == ' '))
            {
                e.Handled = true;
                if (tbx.Name != "yearTextbox")
                {
                    tbx.Parent.SelectNextControl(tbx, true, true, true, true);
                }
            }
        }

        /* TODO Cause focus to move to the next date control if the current one is filled. It is faster but may be too automated for most users so make it a user setting that is off by default.
        private void datesTextBox_Up(object sender, KeyEventArgs e)
        {
            var tbx = (TextBox)sender;
            if (tbx.Name == "monthTextBox")
            {
                if (tbx.Text.Length == 3)
                {
                    tbx.Parent.SelectNextControl(tbx, true, true, true, true);
                }
                else if (tbx.Text.Length == 2)
                {
                    int i;
                    if (int.TryParse(tbx.Text, out i))
                    {
                        tbx.Parent.SelectNextControl(tbx, true, true, true, true);
                    }
                }
            }
            else if ((tbx.Name == "dayTextBox") && (tbx.Text.Length == 2))
            {
                tbx.Parent.SelectNextControl(tbx, true, true, true, true);
            }
        }
        */
    }
}
