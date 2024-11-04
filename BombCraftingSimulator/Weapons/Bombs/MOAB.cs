using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Weapons.Bombs
{
    public class MOAB : IWeapon
    {
        public IWeaponBlueprint blueprint { get; }

        public Detonation _detonation { get; set; }
        public Explosive _explosive { get; set; }
        public MetalCase _metalcase { get; set; }
        public Launcher _launcher { get; set; }
        public Propulsion _propulsion { get; set; }
        public GuidanceKit _guidancekit { get; set; }

        public MOAB(IWeaponBlueprint blueprint)
        {
            this.blueprint = blueprint;
        }

        public void Launch()
        {
            Console.WriteLine("MOAB goes boom");
        }

        public override string ToString()
        {
            return blueprint.weaponName;
        }
    }
}
