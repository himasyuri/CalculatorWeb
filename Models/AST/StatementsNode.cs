namespace Calculator.Models.AST
{
    public class StatementsNode : ExpressionNode
    {
        public List<ExpressionNode> Code { get; private set; }

        public void AddNode(ExpressionNode node)
        {
            Code.Add(node);
        }
    }
}