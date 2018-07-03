using System.Collections;
using System.Collections.Generic;
using Colors;
using NUnit.Framework;
using Obstacles;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Editor
{
    public class WallTests
    {
        [Test]
        public void _CAN_CREATE()
        {
            Wall wall = new Wall(Color.red);
            Assert.NotNull(wall);
        }

        [Test]
        public void _CHECK_CAN_DESTROY()
        {
            Wall wall = new Wall(Color.red);
            Assert.IsTrue(wall.IsDestroyedByColor(Color.red));
            Assert.IsTrue(wall.IsDestroyedByColor(new Color(0.95f,0,0)));
            Assert.IsFalse(wall.IsDestroyedByColor(new Color(0.85f,0,0)));
            Assert.IsFalse(wall.IsDestroyedByColor(new Color(0.95f,0.05f,0.05f)));           
            
        }
    }
}