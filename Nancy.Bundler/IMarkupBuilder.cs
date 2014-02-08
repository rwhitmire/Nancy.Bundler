namespace Nancy.Bundler
{
    public interface IMarkupBuilder
    {
        string GetScriptsForDebugging(string bundleName);
        string GetScriptsForProduction(string bundleName);
    }
}