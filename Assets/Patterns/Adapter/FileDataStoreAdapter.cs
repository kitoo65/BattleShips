﻿using UnityEngine;
using System.IO;
namespace Patterns.Adapter
{
    // SE crea una clase, y se extrae en un nuevo script. 2
    //Creamos una implementacion de la interfaz.   1
    public class FileDataStoreAdapter : DataStore
    {
        //Para SetData, creare un fichero con un nombre, y se serializaran los datos a JSON. 
        //Luego los guardo en el fichero.
        public void SetData<T>(T data, string name)
        {
            var json = JsonUtility.ToJson(data);
            //dataPath, es la carpeta Assets. 
            var path = Path.Combine(Application.dataPath, name);

            File.WriteAllText(path, json);
        }
        //En el GetData, busco un fichero con un nombre, convertire a json, luego a mi clase.
        public T GetData<T>(string name)
        {
            //4 . Luego yo nuevamente busco el archivo, lo convierto a json, y lo devuelvo.
            //Ir al consumer. 4
            var path = Path.Combine(Application.dataPath, name);
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);

        }

      
    }
}