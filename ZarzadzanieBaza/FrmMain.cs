using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
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
            //tbxPressureTo.Clear();
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
            string Name = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { Name = tbxName.Text; }));
            string PowerFrom = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { PowerFrom = tbxPowerFrom.Text; }));
            string PowerTo = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { PowerTo = tbxPowerTo.Text; }));
            string PressureFrom = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { PressureFrom = tbxPressureFrom.Text; }));
            string AirMassFlow = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { AirMassFlow = tbxAirMassFlow.Text; }));
            string RevolutionFrom = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { RevolutionFrom = tbxRevolutionFrom.Text; }));
            string RevolutionTo = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { RevolutionTo = tbxRevolutionTo.Text; }));
            string Nature = String.Empty;
            tbxName.Invoke(new MethodInvoker(delegate { Nature = cbxNature.Text; }));
            List<Wentylator> wentylatory;
            using (var context = new DBContext())
            {
                wentylatory = context.Wentylatory.Include(b => b.Nature).Include(b => b.Coefficients).Select(w => w).ToList();

                if (Name != String.Empty)
                {
                    wentylatory = wentylatory.Where(w => w.Name.Equals(Name)).ToList();
                }

                if (PowerFrom != String.Empty)
                {
                    double power = double.Parse(PowerFrom);
                    wentylatory = wentylatory.Where(w => w.Power >= power).ToList();
                }
                if (PowerTo != String.Empty)
                {
                    double power = double.Parse(PowerTo);
                    wentylatory = wentylatory.Where(w => w.Power <= power).ToList();
                }

                if (PressureFrom != String.Empty && AirMassFlow != String.Empty)
                {
                    double airMassFlow = double.Parse(AirMassFlow);
                    double pressure = double.Parse(PressureFrom);
                    wentylatory = wentylatory
                        .Where(w =>                            
                                 Chebyshev.EvaluateFunctionFromCoefficients(
                                    w.Coefficients.OrderBy(c => c.Level).Select(v => v.Value).ToArray(),
                                    Chebyshev.Normalize(w.AirMassFlowFrom, w.AirMAssFlowTo, airMassFlow))
                                / pressure > 0.8  &&
                                Chebyshev.EvaluateFunctionFromCoefficients(
                                    w.Coefficients.OrderBy(c => c.Level).Select(v => v.Value).ToArray(),
                                    Chebyshev.Normalize(w.AirMassFlowFrom, w.AirMAssFlowTo, airMassFlow))
                                / pressure < 1.2
                            ).ToList();
                    //wentylatory = wentylatory.Where(w => w.Pressure >= pressure).AsQueryable();
                }
               

                if (RevolutionFrom != String.Empty)
                {
                    double revolution = double.Parse(RevolutionFrom);
                    wentylatory = wentylatory.Where(w => w.Revolution <= revolution).ToList();
                }
                if (RevolutionTo != String.Empty)
                {
                    double revolution = double.Parse(RevolutionTo);
                    wentylatory = wentylatory.Where(w => w.Revolution <= revolution).ToList();
                }

                if (Nature != String.Empty)
                {
                    wentylatory = wentylatory.Where(w => w.Nature.Name.Equals(Nature)).ToList();
                }

                DataTable dt = wentylatory.Select(w => new WentylatorDT
                {
                    Name = w.Name,
                    Power = w.Power,
                    //Ciśnienie = w.Pressure,
                    Revolution = w.Revolution,
                    Nature = w.Nature
                }).ToList().ToDataTable();

                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;

                dataGridView1.Invoke(new MethodInvoker(delegate {
                    dataGridView1.DataSource = dt;
                    //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        int colw = dataGridView1.Columns[i].Width;
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[i].Width = colw;
                    }
                }));
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

            FillTypesComboBox();
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
                        //Pressure = double.Parse(row.Cells["Ciśnienie"].Value.ToString()),
                        Revolution = double.Parse(row.Cells["Obroty"].Value.ToString()),
                        Nature = row.Cells["Typ"].Value as Nature
                    };
                    FrmAddFan frm = new FrmAddFan(w);
                    frm.ShowDialog();
                    break;
                case "Usuń":
                    using (var context = new DBContext())
                    {
                        string name = row.Cells["Nazwa"].Value.ToString();
                        var toDelete = context.Wentylatory.Include(b => b.Coefficients).First(
                            we => we.Name.Equals(name));

                        context.Coefficients.RemoveRange(toDelete.Coefficients);
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
