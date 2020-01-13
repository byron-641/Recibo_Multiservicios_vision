using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using System.IO;

namespace vision
{
    public partial class main1 : Form
    {
        //rounder corner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            //rounder corner coordination //by641
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public main1()
        {
            InitializeComponent();
            //rounder
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialDivider5_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            date.Text = thisDay.ToString("d");
            decimal inicial, anticipo, total;
            inicial = Convert.ToDecimal(cost.Text);
            anticipo = Convert.ToDecimal(payment.Text);
            total = inicial - anticipo;
            saldo.Text = Convert.ToString(total);
            if (pendiente.Checked)
            {
                saldo.Enabled = true;
                saldo.Text = "Pendiente";
                cost.Text = "---";
                cost.Enabled = false;
                payment.Text="---";
                payment.Enabled = false;
            }
            else
            {
                saldo.Enabled = false;
                
            }
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            DateTime thisDay = DateTime.Today;
            date.Text = thisDay.ToString("d");
            string fecha, fecha2, descripcion, name;
            int telefono;
            decimal costo_inicial, anticipo, total;
            fecha = date.Text = thisDay.ToString("d");
            fecha2 = date.Text;
            name = tname.Text;
            descripcion = Convert.ToString(description.Text);
            telefono = Convert.ToInt32(number.Text);
            costo_inicial = Convert.ToDecimal(cost.Text);
            anticipo = Convert.ToDecimal(payment.Text);
            total = costo_inicial - anticipo;
            saldo.Text = Convert.ToString(total);


            int pdf = 0;
            pdf = ++pdf;
            string pdfTemplate = @"\Multiservicios\Recibos\test.pdf";
            string newFile = @"\Multiservicios\Recibos\creados\recibo " + descripcion + ".pdf";

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));

            AcroFields pdfFormFields = pdfStamper.AcroFields;

            // Asigna los campos

            pdfFormFields.SetField("untitled1", fecha);
            pdfFormFields.SetField("untitled11", fecha);
            pdfFormFields.SetField("untitled7", descripcion);
            pdfFormFields.SetField("untitled10", descripcion);
            pdfFormFields.SetField("untitled12", Convert.ToString(telefono));
            pdfFormFields.SetField("untitled6", Convert.ToString(telefono));
            pdfFormFields.SetField("untitled2", Convert.ToString(costo_inicial));
            pdfFormFields.SetField("untitled13", Convert.ToString(costo_inicial));
            pdfFormFields.SetField("untitled3", Convert.ToString(anticipo));
            pdfFormFields.SetField("untitled14", Convert.ToString(anticipo));
            pdfFormFields.SetField("untitled4", Convert.ToString(total));
            pdfFormFields.SetField("untitled15", Convert.ToString(total));


            string sTmp = "Datos asignados";
            MessageBox.Show(sTmp, "Terminado");

            // Cambia la propiedad para que no se pueda editar el PDF
            pdfStamper.FormFlattening = false;

            // Cierra el PDF
            pdfStamper.Close();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void main1_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
