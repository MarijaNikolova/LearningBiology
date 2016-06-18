using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningBiology.Startup))]
namespace LearningBiology
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
