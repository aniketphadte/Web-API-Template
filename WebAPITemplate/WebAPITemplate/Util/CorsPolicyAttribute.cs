using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace WebAPITemplate.Util
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CorsPolicyAttribute : Attribute, ICorsPolicyProvider 
    {
        private const string keyCorsHeaders = "cors:headers";
        private const string keyCorsMethods = "cors:methods";
        private const string keyCorsOrigins = "cors:origins";

        private CorsPolicy _policy;

        public CorsPolicyAttribute()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy();

            #region Headers
            var headers = ConfigurationManager.AppSettings[keyCorsHeaders];
            if (headers == "*")
                _policy.AllowAnyHeader = true;
            else
                headers.Split(';').ToList().ForEach(i => _policy.Headers.Add(i));
            #endregion

            #region Methods
            var methods = ConfigurationManager.AppSettings[keyCorsMethods];
            if (methods == "*")
                _policy.AllowAnyMethod = true;
            else
                methods.Split(';').ToList().ForEach(i => _policy.Methods.Add(i));
            #endregion

            #region Origins
            var origins = ConfigurationManager.AppSettings[keyCorsOrigins];
            if (origins == "*")
                _policy.AllowAnyOrigin = true;
            else
                origins.Split(';').ToList().ForEach(i => _policy.Methods.Add(i));
            #endregion
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}