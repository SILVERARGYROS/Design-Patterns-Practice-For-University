using BombCraftingSimulator.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Weapons;

namespace BombCraftingSimulator.Decorator {
    internal interface IBombDecorator : IWeapon{
        new IWeaponBlueprint blueprint { get; }
        new String Launch();
    }
}
