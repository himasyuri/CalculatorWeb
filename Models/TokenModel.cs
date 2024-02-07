namespace Calculator.Models
{
    public class TokenModel
    {
        private TokenTypeModel? tokenTypeModel;
        private string text;

        public TokenTypeModel? TokenType 
        {
            get => tokenTypeModel;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("TokenTypeModel can't be null");
                }

                tokenTypeModel = value;
            }
        }

        public string Text 
        {
            get => text;
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException("Text can't be null");
                }

                text = value;
            }
        }

        public TokenModel(TokenTypeModel? tokenTypeModel, string text)
        {
            this.tokenTypeModel = tokenTypeModel;
            this.text = text;
        }
    }
}