using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SequenceCalculator.Models;

namespace SequenceCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SequenceViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SequenceViewModel model)
        {
            model.allNumbers = String.Join(", ", GetAllNumbers(model.input));
            model.evenNumbers = String.Join(", ", GetEvenNumbers(model.input));
            model.oddNumbers = String.Join(", ", GetOddNumbers(model.input));
            model.fizzBuzzNumbers = String.Join(", ", GetFizzBuzzNumbers(model.input));
            model.fibonacciNumbers = String.Join(", ", GetFibonacciNumbers(model.input));

            return View(model);
        }

        public IEnumerable<int> GetAllNumbers(int input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i <= input; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public IEnumerable<int> GetOddNumbers(int input)
        {
            List<int> result = new List<int>();

            for (int i = 1; i <= input; i += 2)
            {
                result.Add(i);
            }

            return result;
        }

        public IEnumerable<int> GetEvenNumbers(int input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i <= input; i += 2)
            {
                result.Add(i);
            }

            return result;
        }

        public IEnumerable<string> GetFizzBuzzNumbers(int input)
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= input; i++)
            {
                if ((i % 3 == 0) && (i % 5 ==0) && (i != 0))
                {
                    result.Add("Z");
                }
                else if (i % 3 == 0 && i != 0)
                {
                    result.Add("C");
                }
                else if (i % 5 == 0 && i != 0)
                {
                    result.Add("E");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        public IEnumerable<int> GetFibonacciNumbers(int input)
        {
            List<int> result = new List<int>();

            int currentIndex = -1;

            if (input >= 0)
            {
                result.Add(0);
                currentIndex++;
            }

            if (input >= 1)
            {
                result.Add(1);
                currentIndex++;
            }
            
            while (currentIndex > -1 && result.ElementAt(currentIndex) < input)
            {
                var newValue = result.ElementAt(currentIndex - 1) + result.ElementAt(currentIndex);
                if (newValue > input)
                    break;
                else
                {
                    result.Add(newValue);
                    currentIndex++;
                }

            }

            return result;
        }
    }
}