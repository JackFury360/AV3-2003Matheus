using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
	public class BoxCollider
	{
		public Vector2 offset;
		public Vector2 size;

		public void Draw( SpriteBatch spriteBatch, Vector2 position )
		{
			//spriteBatch.DrawRectangle( position + offset, size, Color.Red, 1.0f );
		}

		public static bool AreColliding( GameObject a, GameObject b )
		{
			Vector2 aMinPosition = a.position + a.collider.offset;
			Vector2 bMinPosition = b.position + b.collider.offset;

			Vector2 aMaxPosition = aMinPosition + a.collider.size;
			Vector2 bMaxPosition = bMinPosition + b.collider.size;

			if( aMaxPosition.X < bMinPosition.X || aMinPosition.X > bMaxPosition.X ||
				aMaxPosition.Y < bMinPosition.Y || aMinPosition.Y > bMaxPosition.Y )
				return false;

			return true;
		}
	}
}
