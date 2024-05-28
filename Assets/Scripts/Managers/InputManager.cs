
using Mirror;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Joystick joystick;
    public bool invertDir = false;
    [ClientCallback]
    private void Update()
    {
        if (Player.local == null) return;

        if (joystick != null && joystick.Direction.sqrMagnitude > 0)
        {
            // move 
            var dir = invertDir ? -joystick.Direction : joystick.Direction;
            Player.local.PlayerMove.SetDirection(dir);
        }
        else if (Player.local?.PlayerMove.direction.sqrMagnitude != 0)
        {
            // stop player
            Player.local?.PlayerMove.SetDirection(Vector2.zero);

        }


    }

}
