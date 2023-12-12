using kCura.Agent;
using Relativity.API;
using Relativity.ObjectManager.V1.Interfaces;
using System;
using System.Net;

namespace Relativity.Agent
{
	[kCura.Agent.CustomAttributes.Name("Agent Name")]
	[System.Runtime.InteropServices.Guid("E19FE53D-1611-4972-ADFD-F237AE20BEC9")]
	public class RelativityAgent : AgentBase
	{
		/// <summary>
		/// Agent logic goes here
		/// </summary>
		public override void Execute()
		{
			IAPILog logger = Helper.GetLoggerFactory().GetLogger();

			try
			{
				// Update Security Protocol
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

				//Get the current Agent artifactID
				int agentArtifactId = AgentID;

				//Get a dbContext for the EDDS database
				IDBContext eddsDbContext = Helper.GetDBContext(-1);

				//Get a dbContext for the workspace database
				//int workspaceArtifactId = 01010101; // Update it with the real 
				//IDBContext workspaceDbContext = Helper.GetDBContext(workspaceArtifactId);

				//Get GUID for an artifact
				//int testArtifactId = 10101010;
				//Guid guidForTestArtifactId = Helper.GetGuid(workspaceArtifactId, testArtifactId);

				//Display a message in Agents Tab and Windows Event Viewer
				RaiseMessage("The current time is: " + DateTime.Now.ToLongTimeString(), 1);

				// To interact with Relativity, refer to the APIs documented on platform.relativity.com.
				// The Object Manager is one of the most popular APIs.
				// Relativity Services API (RSAPI) is obsolete and will not work.
				using (IObjectManager objectManager = this.Helper.GetServicesManager().CreateProxy<IObjectManager>(ExecutionIdentity.CurrentUser))
				{

				}

				logger.LogVerbose("Log information throughout execution.");
			}
			catch (Exception ex)
			{
				//Your Agent caught an exception
				logger.LogError(ex, "There was an exception.");
				RaiseError(ex.Message, ex.Message);
			}
		}

		/// <summary>
		/// Returns the name of agent
		/// </summary>
		public override string Name
		{
			get
			{
				return "Agent Name";
			}
		}
	}
}