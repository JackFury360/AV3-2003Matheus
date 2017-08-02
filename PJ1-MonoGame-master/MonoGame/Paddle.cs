using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Paddle : GameObject
    {
        public Wall leftWall;
        public Wall rightWall;

        public GameObject ball;

        private bool estavaPressionado = false;
        public override void Load(ContentManager content)
        {
            position = new Vector2(250.0f, 425.0f);
            collider.size = new Vector2(41.0f, 28.0f);

            animation.textures = new Texture2D[1];
            animation.textures[0] = content.Load<Texture2D>("player");
            scale = 0.3f;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 4.0f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 4.0f;
            }

            if (BoxCollider.AreColliding(this, leftWall))
            {
                position.X += 4.0f;
            }

            if (BoxCollider.AreColliding(this, rightWall))
            {
                position.X -= 4.0f;
            }
        }
        /*
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.FillRectangle(position, collider.size, color);

        }*/

        public void TentaAtirar()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !estavaPressionado)
            {
                Tiro tiro = new Tiro();
                tiro.position = position;
                tiro.velocity = new Vector2(-1000.0f, 0.0f);

                world.InstantiateObject(tiro);
            }

            estavaPressionado = Keyboard.GetState().IsKeyDown(Keys.Space);
        }
    }
}
