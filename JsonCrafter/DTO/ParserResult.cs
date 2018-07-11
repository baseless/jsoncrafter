namespace JsonCrafter.DTO
{
    public class ParserResult
    {
        public bool Succeeded { get; }
        public string Content { get; }

        private ParserResult(bool succeeded, string content = default(string))
        {
            Succeeded = succeeded;
            Content = content;
        }

        public static ParserResult Success(string content) => new ParserResult(true, content);
        public static ParserResult Failure() => new ParserResult(false);
    }
}
