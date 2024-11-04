using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Builder;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator
{
    // We create a facade class to hide the framework's complexity
    // behind a simple interface. It's a trade-off between
    // functionality and simplicity.

    // Application classes don't depend on a billion classes
    // provided by the complex framework. Also, if you decide to
    // switch frameworks, you only need to rewrite the facade class.
    public class WeaponConstructor 
    {
        public WeaponConstructor() 
        {
            
        }

        public IWeapon construct(WeaponBlueprint blueprint)
        {
            ArmyFactory director = new ArmyFactory();
            
            return director.Construct(blueprint); 
        }
    }
}
