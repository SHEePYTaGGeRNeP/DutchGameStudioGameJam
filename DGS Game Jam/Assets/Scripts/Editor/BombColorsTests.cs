using System.Collections;
using System.Collections.Generic;
using Colors;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Editor
{
    public class BombColorTests
    {
        [Test]
        public void _CAN_CREATE()
        {
            BombColors bc = new BombColors(new Dictionary<Color, float>() {{Color.red, 1f}, {Color.blue, 1f}});
            Assert.NotNull(bc);
        }

        [Test]
        public void _THRUST_WHITE()
        {
            BombColors bc = new BombColors(new Dictionary<Color, float>() {{Color.red, 1f}, {Color.blue, 1f}, {Color.green, 1f}});
            Assert.AreEqual(Color.white, bc.CurrentColorValue);
            Assert.AreEqual(3f, bc.CurrentThrust, 0.0001);
        }
    }
}