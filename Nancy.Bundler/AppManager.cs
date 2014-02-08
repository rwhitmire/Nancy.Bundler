using System;
using System.Web;

namespace Nancy.Bundler
{
    public class AppManager : IAppManager
    {
        public bool IsDebugging
        {
            get
            {
                return HttpContext.Current.IsDebuggingEnabled;
            }
        }

        public string GetRootDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}