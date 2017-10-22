namespace Game1
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            IPhysicalObject2D narrow, wide, tall, small;

            if (a.Width > b.Width)
            {
                wide = a;
                narrow = b;
            }
            else
            {
                wide = b;
                narrow = a;
            }

            if (a.Height > b.Height)
            {
                tall = a;
                small = b;
            }
            else
            {
                tall = b;
                small = a;
            }

            if (narrow.X >= wide.X)
            {
                if (narrow.X - wide.X > wide.Width) return false;
            }
            else if (narrow.X < wide.X)
            {
                if (wide.X - narrow.X > narrow.Width) return false;
            }

            if (tall.Y >= small.Y)
            {
                if (tall.Y - small.Y > small.Height) return false;
            }
            else if (tall.Y < small.Y)
            {
                if (small.Y - tall.Y > tall.Height) return false;
            }
            return true;
        }
    }
}