using Common;

namespace CommonComponentUnitTest
{
    [TestClass]
    public class ChangeSignalTestClass
    {
        /// <summary>
        /// Test method for testing sinal A
        /// </summary>
        [TestMethod]
        public void ChangeSignalATest()
        {
            SignalSystem signalSystem = new SignalSystem();
            signalSystem.ChangeSignal("A");
            Assert.AreEqual("Green", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
        } 
        /// </summary>        
        /// Test method for testing signal B
        /// </summary>
        [TestMethod]
        public void ChangeSignalBTest()
        {
            SignalSystem signalSystem = new SignalSystem();
            signalSystem.ChangeSignal("B");
            Assert.AreEqual("Red", signalSystem.a);
            Assert.AreEqual("Green", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
        }
        /// </summary>        
        /// Test method for testing signal C
        /// </summary>
        [TestMethod]
        public void ChangeSignalCTest()
        {
            SignalSystem signalSystem = new SignalSystem();
            signalSystem.ChangeSignal("C");
            Assert.AreEqual("Red", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Green", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
        }
        /// </summary>        
        /// Test method for testing signal D
        /// </summary>
        [TestMethod]
        public void ChangeSignalDTest()
        {
            SignalSystem signalSystem = new SignalSystem();
            signalSystem.ChangeSignal("D");
            Assert.AreEqual("Red", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Green", signalSystem.d);            
        }
        /// </summary>        
        /// Test method for testing ResetTest Method
        /// </summary>
        [TestMethod]
        public void ResetTest()
        {
            SignalSystem signalSystem = new SignalSystem();
            signalSystem.Reset();
            Assert.AreEqual("Green", signalSystem.a);
            Assert.AreEqual("Red", signalSystem.b);
            Assert.AreEqual("Red", signalSystem.c);
            Assert.AreEqual("Red", signalSystem.d);
            Assert.AreEqual<int>(10, signalSystem.atime);
            Assert.AreEqual<int>(10, signalSystem.btime);
            Assert.AreEqual<int>(10, signalSystem.ctime);
            Assert.AreEqual<int>(10, signalSystem.dtime);

        }
        }
    }