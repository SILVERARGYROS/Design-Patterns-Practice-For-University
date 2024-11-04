using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.WeaponSpecs;
using BombCraftingSimulator.Factories;
using System.Globalization;

namespace BombCraftingSimulator.Builder
{

    interface IWeaponFactory {
        public IWeapon Construct(WeaponBlueprint blueprint);
    }

     public class ArmyFactory : IWeaponFactory { // Director class of BuilderFactory
        public IWeapon weapon { get; set; }
        public IWeaponBlueprint weaponblueprint { get; set; }

        private IWeaponBuilder _weaponbuilder;

        public ArmyFactory()
        {
            
        }

        public void changeBuilder(IWeaponBuilder builderfactory) {
            this._weaponbuilder = builderfactory;
        }

        // Method to construct a weapon based on the specified family and version
        public IWeapon Construct(WeaponBlueprint blueprint) {
            WeaponFamily family = blueprint.WeaponFamily;
            int version = blueprint.version;

            // Retrieve the builder and blueprint for the specified family and version
            IWeaponBuilder _weaponbuilder = GetWeaponBuilder(blueprint);

            // Build the various components of the weapon if their blueprints are not null
            if (blueprint.CasingBlueprint != null){
                _weaponbuilder.BuildMetalCasing();
            }
            if (blueprint.ExplosiveBlueprint != null){
                _weaponbuilder.BuildExplosives();
            }
            if (blueprint.GuidanceKitBlueprint != null){
                _weaponbuilder.BuildGuidanceKit();
            }
            if (blueprint.DetonationBlueprint != null){
                _weaponbuilder.BuildDetonation();
            }
            if (blueprint.LauncherBlueprint != null){
                _weaponbuilder.BuildLauncher();
            }

            // Return the constructed weapon
            return _weaponbuilder.GetProduct();
        }

        // Private method to get the weapon builder and blueprint for the specified family and version
        private IWeaponBuilder GetWeaponBuilder(WeaponBlueprint blueprint) {
            // Throw an exception if the blueprint is invalid
            if (blueprint == null) {
                throw new ArgumentException("Invalid weapon version");
            }
            blueprint.version = blueprint.version;
            // Return the appropriate builder and blueprint based on the weapon family
            switch (blueprint.WeaponFamily) {
                case WeaponFamily.FAB:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CFABFactory fabFactory = new CFABFactory(blueprint);
                return new CFABBuilder(fabFactory);
                case WeaponFamily.MOAB:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CJDAMFactory jdamFactory = new CJDAMFactory(blueprint);
                return new CJDAMBuilder(jdamFactory);
                case WeaponFamily.JDAM:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CMOABFactory moabFactory = new CMOABFactory(blueprint);
                return new CMOABBuilder(moabFactory);
                case WeaponFamily.X69:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CX69Factory x69Factory = new CX69Factory(blueprint);
                return new CX69Builder(x69Factory);
                default:
                    // Throw an exception if the weapon family is invalid
                throw new ArgumentException("Invalid weapon family");
            }
        }
     }
}
