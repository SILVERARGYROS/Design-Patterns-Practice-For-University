using BombCraftingSimulator.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Weapons {

    public interface IWeapon {
        IWeaponBlueprint blueprint { get; }
        void Launch();
    }
}
