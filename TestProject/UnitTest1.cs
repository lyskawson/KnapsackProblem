using KnapsackApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestUnit
{
        [ TestClass ]
        public class UnitTest
        {
            [TestMethod]
            public void ShouldReturnOneItem()
            {
                int capacity = 50;
                var problem = new Problem(5, 1);
                Result result = problem.Solve(capacity);
                Assert.IsTrue(result.ItemsIndex.Count > 0,"Expected at least one item");
            }

            [TestMethod]
            public void ShouldReturnEmpty()
            {
                int capacity = 0; 
                var problem = new Problem(5, 2);
                Result result = problem.Solve(capacity);
                Assert.AreEqual(0, result.ItemsIndex.Count, "Expected no items");
            }

            [TestMethod]
            public void SpecificInstance()
            {
                var problem = new Problem(0, 3);
                problem.Items = new List<Item> {
                    new Item(10,1,1), //v = 10, w = 1, ratio = 10
                    new Item(60,5,2), //v = 60, w = 5, ratio = 12
                    new Item(40,8,2), //v = 40, w = 8, ratio = 5
                    new Item(20,10,3) //v = 20, w = 10, ratio = 2
                    };
            
                int capacity = 10;
                Result result = problem.Solve(capacity);
            
                Assert.AreEqual(2, result.ItemsIndex.Count, "Expected two items");
                Assert.AreEqual(70, result.TotalValue, "Expected total value of 70");
                Assert.AreEqual(6, result.TotalWeight, "Expected total weight of 6");
            }

            [TestMethod]    
            public void ShouldNotExceedCapacity()
            {
                var problem = new Problem(15, seed: 4);
                int capacity = 25;
                var result = problem.Solve(capacity);
                Assert.IsTrue(result.TotalWeight <= capacity,"Expected total weight not to exceed capacity");
            }

            [TestMethod]
            public void ShouldTakeAllItems()
            {
            
                var problem = new Problem(0, 5);
                problem.Items = new List<Item>
                {
                    new Item(10,5,1),
                    new Item(20,10,1),
                    new Item(30,15,1)
                };
                int capacity = 5 + 10 + 15; 
                Result result = problem.Solve(capacity);

            
                Assert.AreEqual(problem.Items.Count, result.ItemsIndex.Count, "Expected all items taken");
                Assert.AreEqual(5 + 10 + 15, result.TotalWeight, "Expected total weight of 30");
            }

        

            
        }
}