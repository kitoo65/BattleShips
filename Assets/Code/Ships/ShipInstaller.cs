using System;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller :MonoBehaviour//Me va a configurar el Ship.
    {
        //Para crear la IA, tengo que tener una variable que decida si usar la IA o no.
        [SerializeField] private bool _useAI;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.ConfigureInput(GetInput(),GetCheckLimitsStrategy());   
        }

        private Input GetInput()
        {
            if (_useAI)
            {
                return new AIInputAdapter(_ship); //Le paso la nave para testear.
            }
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);

            }
            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }

        public CheckLimits GetCheckLimitsStrategy()
        {
            return new ViewportCheckLimits(_ship.transform, Camera.main);
        }
    }

}

