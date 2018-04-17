using LifeGame.Memento;
using System;
using System.Collections.Generic;

namespace LifeGame.GameObjects
{
    internal sealed class GameBoard
    {
        private const char _frameSymbol = '+';
        private readonly Cell[,] _cellsArray;

        public GameBoard(int width, int height)
        {
            Height = height;
            Width = width;
            _cellsArray = new Cell[Height, Width];
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    _cellsArray[i, j] = new Cell();
                }
            }
            SetNeighbor();
        }

        public int FrameSize { get; } = 1;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Cell this[int row, int coll] { get { return _cellsArray[row, coll]; } }

        public BoardMemento Save()
        {
            IList<Point> liveCells = new List<Point>();
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (_cellsArray[i, j].IsAlive)
                    {
                        liveCells.Add(new Point(i, j));
                    }
                }
            }
            return new BoardMemento(liveCells);
        }

        public void SetAlive(IList<Point> points)
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    _cellsArray[i, j].IsAlive = false;
                }
            }
            for (int i = 0; i < points.Count; ++i)
            {
                _cellsArray[points[i].X, points[i].Y].IsAlive = true;
            }
        }

        private void SetNeighbor()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (j - 1 >= 0)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i, j - 1]);
                    }
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i - 1, j - 1]);
                    }
                    if (i - 1 >= 0)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i - 1, j]);
                    }
                    if (j + 1 < Width)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i, j + 1]);
                    }
                    if (j + 1 < Width && i + 1 < Height)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i + 1, j + 1]);
                    }
                    if (j + 1 < Width && i - 1 >= 0)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i - 1, j + 1]);
                    }
                    if (i + 1 < Height)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i + 1, j]);
                    }
                    if (j - 1 >= 0 && i + 1 < Height)
                    {
                        _cellsArray[i, j].AddNeighbor(_cellsArray[i + 1, j - 1]);
                    }
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < Height + FrameSize * 2; ++i)
            {
                for (int j = 0; j < Width + FrameSize * 2; ++j)
                {
                    if (i < FrameSize || i >= Height + FrameSize ||
                        j < FrameSize || j >= Width + FrameSize)
                    {
                        Console.Write(_frameSymbol);
                    }
                    else
                    {
                        if (_cellsArray[i - FrameSize, j - FrameSize].IsAlive)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.Write(_cellsArray[i - FrameSize, j - FrameSize]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}