using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NewRelic.Api.Agent;

namespace NetRemotingCommon
{
    public class ShowCapital : MarshalByRefObject
    {
        public ShowCapital()
        {

        }

        [Transaction]
        public string show(string country)
        {
            NewRelicDTrace();
            if (country.ToLower() == "england") return ("London");
            else if (country.ToLower() == "scotland") return ("Edinburgh");
            else return ("Not known");
        }

        private void NewRelicDTrace()
        {
            IAgent agent = NewRelic.Api.Agent.NewRelic.GetAgent();
            ITransaction transaction = agent.CurrentTransaction;
            Header[] headers = CallContext.GetHeaders();
            if (headers != null)
            {
                foreach (Header h in headers)
                {
                    if (h.Name.Equals(NewRelic.Api.Agent.Constants.DistributedTracePayloadKey))
                    {
                        transaction.AcceptDistributedTracePayload(h.Value.ToString(), TransportType.Other);
                        Console.WriteLine(h.Name + "=" + h.Value);
                    }
                }
            }
        }
    }
}
