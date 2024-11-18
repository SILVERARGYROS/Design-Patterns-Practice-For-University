using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Decorator;
using BombCraftingSimulator.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Decorators.BombDecorators {
    internal class ElementBombDecorator : IBombDecorator {
        public IWeaponBlueprint blueprint { get; }

        private IWeapon wrappedBomb { get; }

        private String element = "";

        public ElementBombDecorator(IWeapon wrappedBomb, String element) {
            this.wrappedBomb = wrappedBomb;
            this.element = element;
        }

        public String Launch() {
            return Regex.Replace(wrappedBomb.Launch(), @" \(^.* explosion\)", "") + " (" + element + " explosion)";
        }

        public override string ToString() {
            return blueprint.weaponName;
        }
    }
}
