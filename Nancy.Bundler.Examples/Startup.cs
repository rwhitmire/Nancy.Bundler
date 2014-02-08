using Owin;

namespace Nancy.Bundler.Examples
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}