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
            BombColors bc =
                new BombColors(new Dictionary<Color, float>() {{Color.red, 1f}, {Color.blue, 1f}, {Color.green, 1f}});
            Assert.AreEqual(Color.white, bc.CurrentColorValue);
            Assert.AreEqual(3f, bc.CurrentThrust, 0.0001);
        }

        [Test]
        public void _THRUST_NaN()
        {
            BombColors bc =
                new BombColors(new Dictionary<Color, float>() {{Color.red, 0f}, {Color.blue, 0f}, {Color.green, 0f}});
            Assert.AreEqual(Color.black, bc.CurrentColorValue);
            Assert.AreEqual(0, bc.CurrentThrust);
        }

        [Test]
        public void _THRUST_EVENT()
        {
            BombColors bc =
                new BombColors(new Dictionary<Color, float>() {{Color.red, 1f}, {Color.blue, 1f}, {Color.green, 1f}});
            int test = 0;
            bc.OnEmpty += (sender, args) => { test = 1; };
            for (int i = 0; i < 100; i++)
            {
                bc.DecreaseAll(0.1f);
            }
            Assert.AreEqual(1, test);
        }
    }
}