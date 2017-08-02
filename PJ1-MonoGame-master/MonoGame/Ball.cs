using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Ball : GameObject
    {
        public Paddle paddle;
        public bool atira;
        public bool controle = true;
        public bool desenha = true;
        public Wall topWall;
        public Wall bottonWall;
        public Wall leftWall;
        public Wall rightWall;
        public bool win;
        public Vector2 winPos = new Vector2(100,10);
        public Texture2D winText;

        public int enemiesKilled = 0; 

        public override void Load(ContentManager content)
        {
            winText = content.Load<Texture2D>("You_won");

            animation.textures = new Texture2D[1];
            animation.textures[0] = content.Load<Texture2D>("BallSprite");
            scale = 0.1f;

            position = new Vector2(250.0f, paddle.position.Y);
            velocity = new Vector2(0.0f, 200.0f);

            collider.size = new Vector2(15.0f, 15.0f);
        }

        public override void Update(GameTime gameTime)
        {
            float deltaT = ((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);

            if(enemiesKilled == 29)
            {
                desenha = false;
                win = true;
            }

            if(atira == true)
            position.Y -= velocity.Y * deltaT;

            if(atira == true && controle == true)
            {
                position.X = paddle.position.X + 15;
                controle = false;
            }
            

            if ((Keyboard.GetState().IsKeyDown(Keys.Space)))
            {
                
                atira = true;
            }

            if (BoxCollider.AreColliding(this, topWall))
            {
                position.Y = paddle.position.Y;
                atira = false;
                controle = true;
                desenha = false;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (controle == false)
            {
                Texture2D texture = animation.GetCurrentFrame();
                spriteBatch.Draw(texture, position, null, color,
                    0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);

                collider.Draw(spriteBatch, position);
            }

            if(win == true)
            {
                Texture2D texture = animation.GetCurrentFrame();
                spriteBatch.Draw(winText, winPos, null, color,
                    0.0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0.0f);
            }
        }
    }
}
