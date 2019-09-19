// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

//using CommunicationsLibrary.STXDataSocketServer.Definitions.STXDataSocketServerDefs;



namespace CommunicationsUISupportLibrary
{
	namespace publicationsPosting
	{
		
		[Serializable()]public class PublicationVariableDefinitionData
		{
			
#region  < DATAMEMBERS >
			
			[Serializable()]public enum variableSimulationStatus
			{
				stopped,
				running
			}
			
			private string _variableName;
			private CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.PublicationVariableDataType _publicationVariableDAtaType;
			private bool _isSimulationHandlerCreated;
			private variableSimulationStatus _dataUPDATESimulationStatus;
			private variableSimulationStatus _dataRESETSimulationStatus;
			
			
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public PublicationVariableDefinitionData(string variableName, CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.PublicationVariableDataType dataType)
			{
				this._variableName = variableName;
				this._publicationVariableDAtaType = dataType;
				this._isSimulationHandlerCreated = false;
				this._dataUPDATESimulationStatus = variableSimulationStatus.stopped;
			}
			
#endregion
			
#region  < PROPERTIES >
			
public string VariableName
			{
				get
				{
					return this._variableName;
				}
			}
			
public CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.PublicationVariableDataType DataType
			{
				get
				{
					return this._publicationVariableDAtaType;
				}
			}
			
public bool SimulationHandlerExists
			{
				get
				{
					return this._isSimulationHandlerCreated;
				}
				set
				{
					this._isSimulationHandlerCreated = value;
				}
			}
			
public variableSimulationStatus DataUPDATESimulationStatus
			{
				get
				{
					return this._dataUPDATESimulationStatus;
				}
				set
				{
					this._dataUPDATESimulationStatus = value;
				}
			}
			
public variableSimulationStatus DataRESETSimulationStatus
			{
				get
				{
					return this._dataRESETSimulationStatus;
				}
				set
				{
					this._dataRESETSimulationStatus = value;
				}
			}
			
#endregion
			
		}
		
	}
	
	
}
