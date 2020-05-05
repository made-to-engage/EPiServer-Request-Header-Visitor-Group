using System;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Web;
using EPiServer.Personalization.VisitorGroups;
using MadeToEngage.RequestHeaderVisitorGroup.Business.VisitorGroup.Model;

namespace MadeToEngage.RequestHeaderVisitorGroup.Business.VisitorGroup.Criterion
{
    [VisitorGroupCriterion(
        Category = "Request Criteria",
        Description = "Matches the request to see if it contains a header / with the specified value",
        DisplayName = "Request Header")]
    public class RequestHeaderCriterion : CriterionBase<RequestHeaderModel>
    {
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            NameValueCollection requestHeaders = httpContext.Request.Headers;

            if (Model.Condition == RequestHeaderValueCondition.Exists)
                return requestHeaders.AllKeys.Contains(Model.Key);

            string keyValue = requestHeaders[Model.Key];

            return !string.IsNullOrEmpty(keyValue)
                   && string.Equals(keyValue, Model.Value, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
