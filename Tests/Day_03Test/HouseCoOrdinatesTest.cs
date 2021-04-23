using System;
using Day_03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day_03Test
{
    [TestClass]
    public class HouseCoOrdinatesTest
    {
        [TestMethod]
        public void GetHouseCoOrdinatesNorthValidTest()
        {
            //--Arrange
            var direction = '^';
            var previous = new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = 0
            };
            var expected = new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = 1
            };
            HouseCoOrdinates actual = new HouseCoOrdinates();

            //--Act
            actual = actual.GetHouseCoOrdinates(previous,direction);

            //--Assert
            Assert.AreEqual(expected.XAxis, actual.XAxis);
            Assert.AreEqual(expected.YAxis, actual.YAxis);
        }

        [TestMethod]
        public void GetHouseCoOrdinatesSouthValidTest()
        {
            //--Arrange
            var direction = 'v';
            var previous = new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = 0
            };
            var expected = new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = -1
            };
            HouseCoOrdinates actual = new HouseCoOrdinates();

            //--Act
            actual = actual.GetHouseCoOrdinates(previous, direction);

            //--Assert
            Assert.AreEqual(expected.XAxis, actual.XAxis);
            Assert.AreEqual(expected.YAxis, actual.YAxis);
        }

        [TestMethod]
        public void GetHouseCoOrdinatesEastValidTest()
        {
            //--Arrange
            var direction = '>';
            var previous = new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = 0
            };
            var expected = new HouseCoOrdinates()
            {
                XAxis = 1,
                YAxis = 0
            };
            HouseCoOrdinates actual = new HouseCoOrdinates();

            //--Act
            actual = actual.GetHouseCoOrdinates(previous, direction);

            //--Assert
            Assert.AreEqual(expected.XAxis, actual.XAxis);
            Assert.AreEqual(expected.YAxis, actual.YAxis);
        }

        [TestMethod]
        public void GetHouseCoOrdinatesWestValidTest()
        {
            //--Arrange
            var direction = '<';
            var previous = new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = 0
            };
            var expected = new HouseCoOrdinates()
            {
                XAxis = -1,
                YAxis = 0
            };
            HouseCoOrdinates actual = new HouseCoOrdinates();

            //--Act
            actual = actual.GetHouseCoOrdinates(previous, direction);

            //--Assert
            Assert.AreEqual(expected.XAxis, actual.XAxis);
            Assert.AreEqual(expected.YAxis, actual.YAxis);
        }
    }
}
