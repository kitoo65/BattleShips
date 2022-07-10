using System;
namespace Patterns.Adapter
{
    [Serializable]
    public class Data
    {
        public string Dato1;
        public int Dato2;
        //Constructor:
        public Data(string dato1, int dato2)
        {
            Dato1 = dato1;
            Dato2 = dato2;
        }
    }// Luego, creamos una clase para testear lo que vamos a guardar.   2
}