using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    public class World
    {
        private List<GameObject> gameObjects;
        private ContentManager content;
        public void InstantiateObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            gameObject.world = this;
            gameObject.Load(content);
        }

        public void LoadObjects(ContentManager contentManager)
        {
            gameObjects = new List<GameObject>();
            content = contentManager;

            Wall topWall = new Wall();
            topWall.position = new Vector2(0.0f, 0.0f);
            topWall.collider.size = new Vector2(1000.0f, 1.0f);
            InstantiateObject(topWall);

            Wall leftWall = new Wall();
            leftWall.position = new Vector2(0.0f, 0.0f);
            leftWall.collider.size = new Vector2(1.0f, 1000.0f);
            InstantiateObject(leftWall);

            Wall rightWall = new Wall();
            rightWall.position = new Vector2(800.0f, 0.0f);
            rightWall.collider.size = new Vector2(1.0f, 1000.0f);
            InstantiateObject(rightWall);

            Wall bottonWall = new Wall();
            bottonWall.position = new Vector2(00.0f, 480.0f);
            bottonWall.collider.size = new Vector2(1000.0f, 1.0f);
            InstantiateObject(bottonWall);

            Paddle paddle = new Paddle();
            paddle.leftWall = leftWall;
            paddle.rightWall = rightWall;
            InstantiateObject(paddle);

            Ball ball = new Ball();
            ball.paddle = paddle;
            ball.topWall = topWall;
            ball.bottonWall = bottonWall;
            ball.leftWall = leftWall;
            ball.rightWall = rightWall;
            InstantiateObject(ball);

            for(int i = 0; i < 10; i++)
            {
                Blocks block = new Blocks();
                block.ball = ball;
                block.bottonWall = bottonWall;
                block.position = new Vector2(25 + 80 * i, 20f);
                block.text = "alien-azul1";
                InstantiateObject(block);
            }

            for (int i = 0; i < 9; i++)
            {
                Blocks block = new Blocks();
                block.ball = ball;
                block.bottonWall = bottonWall;
                block.position = new Vector2(65 + 80 * i, 60f);
                block.text = "alien-verde1";
                InstantiateObject(block);
            }

            for (int i = 0; i < 10; i++)
            {
                Blocks block = new Blocks();
                block.ball = ball;
                block.bottonWall = bottonWall;
                block.position = new Vector2(25 + 80 * i, 100f);
                block.text = "alien-vermelho";
                InstantiateObject(block);
            }
        }

        public void UpdateObjects(GameTime gameTime)
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                GameObject obj = gameObjects[i];
                obj.Update(gameTime);
            }
        }

        public void DrawObjects(SpriteBatch spriteBatch)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(spriteBatch);
            }
        }
    }
}
