using System.Text.RegularExpressions;
using Calculator.Models;

namespace Calculator.Utils
{
    public class Lexer
    {
        private string expression;
        private int position = 0;

        public string Expression
        {
            get
            {
                return expression;
            }
            set
            {
                if (expression == string.Empty)
                {
                    throw new ArgumentException("Expression must not be empty");
                }

                expression = value;
            }
        }

        public Dictionary<int, TokenTypeModel> TokenTypesDictionary { get; set; }

        public List<TokenModel> TokenList { get; set; } = new List<TokenModel>();

        public Lexer(string expression)
        {
            this.expression = expression + "endl";

            TokenTypesDictionary = new Dictionary<int, TokenTypeModel>()
            {
                { 0, new TokenTypeModel("number", @"[0-9]")},
                { 1, new TokenTypeModel("plus", @"\+")},
                { 2, new TokenTypeModel("minus", @"\-")},
                { 3, new TokenTypeModel("multiply", @"\*")},
                { 4, new TokenTypeModel("division", @"\/")},
                { 5, new TokenTypeModel("exponentation", @"\^")},
                { 6, new TokenTypeModel("sqrt", @"sqrt")},
                { 7, new TokenTypeModel("lpar", @"\(")},
                { 8, new TokenTypeModel("rpar", @"\)")},
                { 9, new TokenTypeModel("endl", @"endl")}
            };
        }

        public List<TokenModel> LexAnalysis()
        {
            
            while (NextToken())
            {

            }

            return TokenList;
        }

        private bool NextToken()
        {
            if (position >= expression.Length)
            {
                return false;
            }

            for (int i = 0; i < TokenTypesDictionary.Count; i++)
            {
                Regex regex = new Regex(TokenTypesDictionary[i].Regex);
                var subsr = expression.Substring(position, 1);
                Console.WriteLine(subsr);

                var result = regex.Match(expression.Substring(position, 1));

                if (result.Success)
                {
                    var token = new TokenModel(TokenTypesDictionary[i], result.Value);
                    position += result.Value.Length;
                    TokenList.Add(token);

                    return true;
                }
            }

            throw new Exception($"Invalid symbol in this position: {position}");
        }
    }
}