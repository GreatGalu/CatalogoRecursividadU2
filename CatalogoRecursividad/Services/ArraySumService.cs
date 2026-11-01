using System;

namespace CatalogoRecursividad.Services
{
    public class ArraySumService
    {
        // Solución Iterativa
        public int SumArrayIterative(int[] array)
        {
            if (array == null) return 0;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        // Solución Recursiva
        public int SumArrayRecursive(int[] array, int index)
        {
            if (array == null || index < 0 || index >= array.Length)
            {
                return 0; // Caso Base
            }
            // Caso Recursivo
            return array[index] + SumArrayRecursive(array, index - 1);
        }
    }
}
