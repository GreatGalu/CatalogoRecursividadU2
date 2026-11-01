using CatalogoRecursividad.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatalogoRecursividad.Controls
{
    public partial class FibonacciControl : UserControl
    {
        private Label lblTitle;
        private Label lblInput;
        private NumericUpDown nudNumber;
        private Button btnCalculate;
        private Label lblBaseCase;
        private TextBox txtBaseCase;
        private Label lblRecursiveCase;
        private TextBox txtRecursiveCase;
        private Label lblComparison;
        private TextBox txtComparison;
        private Label lblResult;
        private TextBox txtResult;

        public FibonacciControl()
        {
            InitializeComponent();
            SetupUI();
        }

        private void InitializeComponent()
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.DoubleBuffered = true;
        }

        private void SetupUI()
        {
            lblTitle = new Label();
            lblInput = new Label();
            nudNumber = new NumericUpDown();
            btnCalculate = new Button();
            lblBaseCase = new Label();
            txtBaseCase = new TextBox();
            lblRecursiveCase = new Label();
            txtRecursiveCase = new TextBox();
            lblComparison = new Label();
            txtComparison = new TextBox();
            lblResult = new Label();
            txtResult = new TextBox();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Text = "Fibonacci (Iterativo vs Recursivo)";

            // lblInput
            lblInput.AutoSize = true;
            lblInput.Location = new Point(20, 50);
            lblInput.Text = "Posición (n):";

            // nudNumber
            nudNumber.Location = new Point(120, 48);
            nudNumber.Maximum = 38;
            nudNumber.Minimum = 0;
            nudNumber.Value = 8;
            nudNumber.Width = 90;

            // btnCalculate
            btnCalculate.Location = new Point(225, 46);
            btnCalculate.Text = "Calcular";
            btnCalculate.Width = 100;
            btnCalculate.Height = 28;
            btnCalculate.Click += BtnCalculate_Click;

            // lblBaseCase
            lblBaseCase.AutoSize = true;
            lblBaseCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBaseCase.Location = new Point(20, 85);
            lblBaseCase.Text = "Casos Base:";

            // txtBaseCase
            txtBaseCase.Location = new Point(20, 105);
            txtBaseCase.Multiline = true;
            txtBaseCase.ReadOnly = true;
            txtBaseCase.Size = new Size(620, 40);
            txtBaseCase.Text = "Si n == 0 → retorna 0.\r\nSi n == 1 → retorna 1.";

            // lblRecursiveCase
            lblRecursiveCase.AutoSize = true;
            lblRecursiveCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRecursiveCase.Location = new Point(20, 155);
            lblRecursiveCase.Text = "Caso Recursivo:";

            // txtRecursiveCase
            txtRecursiveCase.Location = new Point(20, 175);
            txtRecursiveCase.Multiline = true;
            txtRecursiveCase.ReadOnly = true;
            txtRecursiveCase.Size = new Size(620, 40);
            txtRecursiveCase.Text = "F(n) = F(n - 1) + F(n - 2) (Recursión múltiple o en árbol con complejidad temporal O(2^n)).";

            // lblComparison
            lblComparison.AutoSize = true;
            lblComparison.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblComparison.Location = new Point(20, 225);
            lblComparison.Text = "Conversión Iterativo a Recursivo:";

            // txtComparison
            txtComparison.Location = new Point(20, 245);
            txtComparison.Multiline = true;
            txtComparison.ReadOnly = true;
            txtComparison.ScrollBars = ScrollBars.Vertical;
            txtComparison.Size = new Size(620, 70);
            txtComparison.Text = "Iterativo: Calcula con 2 variables temporales en O(n) tiempo y O(1) memoria, evitando llamadas repetidas.\r\n" +
                                 "Recursivo: Se descompone en un árbol binario de llamadas generando ramas redundantes y consumo de pila O(n).";

            // lblResult
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResult.Location = new Point(20, 325);
            lblResult.Text = "Resultados y Verificación:";

            // txtResult
            txtResult.Location = new Point(20, 345);
            txtResult.Multiline = true;
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(620, 140);
            txtResult.Font = new Font("Consolas", 10F);

            // Controls
            Controls.Add(lblTitle);
            Controls.Add(lblInput);
            Controls.Add(nudNumber);
            Controls.Add(btnCalculate);
            Controls.Add(lblBaseCase);
            Controls.Add(txtBaseCase);
            Controls.Add(lblRecursiveCase);
            Controls.Add(txtRecursiveCase);
            Controls.Add(lblComparison);
            Controls.Add(txtComparison);
            Controls.Add(lblResult);
            Controls.Add(txtResult);

            Size = new Size(660, 520);
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnCalculate_Click(object? sender, EventArgs e)
        {
            try
            {
                int n = (int)nudNumber.Value;
                long recResult = FibonacciService.CalculateFibonacci(n);
                long itResult = FibonacciService.CalculateFibonacciIterative(n);

                txtResult.Text = $"=== Prueba de Fibonacci ===\r\n" +
                                 $"Término solicitado  : n = {n}\r\n" +
                                 $"Resultado Recursivo : F({n}) = {recResult}\r\n" +
                                 $"Resultado Iterativo : F({n}) = {itResult}\r\n" +
                                 $"Profundidad de pila : {n} marcos máximos\r\n" +
                                 $"Consistencia        : {(recResult == itResult ? "Éxito (Ambos métodos concuerdan)" : "Error en cálculo")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}