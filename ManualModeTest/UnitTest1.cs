using TrafficManagementSystem;

namespace ManualModeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ManualModeATest()
        {

            // Arrange
            var signalSystem = new SignalSystem();

            // Act
            ManualMode.manual("A", signalSystem);

            // Assert
            Assert.AreEqual("Green", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
        }

        // testing for signal B
        [TestMethod]
        public void ManualModeBTest()
        {

            // Arrange
            var signalSystem = new SignalSystem();

            // Act
            ManualMode.manual("B", signalSystem);

            // Assert
            Assert.AreEqual("Red", signalSystem.a);
            Assert.AreEqual("Green", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
        }

        // testing for signal C
        [TestMethod]
        public void ManualModeCTest()
        {

            // Arrange
            var signalSystem = new SignalSystem();

            // Act
            ManualMode.manual("C", signalSystem);

            // Assert
            Assert.AreEqual("Red", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Green", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
        }

        // testing for signal D
        [TestMethod]
        public void ManualModeDTest()
        {

            // Arrange
            var signalSystem = new SignalSystem();

            // Act
            ManualMode.manual("D", signalSystem);

            // Assert
            Assert.AreEqual("Red", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Green", signalSystem.d);
        }
    }
}