namespace CryEngine.Game
{
    public static class PassableData
    {
		public static float _horizontalInput;
		public static float _verticalInput;
		public static float _depthInput;

		public static float HorizontalInput(float inputValue)
        {
			_horizontalInput = inputValue;
			return _horizontalInput;
        }

		public static float VerticalInput(float inputValue)
        {
			_verticalInput = inputValue;
			return _verticalInput;
        }

		public static float DepthInput(float inputValue)
        {
			_depthInput = inputValue;
			return _depthInput;
        }
	}
}