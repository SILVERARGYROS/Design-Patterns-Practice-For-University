using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons.Bombs;
using BombCraftingSimulator.Factories;
using BombCraftingSimulator.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;


//Builder represents the "WeaponFactory".Eventually, it retrieves the weapon parts after a request from the "WeaponPartsFactory" and assembles it.

namespace BombCraftingSimulator.Builder
{
    public interface IWeaponBuilder
    {
        void reset();
        void BuildMetalCasing();
        void BuildExplosives();
        void BuildPropulsion();
        void BuildGuidanceKit();
        void BuildDetonation();
        void BuildLauncher();
        IWeapon GetProduct();
    }

    public class CFABBuilder : IWeaponBuilder
    {
        private CFABFactory _factory;
        private FABBomb _bomb;

        public CFABBuilder(CFABFactory factory)
        {
            this._factory = factory;
            this._bomb = new FABBomb(_factory.blueprint);
        }

        public void reset()
        {
            this._bomb = new FABBomb(_factory.blueprint);
        }

        public void BuildMetalCasing()
        {
            _bomb._metalcase = this._factory.CreateMetalCasing();
        }

        public void BuildExplosives()
        {
            _bomb._explosive = this._factory.CreateExplosive();
        }

        public void BuildPropulsion()
        {
            _bomb._propulsion = this._factory.CreatePropulsion();
        }

        public void BuildGuidanceKit()
        {
            _bomb._guidancekit = this._factory.CreateGuidanceKit();
        }

        public void BuildDetonation()
        {
            _bomb._detonation = this._factory.CreateDetonation();
        }

        public void BuildLauncher()
        {
            _bomb._launcher = this._factory.CreateLauncher();
        }


        public IWeapon GetProduct()
        {
            return _bomb;
        }
    }

    public class CJDAMBuilder : IWeaponBuilder
    {
        private CJDAMFactory _factory;
        private JDAM _bomb;

        public CJDAMBuilder(CJDAMFactory factory)
        {
            this._factory = factory;
            this._bomb = new JDAM(_factory.blueprint);
        }

        public void reset()
        {
            this._bomb = new JDAM(_factory.blueprint);
        }

        public void BuildMetalCasing()
        {
            _bomb._metalcase = this._factory.CreateMetalCasing();
        }

        public void BuildExplosives()
        {
            _bomb._explosive = this._factory.CreateExplosive();
        }

        public void BuildPropulsion()
        {
            _bomb._propulsion = this._factory.CreatePropulsion();
        }

        public void BuildGuidanceKit()
        {
            _bomb._guidancekit = this._factory.CreateGuidanceKit();
        }

        public void BuildDetonation()
        {
            _bomb._detonation = this._factory.CreateDetonation();
        }

        public void BuildLauncher()
        {
            _bomb._launcher = this._factory.CreateLauncher();
        }

        public IWeapon GetProduct()
        {
            return _bomb;
        }

    }

    public class CMOABBuilder : IWeaponBuilder
    {
        private CMOABFactory _factory;
        private MOAB _bomb;

        public CMOABBuilder(CMOABFactory factory)
        {
            this._factory = factory;
            this._bomb = new MOAB(_factory.blueprint);
        }

        public void reset()
        {
            this._bomb = new MOAB(_factory.blueprint);
        }

        public void BuildMetalCasing()
        {
            _bomb._metalcase = this._factory.CreateMetalCasing();
        }

        public void BuildExplosives()
        {
            _bomb._explosive = this._factory.CreateExplosive();
        }

        public void BuildPropulsion()
        {
            _bomb._propulsion = this._factory.CreatePropulsion();
        }

        public void BuildGuidanceKit()
        {
            _bomb._guidancekit = this._factory.CreateGuidanceKit();
        }

        public void BuildDetonation()
        {
            _bomb._detonation = this._factory.CreateDetonation();
        }

        public void BuildLauncher()
        {
            _bomb._launcher = this._factory.CreateLauncher();
        }

        public IWeapon GetProduct()
        {
            return _bomb;
        }

    }

    public class CX69Builder : IWeaponBuilder
    {
        private CX69Factory _factory;
        private X69 _bomb;

        public CX69Builder(CX69Factory factory)
        {
            this._factory = factory;
            this._bomb = new X69(_factory.blueprint);
        }

        public void reset()
        {
            this._bomb = new X69(_factory.blueprint);
        }

        public void BuildMetalCasing()
        {
            _bomb._metalcase = this._factory.CreateMetalCasing();
        }

        public void BuildExplosives()
        {
            _bomb._explosive = this._factory.CreateExplosive();
        }

        public void BuildPropulsion()
        {
            _bomb._propulsion = this._factory.CreatePropulsion();
        }

        public void BuildGuidanceKit()
        {
            _bomb._guidancekit = this._factory.CreateGuidanceKit();
        }

        public void BuildDetonation()
        {
            _bomb._detonation = this._factory.CreateDetonation();
        }

        public void BuildLauncher()
        {
            _bomb._launcher = this._factory.CreateLauncher();
        }

        public IWeapon GetProduct()
        {
            return _bomb;
        }

    }
}