﻿using kCura.EventHandler;
using Relativity.API;
using Relativity.ObjectManager.V1.Interfaces;
using System;
using System.Net;

namespace Relativity.PreInstallEventHandler
{
	[kCura.EventHandler.CustomAttributes.Description("Pre Install EventHandler")]
	[System.Runtime.InteropServices.Guid("1af2e7b0-5a55-4c04-a10b-531ea78927da")]
	public class PreInstallEventHandler : kCura.EventHandler.PreInstallEventHandler
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


				//Use version properties to alter your workflow
				if (CurrentVersion != null && CurrentVersion < new Version("2.0.0.0"))
				{
				}

				//Dirty flag indicates that the application has been unlocked since the previous install, thus the validity of the application can't be determined
				if (Dirty)
				{
				}

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