using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Factories
{
    public class CX69Factory
    {
        // Private field to hold the weapon blueprint
        public IWeaponBlueprint blueprint { get; }

        // Constructor to initialize the factory with a specific version of the FAB weapon
        public CX69Factory(int FABversion)
        {
            // Retrieve the blueprint for the specified version from the repository
            blueprint = CReasearchAndDevelopment.instance.GetBlueprint(WeaponFamilies.X69, FABversion);
        }

        // Method to create a metal casing blueprint using the details from the retrieved blueprint
        public MetalCase CreateMetalCasing()
        {
            return new MetalCase(blueprint.CasingBlueprint);
        }

        // Method to create an explosive blueprint using the details from the retrieved blueprint
        public Explosive CreateExplosive()
        {
            return new Explosive(blueprint.ExplosiveBlueprint);
        }

        // Method to create a guidance kit blueprint using the details from the retrieved blueprint
        public GuidanceKit CreateGuidanceKit()
        {
            return new GuidanceKit(blueprint.GuidanceKitBlueprint);
        }

        // Method to create a detonation blueprint using the details from the retrieved blueprint
        public Detonation CreateDetonation()
        {
            return new Detonation(blueprint.DetonationBlueprint);
        }

        // Method to create a launcher blueprint using the details from the retrieved blueprint
        public Launcher CreateLauncher()
        {
            return new Launcher(blueprint.LauncherBlueprint);
        }

        public Propulsion CreatePropulsion()
        {
            return new Propulsion(blueprint.PropulsionBlueprint);
        }
    }
}
