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

            bool whiteTurn = true;
            bool mRealeased = true;

            Texture2D whiteBlock;
            Texture2D brownBlock;

            List<int> postion = new List<int>() {0, 100, 200, 300, 400, 500, 600, 700};
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
    
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

                //BlackKey
                List<string> pieceTypesB = new List<string>() { "RookB1", "HorseB1", "BishopB1", "KingB", "QueenB", "BishopB2", "HorseB2", "RookB2", "PawnB1", "PawnB2", "PawnB3", "PawnB4", "PawnB5", "PawnB6", "PawnB7", "PawnB8"};

                //WhiteKey
                List<string> pieceTypesW = new List<string>() { "RookW1", "HorseW1", "BishopW1", "KingW", "QueenW", "BishopW2", "HorseW2", "RookW2", "PawnW1", "PawnW2", "PawnW3", "PawnW4", "PawnW5", "PawnW6", "PawnW7", "PawnW8" };

                List<string> pieceNames = new List<string>() { "Rook", "Horse", "Bishop", "King", "Queen", "Bishop", "Horse", "Rook", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn"};


                //Add blackPieces
                for (int i = 0; i < pieceNames.Count; i++)
                {
                    if (i > 7)
                    {
                        pieces.Add(pieceTypesB[i], new Piece(new Vector2(i * 100 - 800, 100), Content.Load<Texture2D>(pieceNames[i] + "W"), true, false, pieceNames[i], "B"));
                    
                    }
                    else
                    {
                        pieces.Add(pieceTypesB[i], new Piece(new Vector2(i * 100, 0), Content.Load<Texture2D>(pieceNames[i] + "W"), true, false, pieceNames[i], "B"));
                    }
                }
                //Add whitePieces
                for (int i = 0; i < pieceNames.Count; i++)
                {
                    if (i > 7)
                    {
                        pieces.Add(pieceTypesW[i], new Piece(new Vector2(i * 100 - 800, 600), Content.Load<Texture2D>(pieceNames[i] + "W"), true, false, pieceNames[i], "W"));

                    }
                    else
                    {
                        pieces.Add(pieceTypesW[i], new Piece(new Vector2(i * 100, 700), Content.Load<Texture2D>(pieceNames[i] + "W"), true, false, pieceNames[i], "W"));
                    }
                }
            }

            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                mState = Mouse.GetState();


                if (mState.LeftButton == ButtonState.Pressed && mRealeased == true)
                {
                    foreach (var p in pieces)
                        if (p.Value.Clicked(mState.Position.ToVector2()))
                        {
                            p.Value.Move(200, 0);
                        }

                    mRealeased = false;
                }

                if (mState.LeftButton == ButtonState.Released)
                {
                    mRealeased = true;
                }

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

                //Draw Pieces
                foreach (var p in pieces)
                {
                    p.Value.Draw(_spriteBatch);
                }


                _spriteBatch.End();

                // TODO: Add your drawing code here

                base.Draw(gameTime);
            }
        }
    }
