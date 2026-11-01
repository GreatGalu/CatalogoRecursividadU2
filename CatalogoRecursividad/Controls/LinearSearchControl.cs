using CatalogoRecursividad.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CatalogoRecursividad.Controls
{
    public partial class LinearSearchControl : UserControl
    {
        private readonly LinearSearchService _searchService;

        private Label lblTitle;
        private Label lblArrayInput;
        private TextBox txtArray;
        private Label lblTargetInput;
        private TextBox txtTarget;
        private Button btnCalculate;
        private Label lblBaseCase;
        private TextBox txtBaseCase;
        private Label lblRecursiveCase;
        private TextBox txtRecursiveCase;
        private Label lblComparison;
        private TextBox txtComparison;
        private Label lblResult;
        private TextBox txtResult;

        public LinearSearchControl()
        {
            InitializeComponent();
            _searchService = new LinearSearchService();
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
            lblArrayInput = new Label();
            txtArray = new TextBox();
            lblTargetInput = new Label();
            txtTarget = new TextBox();
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
            lblTitle.Text = "Búsqueda Lineal (Iterativo vs Recursivo)";

            // lblArrayInput
            lblArrayInput.AutoSize = true;
            lblArrayInput.Location = new Point(20, 50);
            lblArrayInput.Text = "Arreglo (separado por comas):";

            // txtArray
            txtArray.Location = new Point(20, 72);
            txtArray.Size = new Size(330, 27);
            txtArray.Text = "14, 25, 3, 89, 42, 7, 50";

            // lblTargetInput
            lblTargetInput.AutoSize = true;
            lblTargetInput.Location = new Point(365, 50);
            lblTargetInput.Text = "Elemento a buscar:";

            // txtTarget
            txtTarget.Location = new Point(365, 72);
            txtTarget.Size = new Size(130, 27);
            txtTarget.Text = "42";

            // btnCalculate
            btnCalculate.Location = new Point(510, 71);
            btnCalculate.Text = "Buscar";
            btnCalculate.Width = 130;
            btnCalculate.Height = 28;
            btnCalculate.Click += BtnCalculate_Click;

            // lblBaseCase
            lblBaseCase.AutoSize = true;
            lblBaseCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBaseCase.Location = new Point(20, 110);
            lblBaseCase.Text = "Casos Base:";

            // txtBaseCase
            txtBaseCase.Location = new Point(20, 130);
            txtBaseCase.Multiline = true;
            txtBaseCase.ReadOnly = true;
            txtBaseCase.Size = new Size(620, 40);
            txtBaseCase.Text = "1. Si index >= array.Length → retorna -1 (Elemento no encontrado en el arreglo).\r\n2. Si array[index] == target → retorna index (Elemento hallado).";

            // lblRecursiveCase
            lblRecursiveCase.AutoSize = true;
            lblRecursiveCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRecursiveCase.Location = new Point(20, 180);
            lblRecursiveCase.Text = "Caso Recursivo:";

            // txtRecursiveCase
            txtRecursiveCase.Location = new Point(20, 200);
            txtRecursiveCase.Multiline = true;
            txtRecursiveCase.ReadOnly = true;
            txtRecursiveCase.Size = new Size(620, 35);
            txtRecursiveCase.Text = "Search(array, target, index + 1) → avanza el puntero de inspección al siguiente elemento.";

            // lblComparison
            lblComparison.AutoSize = true;
            lblComparison.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblComparison.Location = new Point(20, 245);
            lblComparison.Text = "Conversión Iterativo a Recursivo:";

            // txtComparison
            txtComparison.Location = new Point(20, 265);
            txtComparison.Multiline = true;
            txtComparison.ReadOnly = true;
            txtComparison.ScrollBars = ScrollBars.Vertical;
            txtComparison.Size = new Size(620, 65);
            txtComparison.Text = "Iterativo: Recorre el índice con un for hasta encontrar coincidencia, retornando el índice inmediatamente con memoria O(1).\r\nRecursivo: Pasa el índice incrementado como argumento recursivo, simulando el contador del bucle con consumo de pila O(n).";

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
            Controls.Add(lblArrayInput);
            Controls.Add(txtArray);
            Controls.Add(lblTargetInput);
            Controls.Add(txtTarget);
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

                if (!int.TryParse(txtTarget.Text.Trim(), out int target))
                {
                    MessageBox.Show("Por favor ingresa un número entero válido en el campo a buscar.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int recIndex = _searchService.LinearSearchRecursive(array, target);
                int itIndex = _searchService.LinearSearchIterative(array, target);

                txtResult.Text = $"=== Prueba de Búsqueda Lineal ===\r\n" +
                                 $"Arreglo analizado    : [{string.Join(", ", array)}]\r\n" +
                                 $"Objetivo buscado     : {target}\r\n" +
                                 $"Resultado Recursivo  : {(recIndex >= 0 ? $"Encontrado en índice {recIndex}" : "No encontrado (-1)")}\r\n" +
                                 $"Resultado Iterativo  : {(itIndex >= 0 ? $"Encontrado en índice {itIndex}" : "No encontrado (-1)")}\r\n" +
                                 $"Profundidad de llamada: {(recIndex >= 0 ? recIndex + 1 : array.Length + 1)} marcos de pila\r\n" +
                                 $"Consistencia         : {(recIndex == itIndex ? "Coincidencia exacta entre ambos enfoques" : "Error en resultados")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
