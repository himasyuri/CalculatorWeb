namespace Calculator.Models.AST
{
    public class NumberNode : ExpressionNode
    {
        private TokenModel token;

        public TokenModel Token
        {
            get => token;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Token can't be null");
                }

                token = value;
            }
        }

        public NumberNode(TokenModel token)
        {
            this.token = token;
        }
    }
}