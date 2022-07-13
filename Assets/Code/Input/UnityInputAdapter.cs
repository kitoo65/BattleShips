﻿using UnityEngine;

namespace Input
{
    public class UnityInputAdapter : Input
    {
        
        public Vector2 GetDirection()
        {
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
            var vertical = UnityEngine.Input.GetAxis("Vertical");
            return new Vector2(horizontal,vertical);
        }

        public bool IsFireActionPressed()
        {
            return UnityEngine.Input.GetButton("Fire1");
            //Disparo con la barra espaciadora y el click.
        }
    }
}
