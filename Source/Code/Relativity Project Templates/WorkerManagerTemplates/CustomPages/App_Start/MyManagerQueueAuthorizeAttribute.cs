﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Relativity.API;
using System;
using Relativity_Extension.Helpers.Rsapi;
using Relativity.CustomPages;

namespace Relativity_Extension.CustomPages
{
	public class MyManagerQueueAuthorizeAttribute : AuthorizeAttribute
	{
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			bool isAuthorized = false;

			if (httpContext.Session != null)
			{
				Int32 caseArtifactId = -1;
				Int32.TryParse(httpContext.Request.QueryString["appid"], out caseArtifactId);

				ArtifactQueries query = new ArtifactQueries();
				bool res = query.DoesUserHaveAccessToArtifact(
				ConnectionHelper.Helper().GetServicesManager(),
				ExecutionIdentity.CurrentUser,
				caseArtifactId,
				Helpers.Constant.Guids.ManagerQueueTab,
				"Tab");
				isAuthorized = res;
			}

			return isAuthorized;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                {"action", "AccessDenied"},
                {"controller", "Error"}
            });
		}
	}
}
