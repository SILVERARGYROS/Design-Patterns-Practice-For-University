using System;
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs;
using System.Collections.Generic;
using BombCraftingSimulator.Weapons;
using BombCraftingSimulator.MinistryOfNationalDefence;
using BombCraftingSimulator.Weapons.Bombs;
using BombCraftingSimulator.Builder;
using BombCraftingSimulator.Decorators.BombDecorators;

namespace BombCraftingSimulator {
    class Program {
        private static ArmyCommand armyCommand;
        private static Dictionary<int, String> familyChoices = new Dictionary<int, String>();
        private static Dictionary<int, int> versionChoices = new Dictionary<int, int>();
        private static WeaponFamily selectedFamily;
        private static int selectedVersion;
        private static int selectedFamilyIndex;
        private static Boolean DebugPrintsActivated = true; // Used to toggle debug messages on/off easily

        static void Main(string[] args) {
            Program.Print("Hello World", "DarkRed");

            // https://refactoring.guru/design-patterns/singleton
            armyCommand = ArmyCommand.GetInstance();
            ArmyFactory armyFactory = new ArmyFactory();
            IWeapon bomb = null;    // will be used to store user's crafted bomb
            int inputNumber;        // will be used to collect int input from the user


        //// might implement a menu here

        // Program Title
        Console.WriteLine("Welcome to Bomb Crafting Simulator");
            Console.WriteLine();


            showWeaponFamilyMenu();

            while (true) {
                Console.WriteLine();
                Console.Write("-->");

                // To make sure given input is of type int
                try {
                    inputNumber = int.Parse(Console.ReadLine());
                } catch(Exception ex) { 
                    Console.WriteLine("Invalid Input. Please enter a proper integer.");
                    Program.Print(ex.ToString(), "DarkRed");
                    continue;
                }

                // To make sure given input is not out of bounds
                if (inputNumber == 0) {
                    Program.Exit(0);
                } else if (inputNumber < 0 || inputNumber > familyChoices.Count) {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input! Please enter a valid number.");

                } else {
                    selectedFamilyIndex = inputNumber;
                    selectedFamily = armyCommand.GetWeaponFamilyFromString(familyChoices[selectedFamilyIndex]);

                    // Version Options Menu 
                    showWeaponVersionMenu();

                    while (true) {

                        Console.WriteLine();
                        Console.Write("-->");

                        // To make sure given input is of type int
                        try {
                            inputNumber = int.Parse(Console.ReadLine());
                        } catch (Exception ex) {
                            Console.WriteLine("Invalid Input. Please enter a proper integer.");
                            Program.Print(ex.ToString(), "DarkRed");
                            continue;
                        }

                        if (inputNumber == 0) {
                            // go back, propably break
                            break;
                        } else if (inputNumber < 0 || inputNumber > versionChoices.Count) {
                            Console.WriteLine();
                            Console.WriteLine("Invalid input! Please enter a valid number.");
                        } else {
                            // Build weapon
                            selectedVersion = versionChoices[inputNumber];
                            WeaponBlueprint weaponBlueprint = armyCommand.RequestWeaponΒlueprint(selectedFamily, selectedVersion);
                            bomb = armyCommand.RequestsWeapon(armyFactory, weaponBlueprint);
                            break;
                        }
                        break;
                    }
                    if(inputNumber == 0) {
                        showWeaponFamilyMenu();
                    } else {
                        break;
                    }
                }
            }

            showActionsMenu();

            while (true) {
                Console.WriteLine();
                Console.Write("-->");

                // To make sure given input is of type int
                try {
                    inputNumber = int.Parse(Console.ReadLine());
                } catch (Exception ex) {
                    Console.WriteLine("Invalid Input. Please enter a proper integer.");
                    Program.Print(ex.ToString(), "DarkRed");
                    continue;
                }

                switch (inputNumber) {
                    case 1: // change color
                        Console.WriteLine("Please enter your desired color (Leave blank to cancel);");
                        Console.WriteLine("");
                        Console.Write("-->");
                        String color = Console.ReadLine();
                        bomb = new ColorBombDecorator(bomb, color);
                        break;

                    case 2: // change sound
                        Console.WriteLine("Please enter your desired sound effect (Leave blank to cancel);");
                        Console.WriteLine("");
                        Console.Write("-->");
                        String sound = Console.ReadLine();
                        bomb = new SoundEffectBombDecorator(bomb, sound);
                        break;

                    case 3: // change element
                        Console.WriteLine("Please enter your desired element (Leave blank to cancel);");
                        Console.WriteLine("");
                        Console.Write("-->");
                        String element = Console.ReadLine();
                        bomb = new ElementBombDecorator(bomb, element);
                        break;

                    case 0: // Launching the final bomb
                        Console.WriteLine();
                        Console.WriteLine(bomb.Launch());
                        Console.WriteLine("Press any key to continue...");
                        Console.WriteLine();
                        Console.WriteLine();
                        
                        //Console.ReadLine();
                        Program.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input! Please enter a valid integer.");
                        break;
                }
                showActionsMenu();
            }
        }

        public static void showWeaponFamilyMenu() {
            // Family Options Menu
            Console.WriteLine("Please select weapon family.");
            Console.WriteLine();

            List<String> families = armyCommand.RequestWeaponFamilies();

            familyChoices.Clear();
            for (int i = 0; i < families.Count; i++) {
                familyChoices.Add(i + 1, families[i]);
                Console.WriteLine("Press " + (i + 1) + " to craft " + familyChoices[i + 1]);
            }
            Console.WriteLine("Press 0 to exit");
        }

        public static void showWeaponVersionMenu() {
            Console.WriteLine("Please select version.");
            Console.WriteLine();

            selectedFamily = armyCommand.GetWeaponFamilyFromString(familyChoices[selectedFamilyIndex]);
            List<int> versions = armyCommand.RequestFamilyCodes(selectedFamily);
            
            versionChoices.Clear();
            for (int i = 0; i < versions.Count; i++) {
                versionChoices.Add(i + 1, versions[i]);
                Console.WriteLine("Press " + (i + 1) + " to select version " + versionChoices[i + 1]);
            }
            Console.WriteLine("Press 0 to go back");
        }

        public static void showActionsMenu() {
            Console.WriteLine();
            Console.WriteLine("Please choose action.");
            Console.WriteLine();

            Console.WriteLine("Press 1) to change weapon color.");
            Console.WriteLine("Press 2) to change weapon sound effect.");
            Console.WriteLine("Press 3) to change weapon element.");
            Console.WriteLine("Press 0) to launch the weapon.");
        }

        public static void Print(string message, string color) {
            if (DebugPrintsActivated) {
                // Change the Console.Foregroundcolor from a string: https://stackoverflow.com/questions/30799107/change-the-console-foregroundcolor-from-a-string
                ConsoleColor c;
                if (Enum.TryParse(color, out c)) {
                    Console.ForegroundColor = c;
                }

                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        public static void Exit(int code) {
            Console.WriteLine("Terminating Program");
            System.Environment.Exit(code);
        }
    }
}
