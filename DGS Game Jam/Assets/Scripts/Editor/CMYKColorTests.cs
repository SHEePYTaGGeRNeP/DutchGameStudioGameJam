using System.Collections;
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
            Assert.AreEqual(new CMYKColor(0,100,100,0), cc);
        }

        [Test]
        public void _TEST_TO_UNITY_COLORS()
        {
            CMYKColor cc = new CMYKColor(Color.red);
            Assert.AreEqual(Color.red, cc.ToUnityColor());
        }

        [Test]
        public void _TEST_SIMPLE_COMPLEX_COLORS()
        {
            CMYKColor cc = new CMYKColor(Color.red);
            Assert.AreEqual(new CMYKColor(0,100,100,0), cc);
        }


        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator ChimcalColorTestsWithEnueratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }
    }
}