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
        private readonly GameOverControl _gameOverControl = new GameOverControl();
        private readonly ConsoleCursor _cursor = new ConsoleCursor();
        private readonly GameBoard _gameBoard;
        private Generation _generation = new Generation();
        private readonly int _delay;

        public Universe(int width, int height, int delay)
        {
            _gameBoard = new GameBoard(width, height);
            _delay = delay;
        }

        public bool IsGameOver { get; set; }

        public void Execute()
        {
            _generation.Show();
            Point startPosition = new Point(Console.CursorLeft, Console.CursorTop);
            _gameBoard.Show();
            IList<ICommand> commandList = CreateCommandList(startPosition, _cursor);
            do
            {
                _cursor.Show();
                ConsoleKey key = Console.ReadKey().Key;
                foreach (var item in commandList)
                {
                    if (item.CanExecute(key))
                    {
                        item.Execute();
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
            IsGameOver = _gameOverControl.IsGameOver(CreateStrategyList());

            while (!IsGameOver)
            {
                Console.SetCursorPosition(0, 0);
                ++_generation;
                _generation.Show();
                _gameBoard.Show();
                UpdateGameBoard();
                _gameOverControl.AliveHistory.Add(_gameBoard.Save());
                IsGameOver = _gameOverControl.IsGameOver(CreateStrategyList());
                Thread.Sleep(_delay);
            }
        }

        private void UpdateGameBoard()
        {
            IList<Point> alivePoints = new List<Point>();
            for (int i = 0; i < _gameBoard.Height; ++i)
            {
                for (int j = 0; j < _gameBoard.Width; ++j)
                {
                    Cell currentCell = _gameBoard[i, j];
                    if (!currentCell.IsAlive &&
                        currentCell.GetAliveNeighborsCount() == 3)
                    {
                        alivePoints.Add(new Point(i, j));
                    }
                    else if (currentCell.IsAlive &&
                        (currentCell.GetAliveNeighborsCount() == 2 ||
                        currentCell.GetAliveNeighborsCount() == 3))
                    {
                        alivePoints.Add(new Point(i, j));
                    }
                }
            }
            _gameBoard.SetAlive(alivePoints);
        }

        private IList<IGameOverStrategy> CreateStrategyList()
        {
            GameStrategyListCreator creator = new GameStrategyListCreator(
               _gameOverControl.AliveHistory);
            return creator.Create();
        }

        private IList<ICommand> CreateCommandList(Point startPosition, ConsoleCursor cursor)
        {
            int left = startPosition.X + _gameBoard.FrameSize;
            int top = startPosition.Y + _gameBoard.FrameSize;

            // -1 для корректного отображения курсора после ввода
            int right = _gameBoard.Width + _gameBoard.FrameSize - 1;
            int buttom = _gameBoard.Height + _gameBoard.FrameSize;
            CursorField _cursorField = new CursorField(left, top, right, buttom, cursor);

            IList<ICommand> commandList = new List<ICommand>
            {
                new MoveRightCommand(ConsoleKey.RightArrow, _cursorField),
                new MoveLeftCommand(ConsoleKey.LeftArrow, _cursorField),
                new MoveDownCommand(ConsoleKey.DownArrow, _cursorField),
                new MoveUpCommand(ConsoleKey.UpArrow, _cursorField),
                new EnterCommand(ConsoleKey.Enter, _cursorField, _gameBoard),
                new SpaceCommand(ConsoleKey.Spacebar, this)
            };
            return commandList;
        }
    }
}