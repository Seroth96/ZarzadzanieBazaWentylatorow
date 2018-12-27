using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZarzadzanieBaza.Model;

namespace ZarzadzanieBaza
{
    public partial class FrmMain : Form
    {
        private int _selectedRow = -1;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            bgwBrowser.RunWorkerAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            tbxName.Clear();
            tbxPowerFrom.Clear();
            tbxPowerTo.Clear();
            tbxPressureFrom.Clear();
            tbxPressureTo.Clear();
            tbxRevolutionFrom.Clear();
            tbxRevolutionTo.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddFan frm = new FrmAddFan();
            frm.ShowDialog();
        }

        private void FillTypesComboBox()
        {
            using (var context = new DBContext())
            {
                var natures = context.Natures.ToList();
                foreach (var nature in natures)
                {
                    cbxNature.Items.Add(nature);
                }
            }
        }

        private void bgwBrowser_DoWork(object sender, DoWorkEventArgs e)
        {
            IQueryable<Wentylator> wentylatory;
            using (var context = new DBContext())
            {
                wentylatory = context.Wentylatory.AsQueryable();

                if (tbxName.Text != String.Empty)
                {
                    wentylatory = wentylatory.Where(w => w.Name.Equals(tbxName.Text)).AsQueryable();
                }

                if (tbxPowerFrom.Text != String.Empty)
                {
                    double power = double.Parse(tbxPowerFrom.Text);
                    wentylatory = wentylatory.Where(w => w.Power >= power).AsQueryable();
                }
                if (tbxPowerTo.Text != String.Empty)
                {
                    double power = double.Parse(tbxPowerTo.Text);
                    wentylatory = wentylatory.Where(w => w.Power <= power).AsQueryable();
                }

                if (tbxPressureFrom.Text != String.Empty)
                {
                    double pressure = double.Parse(tbxPressureFrom.Text);
                    wentylatory = wentylatory.Where(w => w.Pressure >= pressure).AsQueryable();

                }
                if (tbxPressureTo.Text != String.Empty)
                {
                    double pressure = double.Parse(tbxPressureTo.Text);
                    wentylatory = wentylatory.Where(w => w.Pressure <= pressure).AsQueryable();
                }

                if (tbxRevolutionFrom.Text != String.Empty)
                {
                    double revolution = double.Parse(tbxRevolutionTo.Text);
                    wentylatory = wentylatory.Where(w => w.Revolution <= revolution).AsQueryable();
                }
                if (tbxRevolutionTo.Text != String.Empty)
                {
                    double revolution = double.Parse(tbxRevolutionTo.Text);
                    wentylatory = wentylatory.Where(w => w.Revolution <= revolution).AsQueryable();
                }

                if (cbxNature.SelectedIndex != -1)
                {
                    wentylatory = wentylatory.Where(w => w.Nature.Name.Equals(cbxNature.SelectedText)).AsQueryable();
                }
            }

            DataTable dt = wentylatory.Select(w => new
            {
                Nazwa = w.Name,
                Moc = w.Power,
                Ciśnienie = w.Pressure,
                Obroty = w.Revolution,
                Typ = w.Nature
            }).ToList().ToDataTable();

            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void bgwBrowser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                 _selectedRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (_selectedRow >= 0)
                {
                    menu.Items.Add("Edytuj").Name = "Edytuj";
                    menu.Items.Add("Usuń").Name = "Usuń";
                }

                menu.Show(dataGridView1, new Point(e.X, e.Y));

                //events
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked);
            }
        }

        private void numericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22)
                e.Handled = true;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            TextBox tbx = sender as TextBox;

            // only allow one decimal point
            if ((e.KeyChar == '.') && (tbx.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // allow negative numbers
            if ((e.KeyChar == '-') && tbx.SelectionStart != 0)
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '-') && (tbx.Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var row = dataGridView1.Rows[_selectedRow];
            switch (e.ClickedItem.Name.ToString())
            {
                case "Edytuj":
                    Wentylator w = new Wentylator()
                    {
                        Name = row.Cells["Nazwa"].Value.ToString(),
                        Power = double.Parse(row.Cells["Moc"].Value.ToString()),
                        Pressure = double.Parse(row.Cells["Ciśnienie"].Value.ToString()),
                        Revolution = double.Parse(row.Cells["Obroty"].Value.ToString()),
                        Nature = row.Cells["Typ"].Value as Nature
                    };
                    FrmAddFan frm = new FrmAddFan(w);
                    frm.ShowDialog();
                    break;
                case "Usuń":
                    using (var context = new DBContext())
                    {
                        var toDelete = context.Wentylatory.First(
                            we => we.Name.Equals(row.Cells["Nazwa"].Value.ToString()));
                        context.Wentylatory.Remove(toDelete);
                        context.SaveChanges();
                    }
                    dataGridView1.Rows.RemoveAt(_selectedRow);
                    _selectedRow = -1;
                    break;
                default:
                    break;
            }
        }
    }
}
