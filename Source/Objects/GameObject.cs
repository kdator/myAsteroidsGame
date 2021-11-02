using myAsteroidsGame.Source.Graphics;
using myAsteroidsGame.Source.Physics;

namespace myAsteroidsGame.Source.Objects
{
    class GameObject
    {
        private Transform transform_;
        public Transform Transform => transform_;

        private IPhysicComponent physic_;
        public IPhysicComponent Physic
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

        public GameObject(float xPos, float yPos, IPhysicComponent physic, IGraphicsComponent graphics)
        {
            transform_ = new Transform(xPos, yPos);
            physic_ = physic;
            graphics_ = graphics;
            isActive_ = true;
        }

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