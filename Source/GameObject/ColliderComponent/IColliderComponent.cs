using System.Collections.Generic;

using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.GameObjects.ColliderComponent
{
    interface IColliderComponent
    {
        public void OnCollision();

        public void OnRadiusEnter();

        public void UpdateVertexes();

        public List<Vector2> GetAbsoluteVertexes();

        public float Radius { get; }
    }
}
