using NetRemotingCommon;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RWebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // Inject ShowCapital
            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownClientType(
            typeof(ShowCapital), "tcp://localhost:1234/ShowCapital");
            container.RegisterType<ShowCapital, ShowCapital>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}