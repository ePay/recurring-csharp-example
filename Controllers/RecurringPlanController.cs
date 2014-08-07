using System;
using System.Linq;
using System.Web.Mvc;
using RecurringServiceExample.RecurringService;

namespace RecurringServiceExample.Controllers
{
    public class RecurringPlanController : Controller
    {
        private RecurringClient client = new RecurringClient();

        public ActionResult Index()
        {
            listrecurringplanresponse response = client.listrecurringplan(new listrecurringplanrequest
            {
                authentication = Helper.AuthenticationHelper.GetAuthentication(),
                sorting = sorting.createddescending
            });

            return View(response);
        }

        public ActionResult Create()
        {
            return View(new recurringplan());
        }

        [HttpPost]
        public ActionResult Create(recurringplan recurringplan)
        {
            createrecurringplanresponse response = client.createrecurringplan(new createrecurringplanrequest
            {
                authentication = Helper.AuthenticationHelper.GetAuthentication(),
                recurringplan = recurringplan
                
            });

            if (response.result)
            {
                return RedirectToAction("index");
            }

            ViewBag.errorMsg = response.message;

            return View(recurringplan);
        }
	}
}