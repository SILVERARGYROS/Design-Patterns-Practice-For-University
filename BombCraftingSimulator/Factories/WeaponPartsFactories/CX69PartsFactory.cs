using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Factories.WeaponFactories
{
    public class CX69PartsFactory : IWeaponPartsFactory {
        // Private field to hold the weapon blueprint
        public IWeaponBlueprint blueprint { get; }

        public CX69PartsFactory(IWeaponBlueprint blueprint)
        {
            this.blueprint = blueprint;
        }

        // Method to create a metal casing blueprint using the details from the retrieved blueprint
        public MetalCase BuildMetalCasing()
        {
            Program.Print("Building X69 metal casing.", "Green");
            return new MetalCase(blueprint.CasingBlueprint);
        }

        // Method to create an explosive blueprint using the details from the retrieved blueprint
        public Explosive BuildExplosive()
        {
            Program.Print("Building X69 explosive.", "Green");
            return new Explosive(blueprint.ExplosiveBlueprint);
        }

        // Method to create a guidance kit blueprint using the details from the retrieved blueprint
        public GuidanceKit BuildGuidanceKit()
        {
            Program.Print("Building X69 guidance kit.", "Green");
            return new GuidanceKit(blueprint.GuidanceKitBlueprint);
        }

        // Method to create a detonation blueprint using the details from the retrieved blueprint
        public Detonation BuildDetonation()
        {
            Program.Print("Building X69 detonation.", "Green");
            return new Detonation(blueprint.DetonationBlueprint);
        }

        // Method to create a launcher blueprint using the details from the retrieved blueprint
        public Launcher BuildLauncher()
        {
            Program.Print("Building X69 launcher.", "Green");
            return new Launcher(blueprint.LauncherBlueprint);
        }

        public Propulsion BuildPropulsion()
        {
            Program.Print("Building X69 propulsion.", "Green");
            return new Propulsion(blueprint.PropulsionBlueprint);
        }
    }
}
