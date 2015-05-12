using System;
using SpriteSheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace UnitTestProject1
{
    [TestClass]

    public class UnitTest1
    {


        MySprite bryson = null;
        [TestInitialize]
        public void Init()
        { 
        bryson = new MySprite(Environment.CurrentDirectory+@"\foo.png");
        }


        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(@"foo.png", bryson.FileName);
            Assert.AreEqual(0, bryson.Width);
            Assert.AreEqual(0, bryson.Height);
            Assert.AreEqual(0,bryson.X);
            Assert.AreEqual(0, bryson.Y);
           


        }


        [TestMethod]
        public void Width()
        { 
        bryson.Width = 100;
        
        Assert.AreEqual(100, bryson.Width);
        
        }
        [TestMethod]
        public void Height()
        { 
            bryson.Height = 56;
            Assert.AreEqual(56, bryson.Height);
        }

        [TestMethod]
        public void X()
        {
            bryson.X = 6;
            Assert.AreEqual(6, bryson.X);
        }
        [TestMethod]
        public void Y()
        {
            bryson.Y = 556;
            Assert.AreEqual(556, bryson.Y);
        }

        
    }
}
