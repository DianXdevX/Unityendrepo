using UnityEngine;
using UnityEngine.EventSystems;

public class Basejogador : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void Start()
    { 
     rb = GetComponent<Rigidbody>();
        
    }

   public  void Update()
    {
        // Entrada de movimento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Aplica movimento com física
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
