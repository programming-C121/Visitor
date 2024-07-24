using BaseVisitor.Interfaces;

namespace Example.AST;

public class AdditionNode(INode left, INode right) : ArithmeticBinaryNode(left, right);