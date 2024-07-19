# Patrón Visitor

El patrón Visitor es un patrón de diseño de comportamiento que permite separar algoritmos de las estructuras de objetos sobre las que operan. En compilación, este patrón es especialmente útil para realizar operaciones sobre el árbol de sintaxis abstracta (AST) de un programa.

## Propósito

En compilación, el patrón Visitor se utiliza principalmente para:

1. Recorrer y operar sobre el AST.
2. Implementar diferentes fases del proceso de compilación (análisis semántico, generación de código, optimización, etc.).
3. Mantener la separación de preocupaciones entre la estructura del AST y las operaciones realizadas sobre él.

## Ventajas

1. Facilita la adición de nuevas operaciones sin modificar las clases de nodos existentes.
2. Permite agrupar funcionalidades relacionadas en una sola clase visitor.
3. Mejora la separación de preocupaciones en el compilador, facilita la implementación de diferentes fases de manera modular y extensible.

## Desventajas

1. Puede ser complicado de implementar si la jerarquía de clases del AST cambia frecuentemente.
2. Puede llevar a un acoplamiento fuerte entre los visitors y la estructura del AST.
