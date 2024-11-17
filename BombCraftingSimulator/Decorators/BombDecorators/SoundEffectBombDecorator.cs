using BombCraftingSimulator.Blueprints;
using BombCraftingSimulator.Decorator;
using BombCraftingSimulator.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombCraftingSimulator.Decorators.BombDecorators {
    internal class SoundEffectBombDecorator : IBombDecorator {
        public IWeaponBlueprint blueprint { get; }

        private IWeapon wrappedBomb { get; }

        private String soundEffect = "";

        public SoundEffectBombDecorator(IWeapon wrappedBomb, String soundEffect) {
            this.wrappedBomb = wrappedBomb;
            this.soundEffect = soundEffect;
        }

        public String Launch() {

            return wrappedBomb.Launch().Replace("boom", soundEffect);
        }

        public override string ToString() {
            return blueprint.weaponName;
        }
    }
}
