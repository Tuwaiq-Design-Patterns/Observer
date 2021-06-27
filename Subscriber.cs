using System;
namespace Observer
{
    public interface ITawakkalnaUser
    {
        void Update(ITawakkalnaApp app);
    }


    class Citizen : ITawakkalnaUser
    {
        public void Update(ITawakkalnaApp app)
        {
            Console.WriteLine($"{this.GetType().Name}: user has received an update.");
        }
    }

    class Alien : ITawakkalnaUser
    {
        public void Update(ITawakkalnaApp app)
        {

            Console.WriteLine($"{this.GetType().Name}: user has received an update.");
        }
    }
}
