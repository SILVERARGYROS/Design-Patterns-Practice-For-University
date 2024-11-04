//using BombCraftingSimulator.Weapons;
//using BombCraftingSimulator.WeaponSpecs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BombCraftingSimulator.Builder
//{
//    // Proxy class 
//    public class CachedArmyFactory : IWeaponFactory 
//    {
//        private ArmyFactory _factory;
//        private List<IWeapon> _weapon_listCache;
//        private bool needReset;

//        public CachedArmyFactory(ArmyFactory factory) 
//        {
//            _factory = factory;
//        }

//        public IWeapon Construct(WeaponFamily family, int version)
//        {
//            if (_weapon_listCache.Find(w => w.blueprint.WeaponFamily == family && w.blueprint.version == version) == null)
//                _weapon_listCache.Add(_factory.Construct(family, version));

//            return _weapon_listCache.Find(w => w.blueprint.WeaponFamily == family && w.blueprint.version == version);
//        }
//    }
//}
