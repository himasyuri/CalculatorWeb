using System.Text;
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
            this.expression = expression;

            TokenTypesDictionary = new Dictionary<int, TokenTypeModel>()
            {
                { 0, new TokenTypeModel("number", @"[0-9]")},
                { 1, new TokenTypeModel("plus", @"\+")},
                { 2, new TokenTypeModel("minus", @"\-")},
                { 3, new TokenTypeModel("multiply", @"\*")},
                { 4, new TokenTypeModel("division", @"\/")},
                { 5, new TokenTypeModel("exponentation", @"\^")},
                { 6, new TokenTypeModel("lpar", @"\(")},
                { 7, new TokenTypeModel("rpar", @"\)")},
                { 8, new TokenTypeModel("sqrt", @"sqrt")},
                { 9, new TokenTypeModel("endl", @"endl")},
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
            int length = 1;
            Match? result;

            if (position >= expression.Length)
            {
                return false;
            }

            for (int i = 0; i < TokenTypesDictionary.Count; i++)
            {
                Regex regex = new Regex(TokenTypesDictionary[i].Regex);

                if (i > 7) // word commands
                {
                    Regex letters = new Regex(@"[a-z]");
                    int newPosition = position;
                    while (CheckLength(letters, newPosition, length))
                    {
                        newPosition++;
                        if (newPosition >= expression.Length)
                        {
                            break;
                        }
                    }

                    length = newPosition - position;

                    result = regex.Match(expression.Substring(position, length));

                    if (result.Success)
                    {
                        var token = new TokenModel(TokenTypesDictionary[i], result.Value);
                        position += result.Value.Length;
                        TokenList.Add(token);

                        return true;
                    }
                }

                result = regex.Match(expression.Substring(position, length));
                if (result.Success)
                {
                    int newPosition = position;
                    //get length of token
                    while (CheckLength(regex, newPosition, length))
                    {
                        newPosition++;
                    }

                    length = newPosition - position;
                }

                //regex for complex numbers
                if (length > 1 && i == 0)
                {
                    StringBuilder stringNums = new StringBuilder(TokenTypesDictionary[i].Regex);

                    for (int j = 1; j < length; j++)
                    {
                        stringNums.Append(TokenTypesDictionary[i].Regex);
                    }

                    Regex complexNumsRegex = new Regex(stringNums.ToString());

                    result = complexNumsRegex.Match(expression.Substring(position, length));

                    if (result.Success)
                    {
                        var token = new TokenModel(TokenTypesDictionary[i], result.Value);
                        position += result.Value.Length;
                        TokenList.Add(token);

                        return true;
                    }
                }
                

                result = regex.Match(expression.Substring(position, length));

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

        private bool CheckLength(Regex regex, int position, int length)
        {
            //for numbers
            if (regex.Match(expression.Substring(position, length)).Success)
            {
                return true;
            }

            return false;
        }
    }
}