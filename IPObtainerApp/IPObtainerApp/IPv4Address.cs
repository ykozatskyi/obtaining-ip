using System;

namespace IPObtainerApp
{
    public struct IPv4Address
    {
        public byte Byte1 { get; private set; }
        public byte Byte2 { get; private set; }
        public byte Byte3 { get; private set; }
        public byte Byte4 { get; private set; }

        private readonly string _address;

        /// <summary>
        /// Create a new instance of IpAddress class
        /// </summary>
        /// <param name="address">Required</param>
        public IPv4Address(string address)
        {
            Byte1 = 0;
            Byte2 = 0;
            Byte3 = 0;
            Byte4 = 0;
            _address = address;

            Initialize();
        }

        /// <summary>
        /// Initialize class properties with given parameters
        /// </summary>
        private void Initialize()
        {
            if (_address == null || _address.Length == 0)
                throw new Exception("The incoming string was empty");

            var splitAddressResult = SplitAddress();

            Byte1 = splitAddressResult[0];
            Byte2 = splitAddressResult[1];
            Byte3 = splitAddressResult[2];
            Byte4 = splitAddressResult[3];
        }

        /// <summary>
        /// Split given ip adress to bytes. Same as _address.Split('.')
        /// </summary>
        /// <returns></returns>
        private byte[] SplitAddress()
        {
            int byteIndex = 0;
            int charIndex = 0;
            char[] byteBuffer = new char[3];
            byte[] result = new byte[4];

            for (int i = 0; i < _address.Length; i++)
            {
                if (_address[i] >= Constants.Char_0 && _address[i] <= Constants.Char_9)
                {
                    byteBuffer[charIndex] = _address[i];
                    charIndex++;
                }
                else if (_address[i] == Constants.Char_Dot)
                {
                    if (byte.TryParse(new string(byteBuffer), out result[byteIndex]))
                        byteBuffer = new char[3];

                    charIndex = 0;
                    byteIndex++;
                }
                else
                    throw new Exception("The incoming string has incorrect format");
            }

            //takeover the last byte because ip address is not ending by the dot 
            byte.TryParse(new string(byteBuffer), out result[byteIndex]);

            return result;
        }
    }
}
