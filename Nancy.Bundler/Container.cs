using Nancy.TinyIoc;

namespace Nancy.Bundler
{
    public class Container
    {
        private static readonly TinyIoCContainer container = TinyIoCContainer.Current;

        public static T Resolve<T>() where T : class
        {
            container.AutoRegister();
            return container.Resolve<T>();
        }
    }
}