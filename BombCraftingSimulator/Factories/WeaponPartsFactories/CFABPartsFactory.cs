using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Factories
{

    // Class to create various parts of the FAB weapon using a factory design pattern
    public class CFABPartsFactory : IWeaponPartsFactory
    {

        // Private field to hold the weapon blueprint
        public IWeaponBlueprint blueprint {get;}

        // Constructor to initialize the factory with a specific version of the FAB weapon
        public CFABPartsFactory(IWeaponBlueprint blueprint)
        {
            // Retrieve the blueprint for the specified version from the repository
            this.blueprint = blueprint;
        }

        // Method to create a metal casing blueprint using the details from the retrieved blueprint
        public MetalCase BuildMetalCasing()
        {
            return new MetalCase(blueprint.CasingBlueprint);
        }

        // Method to create an explosive blueprint using the details from the retrieved blueprint
        public Explosive BuildExplosive()
        {
            return new Explosive(blueprint.ExplosiveBlueprint);
        }

        // Method to create a guidance kit blueprint using the details from the retrieved blueprint
        public GuidanceKit BuildGuidanceKit()
        {
            return new GuidanceKit(blueprint.GuidanceKitBlueprint);
        }

        // Method to create a detonation blueprint using the details from the retrieved blueprint
        public Detonation BuildDetonation()
        {
            return new Detonation(blueprint.DetonationBlueprint);
        }

        // Method to create a launcher blueprint using the details from the retrieved blueprint
        public Launcher BuildLauncher()
        {
            return new Launcher(blueprint.LauncherBlueprint);
        }

        public Propulsion BuildPropulsion()
        {
            return new Propulsion(blueprint.PropulsionBlueprint);
        }
    }
}