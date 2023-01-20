using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{

    [SerializeField] private bool activarDontDestroy;
    private static T _instancia;
    public static T Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = FindObjectOfType<T>();
                if (_instancia == null)
                {
                    GameObject nuevoGO = new GameObject();
                    _instancia = nuevoGO.AddComponent<T>();
                }
            }

            return _instancia;
        }
    }

    protected virtual void Awake()
    {
        if (activarDontDestroy)
        {
            if (_instancia == null)
            {
                _instancia = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            _instancia = this as T;
        }
    }
}
