using System.Collections;
using System.Collections.Generic;
using Colors;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Editor
{
    public class CMYKColorTests
    {
        [Test]
        public void _TEST_EQUAL()
        {
            CMYKColor cc1 = null;
            CMYKColor cc2 = null;
            Assert.IsTrue(cc1 == cc2);
            cc1 = new CMYKColor(1,1,1,1);
            Assert.IsFalse(cc1 == cc2);
        }

        [Test]
        public void _TEST_SIMPLE_COLORS()
        {
            CMYKColor cc = new CMYKColor(Color.red);
            Assert.AreEqual(new CMYKColor(0,1,1,0), cc);
            cc = new CMYKColor(Color.cyan);
            Assert.AreEqual(new CMYKColor(1,0,0,0), cc);
        }

        [Test]
        public void _TEST_TO_UNITY_COLORS()
        {
            CMYKColor cc = new CMYKColor(1,0,0,0);
            Assert.AreEqual(Color.cyan, cc.ToUnityColor());
            cc = new CMYKColor(Color.red);
            Assert.AreEqual(Color.red, cc.ToUnityColor());
        }

        [Test]
        public void _TEST_SIMPLE_COMPLEX_COLORS()
        {
            CMYKColor cc = new CMYKColor(Color.red);
            Assert.AreEqual(new CMYKColor(0,1,1,0), cc);
        }
        [Test]
        public void _TEST_MIX_COLORS()
        {
            Assert.AreEqual(Color.magenta, CMYKColor.CombineColors(new[] {new KeyValuePair<Color, float>(Color.red, 1f), 
                new KeyValuePair<Color, float>(Color.blue,1f)}));
            Assert.AreEqual(1, CMYKColor.CombineColors(new[] {new KeyValuePair<Color, float>(Color.red, 1f), 
                new KeyValuePair<Color, float>(Color.blue,1f)}).a);
            Assert.AreEqual(Color.cyan, CMYKColor.CombineColors(new[] {new KeyValuePair<Color, float>(Color.green, 1f), 
                new KeyValuePair<Color, float>(Color.blue,1f)}));
        }


        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator TestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }
    }
}