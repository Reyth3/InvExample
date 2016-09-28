using RPGCore.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTest
{
    class Program
    {
        static Inventory inv;
        static Random r;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing");
            inv = new Inventory();
            r = new Random();
            Console.WriteLine("Inventory created: "+inv);
            AddWeapon("Sword", 6);
            AddWeapon("Old Axe", 4);
            AddWeapon("Warhammer", 40000);
            AddWeapon("Stick", 3);
            AddWeapon("Dagger", 5);

            AddPotion("Healing Potion");
            AddPotion("Healing Potion");
            AddPotion("Healing Potion");
            AddPotion("Healing Potion");

            Console.WriteLine("Inv ready:"+inv);
            Console.ReadKey();
            inv.Serialize();
        }

        static void AddPotion(string name)
        {
            inv.Items.Add(new Consumable(name, "It's a potion.", r.Next(2, 10) * 2, 5, 0));
            Console.WriteLine("Added Weapon: "+inv.Items.Last());
        }

        static void AddWeapon(string name, int damage)
        {
            inv.Items.Add(new Weapon(name, "It's a weapon.", r.Next(2, 350)*5, damage));
            Console.WriteLine("Added Weapon: " + inv.Items.Last());
        }
    }
}
