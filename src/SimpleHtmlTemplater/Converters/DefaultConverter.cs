namespace SimpleHtmlTemplater.Converters
{
    public class DefaultConverter : IConverter
    {
        public string Convert(object obj)
        {
            return obj.ToString();
        }
    }
}
