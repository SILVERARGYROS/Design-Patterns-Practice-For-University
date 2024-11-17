using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons.Bombs;

namespace BombCraftingSimulator.WeaponSpecs {
    public class RND {
        private static RND instance;

        Dictionary<(WeaponFamily,int), WeaponBlueprint> _blueprintRegistry;

        public RND() {
            _blueprintRegistry = new Dictionary<(WeaponFamily, int), WeaponBlueprint>();
            initializeBlueprintRegistery();
        }

        private void initializeBlueprintRegistery() {   // Need to implement a more dynamic way later
            RegisterBlueprint(WeaponFamily.FAB, 0, new WeaponBlueprint());
            RegisterBlueprint(WeaponFamily.MOAB, 0, new WeaponBlueprint());
            RegisterBlueprint(WeaponFamily.X69, 0, new WeaponBlueprint());
            RegisterBlueprint(WeaponFamily.JDAM, 0, new WeaponBlueprint());
        }

        public WeaponBlueprint GetBlueprint(WeaponFamily family, int code) {
            if (_blueprintRegistry.ContainsKey((family, code))) {
                return (WeaponBlueprint) _blueprintRegistry[(family, code)].Clone();
            }
            // exception handling - check if code exists
            return null;
        }

        public void RegisterBlueprint(WeaponFamily family, int code, WeaponBlueprint blueprint) {
            _blueprintRegistry.Add((family,code), blueprint);
        }

        public List<String> GetRegisteredFamilies() {
            // How to get keys from hashmap in C#: https://stackoverflow.com/questions/1276763/how-do-i-get-the-list-of-keys-in-a-dictionary
            List<(WeaponFamily, int)> tupleList = new List<(WeaponFamily, int)>(_blueprintRegistry.Keys);

            List<String> familyList = new List<string>();


            foreach ((WeaponFamily,int) tuple in tupleList) {
                // How to get tuple items in C#: https://stackoverflow.com/questions/21277364/best-way-to-get-the-value-from-a-tuple-in-c-sharp
                // How to get enumaration name in c#: https://stackoverflow.com/questions/309333/enum-string-name-from-value
                String family = tuple.Item1.ToString();
                if (!familyList.Contains(family)) { 
                    familyList.Add(family);
                }
            }
            return familyList;
        }

        public List<int> GetRegisteredFamilyCodes(WeaponFamily family) {
            // How to get keys from hashmap in C#: https://stackoverflow.com/questions/1276763/how-do-i-get-the-list-of-keys-in-a-dictionary
            List<(WeaponFamily, int)> tupleList = new List<(WeaponFamily, int)>(_blueprintRegistry.Keys);

            List<int> familyCodeList = new List<int>();


            foreach ((WeaponFamily, int) tuple in tupleList) {
                // How to get tuple items in C#: https://stackoverflow.com/questions/21277364/best-way-to-get-the-value-from-a-tuple-in-c-sharp
                // How to get enumaration name in c#: https://stackoverflow.com/questions/309333/enum-string-name-from-value
                int code = tuple.Item2;
                if (family == tuple.Item1 && !familyCodeList.Contains(code)) {
                    familyCodeList.Add(code);
                }
            }
            return familyCodeList;
        }

        // How to loop through all enum values in C#: https://stackoverflow.com/questions/972307/how-to-loop-through-all-enum-values-in-c
        public List<String> GetWeaponTypes() {
            List<String> types = new List<String>();

            foreach (WeaponType type in Enum.GetValues(typeof(WeaponType))) {
                switch (type) {
                    case WeaponType.AntiPersonnel:
                        types.Add("AntiPersonnel");
                    break;
                    case WeaponType.AntiTank:
                        types.Add("AntiTank");
                    break;
                    case WeaponType.AntiFortification:
                        types.Add("AntiFortification");
                    break;
                    case WeaponType.AntiInfrastructure:
                        types.Add("AntiInfrastructure");
                    break;
                    case WeaponType.Entry_Denial:
                        types.Add("Entry_Denial");
                    break;
                    case WeaponType.Concealment:
                        types.Add("Concealment");
                    break;
                }
            }

            return types;
        }

        public List<String> GetWeaponFamilies() {
            List<String> families = new List<String>();

            foreach (WeaponFamily type in Enum.GetValues(typeof(WeaponFamily))) {
                switch (type) {
                    case WeaponFamily.FAB:
                    families.Add("FAB");
                    break;
                    case WeaponFamily.JDAM:
                    families.Add("JDAM");
                    break;
                    case WeaponFamily.MOAB:
                    families.Add("MOAB");
                    break;
                    case WeaponFamily.X69:
                    families.Add("X69");
                    break;
                }
            }
            return families;
        }

        public IEnumerable<IWeaponStats> Stats() {
            foreach (var stat in _blueprintRegistry.Values) {
                yield return stat;
            }
        }




        //Dictionary<int, IWeaponBlueprint> _blueprintRegistry = new Dictionary<int, IWeaponBlueprint>();
        //Dictionary<WeaponType, int> _codeRegistry = new Dictionary<WeaponType, int>();

        //public void RegisterCode(WeaponType type, int code){
        //    _codeRegistry.Add(type, code);
        //}

        //public int GetCode(WeaponType type)
        //{
        //    if (_codeRegistry.ContainsKey(type))
        //    {
        //        return _codeRegistry[type];
        //    }
        //    // exception handling - check if code exists
        //    return -1;
        //}
    }
}
