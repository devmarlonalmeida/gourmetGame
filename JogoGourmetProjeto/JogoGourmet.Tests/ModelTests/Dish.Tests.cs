using Microsoft.VisualStudio.TestTools.UnitTesting;
using cl = JogoGourmet.Model.Models;
using System;

namespace JogoGourmet.Tests.ModelTests
{
    [TestClass]
    public class Dish
    {
        [TestMethod]
        public void IsDishValid()
        {
            string name = "testName",
                mainFeature = "testFeature";

            cl.Dish testDish = new cl.Dish(name, mainFeature);

            Assert.IsNotNull(testDish);
            Assert.IsTrue(testDish.GetName() == name);
            Assert.IsTrue(testDish.GetMainFeature() == mainFeature);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNullFields()
        {
            string name = null,
                mainFeature = "test";

            cl.Dish testDish = new cl.Dish(name, mainFeature);
        }

        [TestMethod]
        public void IsValidDishNextNodes()
        {
            string name = "testName",
                mainFeature = "testFeature";

            cl.Dish testDish = new cl.Dish(name, mainFeature);
            cl.Dish testDishWithFeature = new cl.Dish(name, mainFeature);
            cl.Dish testDishWithoutFeature = new cl.Dish(name, mainFeature);

            testDish.AddDishWithMainFeature(testDishWithFeature);
            testDish.AddDishWithoutMainFeature(testDishWithoutFeature);

            Assert.IsNotNull(testDish.GetDishWithMainFeature());
            Assert.IsNotNull(testDish.GetDishWithoutMainFeature());
            Assert.IsTrue(testDish.GetDishWithMainFeature() == testDishWithFeature);
            Assert.IsTrue(testDish.GetDishWithoutMainFeature() == testDishWithoutFeature);
        }
    }
}
