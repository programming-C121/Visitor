using BaseVisitor.Interfaces;

namespace Example.AST;

public class MultiplicationNode(INode left, INode right) : ArithmeticBinaryNode(left, right);