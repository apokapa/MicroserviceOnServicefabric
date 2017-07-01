using Owin;

namespace ProductsSrvc
{
    public interface IOwinAppBuilder
    {
        void Configuration(IAppBuilder appBuilder);
    }

}
