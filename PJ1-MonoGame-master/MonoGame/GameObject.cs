using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
	public class GameObject
	{
		public World world;

		public Vector2 position = new Vector2( 0.0f, 0.0f );
		public Vector2 velocity = new Vector2( 0.0f, 0.0f );

		public BoxCollider collider = new BoxCollider();

		public Animation animation = new Animation();
		public Color color = new Color( 1.0f, 1.0f, 1.0f, 1.0f );
		public float scale = 1.0f;

		public virtual void Load( ContentManager content )
		{
		}

		public virtual void Update( GameTime gameTime )
		{
			animation.Animate( gameTime );
		}

		public virtual void Draw( SpriteBatch spriteBatch )
		{
			Texture2D texture = animation.GetCurrentFrame();
			spriteBatch.Draw( texture, position, null, color,
				0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f );

			collider.Draw( spriteBatch, position );
		}
	}
}
