using IPObtainerApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IPObtainerApp_Tests
{
    [TestClass]
    public class IPv4AddressTests
    {
        [TestMethod]
        public void IPv4Address_CorrectIpnputTest()
        {
            string inputAddressAsString = "192.168.0.1";
            byte[] inputAddressAsBytesArray = { 192, 168, 0, 1 };

            var addressEntity = new IPv4Address(inputAddressAsString);

            Assert.AreEqual(inputAddressAsBytesArray[0], addressEntity.Byte1);
            Assert.AreEqual(inputAddressAsBytesArray[1], addressEntity.Byte2);
            Assert.AreEqual(inputAddressAsBytesArray[2], addressEntity.Byte3);
            Assert.AreEqual(inputAddressAsBytesArray[3], addressEntity.Byte4);
        }

        [TestMethod]
        public void IPv4Address_ZerosInputTest()
        {
            string inputAddressAsString = "0.0.0.0";
            byte[] inputAddressAsBytesArray = { 0, 0, 0, 0 };

            var addressEntity = new IPv4Address(inputAddressAsString);

            Assert.AreEqual(inputAddressAsBytesArray[0], addressEntity.Byte1);
            Assert.AreEqual(inputAddressAsBytesArray[1], addressEntity.Byte2);
            Assert.AreEqual(inputAddressAsBytesArray[2], addressEntity.Byte3);
            Assert.AreEqual(inputAddressAsBytesArray[3], addressEntity.Byte4);
        }

        [TestMethod]
        public void IPv4Address_BrokenInputTest()
        {
            string inputAddressAsString = "0..192.1";
            byte[] inputAddressAsBytesArray = { 0, 0, 192, 1 };

            var addressEntity = new IPv4Address(inputAddressAsString);

            Assert.AreEqual(inputAddressAsBytesArray[0], addressEntity.Byte1);
            Assert.AreEqual(inputAddressAsBytesArray[1], addressEntity.Byte2);
            Assert.AreEqual(inputAddressAsBytesArray[2], addressEntity.Byte3);
            Assert.AreEqual(inputAddressAsBytesArray[3], addressEntity.Byte4);
        }

        [TestMethod]
        public void IPv4Address_NotEnoughDataInputTest()
        {
            string inputAddressAsString = "0.192.1";
            byte[] inputAddressAsBytesArray = { 0, 192, 1 };

            var addressEntity = new IPv4Address(inputAddressAsString);

            Assert.AreEqual(inputAddressAsBytesArray[0], addressEntity.Byte1);
            Assert.AreEqual(inputAddressAsBytesArray[1], addressEntity.Byte2);
            Assert.AreEqual(inputAddressAsBytesArray[2], addressEntity.Byte3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The incoming string was empty")]
        public void IPv4Address_EmptyAddressInputTest()
        {
            string inputAddressAsString = string.Empty;

            new IPv4Address(inputAddressAsString);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The incoming string has incorrect format")]
        public void IPv4Address_IncorrectFormatInputTest()
        {
            string inputAddressAsString = "hello";

            new IPv4Address(inputAddressAsString);
        }
    }
}
