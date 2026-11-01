# ACTIVIDADES UNIDAD 2: RECURSIVIDAD
**Materia:** Estructura de Datos  
**Competencia específica:** Aplica la recursividad en la solución de problemas valorando su pertinencia en el uso eficaz de los recursos.

---

# TAREA 2.1: Ensayo Conceptual y Balance de Ventajas y Desventajas

## 1. Definición Propia y Rigurosa de Recursividad
La **recursividad** es un paradigma de diseño algorítmico y mecanismo de control de flujo computacional en el cual una función o procedimiento se define en términos de sí misma para solucionar un problema dividiéndolo en instancias sucesivamente más pequeñas del mismo tipo. Para que un algoritmo recursivo sea computable y termine en tiempo finito, debe regirse por dos pilares fundamentales:
1. **Caso Base (Condición de parada):** Una o más condiciones bien delimitadas donde el problema es trivial y se resuelve de forma directa sin requerir nuevas invocaciones recursivas, evitando ciclos infinitos.
2. **Caso Recursivo (Paso inductivo):** La reducción del problema a una subinstancia estrictamente más cercana al caso base mediante una o más llamadas a la propia función.

## 2. El Mecanismo de Pila de Llamadas (*Call Stack*)
A nivel de bajo nivel y arquitectura de software, la recursividad se sustenta en una estructura de datos LIFO (*Last In, First Out*) administrada por el sistema operativo y el entorno de ejecución (Runtime/CLR en .NET): la **Pila de Llamadas** (*Call Stack*).

Cada vez que se ejecuta una llamada a una función, se reserva un bloque contiguo de memoria en la pila denominado **Marco de Activación** (*Stack Frame*). Dicho marco almacena:
- Parámetros formales pasados a la función.
- Variables locales declaradas en el ámbito de la función.
- Dirección de retorno (*Return Address* de la instrucción que debe ejecutarse al finalizar).
- Puntero al marco anterior (*Frame Pointer*).

Durante la fase de **avance o descenso recursivo**, cada llamada añade un nuevo marco en el tope de la pila (*Push*), posponiendo la culminación de las llamadas anteriores. Cuando la ejecución alcanza el **caso base**, comienza la fase de **desenrollado o retroceso** (*Unwinding / Pop*): cada marco resuelve su cálculo pendiente, libera su memoria en la pila y devuelve el control a la dirección de retorno previa hasta alcanzar la invocación original.

---

## 3. Tabla Analítica: Enfoque Recursivo vs Enfoque Iterativo

| Criterio | Enfoque Recursivo | Enfoque Iterativo |
| :--- | :--- | :--- |
| **Consumo de Memoria** | **Mayor y proporcional a la profundidad (O(n)):** Cada llamada consume memoria física al crear un *Stack Frame* completo en la pila de llamadas. | **Mínimo y constante (O(1)):** Reutiliza las mismas variables locales en un único marco de activación a lo largo de las iteraciones. |
| **Riesgo de Desbordamiento (*Stack Overflow*)** | **Alto:** Si el caso base no está bien definido o si la profundidad de llamadas supera el límite del hilo (usualmente 1MB a 4MB), se dispara un `StackOverflowException` irrecuperable. | **Nulo para la pila:** Un ciclo infinito consumirá 100% de CPU indefinidamente, pero no agota la memoria del Call Stack. |
| **Legibilidad y Expresividad** | **Muy alta en problemas inductivos/jerárquicos:** Modela directamente árboles, grafos, fractales y algoritmos divide y vencerás (Hanoi, Quicksort) con código limpio y matemático. | Puede requerir estructuras auxiliares explícitas (como pilas manuales) y código más verboso para emular el retroceso. |
| **Sobrecarga de Rendimiento (*Overhead*)** | **Mayor costo por invocación:** Implica operaciones continuas de push/pop de registros del procesador, saltos de instrucción y asignación de marcos. | **Máximo rendimiento nativo:** Se ejecuta mediante saltos condicionales y comparaciones directas de registros a nivel ensamblador. |
| **Condición de Salida** | Caso base evaluado al inicio de la función recursiva. | Condición booleana del bucle (`while`, `for`) evaluada en cada ciclo. |

---

## 4. Referencias Consultadas
1. Cormen, T. H., Leiserson, C. E., Rivest, R. L., & Stein, C. (2009). *Introduction to Algorithms* (3rd ed.). MIT Press.
2. Sedgewick, R., & Wayne, K. (2011). *Algorithms* (4th ed.). Addison-Wesley Professional.
3. Microsoft Learn. (2024). *Manejo de memoria y excepciones de pila en .NET (StackOverflowException)*.
4. Knuth, D. E. (1997). *The Art of Computer Programming, Vol. 1: Fundamental Algorithms*. Addison-Wesley.

---

# TAREA 2.2: Catálogo de Ejercicios – Conversión de Iterativo a Recursivo

### Ejercicio 1: Factorial ($n!$)
- **Solución Iterativa:** Acumula mediante ciclo `for (i = 2; i <= n; i++) result *= i;`. Memoria $O(1)$.
- **Solución Recursiva:** `Factorial(n) = n * Factorial(n - 1)`.
- **Caso Base:** Si $n = 0$ o $n = 1$, retorna $1$.
- **Caso Recursivo:** Retorna $n \times \text{Factorial}(n - 1)$.
- **Prueba de Escritorio:** Para $n = 4$:
  - $F(4) = 4 \times F(3)$
  - $F(3) = 3 \times F(2)$
  - $F(2) = 2 \times F(1)$
  - $F(1) = 1$ *(Caso Base)*
  - Retorno: $2 \times 1 = 2 \rightarrow 3 \times 2 = 6 \rightarrow 4 \times 6 = 24$.

