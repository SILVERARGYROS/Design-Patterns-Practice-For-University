using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.Blueprints {

    public interface IWeaponPartsBluePrint {
        string componentname { get; set; }
    }

    //Prototype Design Pattern
    public interface IPrototype<out T> {
        T Clone();
    }

    public interface IMetalCasingBlueprint : IPrototype<IMetalCasingBlueprint>, IWeaponPartsBluePrint {
        MetalCasingType MetalCasing { get; set; }
        int CasingWeightKG { get; set; }
        int CasingThicknessMM { get; set; }
    }

    public interface IExplosiveBlueprint : IPrototype<IExplosiveBlueprint>, IWeaponPartsBluePrint {
        ExplosiveType ExplosiveType { get; set; }
        int PayloadKG { get; set; }
    }

    public interface IDetonationBlueprint : IPrototype<IDetonationBlueprint>, IWeaponPartsBluePrint {
        DetonationType DetonationType { get; set; }
    }

    public interface IGuidanceKitBlueprint : IPrototype<IGuidanceKitBlueprint>, IWeaponPartsBluePrint {
        GuidanceType GuidanceType { get; set; }
    }

    public interface IPropulsionBlueprint : IPrototype<IPropulsionBlueprint>, IWeaponPartsBluePrint {
        FuelType FuelType { get; set; }
        int FuelWeightKG { get; set; }
        int ThrustMACH { get; set; }
    }

    public interface ILauncherBlueprint : IPrototype<ILauncherBlueprint>, IWeaponPartsBluePrint {
        LauncherType LauncherType { get; set; }
    }

}
