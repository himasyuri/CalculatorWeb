namespace Calculator.Models.AST
{
    public class BinOperationNode : ExpressionNode
    {
        private TokenModel binOperator;
        private ExpressionNode leftNode;
        private ExpressionNode rightNode;

        public TokenModel BinOperator
        {
            get => binOperator;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Operator can't be null");
                }

                binOperator = value;
            }
        }

        public ExpressionNode LeftNode
        {
            get => leftNode;
            set => leftNode = value;
        }

        internal ExpressionNode RightNode
        {
            get => rightNode;
            set => rightNode = value;
        }

        public BinOperationNode(TokenModel binOperator, ExpressionNode leftNode, ExpressionNode rightNode)
        {
            this.binOperator = binOperator;
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }
    }
}