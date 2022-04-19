using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace PROGRAMA_MEDIDAS_DESCRITIVAS
{
    public partial class Form1 : Form
    {
        List<double> listaNumeros = new List<double>();
        double mediaAritmetica, mediana, varianciaAmostral, desvioPadrao, coeficienteDeVariacao;
        string homoOuHetero;

        Point DragCursor;
        Point DragForm;
        bool Dragging;
        public Form1()
        {
            InitializeComponent();
            LimparEfocar();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        void Adicionar()
        {
            listaNumeros.Add((double)numericUpDown1.Value);
            richTextBox1.AppendText($"{listaNumeros[listaNumeros.Count - 1]} - ");
            LimparEfocar();
        }
        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Adicionar();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Adicionar();
        }
        private void LimparEfocar()
        {
            numericUpDown1.Value = 0;
            numericUpDown1.Focus();
            numericUpDown1.Select(0, 4);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            mediaAritmetica = Calcula.MediaAritmetica(listaNumeros);
            mediana = Calcula.Mediana(listaNumeros);
            varianciaAmostral = Calcula.VarianciaAmostral(listaNumeros, mediaAritmetica);
            desvioPadrao = Calcula.DesvioPadrao(varianciaAmostral);
            coeficienteDeVariacao = Calcula.CoeficienteDeVariacao(mediaAritmetica, desvioPadrao);
            homoOuHetero = Calcula.HomogenioOuHeterogenio(coeficienteDeVariacao);

            Resultados resultados = new Resultados(mediaAritmetica, mediana, varianciaAmostral, desvioPadrao, coeficienteDeVariacao, homoOuHetero);
            resultados.ShowDialog();


            //MessageBox.Show($"Media aritmética: {mediaAritmetica}\nMediana: {mediana}\nVariância Amostral: {varianciaAmostral}\nDesvio Padrão: {desvioPadrao}\nCoeficiente de variação: {coeficienteDeVariacao}%\nConjunto de dados é: {homoOuHetero}");
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            listaNumeros.Clear();
            richTextBox1.Clear();
            LimparEfocar();
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
