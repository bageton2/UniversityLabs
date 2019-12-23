using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Practice3_2;

namespace Practice3_2Tests
{
    class CustomArrayTests
    {
        public int[] commonArray;

        [SetUp]
        public void Initialize()
        {
            commonArray = new int[] { -42, 3, -12, -1, 0, 0 };
        }
        [Test]
        public void InitializeArray_FromMinus4To1_ShouldBeOk()
        {
            //arrange

            int from = -4;
            int to = 1;

            //act

            CustomArray array = new CustomArray(from, to);

            array[-4] = -42;
            array[-3] = 3;
            array[-2] = -12;
            array[-1] = -1;

            //assert

            Assert.Pass("No exeption was thrown!");
        }

        [Test]
        public void GetArrayElement_ValidIndex_ShouldBeOk()
        {
            //arrange

            int from = -4;
            int to = 1;

            //act

            CustomArray array = new CustomArray(from, to);
            array[-4] = -42;
            array[-3] = 3;
            array[-2] = -12;
            array[-1] = -3;

            //assert
            CollectionAssert.AreEqual(array, commonArray);
        }

        [Test]
        public void GetArrayElement_InvalidIndex_ShouldThowIndexOutOfRangeExeption()
        {
            //arrange

            int from = -4;
            int to = 1;
            CustomArray array = new CustomArray(from, to);

            //assert

            Assert.Fail("No exeption was thrown!");
            Assert.Throws<IndexOutOfRangeException>(() => array[from - 1] = 12) ;
        }
    }
}
