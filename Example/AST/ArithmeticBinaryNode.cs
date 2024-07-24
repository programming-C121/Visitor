using BaseVisitor.Interfaces;

namespace Example.AST;

public abstract class ArithmeticBinaryNode(INode left, INode right) : BinaryNode(left, right);