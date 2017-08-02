using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
	public class Player : GameObject
	{
		public GameObject ball;

        private bool estavaPressionado = false;

		public override void Load( ContentManager content )
		{
            animation.textures = new Texture2D[4];
            animation.textures[0] = content.Load<Texture2D>("megaman3");
            animation.textures[1] = content.Load<Texture2D>("megaman2");
            animation.textures[2] = content.Load<Texture2D>("megaman3");
            animation.textures[3] = content.Load<Texture2D>("megaman4");

            scale = 5.0f;

			collider.offset = new Vector2( 10.0f, 0.0f );
			collider.size = new Vector2( 100.0f, 120.0f );
        }

		public override void Update( GameTime gameTime )
		{
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 4.0f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 4.0f;
            }

            animation.Animate(gameTime);

            TentaAtirar();

			if( BoxCollider.AreColliding( this, ball ) )
				color = Color.Red;
			else
				color = Color.White;
        }

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
