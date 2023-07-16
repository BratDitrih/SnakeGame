using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Змейка
{
    public partial class Form1 : Form
    {
        private int mapSize = 750;
        private int indent = 50;
        private int cellSize = 50;
        private int score = 0;
        private Direction direction = Direction.Right;
        public Direction Direction { get { return direction; } 
            set { if ((int)value != ((int)direction + 2) % 4) direction = value; } }

        private List<PictureBox> snake = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(mapSize + 2 * indent, mapSize + 2 * indent);

            Head.Size = new Size(cellSize, cellSize);
            Head.Location = new Point(indent + 3 * cellSize, (indent + mapSize) / 2);
            GenerateNewFruit();

            snake.Add(Head);
            Score.Location = new Point(indent, 10);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(indent, indent);
            Pen pen = new Pen(Color.Black, 2);
            for (int i = 0; i <= mapSize; i += cellSize)
            {
                g.DrawLine(pen, new Point(0, i), new Point(mapSize, i));
            }
            for (int i = 0; i <= mapSize; i += cellSize)
            {
                g.DrawLine(pen, new Point(i, 0), new Point(i, mapSize));
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Direction = Direction.Left;
                    break;
                case Keys.Up:
                    Direction = Direction.Up;
                    break;
                case Keys.Right:
                    Direction = Direction.Right;
                    break;
                case Keys.Down:
                    Direction = Direction.Down;
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MoveForward();
            CheckForLose();
            EatFruit();
        }

        private void CheckForLose()
        {
            if (IsOverBorders() || IsEatItself())
            {
                timer.Stop();
                MessageBox.Show("GAME OVER");
            } 
        }

        private void EatFruit()
        {
            if (Head.Bounds.IntersectsWith(Fruit.Bounds))
            {
                Grow();
                GenerateNewFruit();
                Score.Text = $"Счет: {++score}";
            }
        }

        private void GenerateNewFruit()
        {
            int x, y;
            Random r = new Random();
            do
            {
                x = r.Next(indent, mapSize);
                x -= x % cellSize;
                y = r.Next(indent, mapSize);
                y -= y % cellSize;
            } while (IsIntersects(new Point(x, y)));
            int fruitIndent = indent / 4;
            Fruit.Size = new Size(cellSize - fruitIndent, cellSize - fruitIndent);
            Fruit.Location = new Point(fruitIndent / 2 + x, fruitIndent / 2 + y);
        }

        private bool IsIntersects(Point point)
        {
            foreach (PictureBox node in snake)
            {
                if (node.Bounds.IntersectsWith(new Rectangle(point, new Size(cellSize, cellSize)))) return true;
            }
            return false;
        }

        private bool IsOverBorders()
        {
            if (Head.Left >= indent && Head.Right <= mapSize + indent && Head.Top >= indent && Head.Bottom <= mapSize + indent) return false;
            return true;
        }

        private bool IsEatItself()
        {
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[i].Bounds.IntersectsWith(Head.Bounds)) return true;
            }
            return false;
        }

        private void Grow()
        {
            PictureBox node = new PictureBox();
            node.Size = Head.Size;
            node.BackColor = Color.DarkBlue;
            node.Location = Head.Location;
            Controls.Add(node);
            snake.Add(node);
        }

        private void MoveLeft()
        {
            Head.Left -= cellSize;
        }

        private void MoveUp()
        {
            Head.Top -= cellSize;
        }

        private void MoveRight()
        {
            Head.Left += cellSize;
        }

        private void MoveDown()
        {
            Head.Top += cellSize;
        }

        private void MoveForward()
        {
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            switch (direction)
            {
                case Direction.Up:
                    MoveUp();
                    break;
                case Direction.Down:
                    MoveDown();
                    break;
                case Direction.Right:
                    MoveRight();
                    break;
                case Direction.Left:
                    MoveLeft();
                    break;
            }
        }
    }
}

public enum Direction
{
    Left,
    Up,
    Right,
    Down
}
