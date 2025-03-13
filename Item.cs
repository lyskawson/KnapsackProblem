using System;

namespace KnapsackApp
{
    public class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public int Index { get; set; }
        public double Ratio
        {
            get
            {
                return (double)Value / Weight;
            }
        }

        public Item(int value, int weight, int index)
        {
            Value = value;
            Weight = weight;
            Index = index;
        }

        public override string ToString()
        {
            return $"v: {Value}   w: {Weight}";
        }
    }
}