using CatalogoRecursividad.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatalogoRecursividad.Controls
{
    public partial class FactorialControl : UserControl
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

        public FactorialControl()
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
            lblTitle.Text = "Factorial (Iterativo vs Recursivo)";

            // lblInput
            lblInput.AutoSize = true;
            lblInput.Location = new Point(20, 50);
            lblInput.Text = "Número (n):";

            // nudNumber
            nudNumber.Location = new Point(110, 48);
            nudNumber.Maximum = 20; // 20! cabe en long (64 bits)
            nudNumber.Minimum = 0;
            nudNumber.Value = 5;
            nudNumber.Width = 90;

            // btnCalculate
            btnCalculate.Location = new Point(215, 46);
            btnCalculate.Text = "Calcular";
            btnCalculate.Width = 100;
            btnCalculate.Height = 28;
            btnCalculate.Click += BtnCalculate_Click;

            // lblBaseCase
            lblBaseCase.AutoSize = true;
            lblBaseCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBaseCase.Location = new Point(20, 85);
            lblBaseCase.Text = "Caso Base:";

            // txtBaseCase
            txtBaseCase.Location = new Point(20, 105);
            txtBaseCase.Multiline = true;
            txtBaseCase.ReadOnly = true;
            txtBaseCase.Size = new Size(620, 40);
            txtBaseCase.Text = "Si n == 0 o n == 1 → retorna 1 (Termina las llamadas recursivas sin apilar más marcos).";

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
            txtRecursiveCase.Text = "Factorial(n) = n * Factorial(n - 1) (Apila n llamadas en el Call Stack con O(n) memoria).";

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
            txtComparison.Size = new Size(620, 95);
            txtComparison.Text = "Iterativo: Utiliza un ciclo for (i = 2..n) acumulando el producto en una variable local con memoria O(1).\r\n" +
                                 "Recursivo: Cada multiplicación se pospone en la pila de llamadas hasta llegar a n=1, desenvolviendo la pila en el retorno.";

            // lblResult
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResult.Location = new Point(20, 350);
            lblResult.Text = "Resultados y Verificación:";

            // txtResult
            txtResult.Location = new Point(20, 370);
            txtResult.Multiline = true;
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(620, 120);
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
                long recResult = FactorialService.CalculateFactorial(n);
                long itResult = FactorialService.CalculateFactorialIterative(n);

                txtResult.Text = $"=== Prueba de Ejecución ===\r\n" +
                                 $"Valor ingresado: {n}\r\n" +
                                 $"Resultado Recursivo : {n}! = {recResult}\r\n" +
                                 $"Resultado Iterativo : {n}! = {itResult}\r\n" +
                                 $"Profundidad de pila : {n + 1} llamadas apiladas\r\n" +
                                 $"Consistencia        : {(recResult == itResult ? "Éxito (Ambos métodos coinciden)" : "Discrepancia detectada")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
