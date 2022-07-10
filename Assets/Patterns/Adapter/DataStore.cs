namespace Patterns.Adapter
{
    public interface DataStore
    {
        //Metodo para Guardar los datos
        void SetData<T>(T data, string name);
        //Metodo para obtener los datos.
        T GetData<T>(string name);

    }
}