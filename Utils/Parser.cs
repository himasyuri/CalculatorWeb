using Calculator.Models;
using Calculator.Models.AST;

namespace Calculator.Utils
{
    public class Parser
    {
        private int position = 0;
        private double result = 0;
        private List<TokenModel> tokens;
        private Dictionary<int, TokenTypeModel> tokenTypesList;

        public double Result
        {
            get => result;
            set => result = value;
        }

        public Parser(List<TokenModel> tokens, Dictionary<int, TokenTypeModel> tokenTypesList)
        {
            this.tokens = tokens;
            this.tokenTypesList = tokenTypesList;
        }

        public dynamic Run(ExpressionNode node)
        {
            if (node is NumberNode)
            {
                return ParseNumber();
            }
            if (node is BinOperationNode)
            {
                var binOperationNode = node as BinOperationNode;
                switch (binOperationNode.BinOperator.TokenType.Name)
                {
                    case "plus":
                        return Run(binOperationNode.LeftNode) + Run(binOperationNode.RightNode);
                    case "minus":
                        return Run(binOperationNode.LeftNode) - Run(binOperationNode.RightNode);
                }
            }
            if (node is StatementsNode)
            {
                var statementsNode = node as StatementsNode;
                return Run(statementsNode.Code.FirstOrDefault());
            }

            throw new Exception("Unexpected");
        }

        public ExpressionNode ParseString()
        {
            var root = new StatementsNode();

            while (position < tokens.Count)
            {
                var codeStringNode = ParseExpression();
                root.AddNode(codeStringNode);
            }

            return root;
        }

        private TokenModel? Match(List<TokenTypeModel> expected)
        {
            if (position < tokens.Count)
            {
                var currentToken = tokens[position];

                if (expected.Any(type => type.Name == currentToken?.TokenType?.Name))
                {
                    position += 1;
                    return currentToken;
                }
            }

            return null;
        }

        private TokenModel Require(List<TokenTypeModel> expected)
        {
            var token = Match(expected) ?? 
                throw new Exception($"Expected {expected[0].Name}");
            
            return token;
        }

        // private ExpressionNode ParseResult()
        // {
            
        // }

        private ExpressionNode ParseExpression()
        {
            var numberNode = ParseFormula();
            List<TokenTypeModel> expected = new List<TokenTypeModel>()
            {
                tokenTypesList[2],
                tokenTypesList[3],
            };
            var binOperator = Match(expected);

            if (binOperator != null)
            {
                var rightNode = ParseFormula();
                var binaryNode = new BinOperationNode(binOperator, numberNode, rightNode);
                
                return binaryNode;
            }

            throw new Exception();
        }

        private ExpressionNode ParseFormula()
        {
            var leftNode = ParseParentheses();
            var expected = new List<TokenTypeModel>()
            {
                tokenTypesList[2],
                tokenTypesList[3],
            };

            var binOperator = Match(expected);

            while (binOperator != null)
            {
                var rightNode = ParseParentheses();
                leftNode = new BinOperationNode(binOperator, leftNode, rightNode);
                binOperator = Match(expected);
            }

            return leftNode;
        }

        private ExpressionNode ParseNumber()
        {
            var expectedTokens = new List<TokenTypeModel>() {tokenTypesList[1]};
            var number = Match(expectedTokens);

            if (number is not null)
            {
                return new NumberNode(number);
            }

            throw new Exception();
        }

        private ExpressionNode ParseParentheses()
        {
            var expectedTokens = new List<TokenTypeModel>()
            {
                tokenTypesList[8],
                tokenTypesList[9]
            };

            if (Match(expectedTokens) != null)
            {
                var node = ParseFormula();
                Require(expectedTokens);

                return node;
            }
            else 
            {
                return ParseNumber();
            }
        }
    }
}