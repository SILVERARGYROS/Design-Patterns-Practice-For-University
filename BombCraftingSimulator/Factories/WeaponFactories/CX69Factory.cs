using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Weapons.Bombs;
using BombCraftingSimulator.Weapons;

namespace BombCraftingSimulator.Factories.WeaponFactories
{
    public class CX69Factory : IWeaponFactory {

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


        public CX69Factory(IWeaponBlueprint blueprint) {
            this.blueprint = blueprint;
            this.weaponPartsFactory = ((IWeaponFactory)this).GetWeaponPartsFactory(blueprint); // I don't know how to feel about this line...
        }

        public IWeapon BuildWeapon() {

            Program.Print("Gathering weapon parts.", "Green");
            metalCase = weaponPartsFactory.BuildMetalCasing();
            explosive = weaponPartsFactory.BuildExplosive();
            guidanceKit = weaponPartsFactory.BuildGuidanceKit();
            detonation = weaponPartsFactory.BuildDetonation();
            launcher = weaponPartsFactory.BuildLauncher();
            propulsion = weaponPartsFactory.BuildPropulsion();

            Program.Print("Constructing weapon.", "Green");
            metalCase = null;
            explosive = null;
            guidanceKit = null;
            detonation = null;
            launcher = null;
            propulsion = null;

            Program.Print("Passing back freshly created weapon.", "Green");
            return new X69(blueprint);
        }
    }
}
