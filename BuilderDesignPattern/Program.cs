using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDesignPattern
{
    class Program
    {
        abstract class Pizza
        {
            public abstract string PizzaType { get; }
            public string Dough { get; set; } = "";
            public string Sauce { get; set; } = "";
            public List<string> Topping { get; set; } = new List<string>();

            public override string ToString()
            {
                List<string> pizza = new List<string>();

                pizza.Add($"This is a [{PizzaType}]");

                if (Dough.Length > 0) pizza.Add($"it has a {Dough} dough");
                if (Sauce.Length > 0) pizza.Add($"with a {Sauce} sauce");
                if(Topping.Count > 0)
                {
                    string toppingString = "with added(";
                    foreach (var t in Topping) toppingString += $"{t},";
                    toppingString = toppingString.TrimEnd(',');
                    toppingString += ")";
                    pizza.Add(toppingString);
                }

                return string.Join(", ", pizza);
            }
        }

        class WhitePizza : Pizza
        {
            public override string PizzaType => "White Pizza";
        }

        class WheatPizza : Pizza
        {
            public override string PizzaType => "Wheat Pizza";
        }

        #region Task #1 & Bouns #1 | IPizzaBuilder - WhitePizzaBuilder - WhearPizzaBuilder - Director
        interface IPizzaBuilder
        {
            public void Reset();
            public void BuildDough();
            public void BuildSauce();
            public void BuildTopping();
        }

        class WhitePizzeBuilder : IPizzaBuilder
        {
            private WhitePizza _pizza;

            public WhitePizzeBuilder()
            {
                this.Reset();
            }

            public void BuildDough()
            {
                _pizza.Dough = "White";
            }

            public void BuildSauce()
            {
                _pizza.Sauce = "Red";
            }

            public void BuildTopping()
            {
                _pizza.Topping.Add("Broccoli");
                _pizza.Topping.Add("Mushroom");
            }

            public void Reset()
            {
                _pizza = new WhitePizza();
            }

            public WhitePizza GetPizza()
            {
                WhitePizza whitePizza = _pizza;
                this.Reset();
                return whitePizza;
            }
        }

        class WheatPizzaBuilder : IPizzaBuilder
        {
            private WheatPizza _pizza;

            public WheatPizzaBuilder()
            {
                this.Reset();
            }

            public void BuildDough()
            {
                _pizza.Dough = "Wheat";
            }

            public void BuildSauce()
            {
                _pizza.Sauce = "White";
            }

            public void BuildTopping()
            {
                _pizza.Topping.Add("Gorgonzola");
            }

            public void Reset()
            {
                _pizza = new WheatPizza();
            }

            public WheatPizza GetPizza()
            {
                WheatPizza wheatPizza = _pizza;
                this.Reset();
                return wheatPizza;
            }
        }
        class Director
        {
            private IPizzaBuilder _pizzaBuilder;

            public IPizzaBuilder PizzaBuilder { set => _pizzaBuilder = value; }

            public Director(IPizzaBuilder pizzaBuilder)
            {
                _pizzaBuilder = pizzaBuilder;
            }

            public void MakePizza()
            {
                _pizzaBuilder.BuildDough();
                _pizzaBuilder.BuildSauce();
            }

            public void MakePizzaWithTopping()
            {
                MakePizza();
                _pizzaBuilder.BuildTopping();
            }
        }
        #endregion

        #region Bouns #2 | IPizzaBuilder - WhitePizzaBuilder - WhearPizzaBuilder - Director
        //interface IPizzaBuilder
        //{
        //    public void Reset();
        //    public void BuildDough(string value);
        //    public void BuildSauce(string value);
        //    public void BuildTopping(List<string> value);
        //}

        //class WhitePizzeBuilder : IPizzaBuilder
        //{
        //    private WhitePizza _pizza;

        //    public WhitePizzeBuilder()
        //    {
        //        this.Reset();
        //    }

        //    public void BuildDough(string value)
        //    {
        //        _pizza.Dough = value;
        //    }

        //    public void BuildSauce(string value)
        //    {
        //        _pizza.Sauce = value;
        //    }

        //    public void BuildTopping(List<string> value)
        //    {
        //        _pizza.Topping.AddRange(value);
        //    }

        //    public void Reset()
        //    {
        //        _pizza = new WhitePizza();
        //    }

        //    public WhitePizza GetPizza()
        //    {
        //        WhitePizza whitePizza = _pizza;
        //        this.Reset();
        //        return whitePizza;
        //    }
        //}

        //class WheatPizzaBuilder : IPizzaBuilder
        //{
        //    private WheatPizza _pizza;

        //    public WheatPizzaBuilder()
        //    {
        //        this.Reset();
        //    }

        //    public void BuildDough(string value)
        //    {
        //        _pizza.Dough = value;
        //    }

        //    public void BuildSauce(string value)
        //    {
        //        _pizza.Sauce = value;
        //    }

        //    public void BuildTopping(List<string> value)
        //    {
        //        _pizza.Topping.AddRange(value);
        //    }

        //    public void Reset()
        //    {
        //        _pizza = new WheatPizza();
        //    }

        //    public WheatPizza GetPizza()
        //    {
        //        WheatPizza wheatPizza = _pizza;
        //        this.Reset();
        //        return wheatPizza;
        //    }
        //}
        //class Director
        //{
        //    private IPizzaBuilder _pizzaBuilder;

        //    public IPizzaBuilder PizzaBuilder { set => _pizzaBuilder = value; }

        //    public Director(IPizzaBuilder pizzaBuilder)
        //    {
        //        _pizzaBuilder = pizzaBuilder;
        //    }

        //    public void MakeCustomPizza(string dough, string sauce, List<string> topping)
        //    {
        //        if (!string.IsNullOrEmpty(dough)) _pizzaBuilder.BuildDough(dough);
        //        if (!string.IsNullOrEmpty(sauce)) _pizzaBuilder.BuildSauce(sauce);
        //        if (topping != null && topping.Count > 0) _pizzaBuilder.BuildTopping(topping);
        //    }
        //}
        #endregion

        static void Main(string[] args)
        {
            #region Task #1
            IPizzaBuilder pizzaBuilder = new WhitePizzeBuilder();
            Director director = new Director(pizzaBuilder);

            // white pizza
            director.MakePizza();
            Pizza pizza = (pizzaBuilder as WhitePizzeBuilder).GetPizza();
            Console.WriteLine(pizza);

            // white pizza with topping
            director.MakePizzaWithTopping();
            pizza = (pizzaBuilder as WhitePizzeBuilder).GetPizza();
            Console.WriteLine(pizza);

            // wheat pizza
            director.PizzaBuilder = (pizzaBuilder = new WheatPizzaBuilder());
            director.MakePizza();
            pizza = (pizzaBuilder as WheatPizzaBuilder).GetPizza();
            Console.WriteLine(pizza);

            // wheat pizza with topping
            director.MakePizzaWithTopping();
            pizza = (pizzaBuilder as WheatPizzaBuilder).GetPizza();
            Console.WriteLine(pizza);
            #endregion


            #region Bouns 1
            //IPizzaBuilder pizzaBuilder = new WhitePizzeBuilder();

            //// white pizza
            //pizzaBuilder.BuildDough();
            //pizzaBuilder.BuildSauce();
            //Pizza pizza = (pizzaBuilder as WhitePizzeBuilder).GetPizza();
            //Console.WriteLine(pizza);

            //// white pizza with topping
            //pizzaBuilder.BuildDough();
            //pizzaBuilder.BuildSauce();
            //pizzaBuilder.BuildTopping();
            //pizza = (pizzaBuilder as WhitePizzeBuilder).GetPizza();
            //Console.WriteLine(pizza);

            //// wheat pizza
            //pizzaBuilder = new WheatPizzaBuilder();
            //pizzaBuilder.BuildDough();
            //pizzaBuilder.BuildSauce();
            //pizza = (pizzaBuilder as WheatPizzaBuilder).GetPizza();
            //Console.WriteLine(pizza);

            //// wheat pizza with topping
            //pizzaBuilder.BuildDough();
            //pizzaBuilder.BuildSauce();
            //pizzaBuilder.BuildTopping();
            //pizza = (pizzaBuilder as WheatPizzaBuilder).GetPizza();
            //Console.WriteLine(pizza);
            #endregion


            #region Bouns 2 | Comment out (#region Task #1 & Bouns #1) and uncomment (#region Bouns #2)
            //IPizzaBuilder pizzaBuilder;
            //Director director;
            //Exception invalidInputException = new Exception("Invalid input");
            //string input;

            //string dough = "";
            //string sauce = "";
            //List<string> topping = new List<string>();

            //Console.WriteLine("Welcome to the pizza restaurant");
            //Console.WriteLine("---------------------------------");

            //Console.Write("What kind of pizza do you prefer? (Enter item number)");
            //Console.Write("\n");
            //Console.Write("1. White Pizza");
            //Console.Write("\n");
            //Console.Write("2. Wheat Pizza");
            //Console.Write("\n");

            //pizzaBuilder = Console.ReadLine() switch
            //{
            //    "1" => new WhitePizzeBuilder()
            //    ,
            //    "2" => new WheatPizzaBuilder()
            //    ,
            //    _ => throw invalidInputException
            //};

            //director = new Director(pizzaBuilder);
            //dough = pizzaBuilder is WhitePizzeBuilder ? "White" : "Wheat";

            //// sauce
            //Console.Write("\n");
            //Console.Write("What kind of sauce? (Enter item number)");
            //Console.Write("\n");
            //Console.Write("1. Red sauce");
            //Console.Write("\n");
            //Console.Write("2. White sauce");
            //Console.Write("\n");
            //Console.Write("3. No sauce");
            //Console.Write("\n");

            //string sauceType = Console.ReadLine() switch
            //{
            //    "1" => "Red"
            //    ,
            //    "2" => "White"
            //    ,
            //    "3" => null
            //    ,
            //    _ => throw invalidInputException
            //};
            //sauce = sauceType;


            //// topping
            //Console.Write("\n");
            //Console.Write("What about topping? (Enter item number)");
            //Console.Write("\n");
            //Console.Write("1. Gorgonzola");
            //Console.Write("\n");
            //Console.Write("2. Mushroom");
            //Console.Write("\n");
            //Console.Write("3. Broccoli");
            //Console.Write("\n");
            //Console.Write("4. That's it thanks");
            //Console.Write("\n");

            //while ((input = Console.ReadLine()) != "4")
            //{
            //    topping.Add(
            //        input switch
            //        {
            //            "1" => "Gorgonzola"
            //            ,
            //            "2" => "Mushroom"
            //            ,
            //            "3" => "Broccoli"
            //            ,
            //            _ => throw invalidInputException
            //        }
            //        );

            //    Console.Write("and: ");
            //}

            //director.MakeCustomPizza(dough, sauce, topping);
            //if (pizzaBuilder is WhitePizzeBuilder) Console.WriteLine((pizzaBuilder as WhitePizzeBuilder).GetPizza());
            //else if (pizzaBuilder is WheatPizzaBuilder) Console.WriteLine((pizzaBuilder as WheatPizzaBuilder).GetPizza());
            #endregion
        }
    }
}
