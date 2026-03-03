using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CalculatorTest
{
	[TestFixture]
	internal class CalculatorAppTests
    {
        private CalculatorApp.Calculator calc;
        
        [SetUp]
        public void Setup()
        {
            calc = new CalculatorApp.Calculator();
        }

        [Test]
        public void Add_twoNumbers_ReturnSum()
        {
            //arrange
            int a = 5, b = 3;

            //Act
            int result = calc.Add(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Substract_TwoNumbers_ReturnDiffrence()
        {
            //Arrange
            int a = 10, b = 4;

            //act
            int result = calc.Substract(a, b);

            //assert
            Assert.That(result, Is.EqualTo(6));

        }

		[Test]
		public void Multiply_TwoNumbers_ReturnProduct()
		{
			//Arrange
			int a = 10, b = 4;

			//act
			int result = calc.Multiply(a, b);

			//assert
			Assert.That(result, Is.EqualTo(40));

		}

		[Test]
		public void Divide_ByZero_ThjrowsExecption()
		{
			//Arrange
			int a = 10, b = 0;

            //act and assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(a, b));
			;

		}

		[Test]
		public void Divide_TwoNumber_returnQuotion()
		{
			//Arrange
			int a = 20, b = 5;

			//act and assert
			
			double result = calc.Divide(a, b);

			//assert
			Assert.That(result, Is.EqualTo(4));

		}



	}
}
