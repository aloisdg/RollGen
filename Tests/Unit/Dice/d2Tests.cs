﻿using System;
using D20Dice.Dice;
using D20Dice.RandomWrappers;
using Moq;
using NUnit.Framework;

namespace D20Dice.Test.Unit.Dice
{
    [TestFixture]
    public class d2Tests
    {
        private const Int32 MIN = 1;
        private const Int32 TWICE = 2;

        private IDice dice;
        private Mock<IRandomWrapper> mockRandom;

        [SetUp]
        public void Setup()
        {
            mockRandom = new Mock<IRandomWrapper>();
            dice = new CoreDice(mockRandom.Object);
        }

        [Test]
        public void Default()
        {
            dice.d2();
            mockRandom.Verify(r => r.Next(2), Times.Once());
        }

        [Test]
        public void Minimum()
        {
            var roll = dice.d2();
            Assert.That(roll, Is.EqualTo(MIN));
        }

        [Test]
        public void Quantity()
        {
            dice.d2(TWICE);
            mockRandom.Verify(r => r.Next(2), Times.Exactly(TWICE));
        }

        [Test]
        public void Bonus()
        {
            var roll = dice.d2(bonus: 1);
            Assert.That(roll, Is.EqualTo(MIN + 1));
        }

        [Test]
        public void QuantityAndBonus()
        {
            var roll = dice.d2(TWICE, 1);
            mockRandom.Verify(r => r.Next(2), Times.Exactly(TWICE));
            Assert.That(roll, Is.EqualTo(MIN * TWICE + 1));
        }
    }
}