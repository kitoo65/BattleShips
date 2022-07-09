using UnityEngine;
using System;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
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

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoint.x = Math.Clamp(viewportPoint.x, 0.03f, 0.97f); // Dejo un 3% de margen.
            viewportPoint.y = Math.Clamp(viewportPoint.y, 0.03f, 0.97f);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {
            var horizontalDir = Input.GetAxis("Horizontal");
            var verticalDir = Input.GetAxis("Vertical");
            return new Vector2(horizontalDir,verticalDir);
        }

    }

}

