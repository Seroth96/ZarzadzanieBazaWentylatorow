using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZarzadzanieBaza.Helpers;
using ZarzadzanieBaza.Model;

namespace ZarzadzanieBaza
{
    public partial class FrmAddFan : Form
    {
        private Wentylator _wentylator;
        private bool _excelExists = false;
        public FrmAddFan()
        {
            InitializeComponent();            
        }

        public FrmAddFan(Wentylator w)
        {
            InitializeComponent();
            Text = "Edycja wentylatora";
            btnBrowse.Visible = false;
            lblBrowse.Visible = false;
            tbxExcelFilename.Visible = false;
            _wentylator = w;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xls";
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxExcelFilename.Text = openFileDialog1.FileName;
                _excelExists = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //weryfikacja poprawności danych
            //...
            double power = 0, revolution = 0, pressure = 0;
            int nature;
            try
            {
                power = double.Parse(tbxPower.Text);
                revolution = double.Parse(tbxRevolution.Text);
                nature = (cbxNature.SelectedItem as Nature).ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błędne dane: \n\t" + ex.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            if (_wentylator != null)
            {
                EditWentylatorInDB(_wentylator);
            }
            else
            {
                Wentylator w = new Wentylator()
                {
                    Name = tbxName.Text,
                    Power = power,
                    Revolution = revolution,
                    //Pressure = pressure,
                    NatureId = nature
                };
                AddWentylatorToDB(w);
            }        

            Close();
        }
        private void EditWentylatorInDB(Wentylator w)
        {            
            using (var context = new DBContext())
            {
                Wentylator newWentylator = context.Wentylatory.Include(b => b.Nature).Include(c => c.Coefficients).First(wentylator => wentylator.ID == w.ID);
                newWentylator.Name = w.Name;
                newWentylator.Power = w.Power;
                newWentylator.Revolution = w.Revolution;
                newWentylator.NatureId = w.NatureId;

                if (_excelExists)
                {
                    var oldCoefficients = context.Coefficients.Where(c => c.Wentylator.Name == newWentylator.Name);
                    foreach (var coef in oldCoefficients)
                    {
                        coef.IsArchived = true;
                    }
                    double[,] C = GetCoefficientsFromExcel(ref newWentylator);
                    for (int i = 0; i < C.GetLength(0); i++)
                    {
                        var coefficient = new Coefficient
                        {
                            Wentylator = newWentylator,
                            Level = i,
                            Value = C[i, 0]
                        };
                        context.Coefficients.Add(coefficient);
                    }
                }    
                context.SaveChanges();
            }
        }

        private void AddWentylatorToDB(Wentylator w)
        {     
            using (var context = new DBContext())
            {
                context.Wentylatory.Add(w);

                if (_excelExists)
                {
                    double[,] C = GetCoefficientsFromExcel(ref w);
                    for(int i = 0; i < C.GetLength(0); i++)
                    {
                        var coefficient = new Coefficient
                        {
                            Wentylator = w,
                            Level = i,
                            Value = C[i, 0]
                        };
                        context.Coefficients.Add(coefficient);
                    }
                }                
                context.SaveChanges();
            }
            MessageBox.Show("Pomyślnie dodano wentylator do bazy! \n", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double[,] GetCoefficientsFromExcel(ref Wentylator w)
        {
            ExcellReader xlr = new ExcellReader();
            xlr.getExcelFile(tbxExcelFilename.Text);

            double[,] Y = new double[xlr.Dp.Count(), 1];
            for (int i = 0; i < xlr.Dp.Count(); i++)
            {
                Y[i, 0] = xlr.Dp[i];
            }
            w.AirMassFlowFrom = xlr.Q.First();
            w.AirMAssFlowTo = xlr.Q.Last();
            List<double> U = Chebyshev.ConvertXToU(xlr.Q);
            double[,] T = Chebyshev.CalculatePolynomials(U, 4);
            double[,] C = Chebyshev.ComputeVectorC(T, Y);
            return C;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAddFan_Load(object sender, EventArgs e)
        {
            FillTypesComboBox();

            if (_wentylator != null)
            {
                tbxName.Text = _wentylator.Name;
                tbxPower.Text = _wentylator.Power.ToString();
                //tbxPressure.Text = _wentylator.Pressure.ToString();
                tbxRevolution.Text = _wentylator.Revolution.ToString();
                cbxNature.SelectedIndex = cbxNature.Items.IndexOf(cbxNature.Items.Cast<Nature>().First(nature => nature.Name == _wentylator.Nature.Name));
            }
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
    }
}
