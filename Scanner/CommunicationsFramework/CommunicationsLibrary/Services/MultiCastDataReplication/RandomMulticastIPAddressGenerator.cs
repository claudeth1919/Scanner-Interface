using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;

	
	namespace CommunicationsLibrary
	{
		namespace Services.MultiCastDataReplication
		{
			
			public class RandomMulticastIPAddressGenerator
			{
				
				
#region  <  CLASS INFORMATION >
				// range for multiCast IpAddress
				// 224.0.0.0 - 239.127.255.255
#endregion
				
#region  < DATA MEMBERS >
				private static RandomMulticastIPAddressGenerator _RandomIPAddressGenerator;
			
			private Hashtable _tableOfGeneratedIPAddresses;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			private RandomMulticastIPAddressGenerator()
			{
				this._tableOfGeneratedIPAddresses = new Hashtable();
			}
			
#endregion
			
#region  < PRIVATE METHODS  >
			
			private string Get1stMulticastIPAddressOctet()
			{
				return "255";
			}
			
			private string Get2ndMultiCastIPAddressOctet()
			{
				int _2ndSeg = 0;
				Random random = new Random();
				_2ndSeg = random.Next(1, 255);
				string octet = System.Convert.ToString(_2ndSeg);
				return octet;
			}
			
			private string Get3rdMulticastIPAddressOctet()
			{
				int _3rdSeg = 0;
				Random random = new Random();
				_3rdSeg = random.Next(1, 127);
				string octet = System.Convert.ToString(_3rdSeg);
				return octet;
			}
			
			private string Get4thMulticastIPAddressOctet()
			{
				int _4thSeg = 0;
				Random random = new Random();
				_4thSeg = random.Next(224, 238);
				string octet = System.Convert.ToString(_4thSeg);
				return octet;
			}
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			public static RandomMulticastIPAddressGenerator GetInstance()
			{
				if (_RandomIPAddressGenerator == null)
				{
					_RandomIPAddressGenerator = new RandomMulticastIPAddressGenerator();
				}
				return _RandomIPAddressGenerator;
			}
			
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public string GetRandomMultiCastIPAsString()
			{
				bool validIP = false;
				string ipAddress = "";
				
				string _4thOctet = "";
				string _3rdOctet = "";
				string _2ndOctet = "";
				string _1stOctet = "";
				
				while (!validIP)
				{
					
					_4thOctet = this.Get4thMulticastIPAddressOctet();
					_3rdOctet = this.Get3rdMulticastIPAddressOctet();
					_2ndOctet = this.Get4thMulticastIPAddressOctet();
					_1stOctet = this.Get1stMulticastIPAddressOctet();
					
					ipAddress = _4thOctet + "." + _3rdOctet + "." + _2ndOctet + "." + _1stOctet;
					
					if (!this._tableOfGeneratedIPAddresses.ContainsKey(ipAddress))
					{
						this._tableOfGeneratedIPAddresses.Add(ipAddress, ipAddress);
						validIP = true;
						return ipAddress;
					}
					System.Threading.Thread.Sleep(5);
				}
				return ipAddress;
			}
			
#endregion
			
			
			
			
		}
		
		
	}
	
}
