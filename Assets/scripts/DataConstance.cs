using UnityEngine;


public class DataConstance : MonoBehaviour
{
    public static DataConstance Instance;  // A instância global
    public int player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persiste entre cenas (opcional)
        }
        else if (Instance != this)
        {
            Destroy(gameObject);  // Evita múltiplas instâncias
        }
    }
}
