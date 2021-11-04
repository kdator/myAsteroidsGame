using System;

using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.Objects
{
    class Transform
    {
        private Vector2 pos_;
        public Vector2 Position
        {
            get => pos_;
            set => pos_ = value;
        }

        private float rotDegree_;
        public float RotationDegree
        {
            get => rotDegree_;
            set => rotDegree_ = value;
        }

        public float RotationInRadians
        {
            get => rotDegree_ / 180 * (float)Math.PI;
        }

        public Vector2 RotationDirection
        {
            get => new Vector2((float)Math.Sin(rotDegree_ / 180 * (float)Math.PI),
                              -(float)Math.Cos(rotDegree_ / 180 * (float)Math.PI));
        }

        public Transform()
        {
            pos_ = Vector2.Zero;
            rotDegree_ = 0.0f;
        }

        public Transform(float xPos, float yPos)
        {
            pos_ = new Vector2(xPos, yPos);
            rotDegree_ = 0.0f;
        }
    }
}