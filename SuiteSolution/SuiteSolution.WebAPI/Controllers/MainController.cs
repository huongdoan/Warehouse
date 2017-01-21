using SuiteSolution.Core.Entities;
using SuiteSolution.Service;
using SuiteSolution.WebAPI.Models;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SuiteSolution.WebAPI.Controllers
{
    public class MainController : ApiController
    {
        public IApplicationDataService ApplicationDataService { get; set; }

        public MainController(IApplicationDataService applicationDataService)
        {
            ApplicationDataService = applicationDataService;
        }

        //private AuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.Authentication;
        //    }
        //}
        /// <summary>
        /// Initialize Application
        /// </summary>
        /// <returns></returns>
        [Route("AuthenicateUser")]
        [HttpGet]
        public TransactionalInformation AuthenicateUser(string route)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.IsAuthenicated = User.Identity.IsAuthenticated;
            return transaction;

        }

        [Route("Logout")]
        [HttpGet]
        public TransactionalInformation Logout()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.IsAuthenicated = false;
            AuthenticationManager.Unregister("Cookies");
            return transaction;

        }

        // POST api/values
        /// <summary>
        /// Initialize Application
        /// </summary>
        /// <returns></returns>
        //[Route("main/InitializeApplication")]
        [HttpGet]
        public ApplicationApiModel InitializeApplication()
        {
            ApplicationApiModel applicationWebApiModel = new ApplicationApiModel();
            TransactionalInformation transaction = new TransactionalInformation();

            List<ApplicationMenu> menuItems = ApplicationDataService.GetMenuItems(User.Identity.IsAuthenticated, out transaction);

            if (transaction.ReturnStatus == false)
            {
                applicationWebApiModel.ReturnMessage = transaction.ReturnMessage;
                applicationWebApiModel.ReturnStatus = transaction.ReturnStatus;
                applicationWebApiModel.HttpStatusCode = "400";
                return applicationWebApiModel;
            }
            applicationWebApiModel.ReturnMessage.Add("Application has been initialized.");
            applicationWebApiModel.ReturnStatus = transaction.ReturnStatus;
            applicationWebApiModel.MenuItems = menuItems;
            applicationWebApiModel.IsAuthenicated = User.Identity.IsAuthenticated;
            return applicationWebApiModel;

        }
    }
}
