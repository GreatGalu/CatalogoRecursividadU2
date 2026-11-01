using System;

namespace CatalogoRecursividad.Services
{
    public class LinearSearchService
    {
        // Solución Iterativa
        public int LinearSearchIterative(int[] array, int target)
        {
            if (array == null) return -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        // Solución Recursiva eficiente sin subarreglos O(N)
        public int LinearSearchRecursive(int[] array, int target, int index = 0)
        {
            if (array == null || index >= array.Length)
            {
                return -1; // Caso Base: No encontrado o arreglo vacío
            }
            if (array[index] == target)
            {
                return index; // Caso Base: Elemento encontrado
            }
            // Caso Recursivo: Buscar en la siguiente posición
            return LinearSearchRecursive(array, target, index + 1);
        }
    }
}
