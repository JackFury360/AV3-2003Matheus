using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class Animation
    {
        public Texture2D[] textures;

        public int indiceAnimacao = 0;
        public double contadorTempo = 0.0;

        public void Animate(GameTime gameTime)
        {
            contadorTempo += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (contadorTempo > 300.0)
            {
                indiceAnimacao += 1;
                if (indiceAnimacao == textures.Length)
                    indiceAnimacao = 0;

                contadorTempo = 0.0;
            }
        }

        public Texture2D GetCurrentFrame()
        {
            return textures[indiceAnimacao];
        }
    }
}
