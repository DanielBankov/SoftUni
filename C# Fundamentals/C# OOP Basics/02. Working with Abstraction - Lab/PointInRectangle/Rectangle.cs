namespace PointInRectangle
{
    public class Rectangle
    {
        public Point topLeft { get; set; } 
        public Point botRight { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(Point upperLeft, Point lowerRight)
        {
            this.topLeft = upperLeft;
            this.botRight = lowerRight;
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = point.PointX >= topLeft.PointX && point.PointX <= botRight.PointX;
            bool isInVertical = point.PointY >= topLeft.PointY && point.PointY <= botRight.PointY;
            return isInHorizontal && isInVertical;
        }
    }
}
