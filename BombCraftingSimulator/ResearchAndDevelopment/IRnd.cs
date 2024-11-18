using BombCraftingSimulator.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.ResearchAndDevelopment {
    internal interface IRnd {

        new public WeaponBlueprint GetBlueprint(WeaponFamily family, int code);

        new public void RegisterBlueprint(WeaponFamily family, int code, WeaponBlueprint blueprint);

        new public List<String> GetRegisteredFamilies();

        new public List<int> GetRegisteredFamilyCodes(WeaponFamily family);

        new public List<String> GetWeaponTypes();

        new public List<String> GetWeaponFamilies();

        new public IEnumerable<IWeaponStats> Stats();

    }
}
