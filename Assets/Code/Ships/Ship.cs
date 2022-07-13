using UnityEngine;
using System;
using Ships.Weapons;
using Ships.CheckLimits;


namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Input.Input _input; // Creo una variable que almacena el boton de la UI.    
        //Ahora, cambio la variable de tipo joystick, a Input.
        private Transform _myTransform;
        private CheckLimits.CheckLimits _checkLimits;


        private void Awake()
        {
            _myTransform = transform;
        }
        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }
        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            //Busco un vector2 que guarde los bordes de la camara. De 0 a 100%. 
            //Pongo la estrategia aca.
            _checkLimits.ClampFinalPosition();
        }
     

        private Vector2 GetDirection()
        {
           return _input.GetDirection();

        }

        public void ConfigureInput(Input.Input input, CheckLimits.CheckLimits checkLimits)
        {
            _checkLimits = checkLimits;
            _input = input;
        }

    }

}

