// Interface for a factory to create various parts of a weapon
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs.WeaponParts; 

public interface IWeaponPartsFactory
{
    // Method to create a metal casing 
    MetalCase BuildMetalCasing();

    // Method to create an explosive 
    Explosive BuildExplosive();

    // Method to create a guidance kit 
    GuidanceKit BuildGuidanceKit();

    // Method to create a detonation 
    Detonation BuildDetonation();

    // Method to create a launcher 
    Launcher BuildLauncher();

    // Method to create a propulsion 
    Propulsion BuildPropulsion();
}