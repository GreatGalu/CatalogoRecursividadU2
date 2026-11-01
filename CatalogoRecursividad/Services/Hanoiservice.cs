using System;
using System.Collections.Generic;

namespace CatalogoRecursividad.Services
{
    public class HanoiService
    {
        private readonly List<string> _moves = new();
        public long CallCount { get; private set; }

        public List<string> SolveHanoi(int n, char source, char target, char auxiliary)
        {
            _moves.Clear();
            CallCount = 0;
            if (n > 0)
            {
                SolveHanoiRecursive(n, source, target, auxiliary);
            }
            return _moves;
        }

        private void SolveHanoiRecursive(int n, char source, char target, char auxiliary)
        {
            CallCount++;

            // Caso Base: Mover el disco 1 directamente al destino
            if (n == 1)
            {
                _moves.Add($"Mover disco 1 de torre {source} a torre {target}");
                return;
            }

            // Caso Recursivo:
            // 1. Mover n-1 discos de origen a auxiliar
            SolveHanoiRecursive(n - 1, source, auxiliary, target);

            // 2. Mover disco n de origen a destino
            _moves.Add($"Mover disco {n} de torre {source} a torre {target}");

            // 3. Mover n-1 discos de auxiliar a destino
            SolveHanoiRecursive(n - 1, auxiliary, target, source);
        }
    }
}
