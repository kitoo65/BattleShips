using UnityEngine;
using System;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick; // Creo una variable que almacena el boton de la UI.    
        private Transform _myTransform;
        private Camera _camera;

        private void Awake()
        {
            _myTransform = transform;
            _camera = Camera.main;
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
            ClampFinalPosition();
        }
        //Que problemas presenta esta solucion? Funciona bien. Pero si mañana, en vez de querer movernos con el axis
        //Queremos movernos pulsando la pantalla.... Esta solucion, no valdria porque tenemos que cambiar el GetDirection, 
        //Para utilizar los inputs de la pantalla. 
        //O, por ejemplo que el GetDirection lo lea una inteligencia artificial.
        //Puedo poner ifs, para hacer la implementacion, puedo duplicar los metodos para cada input, etc.
        //Existe un patron: Patron Adapter.

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoint.x = Math.Clamp(viewportPoint.x, 0.03f, 0.97f); // Dejo un 3% de margen.
            viewportPoint.y = Math.Clamp(viewportPoint.y, 0.03f, 0.97f);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {

            return new Vector2(_joystick.Horizontal,_joystick.Vertical); // Aqui, se anulan los inputs del teclado y anda solo con la UI.
            //Acordarse tmb de referenciar la variable de tipo joystick en el editor.
            var horizontalDir = Input.GetAxis("Horizontal");
            var verticalDir = Input.GetAxis("Vertical");
            return new Vector2(horizontalDir,verticalDir);
        }
        //DESVENTAJAS:
        //No puedo jugar en PC. Tengo que ver si utilizo ifs, u optar de aplicar el patron adapter.

    }

}

