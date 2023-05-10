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
        public string _pieceName;
        public string _team;
        public Vector2 _piecePosition;
        public Texture2D _pieceTexture;
        public bool _isAlive;
        public bool _hasMove;
        public Rectangle _boundingBox;
        public Color _color;

        public Piece(Vector2 piecePosition, Texture2D pieceTexture, bool isAlive, bool hasMove, string pieceName, string team)
        {
            _pieceName = pieceName;
            _piecePosition = piecePosition;
            _pieceTexture = pieceTexture;
            _isAlive = isAlive;
            _hasMove = hasMove;
            _team = team;
            _color = Color.White;
            if (team == "B")
            {
                _color = Color.Black;
            }
            _boundingBox = new Rectangle((int)_piecePosition.X, (int)_piecePosition.Y, 100, 100);
        }

        public bool Clicked(Vector2 mousePos)
        {
            if (_boundingBox.Contains(mousePos.X, mousePos.Y))
            {
                return true;
            }
            return false;
        }

        public void Move(float x, float y)
        {
            _piecePosition = new Vector2(x,y);
            _boundingBox = new Rectangle((int)_piecePosition.X, (int)_piecePosition.Y, 100, 100);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(_pieceTexture, _piecePosition, _color);
        }
    }
}
