using System;
using System.Drawing;
using System.Reflection;
using WindowsFormsAppCase2.Properties;

namespace WindowsFormsAppCase2
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Tank
    {
        private static readonly Image[] Image = { Resources.p1tankL, Resources.p1tankR, Resources.p1tankU, Resources.p1tankD };

        // 方向
        public Direction Direction { get; set; } = Direction.Up;

        // 速度
        public int Speed { get; set; } = 10;

        private int _x = 250;
        // x轴位置
        public int X
        {
            get => _x;
            set
            {
                // 控制边界
                if (_x < 0)
                {
                    _x = 20;
                }

                if (_x > 480)
                {
                    _x = 460;
                }
                // 控制移动
                switch (Direction)
                {
                    case Direction.Left:
                        _x -= Speed;
                        break;
                    case Direction.Right:
                        _x += Speed;
                        break;
                }
            }
        }
        // y轴位置
        private int _y = 250;
        public int Y
        {
            get => _y;
            set
            {
                // 控制边界
                if (_y < 0)
                {
                    _y = 20;
                }

                if (_y > 330)
                {
                    _y = 300;
                }
                // 控制移动
                switch (Direction)
                {
                    case Direction.Up:
                        _y -= Speed;
                        break;
                    case Direction.Down:
                        _y += Speed;
                        break;
                }
            }
        }

        private Image _ownImage = Image[2];
        // 自身图片
        public Image OwnImage
        {

            get => _ownImage;
            set
            {
                switch (Direction)
                {
                    case Direction.Left:
                        _ownImage = Image[0];
                        break;
                    case Direction.Right:
                        _ownImage = Image[1];
                        break;
                    case Direction.Up:
                        _ownImage = Image[2];
                        break;
                    case Direction.Down:
                        _ownImage = Image[3];
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Tank()
        {
        }
    }
}