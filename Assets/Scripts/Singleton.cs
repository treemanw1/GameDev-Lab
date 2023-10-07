using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        get
        {
            return _instance;
        }
    }
    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            // Debug.Log("Awake!");
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("Destroyed!");
            Destroy(gameObject);
        }
    }
}