using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackApp
{
    public class Problem
    {
        public int N { get; set; }
        public List<Item> Items { get; set; }


        public Problem(int n, int seed)
        {
            N = n;
            Items = new List<Item>();
            Random random = new Random(seed);

            
            for (int i = 0; i < n; i++)
            {
                int value = random.Next(1, 11); 
                int weight = random.Next(1, 11);
                int index = i;
                Items.Add(new Item(value, weight,index));
            }
        }
        public override string ToString()
        {
            string text = "";
            int index = 0;
            foreach (var item in Items)
            {           
                text = text + $"no.: {index} {item}\n";
                index++;
            }
            return text;
        }

        
        public Result Solve(int capasity)
        {
            Result result = new Result();
            List<Item> sortedItems = Items.OrderByDescending(item => item.Ratio).ToList();
            int currentValue = 0;
            int currentWeight = 0;
            
            foreach (var sortedItem in sortedItems)
            {
                if (currentWeight + sortedItem.Weight <= capasity)
                {
                    currentValue += sortedItem.Value;   
                    currentWeight += sortedItem.Weight;
                    result.ItemsIndex.Add(sortedItem.Index);
                }
            }
            result.TotalValue = currentValue;
            result.TotalWeight = currentWeight;
            return result;
            
            
        }

    }
}