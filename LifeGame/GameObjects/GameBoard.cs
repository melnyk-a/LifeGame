using LifeGame.Memento;
using System;
using System.Collections.Generic;

namespace LifeGame.GameObjects
{
    internal sealed class GameBoard
    {
        private const int _countOfHorizontalFrame = 2;
        private const int _countOfVerticalFrame = 2;
        private const char _frameSymbol = '+';
        private readonly Cell[,] _cells;

        public GameBoard(int width, int height)
        {
            Height = height;
            Width = width;
            _cells = new Cell[Height, Width];
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    _cells[i, j] = new Cell();
                }
            }
            SetNeighbor();
        }

        public Cell this[int row, int coll] { get { return _cells[row, coll]; } }

        public int FrameSize { get; } = 1;

        public int Height { get; }

        public int Width { get;  }

        public BoardMemento Save()
        {
            IList<Point> liveCells = new List<Point>();
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (_cells[i, j].IsAlive)
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
                    _cells[i, j].IsAlive = false;
                }
            }
            for (int i = 0; i < points.Count; ++i)
            {
                _cells[points[i].X, points[i].Y].IsAlive = true;
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
                        _cells[i, j].AddNeighbor(_cells[i, j - 1]);
                    }
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        _cells[i, j].AddNeighbor(_cells[i - 1, j - 1]);
                    }
                    if (i - 1 >= 0)
                    {
                        _cells[i, j].AddNeighbor(_cells[i - 1, j]);
                    }
                    if (j + 1 < Width)
                    {
                        _cells[i, j].AddNeighbor(_cells[i, j + 1]);
                    }
                    if (j + 1 < Width && i + 1 < Height)
                    {
                        _cells[i, j].AddNeighbor(_cells[i + 1, j + 1]);
                    }
                    if (j + 1 < Width && i - 1 >= 0)
                    {
                        _cells[i, j].AddNeighbor(_cells[i - 1, j + 1]);
                    }
                    if (i + 1 < Height)
                    {
                        _cells[i, j].AddNeighbor(_cells[i + 1, j]);
                    }
                    if (j - 1 >= 0 && i + 1 < Height)
                    {
                        _cells[i, j].AddNeighbor(_cells[i + 1, j - 1]);
                    }
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < Height + FrameSize * _countOfVerticalFrame; ++i)
            {
                for (int j = 0; j < Width + FrameSize * _countOfHorizontalFrame; ++j)
                {
                    if (i < FrameSize || i >= Height + FrameSize ||
                        j < FrameSize || j >= Width + FrameSize)
                    {
                        Console.Write(_frameSymbol);
                    }
                    else
                    {
                        if (_cells[i - FrameSize, j - FrameSize].IsAlive)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        Console.Write(_cells[i - FrameSize, j - FrameSize]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}