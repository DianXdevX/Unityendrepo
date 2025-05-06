using UnityEngine;
using UnityEngine.UI;

public class selecttoy : MonoBehaviour
{
    private Button bt;
   [SerializeField] public  static int SelectPlayer;
  [SerializeField]  private int valorp;
    public GameObject UiInicial;
    private DataConstance dt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bt = GetComponent<Button>();
        bt.onClick.AddListener(() => PLAYERMODEL(valorp));
       dt = DataConstance.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PLAYERMODEL(int x) {
        SelectPlayer = x;
        dt.player = SelectPlayer;
        UiInicial.SetActive(false);
    }
}
