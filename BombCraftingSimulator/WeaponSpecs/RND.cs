using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;

namespace BombCraftingSimulator.WeaponSpecs {
    public class CReasearchAndDevelopment {
        Dictionary<int, IWeaponBlueprint> _blueprintRegistry = new Dictionary<int, IWeaponBlueprint>();
        public IWeaponBlueprint GetBlueprint(int code) {
            if (_blueprintRegistry.ContainsKey(code)) {
                return _blueprintRegistry[code];
            }
            // exception handling - check if code exists
            return null;
        }

        public void RegisterBlueprint(int code, IWeaponBlueprint blueprint) {
            _blueprintRegistry.Add(code, blueprint);
        }

        public IEnumerable<IWeaponStats> Stats() {
            foreach (var stat in _blueprintRegistry.Values) {
                yield return stat;
            }
        }
    }
}
