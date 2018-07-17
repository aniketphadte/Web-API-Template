using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebAPITemplate.Filters
{
    public class AuthorizeCheck: AuthorizeAttribute
    {
        const string key = "AEEFSID27_THIS_IS_MY_API_KEY_AZMSHCJSUKS";

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Contains("apiKey"))
                    return actionContext.Request.Headers.GetValues("apiKey").FirstOrDefault() == key ? true : false;
                else
                    return false;

            }
            catch (Exception e)
            {
                //Log error
                return false;
            }
        }
    }
}