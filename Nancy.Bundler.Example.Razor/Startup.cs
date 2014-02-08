using Owin;

namespace Nancy.Bundler.Example.Razor
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}