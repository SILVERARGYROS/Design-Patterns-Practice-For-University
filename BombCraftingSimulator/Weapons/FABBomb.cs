using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.Weapons {
    public class FABBomb : IWeapon {
        IWeaponBlueprint blueprint;

        public FABBomb(IWeaponBlueprint blueprint) {
            this.blueprint = blueprint;
        }

        public void Launch() {
            Console.WriteLine("boom");
        }

        public override string ToString() {
            return blueprint.name;
        }
    }
}
