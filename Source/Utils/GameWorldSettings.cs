namespace myAsteroidsGame.Source.Utils
{
    /// <summary>
    /// Contain global world settings for the game objects.
    /// </summary>
    class GameWorldSettings
    {
        /// <summary>
        /// Reactive Force that act on the player spaseship.
        /// </summary>
        public static float ReactiveForce { get; private set; } = 500f;

        /// <summary>
        /// The force that slows down the player spaceship per frame.
        /// </summary>
        public static float FrictionForce { get; private set; } = 250f;

        /// <summary>
        /// The value by which all space objects are rotated.
        /// </summary>
        public static float AngleRotation { get; private set; } = 5.0f;
    }
}