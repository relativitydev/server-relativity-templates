﻿using Relativity.API;
using Relativity.ObjectManager.V1.Interfaces;
using Relativity.ObjectManager.V1.Models;
using System;

namespace Helpers.ObjectManager
{
	public class ArtifactQueries
	{
		//Do not convert to async
		public Boolean DoesUserHaveAccessToArtifact(IServicesMgr svcMgr, ExecutionIdentity identity, Int32 workspaceArtifactID, Guid guid, String artifactTypeName)
		{
			Boolean result = DoesUserHaveAccessToRdoByType(svcMgr, identity, workspaceArtifactID, guid, artifactTypeName);
			return result;
		}

		//Do not convert to async
		public Boolean DoesUserHaveAccessToRdoByType(IServicesMgr svcMgr, ExecutionIdentity identity, Int32 workspaceArtifactID, Guid guid, String artifactTypeName)
		{
			bool res = false;
			using (IObjectManager objectManager = svcMgr.CreateProxy<IObjectManager>(identity))
			{
				ReadRequest readRequest = new ReadRequest
				{
					Object = new RelativityObjectRef
					{
						Guid = guid
					},
				};
				try
				{
					ReadResult readResult = objectManager.ReadAsync(workspaceArtifactID, readRequest).Result;
					res = true;
				}
				catch (Exception ex)
				{
					res = false;
				}
			}

			return res;
		}
	}
}
