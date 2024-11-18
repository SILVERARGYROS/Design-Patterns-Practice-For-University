using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.MinistryOfNationalDefence;
using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.ResearchAndDevelopment {
    class ProxyRnd : IRnd{

        private static Rnd instance = null;

        public ProxyRnd() {

        }

        private void initializeInstance() {
            instance = Rnd.GetInstance();
        }

        private Boolean isAuthorized() {
            // How to get Class name that is calling my method?: https://stackoverflow.com/questions/48570573/how-to-get-class-name-that-is-calling-my-method
            var methodInfo = new StackTrace().GetFrame(2).GetMethod();
            var className = methodInfo.ReflectedType.Name;

            return className.Equals(typeof(ArmyCommand).Name);
        }
        public WeaponBlueprint GetBlueprint(WeaponFamily family, int code) {
            if (!isAuthorized()) {
                Program.Print("Caller not authorized to access RND", "DarkRed");
                return null;
            }
            Program.Print("Verification complete. Caller authorized to access RND", "Blue");

            initializeInstance();
            return instance.GetBlueprint(family, code);
        }

        public void RegisterBlueprint(WeaponFamily family, int code, WeaponBlueprint blueprint) {
            if (!isAuthorized()) {
                return;
            }

            initializeInstance();
            instance.RegisterBlueprint(family, code, blueprint);
        }

        public List<String> GetRegisteredFamilies() {
            if (!isAuthorized()) {
                return null;
            }

            initializeInstance();
            return instance.GetRegisteredFamilies();
        }

        public List<int> GetRegisteredFamilyCodes(WeaponFamily family) {
            if (!isAuthorized()) {
                return null;
            }

            initializeInstance();
            return instance.GetRegisteredFamilyCodes(family);
        }

        public List<String> GetWeaponTypes() {
            if (!isAuthorized()) {
                return null;
            }

            initializeInstance();
            return instance.GetWeaponTypes();
        }

        public List<String> GetWeaponFamilies() {
            if (!isAuthorized()) {
                return null;
            }

            initializeInstance();
            return instance. GetWeaponFamilies();
        }

        public IEnumerable<IWeaponStats> Stats() {
            if (!isAuthorized()) {
                return null;
            }

            initializeInstance();
            return instance.Stats();
        }
    }
}
