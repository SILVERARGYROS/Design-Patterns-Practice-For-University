using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Blueprints {

    public interface IWeaponBlueprint : IPrototype<IWeaponBlueprint>, IWeaponStats {
        IMetalCasingBlueprint CasingBlueprint { get; set; }
        IExplosiveBlueprint ExplosiveBlueprint { get; set; }
        IDetonationBlueprint DetonationBlueprint { get; set; }
        IGuidanceKitBlueprint GuidanceKitBlueprint { get; set; }
        IPropulsionBlueprint PropulsionBlueprint { get; set; }
        ILauncherBlueprint LauncherBlueprint { get; set; }
    }

    public interface IWeaponStats : IPrototype<IWeaponBlueprint> {
        long serial { get; set; }
        string weaponName { get; set; }
        int costKEUR { get; set; }
        int constructionRateW { get; set; } // crafted per week
        int DamageRadiusM { get; set; }
        int RangeM { get; set; }
        int version { get; set; }          // refers to WeaponTypes (e.g.: enum JDAMTypes, MOABTypes etc...)
        VelocityType CruiseSpeed { get; set; }
        WeaponType WeaponType { get; set; }
        WeaponFamily WeaponFamily { get; set; }
        LauncherType LancherType { get; set; }
        
    }

}
