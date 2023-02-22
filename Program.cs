namespace ShallowCopyVsDeepCopy
{
    internal class Program
    {
        static void Main()
        {
            var pizzasForShallowCopy = new List<Pizza>
            {
                new Pizza
                {
                    Name= "Margherita",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Olive oil",
                        "Basil"
                    }
                },
                new Pizza
                {
                    Name= "Diavola",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Ventricina",
                        "Chili peppers"
                    }
                }
            };

            var pizzasForDeepCopy = new List<Pizza>
            {
                new Pizza
                {
                    Name= "Margherita",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Olive oil",
                        "Basil"
                    }
                },
                new Pizza
                {
                    Name= "Diavola",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Ventricina",
                        "Chili peppers"
                    }
                }
            };

            ShallowCopy(pizzasForShallowCopy);
            DeepCopy(pizzasForDeepCopy);
        }

        private static void ShallowCopy(List<Pizza> pizzas)
        {
            Console.WriteLine("Shallow Copy Example");
            var shallowCopyUsingEnumerableToListMethod = ShallowCopyUsingEnumerableToListMethod(pizzas);
            var shallowCopyUsingListConstructor = ShallowCopyUsingListConstructor(pizzas);
            var shallowCopyUsingCopyToMethod = ShallowCopyUsingCopyToMethod(pizzas);
            var shallowCopyUsingListAddRangeMethod = ShallowCopyUsingListAddRangeMethod(pizzas);
            var shallowCopyUsingConvertAllMethod = ShallowCopyUsingConvertAllMethod(pizzas);

            RemovePizzaFromList(pizzas);
            pizzas.ForEach(item => { Console.WriteLine($"Original List: {item}"); });
            Console.WriteLine();
            shallowCopyUsingEnumerableToListMethod.ForEach(item => { Console.WriteLine($"Cloned with ToList Method: {item}"); });
            Console.WriteLine();
            shallowCopyUsingListConstructor.ForEach(item => { Console.WriteLine($"Cloned with List Constructor: {item} "); });
            Console.WriteLine();
            shallowCopyUsingCopyToMethod.ForEach(item => { Console.WriteLine($"Cloned with CopyTo Method: {item} "); });
            Console.WriteLine();
            shallowCopyUsingListAddRangeMethod.ForEach(item => { Console.WriteLine($"Cloned with AddRange Method: {item} "); });
            Console.WriteLine();
            shallowCopyUsingConvertAllMethod.ForEach(item => { Console.WriteLine($"Cloned with ConvertAll Method: {item}  "); });
            Console.WriteLine();
        }

        private static void DeepCopy(List<Pizza> pizzas)
        {
            Console.WriteLine("Deep Copy Example");
            var deepCopyUsingICloneableInterface = DeepCopyUsingICloneableInterface(pizzas);
            var deepCopyUsingUsingCopyConstructor = DeepCopyUsingUsingCopyConstructor(pizzas);

            RemovePizzaFromList(pizzas);
            pizzas.ForEach(item => { Console.WriteLine($"Original List: {item}  "); });
            Console.WriteLine();
            deepCopyUsingICloneableInterface.ForEach(item => { Console.WriteLine($"Cloned with ICloneableInterface: {item}  "); });
            Console.WriteLine();
            deepCopyUsingUsingCopyConstructor.ForEach(item => { Console.WriteLine($"Cloned with Copy Constructor: {item}  "); });
        }

        private static List<Pizza> ShallowCopyUsingEnumerableToListMethod(List<Pizza> pizzas)
        {
            return pizzas.ToList();
        }

        private static List<Pizza> ShallowCopyUsingListConstructor(List<Pizza> pizzas)
        {
            return new List<Pizza>(pizzas);
        }

        private static List<Pizza> ShallowCopyUsingCopyToMethod(List<Pizza> pizzas)
        {
            var pizzasClonedWithCopyTo = new Pizza[pizzas.Count];
            pizzas.CopyTo(pizzasClonedWithCopyTo);
            return pizzasClonedWithCopyTo.ToList();
        }

        private static List<Pizza> ShallowCopyUsingListAddRangeMethod(List<Pizza> pizzas)
        {
            var pizzasClonedWithAddRange = new List<Pizza>();
            pizzasClonedWithAddRange.AddRange(pizzas);
            return pizzasClonedWithAddRange;
        }

        private static List<Pizza> ShallowCopyUsingConvertAllMethod(List<Pizza> pizzas)
        {
            return pizzas.ConvertAll(x => x);
        }

        private static List<Pizza> DeepCopyUsingICloneableInterface(List<Pizza> pizzas)
        {
            return pizzas.Select(pizza => (Pizza)pizza.Clone()).ToList();
        }

        private static List<Pizza> DeepCopyUsingUsingCopyConstructor(List<Pizza> pizzas)
        {
            return pizzas.Select(pizza => new Pizza(pizza)).ToList();
        }

        private static void RemovePizzaFromList(List<Pizza> pizzas)
        {
            var margherita = pizzas
                .FirstOrDefault(x => x.Name == "Margherita");
            margherita?.Toppings.Clear();
        }
    }
}