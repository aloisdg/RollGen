﻿using Ninject;
using NUnit.Framework;
using RollGen.Tests.Integration.Common;
using System;

namespace RollGen.Tests.Bootstrap.Modules
{
    [TestFixture]
    public class CoreModuleTests : IntegrationTests
    {
        [Test]
        public void DiceAreNotCreatedAsSingletons()
        {
            var dice1 = GetNewInstanceOf<Dice>();
            var dice2 = GetNewInstanceOf<Dice>();
            Assert.That(dice1, Is.Not.EqualTo(dice2));
        }

        [Test]
        public void RandomIsCreatedAsSingleton()
        {
            var random1 = GetNewInstanceOf<Random>();
            var random2 = GetNewInstanceOf<Random>();
            Assert.That(random1, Is.EqualTo(random2));
        }

        [Test]
        public void CannotInjectPartialRoll()
        {
            Assert.That(() => GetNewInstanceOf<PartialRoll>(), Throws.InstanceOf<ActivationException>());
        }
    }
}