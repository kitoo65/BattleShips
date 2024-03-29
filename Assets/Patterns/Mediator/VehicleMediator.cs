using System;
using Unity.VisualScripting;
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
            foreach (var brakeLight in _brakeLights)
            {
             brakeLight.Configure(this);   
            }
            foreach (var wheel in _wheels)
            {
                wheel.Configure(this);
            }
            _brake.Configure(this); //Aca asignamos los brakes al vehiculo.
            _steeringWheel.Configure(this); //Aca asignamos el volante. 

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
            foreach (var wheel in _wheels) //Lo que ocurre en el mediador, es que el mismo decide que se tienen que mover las ruedas.
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