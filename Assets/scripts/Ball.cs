using UnityEngine;

public class Ball : Basejogador
{
    private int dataPlayer;
    private DataConstance dt;
    private Rigidbody rb;

    public float jumpForce = 5f;
    private bool isGrounded;

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
        if (dt != null && dt.player == 3)
        {
            base.Update();

            // Pular com espaço
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (dt != null && dt.player == 3)
        {
            // Adiciona rotação baseada no movimento
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (move != Vector3.zero)
            {
                Vector3 torque = new Vector3(move.z, 0, -move.x) * 10f;
                rb.AddTorque(torque);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta quando a bola toca o chão
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}

