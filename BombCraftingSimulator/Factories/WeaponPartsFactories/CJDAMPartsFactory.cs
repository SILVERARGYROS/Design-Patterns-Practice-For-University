﻿using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using BombCraftingSimulator.WeaponSpecs.WeaponParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Factories
{
    public class CJDAMPartsFactory : IWeaponPartsFactory
    {
        // Private field to hold the weapon blueprint
        public IWeaponBlueprint blueprint { get; }

        public CJDAMPartsFactory(IWeaponBlueprint blueprint)
        {
           this.blueprint = blueprint;
        }

        // Method to create a metal casing blueprint using the details from the retrieved blueprint
        public MetalCase BuildMetalCasing()
        {
            Program.Print("Building JDAM metal casing.", "Green");
            return new MetalCase(blueprint.CasingBlueprint);
        }

        // Method to create an explosive blueprint using the details from the retrieved blueprint
        public Explosive BuildExplosive()
        {
            Program.Print("Building JDAM explosive.", "Green");
            return new Explosive(blueprint.ExplosiveBlueprint);
        }

        // Method to create a guidance kit blueprint using the details from the retrieved blueprint
        public GuidanceKit BuildGuidanceKit()
        {
            Program.Print("Building JDAM guidance kit.", "Green");
            return new GuidanceKit(blueprint.GuidanceKitBlueprint);
        }

        // Method to create a detonation blueprint using the details from the retrieved blueprint
        public Detonation BuildDetonation()
        {
            Program.Print("Building JDAM detonation.", "Green");
            return new Detonation(blueprint.DetonationBlueprint);
        }

        // Method to create a launcher blueprint using the details from the retrieved blueprint
        public Launcher BuildLauncher()
        {
            Program.Print("Building JDAM launcher.", "Green");
            return new Launcher(blueprint.LauncherBlueprint);
        }

        public Propulsion BuildPropulsion()
        {
            Program.Print("Building JDAM propulsion.", "Green");
            return new Propulsion(blueprint.PropulsionBlueprint);
        }
    }
}
