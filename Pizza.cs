namespace ShallowCopyVsDeepCopy
{
    public class Pizza : ICloneable
    {
        public string Name { get; set; }
        public List<string> Toppings { get; set; }
        public override string ToString()
        {
            return $"Pizza name: {Name}; Toppings: {string.Join(", ", Toppings)}";
        }

        public Pizza()
        {
            
        }

        public object Clone()
        {
            return new Pizza
            {
                Name = Name,
                Toppings = Toppings.ToList(),
            };
        }

        public Pizza(Pizza pizza)
        {
            Name = pizza.Name;
            Toppings = pizza.Toppings.ToList();
        }
    }
}
