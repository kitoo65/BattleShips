using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel : MonoBehaviour
    {
        //Un error que puede ocurrir en esta clase, es que si luego yo quiero cambiar
        //Un comportamiento en las wheels,tooodo lo que yo esté relacionando acá en el código
        //Lo voy a tener que modificar, porque recae muchas responsabilidades en la clase wheel.
        //Para ello, creo la clase mediator, la cual se encargará de toodo lo que mencionamos anteriormente.
        public void AddFriction()
        {
            
        }

        public void RemoveFriction()
        {
            
        }

        public void TurnLeft()
        {
            
        }

        public void TurnRight()
        {
             
        }
    }
}