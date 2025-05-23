using UnityEngine;

public class PlayerMovement_boo : MonoBehaviour
{
    public float speed = 5f;

    float hAxis;
    float vAxis;
    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        // 이동
        transform.position += moveVec * speed * Time.deltaTime;

        // 걷기 애니메이션 상태 설정
        anim.SetBool("isWalk", moveVec != Vector3.zero);

        // 고개(몸통) 회전 처리
        if (moveVec != Vector3.zero)
        {
            transform.LookAt(transform.position + moveVec);
        }
    }
}
