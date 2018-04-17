using LifeGame.Commands;
using LifeGame.Cursor;
using LifeGame.GameOverManager;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LifeGame.GameObjects
{
    internal sealed class Universe
    {
        private readonly ConsoleCursor _cursor = new ConsoleCursor();
        private readonly int _delay;
        private readonly GameBoard _gameBoard;
        private readonly GameOverControl _gameOverControl = new GameOverControl();
        private Generation _generation = new Generation();
        

        public Universe(int width, int height, int delay)
        {
            _gameBoard = new GameBoard(width, height);
            _delay = delay;
        }

        public bool IsGameOver { get; set; }

        private IList<ICommand> Create(Point startPosition, ConsoleCursor cursor)
        {
            int left = startPosition.X + _gameBoard.FrameSize;
            int top = startPosition.Y + _gameBoard.FrameSize;

            // -1 для корректного отображения курсора после ввода
            int right = _gameBoard.Width + _gameBoard.FrameSize - 1;
            int bottom = _gameBoard.Height + _gameBoard.FrameSize;
            CursorField _cursorField = new CursorField(left, top, right, bottom, cursor);

            IList<ICommand> commands = new List<ICommand>
            {
                new MoveRightCommand(ConsoleKey.RightArrow, _cursorField),
                new MoveLeftCommand(ConsoleKey.LeftArrow, _cursorField),
                new MoveDownCommand(ConsoleKey.DownArrow, _cursorField),
                new MoveUpCommand(ConsoleKey.UpArrow, _cursorField),
                new EnterCommand(ConsoleKey.Enter, _cursorField, _gameBoard),
                new SpaceCommand(ConsoleKey.Spacebar, this)
            };
            return commands;
        }

        private IList<IGameOverStrategy> Create()
        {
            GameStrategyListCreator creator = new GameStrategyListCreator(
               _gameOverControl.AliveHistory);
            return creator.Create();
        }

        public void Execute()
        {
            _generation.Show();
            Point startPosition = new Point(Console.CursorLeft, Console.CursorTop);
            _gameBoard.Show();
            IList<ICommand> commands = Create(startPosition, _cursor);
            do
            {
                _cursor.Show();
                ConsoleKey key = Console.ReadKey().Key;
                foreach (var command in commands)
                {
                    if (command.CanExecute(key))
                    {
                        command.Execute();
                    }
                }
                Console.SetCursorPosition(startPosition.X, startPosition.Y);
                _gameBoard.Show();

            } while (!IsGameOver);
            int lastLine = startPosition.Y + _gameBoard.Height + _gameBoard.FrameSize * 2;
            Console.SetCursorPosition(0, lastLine);
        }

        public void StartLife()
        {
            _gameOverControl.AliveHistory.Add(_gameBoard.Save());
            IsGameOver = _gameOverControl.IsGameOver(Create());

            while (!IsGameOver)
            {
                Console.SetCursorPosition(0, 0);
                ++_generation;
                _generation.Show();
                _gameBoard.Show();
                UpdateGameBoard();
                _gameOverControl.AliveHistory.Add(_gameBoard.Save());
                IsGameOver = _gameOverControl.IsGameOver(Create());
                Thread.Sleep(_delay);
            }
        }

        private void UpdateGameBoard()
        {
            int deadCellAliveNeighbors = 3;
            int aliveCellAliveNeighbors1 = 2;
            int aliveCellAliveNeighbors2 = 3;

            IList<Point> alivePoints = new List<Point>();
            for (int i = 0; i < _gameBoard.Height; ++i)
            {
                for (int j = 0; j < _gameBoard.Width; ++j)
                {
                    Cell currentCell = _gameBoard[i, j];
                    if (!currentCell.IsAlive &&
                        currentCell.GetAliveNeighborsCount() == deadCellAliveNeighbors)
                    {
                        alivePoints.Add(new Point(i, j));
                    }
                    else if (currentCell.IsAlive &&
                        (currentCell.GetAliveNeighborsCount() == aliveCellAliveNeighbors1 ||
                        currentCell.GetAliveNeighborsCount() == aliveCellAliveNeighbors2))
                    {
                        alivePoints.Add(new Point(i, j));
                    }
                }
            }
            _gameBoard.SetAlive(alivePoints);
        }
    }
}