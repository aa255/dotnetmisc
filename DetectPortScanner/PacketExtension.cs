namespace DetectPortScanner
{
    public static class PacketExtension
    {
        public static bool FindValueFromHash(this byte[] packet, string hash)
        {
            string packetString = BitConverter.ToString(packet);
            packetString = packetString.ToLower();
            packetString = packetString.Replace("-", string.Empty);

            if (packetString.Contains(hash))
                return true;
            return false;
        }

        public static bool FindValueFromString(this byte[] packet, string valueToFind)
        {
            return System.Text.Encoding.ASCII.GetString(packet).Contains(valueToFind);
        }

        public static string GetIP(this byte[] packet)
        {
            return packet[26] + "." + packet[27] + "." + packet[28] + "." + packet[29];
        }

        public static int GetPort(this byte[] packet)
        {
            return Convert.ToInt32(Convert.ToHexString(new byte[] { packet[36], packet[37] }), 16);
        }

        public static string GetString(this byte[] packet)
        {
            return BitConverter.ToString(packet);
        }
    }
}