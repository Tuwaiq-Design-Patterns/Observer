using System;
using System.Text;

namespace FactoryMethodDesignPattern
{
    class Program
    {
        #region Toyota Factory Example
        enum CarType
        {
            Camery
            , Corola
        }
        interface ICar { }
        class Camery : ICar { }
        class Corola : ICar { }

        class ToyotaFactory
        {
            public static ICar Make(CarType carType) => 
                carType switch
                {
                    CarType.Camery => new Camery()
                    , CarType.Corola => new Corola()
                    , _ => throw new NotSupportedException($"{carType.ToString()} is not supported")
                };
        }

        #endregion

        #region Product Factory Example
        interface IProduct { public void Order(); }
        class Spain : IProduct
        {
            public void Order() => Console.WriteLine("Spain");
        }
        class SouthAfrica : IProduct
        {
            public void Order() => Console.WriteLine("SouthAfrica");
        }
        class Creator
        {
            public IProduct FactoryMethod(int month)
            {
                return (month > 0 && month <= 4)
                    ? new Spain()
                    : (month >= 7 && month <= 10)
                        ? new SouthAfrica()
                        : throw new NotSupportedException($"There are no fruits in [month]");
            }
        }
        #endregion

        static void Main(string[] args)
        {
            //RunCarFactoryExample();
            RunProductExample();
        }

        static void RunCarFactoryExample()
        {
            StringBuilder logger = new StringBuilder();
            ICar camery = null;
            ICar corola = null;

            logger.AppendLine("Making Camery...");
            camery = ToyotaFactory.Make(CarType.Camery);
            logger.AppendLine($"The class name of the created car is [{camery.GetType().Name}]");

            logger.AppendLine();
            logger.AppendLine("Making Corola...");
            corola = ToyotaFactory.Make(CarType.Corola);
            logger.AppendLine($"The class name of the created car is [{corola.GetType().Name}]");

            Console.WriteLine(logger.ToString());

            Console.ReadKey();
        }

        static void RunProductExample()
        {
            StringBuilder logger = new StringBuilder();
            IProduct spain = null;
            IProduct southAfrica = null;
            Creator c = new Creator();

            for (int i = 1; i <= 12; i++)
            {
                try
                {
                    logger.AppendLine($"Creating for [{i}]");
                    logger.AppendLine($"Type of the created class is [{(c.FactoryMethod(i)).GetType().Name}]");
                }
                catch (Exception e)
                {
                    logger.AppendLine(e.Message);
                }
                logger.AppendLine(new String('=', 50));
            }

            Console.WriteLine(logger.ToString());

            Console.ReadKey();
        }
    }
}
