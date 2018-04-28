using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NezTestProject
{
    class SimpleMover : Component, IUpdatable
    {
        public float speed = 100f;

        public void update()
        {
            var moveDir = Vector2.Zero;

            // Input provides access to the keyboard here. We check for the left/right/up/down arrow keys and set the movement direction accordingly.
            if (Input.isKeyDown(Keys.Left))
                moveDir.X = -1f;
            else if (Input.isKeyDown(Keys.Right))
                moveDir.X = 1f;

            if (Input.isKeyDown(Keys.Up))
                moveDir.Y = -1f;
            else if (Input.isKeyDown(Keys.Down))
                moveDir.Y = 1f;

            // every Entity has a Transform. The Transform defines the Entity's physical representation in space (position/rotation/scale).
            // here we are just modifying the position to move the Entity around. We multiply the movement by Time.deltaTime to keep things
            // framerate independent.
            entity.position += moveDir * speed * Time.deltaTime;
        }
    }
}
