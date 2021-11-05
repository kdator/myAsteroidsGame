using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.GameObjects.Physics
{
    interface IPhysicsComponent
    {
        /// <summary>
        /// Update position of a physical component of every frame.
        /// Should be called after all other functions.
        /// </summary>
        /// <param name="deltaTime">time between last frames.</param>
        void Update(float deltaTime);

        /// <summary>
        /// Apply the force to the physic component.
        /// </summary>
        /// <param name="force">Vector of applying force.</param>
        void ApplyForce(Vector2 force);

        /// <summary>
        /// Get current acceleration.
        /// </summary>
        Vector2 Acceleration { get; }

        /// <summary>
        /// Get current velocity.
        /// </summary>
        Vector2 Velocity { get; set; }

        /// <summary>
        /// Get maximum speed for this physic component.
        /// </summary>
        float MaxSpeed { get; set; }
    }
}