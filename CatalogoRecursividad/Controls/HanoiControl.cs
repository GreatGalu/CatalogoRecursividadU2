using CatalogoRecursividad.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CatalogoRecursividad.Controls
{
    public partial class HanoiControl : UserControl
    {
        private readonly HanoiService _hanoiService;

        private Label lblTitle;
        private Label lblInput;
        private NumericUpDown nudDisks;
        private Button btnCalculate;
        private Label lblBaseCase;
        private TextBox txtBaseCase;
        private Label lblRecursiveCase;
        private TextBox txtRecursiveCase;
        private Label lblComplexity;
        private TextBox txtComplexity;
        private Label lblResult;
        private TextBox txtResult;

        public HanoiControl()
        {
            InitializeComponent();
            _hanoiService = new HanoiService();
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
            nudDisks = new NumericUpDown();
            btnCalculate = new Button();
            lblBaseCase = new Label();
            txtBaseCase = new TextBox();
            lblRecursiveCase = new Label();
            txtRecursiveCase = new TextBox();
            lblComplexity = new Label();
            txtComplexity = new TextBox();
            lblResult = new Label();
            txtResult = new TextBox();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Text = "Torres de Hanoi - Simulación y Pila Recursiva";

            // lblInput
            lblInput.AutoSize = true;
            lblInput.Location = new Point(20, 50);
            lblInput.Text = "Cantidad de discos (n):";

            // nudDisks
            nudDisks.Location = new Point(170, 48);
            nudDisks.Minimum = 1;
            nudDisks.Maximum = 15;
            nudDisks.Value = 3;
            nudDisks.Width = 70;

            // btnCalculate
            btnCalculate.Location = new Point(255, 46);
            btnCalculate.Text = "Simular y Resolver";
            btnCalculate.Width = 150;
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
            txtBaseCase.Text = "Si n == 1 → Mover el disco 1 directamente desde la torre origen a la torre destino.";

            // lblRecursiveCase
            lblRecursiveCase.AutoSize = true;
            lblRecursiveCase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRecursiveCase.Location = new Point(20, 155);
            lblRecursiveCase.Text = "Caso Recursivo:";

            // txtRecursiveCase
            txtRecursiveCase.Location = new Point(20, 175);
            txtRecursiveCase.Multiline = true;
            txtRecursiveCase.ReadOnly = true;
            txtRecursiveCase.Size = new Size(620, 55);
            txtRecursiveCase.Text = "1. Mover n - 1 discos de Origen a Auxiliar (usando Destino como apoyo).\r\n2. Mover el disco n directamente de Origen a Destino.\r\n3. Mover n - 1 discos de Auxiliar a Destino (usando Origen como apoyo).";

            // lblComplexity
            lblComplexity.AutoSize = true;
            lblComplexity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblComplexity.Location = new Point(20, 240);
            lblComplexity.Text = "Análisis de Complejidad y Call Stack:";

            // txtComplexity
            txtComplexity.Location = new Point(20, 260);
            txtComplexity.Multiline = true;
            txtComplexity.ReadOnly = true;
            txtComplexity.ScrollBars = ScrollBars.Vertical;
            txtComplexity.Size = new Size(620, 55);
            txtComplexity.Text = "Movimientos totales: 2^n - 1. Complejidad temporal O(2^n).\r\nProfundidad máxima del Call Stack: O(n). Solo requiere 'n' marcos de activación activos a la vez.";

            // lblResult
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResult.Location = new Point(20, 325);
            lblResult.Text = "Secuencia de Movimientos Generados:";

            // txtResult
            txtResult.Location = new Point(20, 345);
            txtResult.Multiline = true;
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(620, 145);
            txtResult.Font = new Font("Consolas", 9.5F);

            // Controls
            Controls.Add(lblTitle);
            Controls.Add(lblInput);
            Controls.Add(nudDisks);
            Controls.Add(btnCalculate);
            Controls.Add(lblBaseCase);
            Controls.Add(txtBaseCase);
            Controls.Add(lblRecursiveCase);
            Controls.Add(txtRecursiveCase);
            Controls.Add(lblComplexity);
            Controls.Add(txtComplexity);
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
                int n = (int)nudDisks.Value;
                List<string> moves = _hanoiService.SolveHanoi(n, 'A', 'C', 'B');

                txtResult.Clear();
                txtResult.AppendText($"=== Simulación de Hanoi para n = {n} discos ===\r\n");
                txtResult.AppendText($"Torres: Origen = A, Destino = C, Auxiliar = B\r\n");
                txtResult.AppendText($"Movimientos teóricos mínimos: 2^{n} - 1 = {Math.Pow(2, n) - 1}\r\n\r\n");

                for (int i = 0; i < moves.Count; i++)
                {
                    txtResult.AppendText($"Paso {i + 1,3}: {moves[i]}\r\n");
                }

                txtResult.AppendText($"\r\n--- Total de movimientos ejecutados: {moves.Count} ---");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}