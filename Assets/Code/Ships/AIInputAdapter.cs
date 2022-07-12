using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : Input
    {
        private readonly Ship _ship;
        private int _currentDirectionX;
        public AIInputAdapter(Ship ship)
        {
            _ship = ship;
            _currentDirectionX = 1;//Inicialmente le dire que vaya hacia la derecha.
        }
        public Vector2 GetDirection()
        {
            var viewPortPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);
            if (viewPortPoint.x < 0.05f)
            {
                _currentDirectionX = 1;
            }
            else if (viewPortPoint.x > 0.95f)
            {
                _currentDirectionX = -1;
            }
            return new Vector2(_currentDirectionX, 0);
        }
    }

}

