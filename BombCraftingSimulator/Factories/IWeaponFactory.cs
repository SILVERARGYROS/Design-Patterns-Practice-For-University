using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Factories {
    public interface IWeaponFactory {
        IWeaponPartsFactory GetWeaponPartsFactory(IWeaponBlueprint blueprint) {
            WeaponFamily weaponFamily = blueprint.WeaponFamily;
            if (weaponFamily == WeaponFamily.FAB) {
                return new CFABPartsFactory(blueprint);
            } else if (weaponFamily == WeaponFamily.JDAM) {
                return new CFABPartsFactory(blueprint);
            } else if (weaponFamily == WeaponFamily.MOAB) {
                return new CFABPartsFactory(blueprint);
            } else if (weaponFamily == WeaponFamily.X69) {
                return new CFABPartsFactory(blueprint);
            } else {
                Console.WriteLine("Factory family not found. Returning NULL WeaponPart Factory.");
                return null;
            }
        }

        IWeapon BuildWeapon();
    }
}
