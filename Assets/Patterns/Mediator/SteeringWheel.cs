using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel :MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;
        private Vehicle _vehicle;

        void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Left"))
            {
                //Es importante que los componentes le digan al mediator lo que ha ocurrido, pero no darle una orden.
                //Por ejemplo, si quiero dar ordenes: _vehicle.TurnLeft. Esto no tiene que suceder. Esto no seria decision del componente!
                //El componente tiene que informar lo ocurrido. Lo que ocurrio fue que se requiere ir a la izquierda.
                _vehicle.LeftPressed();
               
            }
            else if (UnityEngine.Input.GetButtonDown("Right"))
            {
                _vehicle.RightPressed(); //Lo mismo aqui!
                
            }
        }


    }
}