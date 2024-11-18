using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Factories;
using BombCraftingSimulator.Factories.WeaponFactories;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.WeaponSpecs;
using System;

namespace BombCraftingSimulator.Builder
{

    //public interface IWeaponFactory {
    //    public IWeapon Construct(WeaponBlueprint blueprint);
    //}

     public class ArmyFactory{ // Facade class of Factory Subsystem
        public ArmyFactory()
        {
            
        }

        // Method to construct a weapon based on the specified family and version
        public IWeapon RequestBomb(WeaponBlueprint blueprint) {
            WeaponFamily family = blueprint.WeaponFamily;
            int version = blueprint.version;

            // Retrieve the builder and blueprint for the specified family and version
            IWeaponFactory weaponFactory = GetWeaponFactory(blueprint);

            // Return the constructed weapon
            return weaponFactory.BuildWeapon();
        }

        // Private method to get the weapon builder and blueprint for the specified family and version
        private IWeaponFactory GetWeaponFactory(WeaponBlueprint blueprint) {
            // Throw an exception if the blueprint is invalid
            if (blueprint == null) {
                Program.Print("Invalid blueprint.", "DarkRed");
                throw new ArgumentException("Invalid blueprint");
            }

            blueprint.version = blueprint.version;
            // Return the appropriate builder and blueprint based on the weapon family
            switch (blueprint.WeaponFamily) {
                case WeaponFamily.FAB:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    Program.Print("Getting factory for FAB.", "Green");
                return new CFABFactory(blueprint);
                case WeaponFamily.MOAB:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    Program.Print("Getting factory for MOAB.", "Green");

                return new CMOABFactory(blueprint);
                case WeaponFamily.JDAM:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    Program.Print("Getting factory for JDAM.", "Green");

                return new CJDAMFactory(blueprint);
                case WeaponFamily.X69:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    Program.Print("Getting factory for X89.", "Green");

                return new CX69Factory(blueprint);
                default:
                    // Throw an exception if the weapon family is invalid
                    Program.Print("Invalid weapon family.", "DarkRed");

                throw new ArgumentException("Invalid weapon family");
            }
        }
     }
}
