using CatalogoRecursividad.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace CatalogoRecursividad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeTabs();
        }

        private void InitializeTabs()
        {
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9.5F);

            // 1. Factorial
            TabPage tabFactorial = new TabPage("1. Factorial");
            FactorialControl factorialControl = new FactorialControl { Dock = DockStyle.Fill };
            tabFactorial.Controls.Add(factorialControl);

            // 2. Fibonacci
            TabPage tabFibonacci = new TabPage("2. Fibonacci");
            FibonacciControl fibonacciControl = new FibonacciControl { Dock = DockStyle.Fill };
            tabFibonacci.Controls.Add(fibonacciControl);

            // 3. Suma de Arreglo
            TabPage tabArraySum = new TabPage("3. Suma de Arreglo");
            ArraySumControl arraySumControl = new ArraySumControl { Dock = DockStyle.Fill };
            tabArraySum.Controls.Add(arraySumControl);

            // 4. Búsqueda Lineal
            TabPage tabLinearSearch = new TabPage("4. Búsqueda Lineal");
            LinearSearchControl linearSearchControl = new LinearSearchControl { Dock = DockStyle.Fill };
            tabLinearSearch.Controls.Add(linearSearchControl);

            // 5. Torres de Hanoi
            TabPage tabHanoi = new TabPage("5. Torres de Hanoi");
            HanoiControl hanoiControl = new HanoiControl { Dock = DockStyle.Fill };
            tabHanoi.Controls.Add(hanoiControl);

            // 6. Práctica 2.3 - Benchmark de Profundidad
            TabPage tabBenchmark = new TabPage("6. Análisis de Profundidad (Tarea 2.3)");
            BenchmarkControl benchmarkControl = new BenchmarkControl { Dock = DockStyle.Fill };
            tabBenchmark.Controls.Add(benchmarkControl);

            // Agregar pestañas al TabControl
            tabControl.TabPages.Add(tabFactorial);
            tabControl.TabPages.Add(tabFibonacci);
            tabControl.TabPages.Add(tabArraySum);
            tabControl.TabPages.Add(tabLinearSearch);
            tabControl.TabPages.Add(tabHanoi);
            tabControl.TabPages.Add(tabBenchmark);

            this.Controls.Add(tabControl);
            this.ClientSize = new Size(720, 600);
            this.MinimumSize = new Size(680, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Recursividad - Unidad 2 (Estructura de Datos)";
            this.Icon = SystemIcons.Application;
        }
    }
}