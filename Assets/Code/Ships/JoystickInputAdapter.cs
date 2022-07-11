using UnityEngine;

namespace Ships
{
    public class JoystickInputAdapter : Input
    {
        private readonly Joystick _joystick;
        //Este es el constructor.
        public JoystickInputAdapter(Joystick joystick)
        {
            _joystick = joystick;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(_joystick.Horizontal,_joystick.Vertical);
        }

    }
}
