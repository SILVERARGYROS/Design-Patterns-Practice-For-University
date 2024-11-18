using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.Builder;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using BombCraftingSimulator.ResearchAndDevelopment;

namespace BombCraftingSimulator.MinistryOfNationalDefence
{
    public class ArmyCommand {

        // Singleton Pattern: https://refactoring.guru/design-patterns/singleton
        private static ArmyCommand instance;
        private static Object mutex;

        private IWeaponBlueprint _blueprint;
        private IWeapon _weapon;
        private ProxyRnd rnd = new ProxyRnd();

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

        // Army Factory Methods
        public IWeapon RequestsWeapon(ArmyFactory army_factory, WeaponBlueprint blueprint) {
            return army_factory.RequestBomb(blueprint);
        }

        // IRND Methods
        public void RegisterBlueprint(WeaponFamily family, int code, WeaponBlueprint blueprint) {
            rnd.RegisterBlueprint(family, code, blueprint);
        }

        public WeaponBlueprint RequestWeaponΒlueprint(WeaponFamily family, int version) {
            Program.Print("Requesting blueprint for " + family + " version " + version + " from proxy RND.", "Blue");
            return rnd.GetBlueprint(family, version);
        }

        public List<String> RequestWeaponTypes() {
            return rnd.GetWeaponTypes();
        }

        public List<String> RequestWeaponFamilies() {
            return rnd.GetWeaponFamilies();
        }

        public WeaponFamily GetWeaponFamilyFromString(String family) {
            return rnd.GetFamilyFromString(family);
        }

        public List<int> RequestFamilyCodes(WeaponFamily family) {
            return rnd.GetRegisteredFamilyCodes(family);
        }

        public IEnumerable<IWeaponStats> RequestStats() {
            return rnd.Stats();
        }
    }
}
