using Microsoft.VisualStudio.TestTools.UnitTesting;
using Random.PinGenerator.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomPinGeneratorUnitTests
{
    [TestClass]
    public class RandomPinGenerator_Should
    {
        private RandomPinGenerator _randomPinGenerator;

        [TestInitialize]
        public void TestStartUp()
        {
            _randomPinGenerator = new RandomPinGenerator();
        }

        [TestMethod]
        public void ReturnBatchSizeOfPins()
        {
            // Arrange
            var batchSize = 1000;
            var pinLength = 4;

            // Act
            var pinHash = _randomPinGenerator.GetPins(batchSize, pinLength);

            // Assert
            Assert.AreEqual(batchSize, pinHash.Count());
            Assert.IsInstanceOfType(pinHash, typeof(HashSet<string>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BatchSizeShouldNotExceedMaxCombinationsForPin()
        {
            // Arrange
            // Arrange
            var batchSize = 100000;
            var pinLength = 4;

            // Act: We can mock the Func<> params
            var result = _randomPinGenerator.GetPins(batchSize, pinLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BatchSizeInBoundsOfMaxCombinationsForPin()
        {
            // Arrange
            // Arrange
            var batchSize = 10000;
            var pinLength = 4;

            // Act: We can mock the Func<> params
            var result = _randomPinGenerator.GetPins(batchSize, pinLength);
        }
    }
}
