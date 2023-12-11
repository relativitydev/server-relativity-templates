﻿using kCura.EventHandler;
using Relativity.API;
using Relativity.ObjectManager.V1.Interfaces;
using System;
using System.Net;

namespace $rootnamespace$
{
	[kCura.EventHandler.CustomAttributes.Description("Pre Uninstall EventHandler")]
	[System.Runtime.InteropServices.Guid("$guid1$")]
	public class $safeitemname$ : kCura.EventHandler.$safeitemname$
	{
		public override Response Execute()
		{
			// Update Security Protocol
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			//Construct a response object with default values.
			kCura.EventHandler.Response retVal = new kCura.EventHandler.Response();
			retVal.Success = true;
			retVal.Message = string.Empty;
			try
			{
				Int32 currentWorkspaceArtifactID = Helper.GetActiveCaseID();

				//The Object Manager is the newest and preferred way to interact with Relativity instead of the Relativity Services API(RSAPI). 
				using (IObjectManager objectManager = this.Helper.GetServicesManager().CreateProxy<IObjectManager>(ExecutionIdentity.System))
				{

				}

				Relativity.API.IDBContext workspaceContext = Helper.GetDBContext(currentWorkspaceArtifactID);

				//Get a dbContext for the EDDS database
				Relativity.API.IDBContext eddsDBContext = Helper.GetDBContext(-1);

				IAPILog logger = Helper.GetLoggerFactory().GetLogger();
				logger.LogVerbose("Log information throughout execution.");
			}
			catch (Exception ex)
			{
				//Change the response Success property to false to let the user know an error occurred
				retVal.Success = false;
				retVal.Message = ex.ToString();
			}

			return retVal;
		}
	}
}