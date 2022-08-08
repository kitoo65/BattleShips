using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        [SerializeField] private Wheel[] _wheels;
        [SerializeField] private VehicleLight[] _brakeLights;

        private Vehicle _vehicle;
        //Debido a que trabajo con Monobehaviour, puedo crear un metodo de configuracion
        //Para poder comunicar este componente con el mediator.

        public void Configure(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Break"))
            {
                //Cuando se pulse el freno, informo al Mediator.
                _vehicle.BrakePressed();
            }
            else if (UnityEngine.Input.GetButtonUp("Break"))
            {
                _vehicle.BrakeReleased();
            }
        }

        
    }
}