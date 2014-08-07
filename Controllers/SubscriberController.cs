using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecurringServiceExample.RecurringService;

namespace RecurringServiceExample.Controllers
{
    public class SubscriberController : Controller
    {
        private RecurringClient client = new RecurringClient();


        private List<SelectListItem> GetRecurringPlanList()
        {
            listrecurringplanresponse response = client.listrecurringplan(new listrecurringplanrequest
            {
                authentication = Helper.AuthenticationHelper.GetAuthentication(),
                sorting = sorting.createddescending
            });

            List<SelectListItem> result = new List<SelectListItem>();

            foreach (var item in response.recurringplanlist)
            {
                result.Add(new SelectListItem { Text = item.description, Value = item.recurringplanid.ToString() });
            }

            return result;
        }

        public ActionResult Signup()
        {
            ViewBag.recurringPlanId = GetRecurringPlanList();

            return View(new signupsubscriberrequest());
        }

        [HttpPost]
        public ActionResult Signup(long subscriptionId, int recurringPlanId, string email)
        {
            recurringplanlist list = new recurringplanlist();
            list.Add(new recurringplan2 { recurringplanid = recurringPlanId });
            signupsubscriberresponse response = client.signupsubscriber(new signupsubscriberrequest
            {
                authentication = Helper.AuthenticationHelper.GetAuthentication(),
                subscription = new subscription { subscriptionid = subscriptionId, emailaddress = email },
                recurringplanlist = list
            });

            ViewBag.recurringPlanId = GetRecurringPlanList();

            if (response.result)
            {
                return View(); 
            }

            ViewBag.errorMsg = response.message;

            return View();
        }
    }
}