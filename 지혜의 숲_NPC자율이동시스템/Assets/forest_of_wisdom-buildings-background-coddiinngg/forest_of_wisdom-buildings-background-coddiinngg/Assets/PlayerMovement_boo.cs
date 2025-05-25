using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        // 애니메이터 변수 설정
        animator.SetBool("isWalking", movement.magnitude > 0);

        // 실제 움직임 적용
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}
