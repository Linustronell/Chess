using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chessgame
{
    internal class Piece
    {
        public Vector2 _piecePosition;
        public Texture2D _pieceTexture;
        public bool _isAlive;
        public bool _hasMove;

        public Piece(Vector2 piecePosition, Texture2D pieceTexture, bool isAlive, bool hasMove)
        {
            _piecePosition = piecePosition;
            _pieceTexture = pieceTexture;
            _isAlive = isAlive;
            _hasMove = hasMove;
        }
    }
}
