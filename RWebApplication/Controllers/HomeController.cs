using NetRemotingCommon;
using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ShowCapital showCapital;

        public HomeController(ShowCapital sc)
        {
            showCapital = sc;
        }
        public ActionResult Index()
        {
            NewRelicDTrace();
            string cap = showCapital.show("england");
            ViewBag.Message = "Capital of england is " + cap;
            return View();
        }

        public ActionResult About()
        {
            NewRelicDTrace();
            Thread.Sleep(320); // simulate some work to be done

            string cap = showCapital.show("scotland");
            ViewBag.Message = "Capital of scotland is " + cap;

            return View();
        }

        public ActionResult Contact()
        {
            NewRelicDTrace();
            Thread.Sleep(747); // simulate some work to be done

            string cap = showCapital.show("norway");
            ViewBag.Message = "Capital of norway is " + cap;

            return View();
        }

        private void NewRelicDTrace()
        {
            IAgent agent = NewRelic.Api.Agent.NewRelic.GetAgent();
            ITransaction transaction = agent.CurrentTransaction;
            IDistributedTracePayload payload = transaction.CreateDistributedTracePayload();
            if (!payload.IsEmpty())
            {
                Header[] headers = { new Header(NewRelic.Api.Agent.Constants.DistributedTracePayloadKey, payload.Text()) };
                CallContext.SetHeaders(headers);
            }
        }
    }
}