using System;
using Owin;
using Microsoft.Owin;


[assembly : OwinStartup(typeof(HR_Manager.App_Start.StartUp))]
namespace HR_Manager.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}