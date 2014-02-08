namespace Nancy.Bundler
{
    public interface IAppManager
    {
        bool IsDebugging { get; }
        string GetRootDirectory();
    }
}