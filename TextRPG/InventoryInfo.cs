using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InventoryInfo
{
    public class Inventory
    {
        
       public static List<string> weapon1 = File.ReadAllLines("D:/Programma/sharp/Weapons.txt", Encoding.UTF8).ToList();
       public static List<string> weapon2 = File.ReadAllLines("D:/Programma/sharp/WeaponsShop.txt", Encoding.UTF8).ToList();
       
    }
    public static class Externals
    {
        public static string StrCutter(string str, string start, string end)
        {
            return str.Substring(str.IndexOf(start) + start.Length, str.IndexOf(end) - (str.IndexOf(start) + start.Length));
        }
        public static void Add(this Inventory S, int a, int Place)
        {
            if (Place == 0)
            {
                File.WriteAllText("D:/Programma/sharp/Inventory.txt", StrCutter(Inventory.weapon1[a], "@Name:", "@Damage:"));
            }
            if(Place == 1)
            {
                File.WriteAllText("D:/Programma/sharp/Inventory.txt", StrCutter(Inventory.weapon2[a], "@Name:", "@Damage:"));
            }
        }
    }
}