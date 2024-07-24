using BaseVisitor.Interfaces;

namespace Example.AST;

public class DivisionNode(INode left, INode right) : ArithmeticBinaryNode(left, right);