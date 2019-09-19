using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using UtilitiesLibrary.EventLoging;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using UtilitiesLibrary.EventLoging;
using System.Net.Sockets;

namespace CommunicationsLibrary.Utilities
{
    public sealed  class CommunicationsUtilities
    {

        /// <summary>
        /// Retrieves the active IP address of the current host
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetActiveIPAddress()
        {
            IPAddress address=null ;
            
            string ip = "";
             
            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipInterface = f.GetIPProperties();
                    if (ipInterface.GatewayAddresses.Count > 0)
                    {
                        foreach (UnicastIPAddressInformation unicastAddress in ipInterface.UnicastAddresses)
                        {
                            if ((unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) && (unicastAddress.IPv4Mask.ToString() != "0.0.0.0"))
                            {
                                ip = unicastAddress.Address.ToString();
                                break;
                            }                          
                        }
                    }
                }
            }
            address = IPAddress.Parse(ip);
            return address;

        }


        public static SortedList GetOpenTCPPorts()
        {

            SortedList OpenTCPPorts = new SortedList();

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            TcpConnectionInformation[] TCPconnections = properties.GetActiveTcpConnections();

            TcpConnectionInformation tcpConnectionInfo = default(TcpConnectionInformation);


            foreach (TcpConnectionInformation tempLoopVar_tcpConnectionInfo in TCPconnections)
            {
                tcpConnectionInfo = tempLoopVar_tcpConnectionInfo;
                if (!OpenTCPPorts.ContainsKey(tcpConnectionInfo.LocalEndPoint.Port))
                {
                    OpenTCPPorts.Add(tcpConnectionInfo.LocalEndPoint.Port, tcpConnectionInfo.LocalEndPoint.Port);
                }

                string localIP = tcpConnectionInfo.LocalEndPoint.Address.ToString();
                string remoteIP = tcpConnectionInfo.RemoteEndPoint.Address.ToString();
                if (localIP == remoteIP)
                {
                    if (!OpenTCPPorts.ContainsKey(tcpConnectionInfo.RemoteEndPoint.Port))
                    {
                        OpenTCPPorts.Add(tcpConnectionInfo.RemoteEndPoint.Port, tcpConnectionInfo.RemoteEndPoint.Port);
                    }
                }
            }

            System.Net.IPEndPoint[] endPoints = null;

            endPoints = properties.GetActiveTcpListeners();

            foreach (var IPEndPoint in endPoints)
            {
                if (!OpenTCPPorts.ContainsKey(IPEndPoint.Port))
                {
                    OpenTCPPorts.Add(IPEndPoint.Port, IPEndPoint.Port);
                }

            }

            endPoints = properties.GetActiveUdpListeners();

            foreach (var IPEndPoint in endPoints)
            {
                if (!OpenTCPPorts.ContainsKey(IPEndPoint.Port))
                {
                    OpenTCPPorts.Add(IPEndPoint.Port, IPEndPoint.Port);
                }
            }

            return OpenTCPPorts;


        }

        public static SortedList GetOpenTCPPortsInARangeOfPorts(int lowPortNumber, int uppperPortNumber)
        {
            int lowerLimit = 0;
            int upperLimit = 0;

            if (lowPortNumber <= uppperPortNumber)
            {
                lowerLimit = lowPortNumber;
                upperLimit = uppperPortNumber;
            }
            else
            {
                lowerLimit = uppperPortNumber;
                upperLimit = lowPortNumber;
            }

            SortedList OpenTCPPorts = new SortedList();

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] TCPconnections = properties.GetActiveTcpConnections();

            TcpConnectionInformation tcpConnectionInfo = default(TcpConnectionInformation);
            foreach (TcpConnectionInformation tempLoopVar_tcpConnectionInfo in TCPconnections)
            {
                tcpConnectionInfo = tempLoopVar_tcpConnectionInfo;

                if (tcpConnectionInfo.LocalEndPoint.Port >= lowerLimit & tcpConnectionInfo.LocalEndPoint.Port <= upperLimit)
                {
                    if (!OpenTCPPorts.ContainsKey(tcpConnectionInfo.LocalEndPoint.Port))
                    {
                        OpenTCPPorts.Add(tcpConnectionInfo.LocalEndPoint.Port, tcpConnectionInfo.LocalEndPoint.Port);
                    }
                }

            }

            System.Net.IPEndPoint[] endPoints = null;

            endPoints = properties.GetActiveTcpListeners();
            System.Net.IPEndPoint ep = default(System.Net.IPEndPoint);
            foreach (System.Net.IPEndPoint tempLoopVar_ep in endPoints)
            {
                ep = tempLoopVar_ep;
                if (ep.Port >= lowerLimit & ep.Port <= upperLimit)
                {
                    if (!OpenTCPPorts.ContainsKey(ep.Port))
                    {
                        OpenTCPPorts.Add(ep.Port, ep.Port);
                    }
                }

            }

            endPoints = properties.GetActiveUdpListeners();
            foreach (System.Net.IPEndPoint tempLoopVar_ep in endPoints)
            {
                ep = tempLoopVar_ep;
                if (ep.Port >= lowerLimit & ep.Port <= upperLimit)
                {
                    if (!OpenTCPPorts.ContainsKey(ep.Port))
                    {
                        OpenTCPPorts.Add(ep.Port, ep.Port);
                    }
                }
            }
            return OpenTCPPorts;
        }

        public static int GetFreeTCPPort(int startLookPortNumber)
        {
            SortedList list = default(SortedList);
            int port = 0;
            for (port = startLookPortNumber; port <= 65000; port++)
            {
                list = GetOpenTCPPorts();
                if (!list.ContainsKey(port))
                {
                    return port;
                }
            }
            return 0;
        }

        public static int GetFreeTCPPortOnPortsRange(int rangeInitialPortNumberLimit, int rangeFinalPortNumberLimit)
        {
            SortedList list = default(SortedList);
            int port = 0;
            for (port = rangeInitialPortNumberLimit; port <= rangeFinalPortNumberLimit; port++)
            {
                list = GetOpenTCPPorts();
                if (!list.ContainsKey(port))
                {
                    return port;
                }
            }
            throw (new Exception("Can\'t found a free port in the range from " + System.Convert.ToString(rangeInitialPortNumberLimit) + " to " + System.Convert.ToString(rangeFinalPortNumberLimit) + ""));
        }

        public static DataTable GetNetworkingStatiticsTable(NetworkInterfaceComponent version)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipStat = null;

            DataTable statsTable = new DataTable("Network Statistics");
            statsTable.Columns.Add("Stats Group", System.Type.GetType("System.String"));
            statsTable.Columns.Add("Item", System.Type.GetType("System.String"));
            statsTable.Columns.Add("Stats", System.Type.GetType("System.String"));


            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                    ipStat = properties.GetIPv4GlobalStatistics();
                    break;
                case NetworkInterfaceComponent.IPv6:
                    ipStat = properties.GetIPv6GlobalStatistics();
                    break;
                default:
                    throw (new Exception("Invalid version for NetworkInterfaceComponent"));
            }

            DataRow row = default(DataRow);
            //*******************************************
            // GENERAL STATISTICS
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "General";
            row["Item"] = "Forwarding enabled";
            row["Stats"] = ipStat.ForwardingEnabled.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "General";
            row["Item"] = "No. Interfaces";
            row["Stats"] = ipStat.NumberOfInterfaces.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "General";
            row["Item"] = "No. IP addresses";
            row["Stats"] = ipStat.NumberOfIPAddresses.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "General";
            row["Item"] = "No. Routes";
            row["Stats"] = ipStat.NumberOfRoutes.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "General";
            row["Item"] = "Default TTL";
            row["Stats"] = ipStat.DefaultTtl.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "General";
            row["Item"] = "Active/Open TCP Ports";
            SortedList list = GetOpenTCPPorts();
            row["Stats"] = list.Count;
            statsTable.Rows.Add(row);

            //*******************************************
            // INBOUND PACKET DATA
            row = statsTable.NewRow();
            row["Stats Group"] = "";
            row["Item"] = "";
            row["Stats"] = "";
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Received";
            row["Stats"] = ipStat.ReceivedPackets.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Forwarded";
            row["Stats"] = ipStat.ReceivedPacketsForwarded.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Delivered";
            row["Stats"] = ipStat.ReceivedPacketsDelivered.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Discarded";
            row["Stats"] = ipStat.ReceivedPacketsDiscarded.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Header Errors";
            row["Stats"] = ipStat.ReceivedPacketsWithHeadersErrors.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Address Errors";
            row["Stats"] = ipStat.ReceivedPacketsWithAddressErrors.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Inbound Packet Data";
            row["Item"] = "Unknown Protocol Errors";
            row["Stats"] = ipStat.ReceivedPacketsWithUnknownProtocol.ToString();
            statsTable.Rows.Add(row);

            //*******************************************
            //OUTBOUND PACKET DATA
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "";
            row["Item"] = "";
            row["Stats"] = "";
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Outbound Packet Data";
            row["Item"] = "Requested";
            row["Stats"] = ipStat.OutputPacketRequests.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Outbound Packet Data";
            row["Item"] = "Discarded";
            row["Stats"] = ipStat.OutputPacketsDiscarded.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Outbound Packet Data";
            row["Item"] = "No Routing Discards";
            row["Stats"] = ipStat.OutputPacketsWithNoRoute.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Outbound Packet Data";
            row["Item"] = "Routing Entry Discards";
            row["Stats"] = ipStat.OutputPacketRoutingDiscards.ToString();
            statsTable.Rows.Add(row);

            //*******************************************
            //REASSEMBLY PACKET DATA
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "";
            row["Item"] = "";
            row["Stats"] = "";
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Reassembly Data";
            row["Item"] = "Reassembly Timeout";
            row["Stats"] = ipStat.PacketReassemblyTimeout.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Reassembly Data";
            row["Item"] = "Reassemblies Required";
            row["Stats"] = ipStat.PacketReassembliesRequired.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Reassembly Data";
            row["Item"] = "Packets Reassembled";
            row["Stats"] = ipStat.PacketsReassembled.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Reassembly Data";
            row["Item"] = "Packets Fragmented";
            row["Stats"] = ipStat.PacketsFragmented.ToString();
            statsTable.Rows.Add(row);
            //-------------------------------------------
            row = statsTable.NewRow();
            row["Stats Group"] = "Reassembly Data";
            row["Item"] = "Fragment Failures";
            row["Stats"] = ipStat.PacketFragmentFailures.ToString();
            statsTable.Rows.Add(row);




            return statsTable;

        }

        public static IPEndPoint ResolveIPAddressForHostName(string hostName, Int32 portOnHost)
        {
            IPEndPoint hostEndPoint = null;

           
            IPHostEntry theIpHostEntry = Dns.GetHostEntry(hostName);        
             
            IPAddress[] serverAddressList = theIpHostEntry.AddressList;

            bool gotIpv4Address = false;
            AddressFamily addressFamily;
            Int32 count = -1;
            for (int i = 0; i < serverAddressList.Length; i++)
            {
                count++;
                addressFamily = serverAddressList[i].AddressFamily;
                if (addressFamily == AddressFamily.InterNetwork)
                {
                    gotIpv4Address = true;
                    i = serverAddressList.Length;
                }
            }

            if (gotIpv4Address == false)
            {
                throw new Exception("Could not resolve name to IPv4 address. Need IP address. Failure!");
            }
            else
            {
                hostEndPoint = new IPEndPoint(serverAddressList[count], portOnHost);
            }        
           


            return hostEndPoint;
        }


    }
}
