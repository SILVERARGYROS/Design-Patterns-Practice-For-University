﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;

namespace BombCraftingSimulator.Weapons.Bombs
{
    public class JDAM : IWeapon
    {
        public IWeaponBlueprint blueprint { get; }

        public Detonation _detonation { get; set; }
        public Explosive _explosive { get; set; }
        public MetalCase _metalcase { get; set; }
        public Launcher _launcher { get; set; }
        public Propulsion _propulsion { get; set; }
        public GuidanceKit _guidancekit { get; set; }

        public JDAM(IWeaponBlueprint blueprint)
        {
            this.blueprint = blueprint;
            Program.Print("Created JDAM.", "Green");
        }

        public String Launch()
        {
            return "JDAM goes boom.";
        }

        public override string ToString()
        {
            return blueprint.weaponName;
        }
    }
}
