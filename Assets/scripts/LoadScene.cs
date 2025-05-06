using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    private Button bt;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     bt = GetComponent<Button>();
        bt.onClick.AddListener(presionado);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void presionado()
    {
        SceneManager.LoadScene(1);
    }
}
