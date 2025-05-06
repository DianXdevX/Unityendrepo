using UnityEngine;

public class Car : Basejogador
{
    private int dataPlayer;
    private DataConstance dt;
    private Rigidbody rb;

    public float acceleration = 10f;
    public float turnSpeed = 100f;

    private float moveInput;
    private float turnInput;

    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();

        if (DataConstance.Instance == null)
        {
            Debug.LogError("DataConstance não foi encontrado! Certifique-se de que o objeto com o componente DataConstance esteja na cena.");
            return;
        }

        dt = DataConstance.Instance;
    }

    new void Update()
    {
        if (dt != null && dt.player == 2)
        {
            // Captura entrada apenas se for o jogador 2
            moveInput = Input.GetAxis("Vertical");    // Frente/trás
            turnInput = Input.GetAxis("Horizontal");  // Direita/esquerda
        }
    }

    void FixedUpdate()
    {
        if (dt != null && dt.player == 2)
        {
            // Move o carro para frente/trás
            Vector3 move = transform.forward * moveInput * acceleration * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            // Rotaciona o carro com base na entrada horizontal
            float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}






