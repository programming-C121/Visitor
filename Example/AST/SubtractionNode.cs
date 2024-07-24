using BaseVisitor.Interfaces;

namespace Example.AST;

public class SubtractionNode(INode left, INode right) : ArithmeticBinaryNode(left, right);