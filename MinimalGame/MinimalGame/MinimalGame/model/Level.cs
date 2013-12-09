using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class Level
    {
        public const int SIZE_X = 10;
        public const int SIZE_Y = 10;

        internal Tile[,] m_tiles = new Tile[SIZE_X, SIZE_Y];

        public Level()
        {
            GenerateLevel();
        }

        

        private void GenerateLevel()
        {
            String level = "XXXXXXXXXX";
            level       += "X        X";
            level       += "X        X";
            level       += "X        X";
            level       += "X        X";
            level       += "XXXXXXXXXX";

            Random rand = new Random();
            for (int x = 0; x < SIZE_X; x++)
            {
                for (int y = 0; y < SIZE_Y; y++)
                {
                    int index = y * SIZE_X + x;
                    
                    if (y < 6 && level[index] == 'X')
                    {
                        m_tiles[x, y] = Tile.createBrick(x, y);
                    }
                    else
                    {
                        m_tiles[x, y] = Tile.createEmpty(x, y);
                    }

                }
                
            }
        }

        internal Vector2 getBallStartPosition()
        {
            return new Vector2(SIZE_X / 2, 3);
        }

        internal Vector2 getPadStartPosition()
        {
            return new Vector2(SIZE_X / 2, SIZE_Y-1);
        }

        internal Collision Collide(Vector2 position, float radius)
        {

            Collision wallCollision = CollideWalls(position, radius);

            if (wallCollision != null)
            {
                return wallCollision;
            }

            Collision brickCollision = CollideBricks(position, radius);

            if (brickCollision != null)
            {
                return brickCollision;
            }

            return null;
        }

        private Collision CollideBricks(Vector2 position, float radius)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                for (int y = 0; y < SIZE_X; y++)
                {
                    if (m_tiles[x, y].isBlocked())
                    {
                        Vector2 normal = new Vector2();
                        if (m_tiles[x, y].isCollidingWith(position, radius, out normal))
                        {
                            m_tiles[x, y] = Tile.createEmpty(x, y);
                            return new Collision(position, normal);
                        }
                    }
                }
            }

            return null;
        }

        private Collision CollideWalls(Vector2 position, float radius)
        {

            if (position.X + radius > Level.SIZE_X)
            {
                return new Collision(position + (new Vector2(radius, 0)), new Vector2(-1, 0));
            }
            else if (position.X - radius < 0)
            {
                return new Collision(position + (new Vector2(-radius, 0)), new Vector2(1, 0));

            }

            if (position.Y - radius < 0)
            {
                return new Collision(position + (new Vector2(0, -radius)), new Vector2(0, 1));
            }

            return null;
        }

        internal bool hasTile(int x, int y)
        {
            return m_tiles[x, y].isBlocked();
        }
    }
}
