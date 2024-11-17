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
            Console.WriteLine("Hello World!");

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
    }

    public interface IWeaponBuilder {
        void BuildMetalCasing();
        void BuildExplosives();
        void BuildPropulsion();
        void BuildGuidanceKit();
        void BuildDetonation();
    }

    public class CFABBuilder : IWeaponBuilder{
        IWeaponBlueprint blueprint;
        FAB _bomb;

        public CFABBuilder(IWeaponBlueprint blueprint) {
            this.blueprint = blueprint;
        }

        public void BuildMetalCasing() {
            Console.WriteLine($"Building metal casing for {_bomb}");
        }
        public void BuildExplosives() {
            Console.WriteLine($"Building metal explosives for {_bomb}");
        }
        public void BuildPropulsion() {
            Console.WriteLine($"Building metal propulsion for {_bomb}");
        }
        public void BuildGuidanceKit() {
            Console.WriteLine($"Building metal guidance for {_bomb}");
        }
        public void BuildDetonation() {
            Console.WriteLine($"Building metal detonation for {_bomb}");
        }
        public FAB GetProduct() {
            return new FAB(blueprint);
        }
    }
}
