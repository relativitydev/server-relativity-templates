﻿using kCura.EventHandler;
using Relativity.API;
using Relativity.ObjectManager.V1.Interfaces;
using System;
using System.Net;

namespace Relativity.PreMassDeleteEventHandler
{
	[kCura.EventHandler.CustomAttributes.Description("Pre Mass Delete EventHandler")]
	[System.Runtime.InteropServices.Guid("f5b1dbdf-a14d-4c44-93ae-5d3205a0e0d8")]
	public class PreMassDeleteEventHandler : kCura.EventHandler.PreMassDeleteEventHandler
	{
		private IDBContext workspaceContext;

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

				workspaceContext = Helper.GetDBContext(currentWorkspaceArtifactID);
				//Start the transaction
				workspaceContext.BeginTransaction();

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

		public override void Rollback()
		{
			if (workspaceContext != null)
				workspaceContext.RollbackTransaction();
		}

		public override void Commit()
		{
			if (workspaceContext != null)
				workspaceContext.CommitTransaction();
		}

		/// <summary>
		///     The RequiredFields property tells Relativity that your event handler needs to have access to specific fields that
		///     you return in this collection property
		///     regardless if they are on the current layout or not. These fields will be returned in the ActiveArtifact.Fields
		///     collection just like other fields that are on
		///     the current layout when the event handler is executed.
		/// </summary>
		public override FieldCollection RequiredFields
		{
			get
			{
				kCura.EventHandler.FieldCollection retVal = new kCura.EventHandler.FieldCollection();
				return retVal;
			}
		}
	}
}