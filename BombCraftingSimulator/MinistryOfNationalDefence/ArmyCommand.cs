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
        //https://refactoring.guru/design-patterns/singleton
        private static ArmyCommand instance;

        private IWeaponBlueprint _blueprint;
        private IWeapon _weapon;

        private ArmyCommand()
        {
            
        }


        public static ArmyCommand getInstance()
        {
            if (instance == null)
            {
                lock (instance)
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
        public void RequestsWeapon(ArmyFactory army_factory, WeaponFamily family, int version)
        {
            army_factory.Construct(family, version);
        }

        //Make a Request Approval Process to the recipient
        //IWeaponBluePrint
        public void RequestsWeaponΒlueprints(RND rnd, WeaponFamily family, int version)
        {
            rnd.GetBlueprint(family, version);
        }

        public List<String> RequestWeaponTypes(RND rnd) {
            return rnd.GetWeaponTypes();
        }

        public List<String> RequestWeaponFamilies(RND rnd) {
            return rnd.GetWeaponFamilies();
        }
    }
}
