using CapaEntidad;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class P_ImprimirQR : Form
    {
        private E_Extintor extintorSeleccionado;
        private Bitmap bmpQR;

        // Controles creados dinámicamente
        private PictureBox picQR;
        private Label lblCodigoU;
        private Label lblNroSerie;
        private Label lblMarca;
        private Label lblTipo;
        private Label lblCapacidad;
        private Button btnImprimir;

        public P_ImprimirQR(E_Extintor extintor)
        {
            InitializeComponent();
            this.extintorSeleccionado = extintor;
            this.Text = "Etiqueta QR - " + (extintor != null ? extintor.codigo_u : "");
            this.Size = new Size(450, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ConstruirInterfaz();
        }

        private void ConstruirInterfaz()
        {
            this.Controls.Clear();

            // 1. PictureBox para el QR
            picQR = new PictureBox
            {
                Location = new Point(20, 20),
                Size = new Size(160, 160),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(picQR);

            // 2. Labels de datos del Extintor
            lblCodigoU = new Label
            {
                Location = new Point(195, 20),
                Size = new Size(220, 25),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            this.Controls.Add(lblCodigoU);

            lblNroSerie = new Label
            {
                Location = new Point(195, 55),
                Size = new Size(220, 20),
                Font = new Font("Arial", 9.5f, FontStyle.Regular)
            };
            this.Controls.Add(lblNroSerie);

            lblMarca = new Label
            {
                Location = new Point(195, 80),
                Size = new Size(220, 20),
                Font = new Font("Arial", 9.5f, FontStyle.Regular)
            };
            this.Controls.Add(lblMarca);

            lblTipo = new Label
            {
                Location = new Point(195, 105),
                Size = new Size(220, 20),
                Font = new Font("Arial", 9.5f, FontStyle.Regular)
            };
            this.Controls.Add(lblTipo);

            lblCapacidad = new Label
            {
                Location = new Point(195, 130),
                Size = new Size(220, 20),
                Font = new Font("Arial", 9.5f, FontStyle.Regular)
            };
            this.Controls.Add(lblCapacidad);

            // 3. Botón de Imprimir
            btnImprimir = new Button
            {
                Text = "Imprimir Etiqueta",
                Location = new Point(140, 210),
                Size = new Size(150, 40),
                Font = new Font("Arial", 9.5f, FontStyle.Bold),
                BackColor = Color.FromArgb(227, 6, 19),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.Controls.Add(btnImprimir);

            // Cargar QR y Datos
            GenerarCodigoQR();
            MapearDatosEtiqueta();
        }

        private void GenerarCodigoQR()
        {
            if (extintorSeleccionado == null || string.IsNullOrEmpty(extintorSeleccionado.codigo_u)) return;

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrData = qrGenerator.CreateQrCode(extintorSeleccionado.codigo_u, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrData))
                {
                    bmpQR = qrCode.GetGraphic(10);
                    if (picQR != null)
                    {
                        picQR.Image = bmpQR;
                    }
                }
            }
        }

        private void MapearDatosEtiqueta()
        {
            if (extintorSeleccionado == null) return;

            if (lblCodigoU != null) lblCodigoU.Text = extintorSeleccionado.codigo_u;
            if (lblNroSerie != null) lblNroSerie.Text = "Nº Serie: " + extintorSeleccionado.nro_serie;
            if (lblMarca != null) lblMarca.Text = "Marca: " + extintorSeleccionado.marca;
            if (lblTipo != null) lblTipo.Text = "Tipo: " + extintorSeleccionado.tipo;
            if (lblCapacidad != null) lblCapacidad.Text = "Capacidad: " + extintorSeleccionado.capacidad;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirEtiqueta_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void ImprimirEtiqueta_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font fontTitulo = new Font("Arial", 11, FontStyle.Bold);
            Font fontDatosBold = new Font("Arial", 10, FontStyle.Bold);
            Font fontDatos = new Font("Arial", 9, FontStyle.Regular);

            Pen penBorde = new Pen(Color.Black, 2);

            int x = 20;
            int y = 20;
            int ancho = 380;
            int alto = 200;

            // Marco de la etiqueta
            g.DrawRectangle(penBorde, x, y, ancho, alto);

            // Título
            g.DrawString("ANKA FIRE - SERVICIOS", fontTitulo, Brushes.DarkRed, x + 90, y + 10);
            g.DrawLine(penBorde, x, y + 35, x + ancho, y + 35);

            // Dibujar QR
            if (bmpQR != null)
            {
                g.DrawImage(bmpQR, x + 10, y + 45, 140, 140);
            }

            // Dibujar Texto
            int textX = x + 160;
            int textY = y + 45;

            g.DrawString(extintorSeleccionado.codigo_u, fontDatosBold, Brushes.Black, textX, textY);
            g.DrawString("Nº Serie: " + extintorSeleccionado.nro_serie, fontDatos, Brushes.Black, textX, textY + 25);
            g.DrawString("Marca: " + extintorSeleccionado.marca, fontDatos, Brushes.Black, textX, textY + 45);
            g.DrawString("Tipo: " + extintorSeleccionado.tipo, fontDatos, Brushes.Black, textX, textY + 65);
            g.DrawString("Capacidad: " + extintorSeleccionado.capacidad, fontDatos, Brushes.Black, textX, textY + 85);
            g.DrawString("Sede: " + extintorSeleccionado.sede, fontDatos, Brushes.Black, textX, textY + 105);
        }
    }
}