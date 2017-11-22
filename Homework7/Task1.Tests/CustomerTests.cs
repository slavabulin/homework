using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1.Tests
{
    [TestClass]
    public class CustomerTests
    {
        Customer customer;
        public CustomerTests()
        {
            var customer = new Customer();
            this.customer = customer;
        }
        [TestMethod]
        public void CustomerInputNoFormatterShouldReturnThreeValue()
        {
            //arrange
            customer.ContactPhone = "+123456789";
            customer.Name = "Jhon Doe";
            customer.Revenue = 1000000;
            string retVal;
            string expectedVal = "Customer record: Jhon Doe 1000000 +123456789";
            //act
            retVal = String.Format("{0}", customer);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomerInputNParamShouldPass()
        {
            //arrange
            customer.ContactPhone = "+123456789";
            customer.Name = "Jhon Doe";
            customer.Revenue = 1000000;
            string retVal;
            string expectedVal = "Customer record: Jhon Doe ";
            //act
            retVal = String.Format("{0:N}", customer);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomerInputPParamShouldPass()
        {
            //arrange
            customer.ContactPhone = "+123456789";
            customer.Name = "Jhon Doe";
            customer.Revenue = 1000000;
            string retVal;
            string expectedVal = "Customer record: +123456789 ";
            //act
            retVal = String.Format("{0:P}", customer);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomerInputRParamShouldPass()
        {
            //arrange
            customer.ContactPhone = "+123456789";
            customer.Name = "Jhon Doe";
            customer.Revenue = 1000000;
            string retVal;
            string expectedVal = "Customer record: 1000000 ";
            //act
            retVal = String.Format("{0:R}", customer);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void CustomerInputCombinedParamShouldPass()
        {
            //arrange
            customer.ContactPhone = "+123456789";
            customer.Name = "Jhon Doe";
            customer.Revenue = 1000000;
            string retVal;
            string expectedVal = "Customer record: +123456789 1000000 Jhon Doe ";
            //act
            retVal = String.Format("{0:PRN}", customer);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
    }
}
