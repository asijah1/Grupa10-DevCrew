using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelYourWay.Startup))]
namespace TravelYourWay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
