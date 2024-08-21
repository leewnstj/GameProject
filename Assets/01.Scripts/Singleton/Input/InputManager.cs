public partial class InputManager : MonoSingleton<InputManager>, PlayerInput.IPlayerActionsActions
{
    private PlayerInput _playerInput;

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.PlayerActions.SetCallbacks(this);
        }

        _playerInput.PlayerActions.Enable();
    }
}