using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceCalculator;
using SequenceCalculator.Controllers;
using System.Net;

namespace SequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestAllNumbers()
        {
            HomeController controller = new HomeController();

            var result = controller.GetAllNumbers(-1);
            Assert.IsTrue(!result.Any());

            result = controller.GetAllNumbers(0);
            Assert.AreEqual(0, result.Last());
            Assert.AreEqual(1, result.Count());

            result = controller.GetAllNumbers(100);
            Assert.AreEqual(101, result.Count());
            Assert.AreEqual(100, result.Last());
            Assert.AreEqual(0, result.First());
            Assert.AreEqual(84, result.ElementAt(84));
        }

        [TestMethod]
        public void TestEvenNumbers()
        {
            HomeController controller = new HomeController();

            var result = controller.GetEvenNumbers(-1);
            Assert.IsTrue(!result.Any());

            result = controller.GetEvenNumbers(0);
            Assert.AreEqual(0, result.Last());
            Assert.AreEqual(1, result.Count());

            result = controller.GetEvenNumbers(23);
            Assert.AreEqual(12, result.Count());
            Assert.AreEqual(22, result.Last());
            Assert.AreEqual(0, result.First());
            Assert.AreEqual(18, result.ElementAt(9));
        }

        [TestMethod]
        public void TestOddNumbers()
        {
            HomeController controller = new HomeController();

            var result = controller.GetOddNumbers(-1);
            Assert.IsTrue(!result.Any());

            result = controller.GetOddNumbers(0);
            Assert.IsTrue(!result.Any());

            result = controller.GetOddNumbers(23);
            Assert.AreEqual(12, result.Count());
            Assert.AreEqual(23, result.Last());
            Assert.AreEqual(1, result.First());
            Assert.AreEqual(19, result.ElementAt(9));
        }

        [TestMethod]
        public void TestFizzBuzzNumbers()
        {
            HomeController controller = new HomeController();

            var result = controller.GetFizzBuzzNumbers(-1);
            Assert.IsTrue(!result.Any());

            result = controller.GetFizzBuzzNumbers(0);
            Assert.AreEqual("0", result.Last());
            Assert.AreEqual(1, result.Count());

            result = controller.GetFizzBuzzNumbers(15);
            Assert.AreEqual("Z", result.Last());
            Assert.AreEqual("E", result.ElementAt(10));
            Assert.AreEqual("C", result.ElementAt(9));
            Assert.AreEqual("11", result.ElementAt(11));
        }

        [TestMethod]
        public void TestFibonacciNumbers()
        {
            HomeController controller = new HomeController();

            var result = controller.GetFibonacciNumbers(-1);
            Assert.IsTrue(!result.Any());

            result = controller.GetFibonacciNumbers(0);
            Assert.AreEqual(0, result.Last());
            Assert.AreEqual(1, result.Count());

            result = controller.GetFibonacciNumbers(1);
            Assert.AreEqual(0, result.First());
            Assert.AreEqual(1, result.Last());
            Assert.AreEqual(2, result.Count());

            //0, 1, 1, 2, 3, 5, 8, 13
            result = controller.GetFibonacciNumbers(13);
            Assert.AreEqual(8, result.Count());
            Assert.AreEqual(13, result.Last());
            Assert.AreEqual(3, result.ElementAt(4));
            Assert.AreEqual(8, result.ElementAt(6));
        }

        [TestMethod]
        public void TestUI()
        {
            using (WebClient client = new WebClient())
            {
                var result = client.DownloadString("http://localhost:51392/");

                Assert.IsTrue(result.Contains("<input class=\"form-control\" data-val=\"true\" data-val-number=\"The field input must be a number.\" data-val-range=\"Must be a positive integer\" data-val-range-max=\"2147483647\" data-val-range-min=\"0\" data-val-required=\"The input field is required.\" id=\"input\" name=\"input\" type=\"text\" value=\"0\" />"));
                Assert.IsTrue(result.Contains("<button type=\"submit\" class=\"btn btn-default\">Submit</button>"));

                var resultBytes = client.UploadValues("http://localhost:51392/", new System.Collections.Specialized.NameValueCollection { { "input", "5" } });
                string resultString = System.Text.Encoding.UTF8.GetString(resultBytes);

                Assert.IsTrue(resultString.Contains("<label for=\"allNumbers\">All Numbers</label>"));
                Assert.IsTrue(resultString.Contains("0, 1, 2, 3, 4, 5"));
                Assert.IsTrue(resultString.Contains("<label for=\"evenNumbers\">Even Numbers</label>"));
                Assert.IsTrue(resultString.Contains("0, 2, 4"));
                Assert.IsTrue(resultString.Contains("<label for=\"oddNumbers\">Odd Numbers</label>"));
                Assert.IsTrue(resultString.Contains("1, 3, 5"));
                Assert.IsTrue(resultString.Contains("<label for=\"fizzBuzzNumbers\">Fizz Buzz Numbers</label>"));
                Assert.IsTrue(resultString.Contains("0, 1, 2, C, 4, E"));
                Assert.IsTrue(resultString.Contains("<label for=\"fibonacciNumbers\">Fibonacci Numbers</label>"));
                Assert.IsTrue(resultString.Contains("0, 1, 1, 2, 3, 5"));
            }
        }
    }
}
