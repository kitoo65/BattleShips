using UnityEngine;
namespace Patterns.Adapter
{
    //3, creamos un consumidor, para nuestra prueba.
    public class Consumer : MonoBehaviour
    {
        //3 El consumidor, busca los datos, se crea una "data" a guardar, 
        //Y luego al recibir con el SetData, se serializa en un JSOn, 
        //Y el json se transforma en un archivo.
        private void Awake()
        {
            var fileDataStoreAdapter = new FileDataStoreAdapter();
            var data = new Data("Dato 1", 123);
            fileDataStoreAdapter.SetData(data, "Data1");

        }
    }
}