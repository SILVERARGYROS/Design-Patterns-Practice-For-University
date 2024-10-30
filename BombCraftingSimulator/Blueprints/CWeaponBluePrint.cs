using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.Blueprints
{
    public class WeaponBlueprint : IWeaponBlueprint{
        //weapon parts
        public IMetalCasingBlueprint CasingBlueprint { get; set; }
        public IExplosiveBlueprint ExplosiveBlueprint { get; set; }
        public IDetonationBlueprint DetonationBlueprint { get; set; }
        public IGuidanceKitBlueprint GuidanceKitBlueprint { get; set; }
        public IPropulsionBlueprint PropulsionBlueprint { get; set; }
        public ILauncherBlueprint LauncherBlueprint { get; set; }

        //weapon stats
        public long serial { get; set; }
        public string weaponName { get; set; }
        public int costKEUR { get; set; }
        public int constructionRateW { get; set; } // crafted per week
        public int DamageRadiusM { get; set; }
        public int RangeM { get; set; }
        public int version { get; set; }
        public VelocityType CruiseSpeed { get; set; }
        public WeaponType WeaponType { get; set; }
        public WeaponFamilies WeaponFamily { get; set; }
        public LauncherType LancherType { get; set; }
        

        public WeaponBlueprint()
        {

        }

        // Implement the Clone() method for IPrototype<IWeaponBlueprint>
        public IWeaponBlueprint Clone()
        {
            return new WeaponBlueprint()
            {
                CasingBlueprint = this.CasingBlueprint?.Clone(),
                ExplosiveBlueprint = this.ExplosiveBlueprint?.Clone(),
                DetonationBlueprint = this.DetonationBlueprint?.Clone(),
                GuidanceKitBlueprint = this.GuidanceKitBlueprint?.Clone(),
                PropulsionBlueprint = this.PropulsionBlueprint?.Clone()
            };
        }
    }
}
