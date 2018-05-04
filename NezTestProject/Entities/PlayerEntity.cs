using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace NezTestProject {
    class PlayerEntity : Entity, IUpdatable {
        enum Animations { };
        Sprite _sprite;

        // Input and movement
        Mover _mover;
        float _moveSpeed = 100f;
        VirtualButton _fireInput;
        VirtualIntegerAxis _xAxisInput, _yAxisInput;

        public PlayerEntity() {
            
            name = "player-entity";
        }
        

        public override void onAddedToScene() {

            // Sprite
            var textureBomb = scene.content.Load<Texture2D>("Graphics\\Bomb");
            _sprite = addComponent(new Sprite(textureBomb));

            // Shadow
            var shadow = addComponent(new SpriteMime(_sprite));
            shadow.color = new Color(10, 10, 10, 80);
            shadow.material = Material.stencilRead();
            shadow.renderLayer = -2; // Above top-most tile map graphics

            // Movement and collision
            addComponent(new CircleCollider());
            _mover = addComponent(new Mover());

            setupInput();
        }

        public override void onRemovedFromScene() {
            base.onRemovedFromScene();
        }

        void setupInput() {
            // setup input for shooting a fireball. we will allow z on the keyboard or a on the gamepad
            _fireInput = new VirtualButton();
            _fireInput.nodes.Add(new Nez.VirtualButton.KeyboardKey(Keys.Z));
            _fireInput.nodes.Add(new Nez.VirtualButton.GamePadButton(0, Buttons.A));

            // horizontal input from dpad, left stick or keyboard left/right
            _xAxisInput = new VirtualIntegerAxis();
            _xAxisInput.nodes.Add(new Nez.VirtualAxis.GamePadDpadLeftRight());
            _xAxisInput.nodes.Add(new Nez.VirtualAxis.GamePadLeftStickX());
            _xAxisInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));

            // vertical input from dpad, left stick or keyboard up/down
            _yAxisInput = new VirtualIntegerAxis();
            _yAxisInput.nodes.Add(new Nez.VirtualAxis.GamePadDpadUpDown());
            _yAxisInput.nodes.Add(new Nez.VirtualAxis.GamePadLeftStickY());
            _yAxisInput.nodes.Add(new Nez.VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Up, Keys.Down));
        }

        public override void update() {
            base.update();

            // Handle movement and animations
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
