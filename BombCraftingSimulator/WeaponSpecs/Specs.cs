using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.WeaponSpecs {
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

    public enum LancherType {
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
        AntiInfrastructure
    }

    public enum VelocityType {
        Subsonic,
        Supersonic,
        Hypersonic
    }
}
