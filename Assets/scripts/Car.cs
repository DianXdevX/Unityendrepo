
using UnityEngine;

public class Car : Basejogador
{
    private int dataPlayer;
    private DataConstance dt;

    new void Start()
    {
        base.Start();
        // Inicializa dt (supondo que seja um Singleton)
        if (DataConstance.Instance == null)
        {
            Debug.LogError("DataConstance não foi encontrado! Certifique-se de que o objeto com o componente DataConstance esteja na cena.");
            return;  
        }

        dt = DataConstance.Instance;  
    }

    new void Update()
    {
        
        if (dt != null)
        {
            dataPlayer = dt.player;  

            
            if (dataPlayer == 2)
            {
                base.Update();  
            }
        }
        else
        {
            Debug.LogWarning("DataConstance não foi inicializado corretamente.");
        }
    }
}





