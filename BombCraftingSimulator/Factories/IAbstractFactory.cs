// Interface for a factory to create various parts of a weapon
using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.WeaponSpecs.WeaponParts; 

public interface IAbstractWeaponPartsFactory
{
    // Method to create a metal casing 
    MetalCase CreateMetalCasing();

    // Method to create an explosive 
    Explosive CreateExplosive();

    // Method to create a guidance kit 
    GuidanceKit CreateGuidanceKit();

    // Method to create a detonation 
    Detonation CreateDetonation();

    // Method to create a launcher 
    Launcher CreateLauncher();

    // Method to create a propulsion 
    Propulsion CreatePropulsion();
}