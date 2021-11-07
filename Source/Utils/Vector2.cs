using System;

namespace myAsteroidsGame.Source.Utils
{
    struct Vector2
    {
        private float xPos_;
        public float X
        {
            get => xPos_;
            set => xPos_ = value;
        }

        private float yPos_;
        public float Y
        {
            get => yPos_;
            set => yPos_ = value;
        }

        public Vector2(float xPos, float yPos)
        {
            xPos_ = xPos;
            yPos_ = yPos;
        }

        public static Vector2 Zero => new Vector2();

        public static Vector2 operator +(Vector2 value1, Vector2 value2) => new Vector2(value1.X + value2.X, value1.Y + value2.Y);
        public static Vector2 operator -(Vector2 value1, Vector2 value2) => new Vector2(value1.X - value2.X, value1.Y - value2.Y);
        public static Vector2 operator *(Vector2 value1, float value2) => new Vector2(value1.X * value2, value1.Y * value2);
        public static Vector2 operator *(float value1, Vector2 value2) => value2 * value1;
        public static Vector2 operator /(Vector2 value1, float value2) => new Vector2(value1.X / value2, value1.Y / value2);
        public static Vector2 operator /(float value1, Vector2 value2) => value2 / value1;
        public static Vector2 operator -(Vector2 v) => Vector2.Zero - v;
        public static bool operator ==(Vector2 value1, Vector2 value2) => (value1.X == value2.X) && (value1.Y == value2.Y);
        public static bool operator !=(Vector2 value1, Vector2 value2) => !(value1 == value2);

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            return (float)Math.Sqrt((value1.X - value2.X) * (value1.X - value2.X) + 
                                    (value1.Y - value2.Y) * (value1.Y - value2.Y));
        }

        public static Vector2 Normalize(Vector2 vector)
        {
            Vector2 copy = vector;
            float copyLength = vector.Length();
            float inversedLength = 1 / copyLength;
            copy.X *= inversedLength;
            copy.Y *= inversedLength;
            return copy;
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            result = Normalize(value);
        }

        public static Vector2 Negate(Vector2 value)
        {
            return new Vector2(value.X * -1f, value.Y * -1f);
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float by)
        {
            if (by >= 1.0000f)
                by = 1.0000f;
            return new Vector2(Lerp(value1.X, value2.X, by), Lerp(value1.Y, value2.Y, by));
        }

        public float Length()
        {
            return Convert.ToSingle(Math.Sqrt(xPos_ * xPos_ + yPos_ * yPos_));
        }

        public override int GetHashCode() => (xPos_, yPos_).GetHashCode();
        public override bool Equals(object obj) => (obj is Vector2) && this == (Vector2)obj;

        private static float Lerp(float value1, float value2, float by)
        {
            return value1 * (1 - by) + value2 * by;
        }
    }
}
