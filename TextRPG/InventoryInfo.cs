﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InventoryInfo
{
    
    public class Inventory
    {
        
       public static List<string> weapon1 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Texts", "Weapons.txt"), Encoding.UTF8).ToList();
       public static List<string> weapon2 = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Texts","WeaponsShop.txt"), Encoding.UTF8).ToList();
       
    }
    public  static class Externals
    {
        
        public static string StrCutter(string str, string start, string end)
        {
            return str.Substring(str.IndexOf(start) + start.Length, str.IndexOf(end) - (str.IndexOf(start) + start.Length));
        }
        public static void Add(this Inventory S, int a, bool Place)
        {
            FileInfo file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "Texts", "Inventory.txt"));
            if (Place == false)
            {
                File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Texts", "Inventory.txt"), StrCutter(Inventory.weapon1[a], "@Name:", "@Damage:"));
            }
            else
            {
                if (file.Length != 0 ) 
                {
                    File.AppendAllText(Path.Combine(Directory.GetCurrentDirectory(), "Texts", "Inventory.txt"), new StringBuilder().Append("\n").Append(StrCutter(Inventory.weapon2[a], "@Name:", "@Damage:")).ToString());
                }
                else
                {
                 File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Texts", "Inventory.txt"), StrCutter(Inventory.weapon2[a], "@Name:", "@Damage:"));
                    
                }
            }
        }
    }
}