using System;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using System.Collections.Generic;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.MinistryOfNationalDefence;
using BombCraftingSimulator.Weapons.Bombs;
using BombCraftingSimulator.Builder;
using BombCraftingSimulator.Decorators.BombDecorators;

namespace BombCraftingSimulator {
    class Program {
        static void Main(string[] args) {
            Program.Print("Hello World", "DarkRed");

            // https://refactoring.guru/design-patterns/singleton
            ArmyCommand armyCommand = ArmyCommand.GetInstance();
            WeaponBlueprint blueprint = armyCommand.RequestWeaponΒlueprint(WeaponFamily.MOAB, 0);
            // might implement a menu here

            ArmyFactory armyFactory = new ArmyFactory();

            // Decorating bomb
            IWeapon bomb = armyFactory.RequestBomb(blueprint);
            ColorBombDecorator d1 = new ColorBombDecorator(bomb, "red");
            ElementBombDecorator d2 = new ElementBombDecorator(d1, "fire");
            SoundEffectBombDecorator d3 = new SoundEffectBombDecorator(d2, "mpammpum");
            IWeapon finalBomb = d3;

            // Launching the final bomb
            Console.WriteLine();
            Console.WriteLine(finalBomb.Launch());
        }

        private static Boolean DebugPrintsActivated = true;

        public static void Print(string message, string color) {
            if (DebugPrintsActivated) {
                // Change the Console.Foregroundcolor from a string: https://stackoverflow.com/questions/30799107/change-the-console-foregroundcolor-from-a-string
                ConsoleColor c;
                if (Enum.TryParse(color, out c)) {
                    Console.ForegroundColor = c;
                }

                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}
