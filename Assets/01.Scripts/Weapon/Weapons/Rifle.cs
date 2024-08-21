public class Rifle : Weapon
{
    private void OnEnable()
    {
        InputManager.OnLeftMouseEvent += Shoot;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseEvent -= Shoot;
    }
}