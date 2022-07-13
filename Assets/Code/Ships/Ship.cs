using UnityEngine;
using System;
using Ships.Weapons;
using Ships.CheckLimits;
using Object = UnityEngine.Object;


namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField]private float _fireRateInSeconds;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnPosition;
        
        private Input.Input _input; // Creo una variable que almacena el boton de la UI.    
        //Ahora, cambio la variable de tipo joystick, a Input.
        private Transform _myTransform;
        private CheckLimits.CheckLimits _checkLimits;
        private float _remainingSecondsToBeAbleToShoot;


        private void Awake()
        {
            _myTransform = transform;
        }
        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            //Diremos TryShoot, porque no disparara siempre. Sera un intento.
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }
            else
            {
                if (_input.IsFireActionPressed())
                {
                    Shoot();
                    
                }
            }
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(_projectilePrefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation); //Para determinar la direccion, voy a Unity y creo un child para manejar esto.

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

