namespace Calculator.Models
{
    public class TokenTypeModel 
    {
        private string name;
        private string regex;

        public string Name
        {
            get => name;
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("The name is null");
                }
                name = value;
            }
        }

        public string Regex 
        {
            get => regex;
            set 
            {
                if (value != string.Empty)
                {
                    regex = value;
                }
            }
        }

        public TokenTypeModel(string name, string regex)
        {
            this.name = name;
            this.regex = regex;
        }
    }
}