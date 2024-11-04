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
        private static Object mutex;

        private IWeaponBlueprint _blueprint;
        private IWeapon _weapon;
        private RND rnd = new RND();

        private ArmyCommand()
        {
            
        }


        public static ArmyCommand GetInstance()
        {
            if (instance == null)
            {
                // To make sure the mutex object is initialized only once
                if (mutex == null) {
                    mutex = new Object();
                }

                lock (mutex)
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
        public void RequestsWeapon(ArmyFactory army_factory, WeaponBlueprint blueprint)
        {
            army_factory.Construct(blueprint);
        }

        //Make a Request Approval Process to the recipient
        //IWeaponBluePrint
        public WeaponBlueprint RequestWeaponΒlueprint(WeaponFamily family, int version)
        {
            return rnd.GetBlueprint(family, version);
        }

        public List<String> RequestWeaponTypes() {
            return rnd.GetWeaponTypes();
        }

        public List<String> RequestWeaponFamilies() {
            return rnd.GetWeaponFamilies();
        }
    }
}
