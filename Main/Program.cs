using Example.AST;
using Test;

// Create the AST nodes for this example program
// x = 5;
// y = 10;
// z = x + y * 2;

// x = 5;
var xDeclaration = new VariableDeclarationNode("x", new NumberNode(5));

// y = 10;
var yDeclaration = new VariableDeclarationNode("y", new NumberNode(10));

// z = x + y * 2;
var multiplication = new MultiplicationNode(
    new VariableNode("y"),
    new NumberNode(2)
);
var addition = new AdditionNode(
    new VariableNode("x"),
    multiplication
);
var zDeclaration = new VariableDeclarationNode("z", addition);

// Create the program node containing all the statements
var program = new ProgramNode([xDeclaration, yDeclaration, zDeclaration]);

program.Execute(debug: true);