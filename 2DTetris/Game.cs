using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTetris
{
    enum Direction
    {
        Down,
        Left,
        Right
    }

    class Game
    {
        int score;
        public int Score 
        { 
            get { return score; }
        }
        public bool gameOver = false;
        Color[,] matrix;
        public int matrixWidth = 12;
        public int matrixHeight = 20;
        Block currentBlock;
        public static Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Gray };
        public int nextColorIndex = 0;

        public Game()
        {
            matrix = new Color[matrixHeight, matrixWidth];
            for (int i = 0; i < matrixHeight; i++)
                for (int j = 0; j < matrixWidth; j++)
                    matrix[i, j] = Color.White;

            createBlock();
        }

        private void createBlock()
        {
            var color = colors[nextColorIndex];
            nextColorIndex = (nextColorIndex + 1) % colors.Length;
            Random rnd = new Random();
            switch (rnd.Next() % 4)
            {
                case 0:
                    currentBlock = new I(color);
                    break;
                case 1:
                    currentBlock = new O(color);
                    break;
                case 2:
                    currentBlock = new Z(color);
                    break;
                case 3:
                    currentBlock = new L(color);
                    break;
                default:
                    currentBlock = new I(color);
                    break;
            }
        }

        private (int, int) movingCoordinates(Direction d)
        {
            int di = d == Direction.Down ? 1 : 0;
            int dj = 0;
            if (d == Direction.Left)
            {
                dj = -1;
            }
            else if (d == Direction.Right)
            {
                dj = 1;
            }
            return (di, dj);
        }

        private bool canMove(Direction d)
        {
            var (di, dj) = movingCoordinates(d);

            bool canMove = true;
            foreach (var (j, i) in currentBlock.Positions)
            {
                try
                {
                    if (matrix[i + di, j + dj] != Color.White)
                    {
                        canMove = false;
                        break;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    canMove = false;
                }
            }

            return canMove;
        }

        public bool MoveBlock(Direction d)
        {
            if (!canMove(d)) return false;
            
            var (di, dj) = movingCoordinates(d);

            for (int i = 0; i < currentBlock.Positions.Count; i++)
            {
                var p = currentBlock.Positions[i];
                p.Item1 += dj;
                p.Item2 += di;
                currentBlock.Positions[i] = p;
            }

            return true;
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < matrixHeight; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    var color = matrix[i, j];
                    DrawUtils.FillRect(g, color, j, i);
                }
            }

            currentBlock.Draw(g);
        }

        private void removeFilledRows()
        {
            for (int i = matrixHeight - 1; i > 0; i--)
            {
                bool allBlocksFilled = true;
                for (int j = 0; j < matrixWidth; j++)
                {
                    if (matrix[i, j] == Color.White)
                    {
                        allBlocksFilled = false;
                        break;
                    }
                }
                if (allBlocksFilled)
                {
                    score += 100;
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < matrixWidth; j++)
                        {
                            matrix[k, j] = matrix[k - 1, j];
                        }
                    }
                    i++;
                }
            }
        }

        private bool isGameOver()
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                if (matrix[3, j] != Color.White)
                {
                    return true;
                }
            }

            return false;
        }

        public void Update()
        {
            if (gameOver) return;
            if (!MoveBlock(Direction.Down))
            {
                var color = currentBlock.BlockColor;
                foreach (var (j, i) in currentBlock.Positions)
                {
                    matrix[i, j] = color;
                }
                if (isGameOver())
                {
                    gameOver = true;
                    return;
                }
                removeFilledRows();
                createBlock();
                score += 10;
            }
            
        }

        public void Rotate()
        {
            currentBlock.rotate(matrix);
        }
    }
}
