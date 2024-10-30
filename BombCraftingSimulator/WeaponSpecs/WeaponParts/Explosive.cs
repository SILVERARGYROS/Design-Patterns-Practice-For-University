using BombCraftingSimulator.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.WeaponSpecs.WeaponParts
{
    public class Explosive : IWeaponPart
    {
        public IWeaponPartsBluePrint _weaponblueprint { get; set; }

        public Explosive(IExplosiveBlueprint _weaponblueprint)
        {
            this._weaponblueprint = _weaponblueprint;
        }

        public override string ToString()
        {
            return _weaponblueprint.componentname;
        }
    }
}
