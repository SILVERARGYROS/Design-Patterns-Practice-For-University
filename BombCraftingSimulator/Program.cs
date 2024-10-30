using System;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using System.Collections.Generic;
using BombCraftingSimulator.Weapons;

namespace BombCraftingSimulator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

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
        FABBomb _bomb;

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
        public FABBomb GetProduct() {
            return new FABBomb(blueprint);
        }
    }
}
