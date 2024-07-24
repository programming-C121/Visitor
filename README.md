# Visitor

El patrón Visitor es un patrón de diseño de comportamiento que permite separar algoritmos de las estructuras de objetos sobre las que operan.

En compilación, este patrón es especialmente útil para:

1. Recorrer y operar sobre el árbol de sintaxis abstracta (AST) de un programa.
2. Implementar diferentes fases del proceso de compilación (análisis semántico, generación de código, optimización, etc.).
3. Mantener la separación de preocupaciones entre la estructura del AST y las operaciones realizadas sobre él.

### Ventajas

1. Facilita la adición de nuevas operaciones sin modificar las clases de nodos existentes.
2. Permite agrupar funcionalidades relacionadas en una sola clase visitor.
3. Mejora la separación de preocupaciones en el compilador, facilita la implementación de diferentes fases de manera modular y extensible.


## Estructura del Proyecto

- **BaseVisitor**: Contiene la implementación principal del patrón Visitor.
- **Example**: Incluye ejemplos de cómo utilizar el patrón Visitor propuesto en diferentes escenarios.
- **Main**: Contiene el programa principal que ejecuta los ejemplos.

## Requisitos

- .NET SDK 8.0

## Cómo Ejecutar

1. Clona el repositorio:
    ```bash
    git clone https://github.com/programming-C121/Visitor.git
    ```
2. Navega al directorio del proyecto:
    ```bash
    cd Visitor
    ```
3. Restaura los paquetes NuGet:
    ```bash
    dotnet restore
    ```
4. Ejecuta el proyecto:
    ```bash
    dotnet run --project Main
    ```