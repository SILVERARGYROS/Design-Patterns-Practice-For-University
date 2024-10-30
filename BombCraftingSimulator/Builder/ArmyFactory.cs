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

    interface IWeaponFactory
    {
        public IWeapon Construct(WeaponFamilies family, int version);
    }

     public class ArmyFactory : IWeaponFactory // Director class of BuilderFactory
    {
        public IWeapon weapon { get; set; }
        public IWeaponBlueprint weaponblueprint { get; set; }

        private IWeaponBuilder _weaponbuilder;

        public ArmyFactory()
        {
            
        }

        public void changeBuilder(IWeaponBuilder builderfactory)
        {
            this._weaponbuilder = builderfactory;
        }

        // Method to construct a weapon based on the specified family and version
        public IWeapon Construct(WeaponFamilies family, int version)
        {

            // Retrieve the builder and blueprint for the specified family and version
            var (_builder, _blueprint) = GetWeaponManufactures(family, version);
            _weaponbuilder = _builder;

            // Build the various components of the weapon if their blueprints are not null
            if (_blueprint.CasingBlueprint != null)
            {
                _weaponbuilder.BuildMetalCasing();
            }
            if (_blueprint.ExplosiveBlueprint != null)
            {
                _weaponbuilder.BuildExplosives();
            }
            if (_blueprint.GuidanceKitBlueprint != null)
            {
                _weaponbuilder.BuildGuidanceKit();
            }
            if (_blueprint.DetonationBlueprint != null)
            {
                _weaponbuilder.BuildDetonation();
            }
            if (_blueprint.LauncherBlueprint != null)
            {
                _weaponbuilder.BuildLauncher();
            }

            // Return the constructed weapon
            return _weaponbuilder.GetProduct();
        }

        // Private method to get the weapon builder and blueprint for the specified family and version
        private (IWeaponBuilder, IWeaponBlueprint) GetWeaponManufactures(WeaponFamilies family, int version)
        {

            // Retrieve the blueprint for the specified family and version from the repository
            IWeaponBlueprint blueprint = CReasearchAndDevelopment.GetInstance().GetBlueprint(family, version);

            // Throw an exception if the blueprint is invalid
            if (blueprint == null)
            {
                throw new ArgumentException("Invalid weapon version");
            }

            // Return the appropriate builder and blueprint based on the weapon family
            switch (family)
            {
                case WeaponFamilies.FAB:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CFABFactory fabFactory = new CFABFactory(version);
                    return (new CFABBuilder(fabFactory), blueprint);
                case WeaponFamilies.MOAB:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CJDAMFactory jdamFactory = new CJDAMFactory(version);
                    return (new CJDAMBuilder(jdamFactory), blueprint);
                case WeaponFamilies.JDAM:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CMOABFactory moabFactory = new CMOABFactory(version);
                    return (new CMOABBuilder(moabFactory), blueprint);
                case WeaponFamilies.X69:
                    // Create a factory for FAB weapon parts and return the builder and blueprint
                    CX69Factory x69Factory = new CX69Factory(version);
                    return (new CX69Builder(x69Factory), blueprint);
                default:
                    // Throw an exception if the weapon family is invalid
                    throw new ArgumentException("Invalid weapon family");
            }
        }


    }

    
}
