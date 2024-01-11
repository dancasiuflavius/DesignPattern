using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GuardiansOfTheCode
{
    public  class EnemyFactory
    {
        private int _areaLevel;
        private Stack<Zombie> _zombiesPool = new Stack<Zombie>();
        private Stack<Warewolf> _warewolf = new Stack<Warewolf>();
        private Stack<Giant> _giant = new Stack<Giant>();

        private void PreLoadZombies()
        {
            int count;
            int health;
            int armor;
            int level;

            if (_areaLevel < 3)
            {
                count = 15;
                
            }
            else if (_areaLevel >= 3 && _areaLevel < 10)
            {
                count = 50;
               
            }
            else
            {
                count = 200;
                
            }
            (health, level, armor) = GetZombieStatus(_areaLevel);
            for(int i= 0;i<count;i++)
            {
                _zombiesPool.Push(new Zombie(health, level, armor));
            }
        }
        private (int health, int level, int armor) GetZombieStatus(int areaLevel)
        {
            int health, armor, level;
            if (areaLevel < 3)
            {
                
                health = 66;
                level = 2;
                armor = 15;
            }
            else if (areaLevel >= 3 && areaLevel < 10)
            {
                
                health = 66;
                level = 5;
                armor = 15;
            }
            else
            {
                health = 100;
                level = 8;
                armor = 15;
            }
            return (health, level, armor);

        }
        private void PreLoadWarewolves()
        {

        }
        private void PreLoadGiants()
        {

        }

        public void ReclaimZombie(Zombie zombie)
        {
            (int health, int level, int armor) = GetZombieStatus(_areaLevel);
            zombie.Health = health;
            
            zombie.Armor = armor;
            _zombiesPool.Push(zombie);
        }


        public int AreaLevel { get => _areaLevel; }
        public EnemyFactory(int areaLevel)
        {
            _areaLevel = areaLevel;
            PreLoadZombies();
            PreLoadWarewolves();
            PreLoadGiants();
        }
        public  Warewolf SpawnWarewolf(int areaLevel)
        {
            if(areaLevel<5)
            {
                return new Warewolf(100, 12);
            }
            else
            {
                return new Warewolf(100, 20);
            }
        }
        public  Zombie SpawnZombie(int areaLevel)
        {
            if(_zombiesPool.Count > 0)
            {
                return _zombiesPool.Pop();
            }
            else
            {
                throw new Exception("Zombies pool deleted");
            }
        }

        public  Giant SpawnGiant(int areaLevel)
        {
            if (areaLevel < 8)
            {
                return new Giant(100, 14);
            }
            else
            {
                return new Giant(100, 32);
            }
        }
    }
}
