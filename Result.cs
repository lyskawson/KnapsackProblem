using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackApp
{
    public class Result
    {
        
        public List<int> ItemsIndex { get; set; } = new List<int>(); //empty list of indexes
        public int TotalValue { get; set; }
        public int TotalWeight { get; set; }

        public override string ToString()
        {
            string items = string.Join(", ", ItemsIndex);
            return $"items: {items}\n" + $"total value: {TotalValue}\n" + $"total weight: {TotalWeight}";
        }
    }
}