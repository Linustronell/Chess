using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Chessgame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        MouseState mState;

        Texture2D whiteBlock;
        Texture2D brownBlock;

        //Black Pieces
        Piece RookB1;
        Piece HorseB1;
        Piece BishopB1;
        Piece KingB;
        Piece QueenB;
        Piece BishopB2;
        Piece HorseB2;
        Piece RookB2;
        Piece PawnB1;
        Piece PawnB2;
        Piece PawnB3;
        Piece PawnB4;
        Piece PawnB5;
        Piece PawnB6;
        Piece PawnB7;
        Piece PawnB8;

        //WHite Pieces
        Piece RookW1;
        Piece HorseW1;
        Piece BishopW1;
        Piece KingW;
        Piece QueenW;
        Piece BishopW2;
        Piece HorseW2;
        Piece RookW2;
        Piece PawnW1;
        Piece PawnW2;
        Piece PawnW3;
        Piece PawnW4;
        Piece PawnW5;
        Piece PawnW6;
        Piece PawnW7;
        Piece PawnW8;

        int space = 100;
    
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            //Grid
            whiteBlock = Content.Load<Texture2D>("white_Block");
            brownBlock = Content.Load<Texture2D>("brown_Block");

            //Black Piece
            RookB1 = new Piece(new Vector2(0, 0), Content.Load<Texture2D>("RookB"), true, false);
            HorseB1 = new Piece(new Vector2(100, 0), Content.Load<Texture2D>("HorseB"), true, false);
            BishopB1 = new Piece(new Vector2(200, 0), Content.Load<Texture2D>("BishopB"), true, false);
            KingB = new Piece(new Vector2(300, 0), Content.Load<Texture2D>("KingB"), true, false);
            QueenB = new Piece(new Vector2(400, 0), Content.Load<Texture2D>("QueenB"), true, false);
            BishopB2 = new Piece(new Vector2(500, 0), Content.Load<Texture2D>("BishopB"), true, false);
            HorseB2 = new Piece(new Vector2(600, 0), Content.Load<Texture2D>("HorseB"), true, false);
            RookB2 = new Piece(new Vector2(700, 0), Content.Load<Texture2D>("RookB"), true, false);

            PawnB1 = new Piece(new Vector2(0, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB2 = new Piece(new Vector2(100, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB3 = new Piece(new Vector2(200, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB4 = new Piece(new Vector2(300, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB5 = new Piece(new Vector2(400, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB6 = new Piece(new Vector2(500, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB7 = new Piece(new Vector2(600, 100), Content.Load<Texture2D>("PawnB"), true, false);
            PawnB8 = new Piece(new Vector2(700, 100), Content.Load<Texture2D>("PawnB"), true, false);

            //White Piece
            RookW1 = new Piece(new Vector2(0, 700), Content.Load<Texture2D>("RookW"), true, false);
            HorseW1 = new Piece(new Vector2(100, 700), Content.Load<Texture2D>("HorseW"), true, false);
            BishopW1 = new Piece(new Vector2(200, 700), Content.Load<Texture2D>("BishopW"), true, false);
            KingW = new Piece(new Vector2(300, 700), Content.Load<Texture2D>("KingW"), true, false);
            QueenW = new Piece(new Vector2(400, 700), Content.Load<Texture2D>("QueenW"), true, false);
            BishopW2 = new Piece(new Vector2(500, 700), Content.Load<Texture2D>("BishopW"), true, false);
            HorseW2 = new Piece(new Vector2(600, 700), Content.Load<Texture2D>("HorseW"), true, false);
            RookW2 = new Piece(new Vector2(700, 700), Content.Load<Texture2D>("RookW"), true, false);

            PawnW1 = new Piece(new Vector2(0, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW2 = new Piece(new Vector2(100, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW3 = new Piece(new Vector2(200, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW4 = new Piece(new Vector2(300, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW5 = new Piece(new Vector2(400, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW6 = new Piece(new Vector2(500, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW7 = new Piece(new Vector2(600, 600), Content.Load<Texture2D>("PawnW"), true, false);
            PawnW8 = new Piece(new Vector2(700, 600), Content.Load<Texture2D>("PawnW"), true, false);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mState = Mouse.GetState();

            //if (mState.LeftButton == ButtonState.Pressed)
            //{
            //    float mousePiecesDist = Vector2.Distance(piecesPosition, mState.Position.ToVector2());
            //    if (mousePiecesDist < piecesPosition)
            //    {
            //        //New Position
            //    }
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            for (int i = 0; i < 8; i += 1)
            {
                if (i % 2 == 0)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        if (z % 2 == 0)
                        {
                            _spriteBatch.Draw(whiteBlock, new Vector2(i*100, z*100), Color.White);
                        }
                        else 
                        {
                            _spriteBatch.Draw(brownBlock, new Vector2(i * 100, z * 100), Color.White);
                        }
                    }
                }
                else
                {
                    for (int z = 0; z < 8; z++)
                    {
                        if (z % 2 == 0)
                        {
                            _spriteBatch.Draw(brownBlock, new Vector2(i * 100, z * 100), Color.White);
                        }
                        else
                        {
                            _spriteBatch.Draw(whiteBlock, new Vector2(i * 100, z * 100), Color.White);
                        }
                    }
                }
            }

            //Draw BlackPieces
            _spriteBatch.Draw(RookB1._pieceTexture, RookB1._piecePosition, Color.White);
            _spriteBatch.Draw(HorseB1._pieceTexture, HorseB1._piecePosition, Color.White);
            _spriteBatch.Draw(BishopB1._pieceTexture, BishopB1._piecePosition, Color.White);
            _spriteBatch.Draw(KingB._pieceTexture, KingB._piecePosition, Color.White);
            _spriteBatch.Draw(QueenB._pieceTexture, QueenB._piecePosition, Color.White);
            _spriteBatch.Draw(BishopB2._pieceTexture, BishopB2._piecePosition, Color.White);
            _spriteBatch.Draw(HorseB2._pieceTexture, HorseB2._piecePosition, Color.White);
            _spriteBatch.Draw(RookB2._pieceTexture, RookB2._piecePosition, Color.White);

            _spriteBatch.Draw(PawnB1._pieceTexture, PawnB1._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB2._pieceTexture, PawnB2._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB3._pieceTexture, PawnB3._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB4._pieceTexture, PawnB4._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB5._pieceTexture, PawnB5._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB6._pieceTexture, PawnB6._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB7._pieceTexture, PawnB7._piecePosition, Color.White);
            _spriteBatch.Draw(PawnB8._pieceTexture, PawnB8._piecePosition, Color.White);

            //Draw WhitePieces
            _spriteBatch.Draw(RookW1._pieceTexture, RookW1._piecePosition, Color.White);
            _spriteBatch.Draw(HorseW1._pieceTexture, HorseW1._piecePosition, Color.White);
            _spriteBatch.Draw(BishopW1._pieceTexture, BishopW1._piecePosition, Color.White);
            _spriteBatch.Draw(KingW._pieceTexture, KingW._piecePosition, Color.White);
            _spriteBatch.Draw(QueenW._pieceTexture, QueenW._piecePosition, Color.White);
            _spriteBatch.Draw(BishopW2._pieceTexture, BishopW2._piecePosition, Color.White);
            _spriteBatch.Draw(HorseW2._pieceTexture, HorseW2._piecePosition, Color.White);
            _spriteBatch.Draw(RookW2._pieceTexture, RookW2._piecePosition, Color.White);

            _spriteBatch.Draw(PawnW1._pieceTexture, PawnW1._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW2._pieceTexture, PawnW2._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW3._pieceTexture, PawnW3._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW4._pieceTexture, PawnW4._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW5._pieceTexture, PawnW5._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW6._pieceTexture, PawnW6._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW7._pieceTexture, PawnW7._piecePosition, Color.White);
            _spriteBatch.Draw(PawnW8._pieceTexture, PawnW8._piecePosition, Color.White);


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
