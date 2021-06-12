// HttpProxy.csx - Simple HTTP proxy 
// Expose methods like WriteLine and WrittePackets
using static System.Console;
using static CANAPE.Cli.ConsoleUtils;

// Create proxy template
var template=new HttpProxyTemplate();
template.LocalPort=80;

// Create proxy instance and start 
var service= template.Create();
service.start();

WriteLine("Create {0}",service);
WriteLine("Press Enter to Exit");
ReadLine();
service.Stop;

//Dump Packets
var packets=service.Packets;
WriteLine("Captured {0} packets:",packets.Count);
WritePackets(packets);