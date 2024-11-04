using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.WeaponSpecs {

    public enum WeaponFamily : byte {
        FAB,
        JDAM,
        MOAB,
        X69
    }

    public enum MetalCasingType {
        Steel,
        Titanium,
        Tungsten,
        DepletedUranium
    }

    public enum ExplosiveType {
        HighExplosive,
        Fragmentation,
        Incendiary,
        Cluster,
        Thermobaric
    }

    public enum GuidanceType {
        Laser,
        GPS,
        Inertial,
        Radar,
        TV,
        Ballistic
    }

    public enum FuelType {
        Solid,
        Liquid,
        Hybrid
    }

    public enum LauncherType {
        Mortar,
        Howitzer,
        Cannon,
        RocketLauncher,
        Aeroplane
    }

    public enum FABTypes {
        FAB250,
        FAB500,
        FAB5000,
        FAB9000
    }

    public enum JDAMTypes : byte {
        GBU_31,
        GBU_31V,
        GBU_31V_3,
        GBU_31V_4
    }

    public enum x69Types : byte {
        x69M,
        x69MK,
        x69MR
    }

    public enum MOABTypes : byte {
        GBU_43,
        GBU_43V,
        GBU_43V_3,
        GBU_43V_4

    }

    public enum DetonationType {
        Impact,
        Proximity,
        Timed,
        Remote,
        Command
    }

    [Flags] // idiothta gia na syndiazontai ta weaponTypes metaji toys
    public enum WeaponType {
        AntiPersonnel,
        AntiTank,
        AntiFortification,
        AntiInfrastructure,
        Entry_Denial, // new
        Concealment   // new
    }

    public enum VelocityType {
        Subsonic,
        Supersonic,
        Hypersonic
    }
}
