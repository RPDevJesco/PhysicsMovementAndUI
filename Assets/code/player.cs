using System;

namespace CryEngine.Game
{
	[EntityComponent(Guid="3082fdf4-2cc8-acfc-94e8-8c3ffa5f0a9d")]
	public class player : EntityComponent
	{
		private playerbase playerbase = new playerbase();
		private float _horizontalInput;
		private float _verticalInput;
		private float _depthInput;
		private float _speed = 10;
		private float _frameTime;
		private Vector3 _jumpForce = new Vector3(0, 0, 10);
		private bool isAirborne;

        protected override void OnGameplayStart()
        {
			Engine.Console.ExecuteString("map example");
			PhysicalizeEntity();
		}

		private void PhysicalizeEntity()
        {
			var physicsEntity = Entity.Physics;

			if (physicsEntity == null)
			{
				return;
			}

			var parameters = new LivingPhysicalizeParams();
			var playerDimensions = parameters.PlayerDimensions;
			parameters.Mass = 90f;
			playerDimensions.PivotHeight = 1f;
			Entity.Physics.Physicalize(parameters);
		}
        private void Move()
        {
			playerbase.Move(this.Entity, _horizontalInput, _depthInput, 0, _speed, _frameTime);
		}

		private void Jump()
        {
			playerbase.Jump(_jumpForce, _verticalInput, isAirborne, this.Entity);
        }

        protected override void OnUpdate(float frameTime)
        {
			// ToDO: Figure out a way to do keyboard and controller movement
			// without utilizing the action mapping.
			isAirborne = Entity.Physics.GetStatus<LivingStatus>().IsFlying;
			_frameTime = frameTime;
			_horizontalInput = PassableData.HorizontalInput(Input.GetInputValue(KeyId.XI_ThumbLX));
			_verticalInput = PassableData.VerticalInput(Input.GetInputValue(KeyId.XI_ThumbRY));
			_depthInput = PassableData.DepthInput(Input.GetInputValue(KeyId.XI_ThumbLY));
		}

        protected override void OnPrePhysicsUpdate(float frameTime)
        {
            base.OnPrePhysicsUpdate(frameTime);
			Move();
			Jump();
		}
    }
}