using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace NezTestProject {
    class PlayerMovementComponent : Component, IUpdatable {

        Mover _mover;
        float _moveSpeed = 100f;
        VirtualButton _fireInput;
        VirtualIntegerAxis _xAxisInput, _yAxisInput;

        public override void onAddedToEntity() {
            setupInput();
            _mover = entity.getComponent<Mover>();
        }

        public override void onRemovedFromEntity() {
            base.onRemovedFromEntity();
        }
        
        void setupInput() {
            // Horizontal input from dpad, left stick or keyboard left/right
            _xAxisInput = new VirtualIntegerAxis();
            _xAxisInput.nodes.Add(new VirtualAxis.GamePadDpadLeftRight());
            _xAxisInput.nodes.Add(new VirtualAxis.GamePadLeftStickX());
            _xAxisInput.nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));

            // Vertical input from dpad, left stick or keyboard up/down
            _yAxisInput = new VirtualIntegerAxis();
            _yAxisInput.nodes.Add(new VirtualAxis.GamePadDpadUpDown());
            _yAxisInput.nodes.Add(new VirtualAxis.GamePadLeftStickY());
            _yAxisInput.nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
        }

        void IUpdatable.update() {
            var moveDirection = new Vector2(_xAxisInput.value, _yAxisInput.value);

            if (moveDirection != Vector2.Zero) {
                var movement = moveDirection * _moveSpeed * Time.deltaTime;
                CollisionResult res;
                _mover.move(movement, out res);
            }
            else {
                // Animation.stop();
            }
        }

    }
}
