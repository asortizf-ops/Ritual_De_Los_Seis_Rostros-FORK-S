using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

  void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            // Le decimos al Animator en qué dirección nos movemos
            anim.SetFloat("DirX", movement.x);
            anim.SetFloat("DirY", movement.y);
            anim.SetBool("Caminando", true);

            // LA MEMORIA: Guardamos la última dirección a la que miró antes de soltar la tecla
            anim.SetFloat("LastDirX", movement.x);
            anim.SetFloat("LastDirY", movement.y);
        }
        else
        {
            anim.SetBool("Caminando", false);
        }
    }

    void FixedUpdate()
    {
        // 3. Aplicamos el movimiento físico. 
        // .normalized evita que el arqueólogo corra más rápido en diagonal
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}