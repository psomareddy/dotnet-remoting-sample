using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace NetRemotingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(1234);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType
            (typeof(NetRemotingCommon.ShowCapital), "ShowCapital", WellKnownObjectMode.SingleCall);
            Console.WriteLine("Starting Remoting Service...");
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
