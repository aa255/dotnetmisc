using System.Net;
using System.Net.Sockets;
using DetectPortScanner;
using SharpPcap;
using SharpPcap.LibPcap;

namespace DetectPortScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var detectPortScanner = new DetectPortScanner();
            detectPortScanner.Start();
        }
    }
}