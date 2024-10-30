using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.Builder;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.MinistryOfNationalDefence
{

    public class ArmyCommand
    {
        private static readonly object lockObject = new object();
        private static ArmyCommand instance;

        private IWeaponBlueprint _blueprint;
        private IWeapon _weapon;

        private ArmyCommand()
        {
            
        }


        public static ArmyCommand GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ArmyCommand();
                    }
                }
            }
            return instance;
        }

        // IWeapon
        public void RequestsWeapon(ArmyFactory army_factory, WeaponFamilies family, int version)
        {
            army_factory.Construct(family, version);
        }

        //Make a Request Approval Process to the recipient
        //IWeaponBluePrint
        public void RequestsWeaponblueprints(CReasearchAndDevelopment rnd, WeaponFamilies family, int version)
        {
            rnd.GetBlueprint(family, version);
        }

      
    }
}
