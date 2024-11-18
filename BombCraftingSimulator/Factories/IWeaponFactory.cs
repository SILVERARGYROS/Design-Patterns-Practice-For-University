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
                Program.Print("Selected FAB weapon factory.", "Green");
                return new CFABPartsFactory(blueprint);
            } else if (weaponFamily == WeaponFamily.JDAM) {
                Program.Print("Selected JDAM weapon factory.", "Green");
                return new CFABPartsFactory(blueprint);
            } else if (weaponFamily == WeaponFamily.MOAB) {
                Program.Print("Selected MOAB weapon factory.", "Green");
                return new CFABPartsFactory(blueprint);
            } else if (weaponFamily == WeaponFamily.X69) {
                Program.Print("Selected X69 weapon factory.", "Green");
                return new CFABPartsFactory(blueprint);
            } else {
                Program.Print("Factory family not found. Returning NULL WeaponPart Factory.", "DarkRed");
                return null;
            }
        }

        IWeapon BuildWeapon();
    }
}
