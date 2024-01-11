using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardiansOfTheCode
{
    public class Sword : IWeapon
    {
        private int _damage;
        public int Damage { get => _damage; }
        private int _armorDamage;
        public int ArmorDamage { get => _armorDamage; }
        public Sword(int damage, int ArmorDamage)
        {
            _damage = damage;
            _armorDamage = ArmorDamage;

        }
        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Armor -= ArmorDamage;
        }
    }
}
