using System;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller :MonoBehaviour//Me va a configurar el Ship.
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.ConfigureInput(GetInput());   
        }

        private Input GetInput()
        {
            return new JoystickInputAdapter(_joystick);
        }
    }

    //De esta manera, se setea el Input para el Joystick Solamente.
}

