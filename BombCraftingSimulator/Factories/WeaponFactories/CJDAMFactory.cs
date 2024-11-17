using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons.Bombs;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.WeaponSpecs;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Factories.WeaponFactories
{
    public class CJDAMFactory : IWeaponFactory
    {
        // Private fields to hold the weapon blueprint and corresponding factory
        private IWeaponBlueprint blueprint;
        private IWeaponPartsFactory weaponPartsFactory;

        // Private fields to hold the weapon parts
        private MetalCase metalCase = null;
        private Explosive explosive = null;
        private GuidanceKit guidanceKit = null;
        private Detonation detonation = null;
        private Launcher launcher = null;
        private Propulsion propulsion = null;


        public CJDAMFactory(IWeaponBlueprint blueprint) {
            this.blueprint = blueprint;
            this.weaponPartsFactory = ((IWeaponFactory)this).GetWeaponPartsFactory(blueprint); // I don't know how to feel about this line...
        }

        public IWeapon BuildWeapon() {
            Console.WriteLine("Gathering weapon parts.");

            metalCase = weaponPartsFactory.BuildMetalCasing();
            explosive = weaponPartsFactory.BuildExplosive();
            guidanceKit = weaponPartsFactory.BuildGuidanceKit();
            detonation = weaponPartsFactory.BuildDetonation();
            launcher = weaponPartsFactory.BuildLauncher();
            propulsion = weaponPartsFactory.BuildPropulsion();

            Console.WriteLine("Constructing weapon...");
            metalCase = null;
            explosive = null;
            guidanceKit = null;
            detonation = null;
            launcher = null;
            propulsion = null;

            Console.WriteLine("Passing back freshly created weapon.");
            return new JDAM(blueprint);
        }
    }
}
