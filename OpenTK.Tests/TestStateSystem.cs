using System;
using NUnit.Framework;
using OpenTK.GameStructure;

namespace OpenTK.Tests
{
    [TestFixture]
    public class TestStateSystem
    {
        [Test]
        public void TestAddedStateExists()
        {
            var stateSystem = new StateSystem();
            stateSystem.AddState("splash", new SplashScreenState(stateSystem));
        }
    }
}
