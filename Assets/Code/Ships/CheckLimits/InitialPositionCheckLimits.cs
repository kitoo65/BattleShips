using System;
using UnityEngine;

namespace Ships.CheckLimits
{
    public class InitialPositionCheckLimits : CheckLimits
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        private readonly float _maxDistance;

        //Constructor
        public InitialPositionCheckLimits (Transform transform, float maxDistance)
        {
            _transform = transform;
            _maxDistance = maxDistance;
            _initialPosition = _transform.position;
        }

        public void ClampFinalPosition()
        {
            var currentPosition = _transform.position;
            var finalPosition = currentPosition;
            //Comprobare la posicion X.
            var distance = Mathf.Abs(currentPosition.x = _initialPosition.x);
            if (distance <= _maxDistance)return;

                if(currentPosition.x> _initialPosition.x) //Estamos yendo hacia la derecha.
                                                          //Le sumamos la maxima distancia.
                {
                    finalPosition.x = _initialPosition.x + _maxDistance;
                }
                else
                {
                    finalPosition.x = _initialPosition.x - _maxDistance;
                }
                _transform.position = finalPosition; //Aplicamos este limite. 
        }
        //Luego de determinar la posición, voy al installer, y devuelvo este tipo de estrategia.
    }
}
