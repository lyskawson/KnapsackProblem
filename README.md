# Knapsack Problem

## Opis projektu

Projekt KnapsackAppjest implementacją klasycznego problemu plecakowego w języku C#. Problem plecakowy polega na wybraniu podzbioru przedmiotów o określonej wartości i wadze, tak aby zmaksymalizować łączną wartość przedmiotów mieszczących się w plecaku o ograniczonej pojemności.


### Pliki źródłowe

#### `Item.cs`

Plik `Item.cs` zawiera definicję klasy `Item`, która reprezentuje przedmiot z wartością, wagą i indeksem. Klasa ta posiada również właściwość `Ratio` obliczającą stosunek wartości do wagi oraz metodę `ToString` do wygodnego wyświetlania informacji o przedmiocie.

```csharp
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
```

#### `Problem.cs`

Plik `Problem.cs` zawiera definicję klasy `Problem`, która reprezentuje instancję problemu plecakowego. Klasa ta zawiera listę przedmiotów oraz metodę `Solve`, która rozwiązuje problem plecakowy przy użyciu algorytmu zachłannego, sortując przedmioty według stosunku wartości do wagi.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TestProject")]

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
                Items.Add(new Item(value, weight, index));
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

        public Result Solve(int capacity)
        {
            Result result = new Result();
            List<Item> sortedItems = Items.OrderByDescending(item => item.Ratio).ToList();
            int currentValue = 0;
            int currentWeight = 0;
            
            foreach (var sortedItem in sortedItems)
            {
                if (currentWeight + sortedItem.Weight <= capacity)
                {
                    currentValue += sortedItem.Value;   
                    currentWeight += sortedItem.Weight;
                    result.ItemsIndex.add(sortedItem.Index);
                }
            }
            result.TotalValue = currentValue;
            result.TotalWeight = currentWeight;
            return result;
        }
    }
}
```

#### `Program.cs`

Plik `Program.cs` zawiera punkt wejścia aplikacji konsolowej. Program prosi użytkownika o wprowadzenie nasionka losowego, liczby przedmiotów oraz pojemności plecaka, a następnie tworzy instancję problemu, wyświetla przedmioty oraz rozwiązuje problem plecakowy, wyświetlając wynik.

```csharp
using System;

namespace KnapsackApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the seed: ");
            int seed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of itmes: ");
            int n = int.Parse(Console.ReadLine());

            Problem problem = new Problem(n, seed);
            Console.WriteLine(problem.ToString());

            Console.WriteLine("Enter capacity:");
            int capacity = int.Parse(Console.ReadLine());

            Result result = problem.Solve(capacity);
            Console.WriteLine("\nRESULT:");
            Console.WriteLine(result.ToString());
        }
    }
}
```

#### `Result.cs`

Plik `Result.cs` zawiera definicję klasy `Result`, która przechowuje wynik rozwiązania problemu plecakowego. Klasa ta zawiera listę indeksów wybranych przedmiotów oraz łączną wartość i wagę tych przedmiotów.

```csharp
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
```

### Testy jednostkowe

Plik `tests/UnitTest.cs` zawiera testy jednostkowe dla projektu "Knapsack Problem". Testy sprawdzają różne przypadki użycia klasy `Problem` oraz jej metody `Solve`. Poniżej znajduje się opis testów jednostkowych:

- **ShouldReturnOneItem**: Test sprawdza, czy w przypadku wystarczającej pojemności plecaka (capacity = 50), metoda `Solve` zwróci przynajmniej jeden przedmiot.
- **ShouldReturnEmpty**: Test sprawdza, czy w przypadku zerowej pojemności plecaka (capacity = 0), metoda `Solve` zwróci pustą listę przedmiotów.
- **SpecificInstance**: Test sprawdza konkretną instancję problemu plecakowego z określoną listą przedmiotów, sprawdzając, czy metoda `Solve` zwróci poprawny wynik (dwa przedmioty o łącznej wartości 70 i wadze 6).
- **ShouldNotExceedCapacity**: Test sprawdza, czy metoda `Solve` nie przekroczy zadanej pojemności plecaka (capacity = 25) w wyniku.
- **ShouldTakeAllItems**: Test sprawdza, czy metoda `Solve` weźmie wszystkie przedmioty, gdy pojemność plecaka jest wystarczająca, aby pomieścić wszystkie przedmioty.



## Instalacja

1. Sklonuj repozytorium:
    ```sh
    git clone https://github.com/lyskawson/KnapsackProblem.git
    ```
2. Przejdź do katalogu projektu:
    ```sh
    cd KnapsackProblem
    ```

## Użycie

1. Zbuduj projekt:
    ```sh
    dotnet build
    ```

2. Uruchom projekt:
    ```sh
    dotnet run
    ```

## Testy

Aby uruchomić testy jednostkowe, wykonaj:
```sh
dotnet test
```