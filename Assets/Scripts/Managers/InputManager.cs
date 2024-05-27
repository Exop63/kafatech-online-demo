
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Joystick joystick;
    public bool invertDir = false;

    private void Update()
    {
        if (Minion.local == null) return;

        if (joystick != null && joystick.Direction.sqrMagnitude > 0)
        {
            // move 
            var dir = invertDir ? -joystick.Direction : joystick.Direction;
            Minion.local.PlayerMove.CmdSetDirectin(dir);
        }
        else if (Minion.local?.PlayerMove.direction.sqrMagnitude != 0)
        {
            // stop player
            Minion.local?.PlayerMove.CmdSetDirectin(Vector2.zero);

        }


    }

}
