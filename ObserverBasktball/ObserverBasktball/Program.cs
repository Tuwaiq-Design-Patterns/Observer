using System;
using System.Collections.Generic;

namespace ObserverBasktball
{
    class Program
    {
        public static void Main()
        {
            BasketballPlayer damianLillard = new BasketballPlayer("Damian Lillard");
            BasketballFan basketballFan1 = new BasketballFan(damianLillard);
            damianLillard.Attach(basketballFan1);
            damianLillard.Score(3);
            BasketballFan basketballFan2 = new BasketballFan(damianLillard);
            damianLillard.Attach(basketballFan2);
            damianLillard.Score(2);
        }

        abstract class Player
        {
            List<Fan> fans = new List<Fan>();

            public void Attach(Fan f)
            {
                fans.Add(f);
            }

            public void Detach(Fan f)
            {
                fans.Remove(f);
            }

            public void Notify()
            {
                foreach (Fan f in fans)
                {
                    f.Update();
                }
            }
        }

        class BasketballPlayer : Player
        {
            public string Name;
            public int Points = 0;

            public BasketballPlayer(string name)
            {
                this.Name = name;
            }

            public void Score(int points)
            {
                this.Points += points;
                this.Notify();
            }
        }

        public interface  Fan
        {
            public void Update();
        }

        class BasketballFan : Fan
        {
            BasketballPlayer FavoritePlayer;
            int FavoritePlayerPoints;

            public BasketballFan(BasketballPlayer player)
            {
                this.FavoritePlayer = player;
                this.FavoritePlayerPoints = this.FavoritePlayer.Points;
            }

            public void Update()
            {
                this.FavoritePlayerPoints = this.FavoritePlayer.Points;
                Console.WriteLine(this.FavoritePlayer.Name + " has " + this.FavoritePlayerPoints + " points!");
            }
        }
    }
}

