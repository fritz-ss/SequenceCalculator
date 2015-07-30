using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SequenceCalculator.Startup))]
namespace SequenceCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
