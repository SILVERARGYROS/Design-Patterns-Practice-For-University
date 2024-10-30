using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.Blueprints {
    public interface IPrototype<out T> {
        T Clone();
    }

    public interface IMetalCasingBlueprint : IPrototype<IMetalCasingBlueprint> {
        MetalCasingType MetalCasing { get; set; }
        int CasingWeightKG { get; set; }
        int CasingThicknessMM { get; set; }
    }

    public interface IExplosiveBlueprint : IPrototype<IExplosiveBlueprint> {
        ExplosiveType ExplosiveType { get; set; }
        int PayloadKG { get; set; }
    }

    public interface IDetonationBlueprint : IPrototype<IDetonationBlueprint> {
        DetonationType DetonationType { get; set; }
    }

    public interface IGuidanceKitBlueprint : IPrototype<IGuidanceKitBlueprint> {
        GuidanceType GuidanceType { get; set; }
    }

    public interface IPropulsionBlueprint : IPrototype<IPropulsionBlueprint> {
        FuelType FuelType { get; set; }
        int FuelWeightKG { get; set; }
        int ThrustMACH { get; set; }
    }

    public interface IWeaponBlueprint : IPrototype<IWeaponBlueprint>, IWeaponStats {
        IMetalCasingBlueprint CasingBlueprint { get; set; }
        IExplosiveBlueprint ExplosiveBlueprint { get; set; }
        IDetonationBlueprint DetonationBlueprint { get; set; }
        IGuidanceKitBlueprint GuidanceKitBlueprint { get; set; }
        IPropulsionBlueprint PropalsionBlueprint { get; set; }

        public void ConfigureBlueprint(int type);
    }

    public interface IWeaponStats: IPrototype<IWeaponBlueprint> {
        long serial { get; set; }
        string weaponName { get; set; }
        int costKEUR { get; set; }
        int constructionRateW { get; set; } // crafted per week
        int DamageRadiusM { get; set; }
        int RangeM { get; set; }
        VelocityType CruiseSpeed { get; set; }
        WeaponType WeaponType { get; set; }
        LancherType LancherType { get; set; }
    }
}
