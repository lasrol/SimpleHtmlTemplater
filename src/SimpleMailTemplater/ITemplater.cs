namespace SimpleHtmlTemplater
{
    public interface ITemplater
    {
        ITemplater AddTemplate(string content);
        ITemplater AddTemplateFromFile(string path);
        ITemplater AddTemplateFromFile(string path, object model);
        ITemplater AddTemplate(string content, object model);
        string Build();
    }
}