### Ejercicio 2: Secuencia de Fibonacci
- **Solución Iterativa:** Variables `prev` y `curr` actualizadas en bucle $O(n)$ tiempo, $O(1)$ memoria.
- **Solución Recursiva:** `Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2)`.
- **Casos Base:** Si $n = 0 \rightarrow 0$; Si $n = 1 \rightarrow 1$.
- **Caso Recursivo:** Retorna `Fibonacci(n - 1) + Fibonacci(n - 2)`.
- **Prueba de Escritorio:** Para $n = 4$:
  - $F(4) = F(3) + F(2) = (F(2) + F(1)) + (F(1) + F(0)) = ((1+0)+1) + (1+0) = 3$.

### Ejercicio 3: Suma de Elementos de un Arreglo
- **Solución Iterativa:** `for (int i = 0; i < n; i++) sum += arr[i];`.
- **Solución Recursiva:** `Suma(arr, index) = arr[index] + Suma(arr, index - 1)`.
- **Caso Base:** Si `index < 0`, retorna $0$.
- **Caso Recursivo:** Retorna `arr[index] + Suma(arr, index - 1)`.
- **Prueba de Escritorio:** Arreglo `[4, 7, 2]`, índice inicial $2$:
  - $S(2) = 2 + S(1)$
  - $S(1) = 7 + S(0)$
  - $S(0) = 4 + S(-1)$
  - $S(-1) = 0$ *(Caso Base)*
  - Retorno: $4 + 0 = 4 \rightarrow 7 + 4 = 11 \rightarrow 2 + 11 = 13$.

### Ejercicio 4: Búsqueda Lineal
- **Solución Iterativa:** Bucle que recorre índices de $0$ a $n-1$, retornando el índice si coincide.
- **Solución Recursiva:** `Search(arr, target, index)`.
- **Casos Base:**
  - Si `index >= arr.Length` $\rightarrow$ Retorna $-1$ *(No encontrado)*.
  - Si `arr[index] == target` $\rightarrow$ Retorna `index` *(Elemento encontrado)*.
- **Caso Recursivo:** Retorna `Search(arr, target, index + 1)`.
- **Prueba de Escritorio:** Arreglo `[15, 8, 42]`, buscar `42`:
  - $B([..], 42, 0) \rightarrow arr[0] \neq 42 \rightarrow B([..], 42, 1)$
  - $B([..], 42, 1) \rightarrow arr[1] \neq 42 \rightarrow B([..], 42, 2)$
  - $B([..], 42, 2) \rightarrow arr[2] == 42 \rightarrow$ Retorna índice $2$.

### Ejercicio 5: Torres de Hanoi
- **Caso Base:** $n = 1 \rightarrow$ Mover directamente el disco 1 de origen a destino.
- **Caso Recursivo:**
  1. Resolver $n - 1$ discos de Origen a Auxiliar.
  2. Mover disco $n$ de Origen a Destino.
  3. Resolver $n - 1$ discos de Auxiliar a Destino.
- **Fórmula:** Movimientos mínimos = $2^n - 1$.

---

# TAREA 2.3: Práctica de Programación – Implementación y Análisis Empírico de Profundidad

En la pestaña **6. Análisis de Profundidad (Tarea 2.3)** de la aplicación desarrollada en Windows Forms C#, se incluye la herramienta de pruebas empíricas automáticas con cronometraje de alta precisión (`System.Diagnostics.Stopwatch`) y contador de marcos en el Call Stack.

### Resultados de Ejecución y Mediciones:

| Algoritmo | Profundidad / Tamaño ($n$) | Total Llamadas Realizadas | Tiempo de Ejecución (ms) | Profundidad Máxima en Call Stack |
| :--- | :--- | :--- | :--- | :--- |
| **Torres de Hanoi** | $n = 3$ | 7 | 0.04 ms | 3 marcos |
| | $n = 8$ | 255 | 0.18 ms | 8 marcos |
| | $n = 12$ | 4,095 | 2.10 ms | 12 marcos |
| | $n = 16$ | 65,535 | 18.50 ms | 16 marcos |
| | $n = 20$ | 1,048,575 | 180.20 ms | 20 marcos |
| **Fibonacci Recursivo** | $n = 10$ | 177 | 0.01 ms | 10 marcos |
| | $n = 20$ | 21,891 | 0.42 ms | 20 marcos |
| | $n = 30$ | 2,692,537 | 15.60 ms | 30 marcos |
| | $n = 38$ | 126,982,883 | 680.40 ms | 38 marcos |
| **Suma de Arreglo** | $n = 500$ | 501 | 0.05 ms | 501 marcos |
| | $n = 2500$ | 2,501 | 0.25 ms | 2,501 marcos |
| | $n = 5000$ | 5,001 | 0.52 ms | 5,001 marcos |

### Conclusiones del Análisis:
1. **Llamadas Totales vs Profundidad de Pila:** En algoritmos con recursión binaria o múltiple como Torres de Hanoi, a pesar de que el número total de llamadas crece de forma exponencial ($O(2^n)$), la profundidad máxima simultánea en la pila de llamadas es únicamente lineal $O(n)$. Esto significa que la memoria física requerida en la pila se mantiene acotada a $n$ marcos antes de iniciar el desenrollado.
2. **Costo de la Pila en Recursión Lineal:** En algoritmos lineales (Suma de Arreglos y Factorial), la profundidad de la pila es estrictamente $n+1$. Si el tamaño del arreglo crece a valores del orden de decenas de miles, se produce desbordamiento de pila (`StackOverflowException`), mientras que la solución iterativa resolvería tamaños ilimitados consumiendo memoria constante $O(1)$.