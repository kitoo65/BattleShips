using UnityEngine;

namespace Input
{
    public class JoystickInputAdapter : Input
    {
        private readonly Joystick _joystick;

        private readonly JoyButton _joyButton;
        //Este es el constructor.
        public JoystickInputAdapter(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton; //Como lo tengo que poner en el constructor, tengo que ponerlo en el installer.
        }

        public Vector2 GetDirection()
        {
            return new Vector2(_joystick.Horizontal,_joystick.Vertical);
        }

        public bool IsFireActionPressed()
        {
            return _joyButton.IsPressed;
        }
    }
}
