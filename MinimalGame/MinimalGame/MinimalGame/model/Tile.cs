using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class Tile
    {
        private enum TileType
        {
            EMPTY = 0,
            BRICK
        };

        TileType m_type;
        private int m_leftX;
        private int m_topY;

        internal static Tile createBrick(int x, int y)
        {
            return new Tile(TileType.BRICK, x, y);

        }

        internal static Tile createEmpty(int x, int y)
        {
            return new Tile(TileType.EMPTY, x, y);
        }

        private Tile(TileType a_type, int x, int y)
        {
            m_type = a_type;
            m_leftX = x;
            m_topY = y;
        }


        internal bool isBlocked()
        {
            return m_type == TileType.BRICK;
        }

        internal bool isCollidingWith(Vector2 position, float radius, out Vector2 normal)
        {
            normal.X = 0;
            normal.Y = 0;
            if (position.X - radius > m_leftX + 1.0f)
            {
                return false;
            }
            if (position.X + radius < m_leftX)
            {
                return false;
            }

            if (position.Y - radius > m_topY + 1.0f)
            {
                return false;
            }
            if (position.Y + radius < m_topY)
            {
                return false;
            }
            if (position.X > m_leftX + 1.0f)
            {
                normal.X = 1;
            }
            else if (position.X < m_leftX )
            {
                normal.X = -1;
            }
            else if (position.Y > m_topY + 1.0f)
            {
                normal.Y = -1;
            }
            else if (position.Y < m_topY)
            {
                normal.Y = 1;
            }

            normal.Normalize();

            return true;
        }
    }
}
