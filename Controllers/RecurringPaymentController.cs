using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecurringServiceExample.RecurringService;

namespace RecurringServiceExample.Controllers
{
    public class RecurringPaymentController : Controller
    {
        private readonly RecurringClient client = new RecurringClient();

        public ActionResult Index(int? recurringPlanId)
        {
            listrecurringpaymentresponse response = client.listrecurringpayment(new listrecurringpaymentrequest
            {
                authentication = Helper.AuthenticationHelper.GetAuthentication(),
            });

            return View(response.recurringpaymentlist);
        }
	}
}