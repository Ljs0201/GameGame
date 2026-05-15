using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rb;

    private float moveInput;
    private float finalSpeed;

    public float speed = 5f;
    public float speedMultiplier = 8f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        if (moveInput < 0)
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
        else if (moveInput > 0)
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            finalSpeed = speedMultiplier;
        }
        else
        {
            finalSpeed = speed;
        }

    }
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * finalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }
    }

}