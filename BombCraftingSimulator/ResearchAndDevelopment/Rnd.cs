using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Weapons.Bombs;
using BombCraftingSimulator.WeaponSpecs;

namespace BombCraftingSimulator.ResearchAndDevelopment {
    public class Rnd : IRnd {
        private static Rnd instance = null;
        private static Object mutex;

        Dictionary<(WeaponFamily,int), WeaponBlueprint> _blueprintRegistry;

        private Rnd() {
            _blueprintRegistry = new Dictionary<(WeaponFamily, int), WeaponBlueprint>();
            initializeBlueprintRegistery();
        }

        internal static Rnd GetInstance() {
            if(instance == null) {
                // To make sure the mutex object is initialized only once
                if (mutex == null) {
                    mutex = new Object();
                }

                lock (mutex) {
                    if(instance == null) {
                        instance = new Rnd();
                    }
                }
            }
            return instance;
        }

        private void initializeBlueprintRegistery() { // Need to implement a more dynamic way later
            //// Get current dir in a class library: https://stackoverflow.com/questions/27233853/get-current-dir-in-a-class-library
            //String path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            //// Use Visual C# to read from and write to a text file: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
            //StreamReader sr = new StreamReader(path);
            //String line = sr.ReadLine();

            ////Continue to read until you reach end of file
            //while (line != null) {
            //    String[] lineParts = line.Split(";");
            //    int version = int.Parse(lineParts[0]);

            //    // How to get a enum value from string in C#: https://stackoverflow.com/questions/1578775/how-to-get-a-enum-value-from-string-in-c
            //    WeaponFamily family;
            //    if (Enum.TryParse("HKEY_LOCAL_MACHINE", out family)) {
            //    uint value = (uint)family;
            //        RegisterBlueprint(family, version, new WeaponBlueprint());
            //    }
            //    else {
            //        Program.print("line in file: \"" + line + "\" was not registered.", "DarkRed");
            //    }

            //    //Read the next line
            //    line = sr.ReadLine();
            //}
            //sr.Close();
            _blueprintRegistry.Clear();
            RegisterBlueprint(WeaponFamily.FAB, 1, new WeaponBlueprint(WeaponFamily.FAB, 1));
            RegisterBlueprint(WeaponFamily.MOAB, 1, new WeaponBlueprint(WeaponFamily.MOAB, 1));
            RegisterBlueprint(WeaponFamily.X69, 1, new WeaponBlueprint(WeaponFamily.X69, 1));
            RegisterBlueprint(WeaponFamily.JDAM, 1, new WeaponBlueprint(WeaponFamily.JDAM, 1));

            RegisterBlueprint(WeaponFamily.FAB, 2, new WeaponBlueprint(WeaponFamily.FAB, 2));
            RegisterBlueprint(WeaponFamily.MOAB, 2, new WeaponBlueprint(WeaponFamily.MOAB, 2));
            RegisterBlueprint(WeaponFamily.X69, 2, new WeaponBlueprint(WeaponFamily.X69, 2));
            RegisterBlueprint(WeaponFamily.JDAM, 2, new WeaponBlueprint(WeaponFamily.JDAM, 2));

            RegisterBlueprint(WeaponFamily.FAB, 3, new WeaponBlueprint(WeaponFamily.FAB, 3));
            RegisterBlueprint(WeaponFamily.MOAB, 3, new WeaponBlueprint(WeaponFamily.MOAB, 3));
            RegisterBlueprint(WeaponFamily.X69, 3, new WeaponBlueprint(WeaponFamily.X69, 3));
            RegisterBlueprint(WeaponFamily.JDAM, 3, new WeaponBlueprint(WeaponFamily.JDAM, 3));
        }

        public WeaponBlueprint GetBlueprint(WeaponFamily family, int version) {
            if (_blueprintRegistry.ContainsKey((family, version))) {
                Program.Print("Fetching blueprint for requested " + family + " version " + version, "Blue");
                WeaponBlueprint blueprint = (WeaponBlueprint)_blueprintRegistry[(family, version)].Clone();
                Program.Print("Fetched blueprint for requested " + blueprint.WeaponFamily + " version " + blueprint.version, "Blue");

                return blueprint;
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

        public WeaponFamily GetFamilyFromString(String familyString) {
            WeaponFamily family;
            if (Enum.TryParse(familyString, out family)) {
                uint value = (uint)family;
                return family;
            } else {
                Program.Print("Weapon family type not found.", "DarkRed");
                throw new Exception("Weapon family type not found.");
            }
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
                        types.Add("EntryDenial");
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
