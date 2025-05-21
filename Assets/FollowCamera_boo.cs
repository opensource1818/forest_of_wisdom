using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (Boo)
    public Vector3 offset = new Vector3(2, 3, -5); // Boo의 오른쪽 뒤 위에서 보기
    public float smoothSpeed = 0.1f;

    void LateUpdate()
    {
        if (target == null) return;

        // Boo의 회전을 반영한 로컬 offset 적용
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // 부드럽게 따라가기
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Boo를 바라보게
        transform.LookAt(target.position + Vector3.up * 1.5f); // Boo 머리 위를 바라보도록
    }
}
