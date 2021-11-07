using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

namespace myAsteroidsGame.Source.GameObjects
{
    class GameObject
    {
        private Transform transform_;
        public Transform Transform => transform_;

        private IPhysicsComponent physic_;
        public IPhysicsComponent Physic
        {
            get => physic_;
            set => physic_ = value;
        }

        private IGraphicsComponent graphics_;
        public IGraphicsComponent Graphics
        {
            get => graphics_;
            set => graphics_ = value;
        }

        private bool isActive_;
        public bool IsActive
        {
            get => isActive_;
            set => isActive_ = value;
        }

        public string Name { get; set; } = "GameObject";

        public GameObject(float xPos, float yPos)
        {
            transform_ = new Transform(xPos, yPos);
            physic_ = null;
            graphics_ = null;
            isActive_ = true;
        }

        public virtual void Update() { }

        public virtual void Rotate(float degree) { }
    }
}