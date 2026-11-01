using System;

namespace CatalogoRecursividad.Services
{
    public static class FactorialService
    {
        // Solución Iterativa
        public static long CalculateFactorialIterative(int n)
        {
            if (n < 0) throw new ArgumentException("El número no puede ser negativo.");
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // Solución Recursiva
        public static long CalculateFactorial(int n)
        {
            if (n < 0) throw new ArgumentException("El número no puede ser negativo.");
            // Caso Base: 0! = 1, 1! = 1
            if (n == 0 || n == 1)
            {
                return 1;
            }
            // Caso Recursivo: n! = n * (n - 1)!
            return n * CalculateFactorial(n - 1);
        }
    }
}
