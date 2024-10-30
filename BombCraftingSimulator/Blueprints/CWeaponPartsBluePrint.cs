using BombCraftingSimulator.WeaponSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombCraftingSimulator.Blueprints;

namespace BombCraftingSimulator.Blueprints{

    public class MetalCasingBlueprint : IMetalCasingBlueprint{
        public string componentname { get; set; }
        public MetalCasingType MetalCasing { get; set; }
        public int CasingWeightKG { get; set; }
        public int CasingThicknessMM { get; set; }

   
        public MetalCasingBlueprint(string componentname, MetalCasingType metalCasing, int casingWeightKG, int casingThicknessMM){
            this.componentname = componentname;
            this.MetalCasing = metalCasing;
            this.CasingWeightKG = casingWeightKG;
            this.CasingThicknessMM = casingThicknessMM;
        }

        // Implement the Clone method from IPrototype interface
        public IMetalCasingBlueprint Clone(){
            return new MetalCasingBlueprint(this.componentname, this.MetalCasing, this.CasingWeightKG, this.CasingThicknessMM);
        }
    }

    public class ExplosiveBlueprint : IExplosiveBlueprint{
        public string componentname { get; set; }
        public ExplosiveType ExplosiveType { get; set; }
        public int PayloadKG { get; set; }


        public ExplosiveBlueprint(string componentname, ExplosiveType explosiveType, int payloadKG){
            this.componentname = componentname;
            this.ExplosiveType = explosiveType;
            this.PayloadKG = payloadKG;
        }

        public IExplosiveBlueprint Clone(){
            return new ExplosiveBlueprint(this.componentname, this.ExplosiveType, this.PayloadKG);
        }
    }

    public class DetonationBlueprint : IDetonationBlueprint
    {
        public string componentname { get; set; }
        public DetonationType DetonationType { get; set; }

  
        public DetonationBlueprint(string componentname, DetonationType detonationType){
            this.componentname = componentname;
            this.DetonationType = detonationType;
        }

        public IDetonationBlueprint Clone(){
            return new DetonationBlueprint(this.componentname, this.DetonationType);
        }
    }

    public class GuidanceKitBlueprint : IGuidanceKitBlueprint
    {
        public string componentname { get; set; }
        public GuidanceType GuidanceType { get; set; }

    
        public GuidanceKitBlueprint(string componentname, GuidanceType guidanceType){
            this.componentname = componentname;
            this.GuidanceType = guidanceType;
        }

        public IGuidanceKitBlueprint Clone(){
            return new GuidanceKitBlueprint(this.componentname, this.GuidanceType);
        }
    }

    public class PropulsionBlueprint : IPropulsionBlueprint{
        public string componentname { get; set; }
        public FuelType FuelType { get; set; }
        public int FuelWeightKG { get; set; }
        public int ThrustMACH { get; set; }

     
        public PropulsionBlueprint(string componentname, FuelType fuelType, int fuelWeightKG, int thrustMACH){
            this.componentname = componentname;
            this.FuelType = fuelType;
            this.FuelWeightKG = fuelWeightKG;
            this.ThrustMACH = thrustMACH;
        }

        public IPropulsionBlueprint Clone(){
            return new PropulsionBlueprint(this.componentname, this.FuelType, this.FuelWeightKG, this.ThrustMACH);
        }
    }


    public class LauncherBlueprint : ILauncherBlueprint
    {
        public string componentname { get; set; }
        public LauncherType LauncherType { get; set; }
        public uint LauncherWeightKG { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }


        public LauncherBlueprint(string componentname, LauncherType launchertype, uint launcherWeightKG, double length, double width)
        {
            this.componentname = componentname;
            this.LauncherWeightKG = launcherWeightKG;
            this.LauncherType = launchertype;
            this.Length = length;
            this.Width = width;
        }

        // Implement the Clone method from IPrototype interface
        public ILauncherBlueprint Clone()
        {
            return new LauncherBlueprint(this.componentname, this.LauncherType, this.LauncherWeightKG, this.Length, this.Width);
        }
    }

}