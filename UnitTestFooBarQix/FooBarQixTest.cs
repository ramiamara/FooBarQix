using Microsoft.VisualStudio.TestTools.UnitTesting;
using FooBarQix.Controllers;
using FooBarQix.Services;
using FooBarQix.Models;
using FooBarQix.Repository;

namespace UnitTestFooBarQix
{
    [TestClass]
    public class FooBarQixTest
    {
        FooBarQixRepository fooBarQixRepo = new FooBarQixRepository();
        Entry entry = new Entry { ANumber = 1, CharReplaced = '*' };
        [TestMethod]
        public void Should_return_input_as_string()
        {
            // Arrange
            entry.ANumber = 1;
            // Act
            var result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void Should_return_Foo_when_input_divisible_by_3()
        {
            // Arrange
            entry.ANumber = 6;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("Foo", result);
        }

        [TestMethod]
        public void Should_return_Bar_when_input_divisible_by_5()
        {
            // Arrange
            entry.ANumber = 10;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("Bar", result);
        }

        [TestMethod]
        public void Should_return_Qix_when_input_divisible_by_7()
        {
            // Arrange
            entry.ANumber = 14;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("Qix", result);
        }

        [TestMethod]
        public void Should_return_combination_of_Foo_Bar_Qix()
        {
            // Arrange
            entry.ANumber = 3 * 5 * 4;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("FooBar", result);

            // Arrange
            entry.ANumber = 5 * 7 * 4;
            // Act
            string result2 = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("BarQix", result2);

            entry.ANumber = 3 * 5 * 7 * 2;
            // Act
            string result3 = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("FooBarQix", result3);
        }

        [TestMethod]
        public void Should_replace_3_by_Foo()
        {
            // Arrange
            entry.ANumber = 13;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("Foo", result);
        }

        [TestMethod]
        public void Should_replace_5_by_Bar()
        {
            // Arrange
            entry.ANumber = 52;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("Bar", result);
        }

        [TestMethod]
        public void Should_replace_7_by_Foo()
        {
            // Arrange
            entry.ANumber = 71;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("Qix", result);
        }

        [TestMethod]
        public void Should_return_combinition_of_contains()
        {
            // Arrange
            entry.ANumber = 713;
            // Act
            string result = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("QixFoo", result);
        }

        [TestMethod]
        public void Should_return_combinition_of_divisible_and_contains()
        {
            // Arrange
            entry.ANumber = 3;
            // Act
            string result1 = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("FooFoo", result1);
            // Arrange
            entry.ANumber = 15;
            // Act
            string result2 = fooBarQixRepo.Calculate(entry);
            // Assert
            Assert.AreEqual("FooBarBar", result2);
        }
    }
}
