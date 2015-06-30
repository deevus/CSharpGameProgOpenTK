using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK.GameStructure;

namespace OpenTK.Tests
{
    [TestClass]
    public class TestStateSystem
    {
        [TestMethod]
        public void TestAddedStateExists()
        {
            var stateSystem = new StateSystem();
            stateSystem.AddState("splash", new SplashScreenState(stateSystem));
        }
    }
}
