namespace CryEngine.Game
{
    public class playerbase
    {
        /// <summary>
        /// Move function for 3D Physics based movement left, right, up, down and/ or forward, backwards
        /// Basically allows for a side scroll space shooter or 3D movement style game.
        /// </summary>
        /// <param name="transform">The Entity component.</param>
        /// <param name="horizontalInput">Left and Right movement.</param>
        /// <param name="verticalInput">Up and Down movement.</param>
        /// <param name="depthInput">Forward and Backwards movement.</param>
        /// <param name="speed">Speed value on how fast the character should move.</param>
        /// <param name="frameTime">the current frametime used to smooth movement to meters per second</param>
        public void Move(Entity transform, float horizontalInput, float verticalInput, float depthInput, float speed, float frameTime)
        {
            // Create a vector to house the three movement variables we need.
            Vector3 movement = new Vector3(horizontalInput, verticalInput, depthInput);
            // normalize the movement and add the speed and frames
            Vector3 fullMovement = movement.Normalized * speed * frameTime;
            // move the physics body based off the transform's position and add the movement to it.
            transform.Position = transform.Position + fullMovement;
        }

        /// <summary>
        /// A jump function designed to make sure the object is grounded before it can jump again.
        /// </summary>
        /// <param name="jumpForce"></param>
        /// <param name="verticalInput"></param>
        /// <param name="isAirborne"></param>
        /// <param name="transform"></param>
        public void Jump(Vector3 jumpForce, float verticalInput, bool isAirborne, Entity transform)
        {
            if (verticalInput > 0 && !isAirborne || verticalInput < 0 && !isAirborne)
            {
                transform.Physics.Jump(jumpForce);
            }
        }
    }
}