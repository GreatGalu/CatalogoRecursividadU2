using CatalogoRecursividad.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CatalogoRecursividad.Controls
{
    public partial class BenchmarkControl : UserControl
    {
        private readonly HanoiService _hanoiService;

        private Label lblTitle;
        private Label lblDescription;
        private Label lblSelect;
        private ComboBox cmbAlgorithm;
        private Button btnRunBenchmark;
        private DataGridView dgvResults;
        private Label lblAnalysisTitle;
        private TextBox txtAnalysis;

        public BenchmarkControl()
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
            lblDescription = new Label();
            lblSelect = new Label();
            cmbAlgorithm = new ComboBox();
            btnRunBenchmark = new Button();
            dgvResults = new DataGridView();
            lblAnalysisTitle = new Label();
            txtAnalysis = new TextBox();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Text = "Práctica Tarea 2.3: Análisis Empírico de Profundidad Recursiva";

            // lblDescription
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 45);
            lblDescription.Text = "Mide tiempo de ejecución, llamadas a la pila y complejidad al variar la profundidad (n).";

            // lblSelect
            lblSelect.AutoSize = true;
            lblSelect.Location = new Point(20, 75);
            lblSelect.Text = "Algoritmo:";

            // cmbAlgorithm
            cmbAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgorithm.Items.AddRange(new object[] {
                "Torres de Hanoi - Complejidad O(2^n)",
                "Fibonacci Recursivo - Complejidad O(2^n)",
                "Factorial Recursivo - Complejidad O(n)",
                "Suma de Arreglo - Complejidad O(n)"
            });
            cmbAlgorithm.SelectedIndex = 0;
            cmbAlgorithm.Location = new Point(95, 72);
            cmbAlgorithm.Size = new Size(330, 27);

            // btnRunBenchmark
            btnRunBenchmark.Location = new Point(440, 71);
            btnRunBenchmark.Size = new Size(190, 29);
            btnRunBenchmark.Text = "Ejecutar Benchmark";
            btnRunBenchmark.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRunBenchmark.Click += BtnRunBenchmark_Click;

            // dgvResults
            dgvResults.Location = new Point(20, 115);
            dgvResults.Size = new Size(620, 210);
            dgvResults.ReadOnly = true;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.RowHeadersVisible = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvResults.Columns.Add("Profundidad", "Profundidad (n)");
            dgvResults.Columns.Add("Llamadas", "Total Llamadas");
            dgvResults.Columns.Add("Tiempo", "Tiempo (ms)");
            dgvResults.Columns.Add("MemoriaPila", "Profundidad Pila (Stack)");
            dgvResults.Columns.Add("Resultado", "Valor / Movimientos");

            // lblAnalysisTitle
            lblAnalysisTitle.AutoSize = true;
            lblAnalysisTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAnalysisTitle.Location = new Point(20, 335);
            lblAnalysisTitle.Text = "Análisis de Comportamiento e Impacto en la Pila de Llamadas (Call Stack):";

            // txtAnalysis
            txtAnalysis.Location = new Point(20, 355);
            txtAnalysis.Multiline = true;
            txtAnalysis.ReadOnly = true;
            txtAnalysis.ScrollBars = ScrollBars.Vertical;
            txtAnalysis.Size = new Size(620, 140);
            txtAnalysis.Font = new Font("Segoe UI", 9.5F);

            // Controls
            Controls.Add(lblTitle);
            Controls.Add(lblDescription);
            Controls.Add(lblSelect);
            Controls.Add(cmbAlgorithm);
            Controls.Add(btnRunBenchmark);
            Controls.Add(dgvResults);
            Controls.Add(lblAnalysisTitle);
            Controls.Add(txtAnalysis);

            Size = new Size(660, 520);
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnRunBenchmark_Click(object? sender, EventArgs e)
        {
            dgvResults.Rows.Clear();
            int selected = cmbAlgorithm.SelectedIndex;
            Stopwatch sw = new Stopwatch();

            if (selected == 0) // Hanoi
            {
                int[] depths = new int[] { 3, 5, 8, 12, 16, 20 };
                foreach (int n in depths)
                {
                    sw.Restart();
                    var moves = _hanoiService.SolveHanoi(n, 'A', 'C', 'B');
                    sw.Stop();
                    long calls = _hanoiService.CallCount;
                    dgvResults.Rows.Add(n, calls.ToString("N0"), $"{sw.Elapsed.TotalMilliseconds:F3} ms", $"O(n) = {n} marcos", $"{moves.Count:N0} movs");
                }
                txtAnalysis.Text = "ANÁLISIS DE TORRES DE HANOI:\r\n" +
                                   "- Total de movimientos requeridos: 2^n - 1. Cada nivel duplica las operaciones.\r\n" +
                                   "- Profundidad máxima en el Call Stack: O(n). A pesar de ejecutarse un número exponencial de llamadas en total, sólo se mantienen 'n' marcos activos simultáneamente en la pila antes del retroceso.\r\n" +
                                   "- Con n=20 se alcanzan más de 1 millón de movimientos de manera casi instantánea, demostrando la elegancia algorítmica.";
            }
            else if (selected == 1) // Fibonacci
            {
                int[] depths = new int[] { 10, 20, 30, 35, 38 };
                foreach (int n in depths)
                {
                    sw.Restart();
                    long fib = FibonacciService.CalculateFibonacci(n);
                    sw.Stop();
                    // Aproximación de llamadas recursivas en árbol binario
                    dgvResults.Rows.Add(n, $"≈ 2^{n}", $"{sw.Elapsed.TotalMilliseconds:F3} ms", $"O(n) = {n} marcos", fib.ToString("N0"));
                }
                txtAnalysis.Text = "ANÁLISIS DE FIBONACCI RECURSIVO PURO:\r\n" +
                                   "- Complejidad Temporal: O(2^n). El árbol de llamadas recalcula los mismos subproblemas repetidas veces de forma exponencial.\r\n" +
                                   "- Profundidad máxima del Call Stack: O(n). La pila alcanza a lo sumo 'n' marcos en la rama más profunda.\r\n" +
                                   "- Alrededor de n=40 el tiempo de espera se vuelve perceptible (segundos a minutos), evidenciando la necesidad de optimización (iteración o memoización).";
            }
            else if (selected == 2) // Factorial
            {
                int[] depths = new int[] { 5, 10, 15, 18, 20 };
                foreach (int n in depths)
                {
                    sw.Restart();
                    long fact = FactorialService.CalculateFactorial(n);
                    sw.Stop();
                    dgvResults.Rows.Add(n, $"{n + 1}", $"{sw.Elapsed.TotalMilliseconds:F4} ms", $"O(n) = {n + 1} marcos", fact.ToString("N0"));
                }
                txtAnalysis.Text = "ANÁLISIS DE FACTORIAL RECURSIVO:\r\n" +
                                   "- Complejidad Temporal: O(n). Recursión lineal simple.\r\n" +
                                   "- Profundidad del Call Stack: O(n). Se apilan exactamente n+1 llamadas consecutivas antes de iniciar el retorno.\r\n" +
                                   "- Riesgo de StackOverflowException: Si n fuera del orden de miles o millones, se agotaría la memoria de pila asignada por el hilo del SO.";
            }
            else if (selected == 3) // Suma de Array
            {
                int[] sizes = new int[] { 100, 500, 1000, 2500, 5000 };
                ArraySumService service = new ArraySumService();
                foreach (int size in sizes)
                {
                    int[] arr = new int[size];
                    for (int i = 0; i < size; i++) arr[i] = 1;

                    sw.Restart();
                    int sum = service.SumArrayRecursive(arr, arr.Length - 1);
                    sw.Stop();
                    dgvResults.Rows.Add(size, $"{size + 1}", $"{sw.Elapsed.TotalMilliseconds:F4} ms", $"O(n) = {size} marcos", $"Suma = {sum}");
                }
                txtAnalysis.Text = "ANÁLISIS DE SUMA RECURSIVA DE ARREGLO:\r\n" +
                                   "- Complejidad Temporal: O(n). Se recorre un elemento por marco de activación.\r\n" +
                                   "- Profundidad del Call Stack: Exactamente O(n). Cada elemento añade una llamada activa.\r\n" +
                                   "- Comparación con iteración: La solución iterativa usa O(1) de memoria adicional, mientras que la recursiva consume n marcos de pila. Al superar tamaños mayores (~10,000 en .NET) se produciría desbordamiento de pila.";
            }
        }
    }
}
