using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;

namespace BombCraftingSimulator.WeaponSpecs.WeaponParts
{
    public interface IWeaponPart
    {
        IWeaponPartsBluePrint _weaponblueprint { get; set; }
    }
}


