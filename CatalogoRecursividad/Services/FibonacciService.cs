using System;

namespace CatalogoRecursividad.Services
{
    public static class FibonacciService
    {
        // Solución Iterativa
        public static long CalculateFibonacciIterative(int n)
        {
            if (n < 0) throw new ArgumentException("El número no puede ser negativo.");
            if (n == 0) return 0;
            if (n == 1) return 1;

            long prev = 0;
            long current = 1;
            for (int i = 2; i <= n; i++)
            {
                long temp = prev + current;
                prev = current;
                current = temp;
            }
            return current;
        }

        // Solución Recursiva
        public static long CalculateFibonacci(int n)
        {
            if (n < 0) throw new ArgumentException("El número no puede ser negativo.");
            // Caso Base
            if (n == 0) return 0;
            if (n == 1) return 1;
            // Caso Recursivo: F(n) = F(n - 1) + F(n - 2)
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }
}
