/*
PortFormatProxy.csx -Simple TCP port-forwarding proxy
Expose methods like WriteLine and WritePackets
*/
using static System.Console;
using static CANAPE.Cli.ConsoleUtils;

//Create a proxy template
var template= new FixedProxyTemplate();
template.LocalPort=255;
template.Host="www.nostarch.com";
template.port=80;

//Create the proxy instance
var service=template.Create();
service.Start();

WriteLine("Created {0}",service);
WriteLine("Press Enter to Exit");
ReadLine();
service.Stop();

//Dump Packets
var packets=service.Packets;
WriteLine("Captured {0} packets",packets.Count);
WritePackets(packets);