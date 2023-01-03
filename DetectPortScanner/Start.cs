using System.Net;
using SharpPcap;
using SharpPcap.LibPcap;

namespace DetectPortScanner
{
    public class DetectPortScanner
    {
        private const string PORTSCANHASH = "450000400000400040067";
        private readonly List<LibPcapLiveDevice> _ethernetDevices = LibPcapLiveDeviceList.Instance.ToList();

        public void Start()
        {
            if (_ethernetDevices.Count == 0)
            {
                Console.WriteLine("No Ethernet devices found.");
                return;
            }

            var device = _ethernetDevices[0];
            device.Open();
            device.OnPacketArrival += Device_OnPacketArrival;
            device.StartCapture();
                Console.ReadLine();
            device.StopCapture();
            device.Close();
        }

        private byte[] packetData;
        private void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            packetData = e.GetPacket().Data;

            if (packetData.FindValueFromHash(PORTSCANHASH) == false)
                return;

            Console.WriteLine(packetData.GetIP() + ": SCAN PORT - " + packetData.GetPort());
        }
    }
}