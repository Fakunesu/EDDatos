using UnityEngine;

//Ejemplo de script que llama al Sort de SimpleList
public class SortCaller : MonoBehaviour
{
    //Tenemos una SimpleList de Transforms 
    SimpleList<Transform> transformList;

    //Un array de Transforms para cargar en la lista
    //(SimpleList no serializa bien)
    [SerializeField] Transform[] transforms;

    // Start is called before the first frame update
    void Start()
    {
        //Creamos una nueva lista vacia
        transformList = new SimpleList<Transform>();

        //Agregamos todos los transforms del array a la lista
        foreach (Transform t in transforms) 
        {
            transformList.Add(t);
        }

        //Llamamos al Sort de SimpleList (lo programan ustedes)
        //Le pasamos por parametro una funcion que cumpla con la firma de Comparison
        //(Que reciba dos T, y devuelva un int)
        transformList.Sort(CompareTransformX);

        //Printeamos la lista para testear que este ordenada
        for(int i = 0; i < transformList.Count; i++)
        {
            Debug.Log(transformList[i].gameObject.name);
        }
    }

    //Esta es nuestra funcion que va a hacer de Comparison<T>
    //Recibe por parametro dos datos del mismo tipo (en este caso Transform)
    //Con alguna logica o criterio nuestro, devuelve 1, -1 o 0
    //En este caso, el criterio es cual tiene la position en X mas grande
    int CompareTransformX(Transform t1, Transform t2)
    {
        if (t1.position.x > t2.position.x) return 1; //El primero es "mayor" al seugndo
        else if (t1.position.x < t2.position.x) return -1; //El primero es "menor" al segundo
        else return 0; //Los dos son iguales 
    }
}
