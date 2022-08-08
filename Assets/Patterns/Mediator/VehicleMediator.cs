using System;
using UnityEngine;

namespace Patterns.Mediator
{

    public class VehicleMediator : MonoBehaviour, Vehicle
    {
        //En el Mediator, se tendran los componentes.
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _brakeLights;
        [SerializeField] private SteeringWheel _steeringWheel;

        [SerializeField] private Brake _brake;
        //La idea principal, es que por ejemplo, para que frene, que le avise al mediador
        //Que busque las ruedas y las luces para poder frenar.

        private void Awake()
        {
            _brake.Configure(this); //Aca asignamos los brakes al vehiculo.
            
        }

        //Estas funciones surgen de haberlas modificado del componente Brake
        public void BrakePressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.AddFriction();
            }

            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.TurnOn();
            }
        }

        public void BrakeReleased()
        {
            foreach (var wheel in _wheels)
            {
                wheel.RemoveFriction();
            }

            foreach (var brakeLight in _brakeLights)
            {
                brakeLight.TurnOff();
            }
        }

        public void LeftPressed() //Luego de crearlas en el mediator, las tengo que implementar.
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void RightPressed()
        {
            foreach (var wheel in _wheels)
            {
                wheel.TurnRight();
            }
        }
    }
}