using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROGRAMA_MEDIDAS_DESCRITIVAS
{
    public partial class Resultados : Form
    {
        Point DragCursor;
        Point DragForm;
        bool Dragging;

        public Resultados(double mediaAritmetica, double mediana, double varianciaAmostral, double desvioPadrao, double coeficienteDeVariacao, string homoOuHetero)
        {
            InitializeComponent();
            listView1.Columns[0].Width = 270;
            listView1.Columns[1].Width = 254;
            CriarTabela(mediaAritmetica, "Media aritmética");
            CriarTabela(mediana, "Mediana");
            CriarTabela(varianciaAmostral, "Variância amostral");
            CriarTabela(desvioPadrao, "Desvio padrão");
            CriarTabela(coeficienteDeVariacao, "Coeficiênte de variação");

            string[] linha = new string[2] { "Conjunto de dados:", homoOuHetero };
            listView1.Items.Add(new ListViewItem(linha));
        }

        void CriarTabela(double valor, string nomeMedida)
        {
            string[] linha = new string[2] { nomeMedida, valor.ToString() };
            listView1.Items.Add(new ListViewItem(linha));
        }

        private void Resultados_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void Resultados_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void Resultados_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
