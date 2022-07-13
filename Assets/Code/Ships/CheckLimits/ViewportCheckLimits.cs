using System;
using UnityEngine;

namespace Ships.CheckLimits
{
    public class ViewportCheckLimits : CheckLimits
    {
        //Aqui yo creo esta estrategia, para poder determinar que se pueda mover entre los limites.

        private readonly Transform _transform;
        private readonly Camera _camera;

        //Constructor.
        public ViewportCheckLimits(Transform Transform, Camera camera)
        {
            _transform = Transform;
            _camera = camera;

        }
        //Esta es la estrategia en si. Ahora tengo que ir a la clase Ship, y hacer referencia a la interfaz.
        public void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);
            viewportPoint.x = Math.Clamp(viewportPoint.x, 0.03f, 0.97f); // Dejo un 3% de margen.
            viewportPoint.y = Math.Clamp(viewportPoint.y, 0.03f, 0.97f);
            _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}
