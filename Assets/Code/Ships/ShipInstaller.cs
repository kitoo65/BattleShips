using System;
using System.Security.Cryptography;
using Input;
using UnityEngine;
using Ships.CheckLimits;

namespace Ships
{
    public class ShipInstaller :MonoBehaviour//Me va a configurar el Ship.
    {
        //Para crear la IA, tengo que tener una variable que decida si usar la IA o no.
        [SerializeField] private bool _useAI;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.ConfigureInput(GetInput(),GetCheckLimitsStrategy());   
        }

        private Input.Input GetInput()
        {
            if (_useAI)
            {
                return new AIInputAdapter(_ship); //Le paso la nave para testear.
            }
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick, _joyButton);

            }
            Destroy(_joystick.gameObject);
            Destroy(_joyButton.gameObject);
            return new UnityInputAdapter();
        }

        public CheckLimits.CheckLimits GetCheckLimitsStrategy()
        {
            if (_useAI)
            {
                return new InitialPositionCheckLimits(_ship.transform, 10f); //Con este codigo, el player solo se puede mover 10 hacia la izq, 
                //O 10 hacia la derecha.
            }
            return new ViewportCheckLimits(_ship.transform, Camera.main);
        }
    }

}

