using CatalogoRecursividad.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CatalogoRecursividad.Controls
{
    public partial class ArraySumControl : UserControl
    {
        private readonly ArraySumService _arraySumService;

        private Label lblTitle;
        private Label lblInput;
        private TextBox txtArray;
        private Button btnCalculate;
        private Label lblBaseCase;
        private TextBox txtBaseCase;
        private Label lblRecursiveCase;
        private TextBox txtRecursiveCase;
        private Label lblComparison;
        private TextBox txtComparison;
        private Label lblResult;
        private TextBox txtResult;

        public ArraySumControl()
        {
            InitializeComponent();
            _arraySumService = new ArraySumService();
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
            txtArray = new TextBox();
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
            lblTitle.Text = "Suma de Arreglo (Iterativo vs Recursivo)";

            // lblInput
            lblInput.AutoSize = true;
            lblInput.Location = new Point(20, 50);
            lblInput.Text = "Arreglo (números separados por comas):";

            // txtArray
            txtArray.Location = new Point(20, 72);
            txtArray.Size = new Size(470, 27);
            txtArray.Text = "1, 2, 3, 4, 5, 10, 20";

            // btnCalculate
            btnCalculate.Location = new Point(505, 71);
            btnCalculate.Text = "Calcular";
            btnCalculate.Width = 135;
            btnCalculate.Height = 28;
            btnCalculate.Click += BtnCalculate_Click;

            // lblBaseCase
            lblBaseCase.AutoSize = true;
            lblBaseCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBaseCase.Location = new Point(20, 110);
            lblBaseCase.Text = "Caso Base:";

            // txtBaseCase
            txtBaseCase.Location = new Point(20, 130);
            txtBaseCase.Multiline = true;
            txtBaseCase.ReadOnly = true;
            txtBaseCase.Size = new Size(620, 40);
            txtBaseCase.Text = "Si index < 0 → retorna 0 (Condición de parada cuando se han procesado todos los elementos).";

            // lblRecursiveCase
            lblRecursiveCase.AutoSize = true;
            lblRecursiveCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRecursiveCase.Location = new Point(20, 180);
            lblRecursiveCase.Text = "Caso Recursivo:";

            // txtRecursiveCase
            txtRecursiveCase.Location = new Point(20, 200);
            txtRecursiveCase.Multiline = true;
            txtRecursiveCase.ReadOnly = true;
            txtRecursiveCase.Size = new Size(620, 40);
            txtRecursiveCase.Text = "Suma(array, index) = array[index] + Suma(array, index - 1)";

            // lblComparison
            lblComparison.AutoSize = true;
            lblComparison.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblComparison.Location = new Point(20, 250);
            lblComparison.Text = "Conversión Iterativo a Recursivo:";

            // txtComparison
            txtComparison.Location = new Point(20, 270);
            txtComparison.Multiline = true;
            txtComparison.ReadOnly = true;
            txtComparison.ScrollBars = ScrollBars.Vertical;
            txtComparison.Size = new Size(620, 60);
            txtComparison.Text = "Iterativo: Acumulador en bucle for (sum += arr[i]) con memoria fija O(1).\r\n" +
                                 "Recursivo: Cada sumando espera el retorno del subarreglo izquierdo en el Call Stack con memoria O(n).";

            // lblResult
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResult.Location = new Point(20, 340);
            lblResult.Text = "Resultados y Verificación:";

            // txtResult
            txtResult.Location = new Point(20, 360);
            txtResult.Multiline = true;
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(620, 120);
            txtResult.Font = new Font("Consolas", 10F);

            // Controls
            Controls.Add(lblTitle);
            Controls.Add(lblInput);
            Controls.Add(txtArray);
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
                string[] parts = txtArray.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] array = parts.Select(p => int.Parse(p.Trim())).ToArray();

                int recResult = _arraySumService.SumArrayRecursive(array, array.Length - 1);
                int itResult = _arraySumService.SumArrayIterative(array);

                txtResult.Text = $"=== Prueba de Suma de Arreglo ===\r\n" +
                                 $"Elementos procesados : [{string.Join(", ", array)}]\r\n" +
                                 $"Cantidad de elementos: {array.Length}\r\n" +
                                 $"Suma Recursiva       : {recResult}\r\n" +
                                 $"Suma Iterativa       : {itResult}\r\n" +
                                 $"Profundidad de pila  : {array.Length + 1} llamadas\r\n" +
                                 $"Consistencia         : {(recResult == itResult ? "Éxito (Ambos métodos son idénticos)" : "Error en cálculo")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
