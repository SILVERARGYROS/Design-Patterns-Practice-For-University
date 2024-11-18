using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.Decorator;
using System.Text.RegularExpressions;

namespace BombCraftingSimulator.Decorators.BombDecorators {
    internal class ColorBombDecorator : IBombDecorator {
        public IWeaponBlueprint blueprint { get; }

        private IWeapon wrappedBomb { get; }

        private String color = "";

        public ColorBombDecorator(IWeapon wrappedBomb, String color) {
            this.wrappedBomb = wrappedBomb;
            this.color = color;
        } 

        public String Launch() {
            // ConsoleColor Enum: https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor?view=net-8.0

            ConsoleColor newColor = Console.ForegroundColor;
            try {
                newColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
            } catch (Exception) {
                Console.WriteLine("Invalid Color. Selecting Default...");
            }
            return newColor + " colored " + Regex.Replace(wrappedBomb.Launch(), @"^.* colored", "");
        }

        public override string ToString() {
            return blueprint.weaponName;
        }
    }
}
