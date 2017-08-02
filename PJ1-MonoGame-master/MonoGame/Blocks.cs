using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Blocks : GameObject
    {
        public Ball ball;
        public bool Desenha = true;
        public Wall bottonWall;
        public string text = "alien-amarelo";
        public bool lose;
        public Texture2D loseText;
        public Vector2 losePos = new Vector2(-85f, 0);
        public override void Load(ContentManager content)
        {
            loseText = content.Load<Texture2D>("You_lose");

            //position = new Vector2(10 + 80, 20f);
            velocity = new Vector2(10f , 5f);
            collider.size = new Vector2(28.0f, 22.0f);
            animation.textures = new Texture2D[1];
            animation.textures[0] = content.Load<Texture2D>(text);
            scale = 2f;
        }

        public override void Update(GameTime gameTime)
        {
            if(ball.win == true)
            {
                Desenha = false;
            }

            if (Desenha == true)
            {
                if (BoxCollider.AreColliding(this, ball))
                {
                    ball.atira = false;
                    ball.position.Y = ball.paddle.position.Y;
                    ball.controle = true;
                    Desenha = false;
                    ball.enemiesKilled += 1;
                }

                if (BoxCollider.AreColliding(this, bottonWall))
                {
                    Desenha = false;
                    lose = true;
                }

                float deltaT = ((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
                position.Y += velocity.Y * deltaT;
            }
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Desenha == true)
            {
                Texture2D texture = animation.GetCurrentFrame();
                spriteBatch.Draw(texture, position, null, color,
                    0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);

                collider.Draw(spriteBatch, position);
            }

            if (lose == true)
            {
                Texture2D texture = animation.GetCurrentFrame();
                spriteBatch.Draw(loseText, losePos, null, color,
                    0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);

                collider.Draw(spriteBatch, position);
            }
        }
    }
}
