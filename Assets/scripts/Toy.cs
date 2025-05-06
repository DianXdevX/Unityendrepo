using UnityEngine;

public class Toy : Basejogador
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
        if (dt != null && dt.player == 1)
        {
            base.Update();

            // Pular com espaço
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            // Rotacionar para a direção do movimento
            Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (moveDir.magnitude > 0.1f)
            {
                Quaternion newRot = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * 10f);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Detecta se tocou no chão para poder pular novamente
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}


