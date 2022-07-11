﻿using System;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller :MonoBehaviour//Me va a configurar el Ship.
    {
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.ConfigureInput(GetInput());   
        }

        private Input GetInput()
        {
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);

            }
            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }
    }

}

