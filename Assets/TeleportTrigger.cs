using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                // CharacterController로 순간이동할 땐 Move 대신 직접 위치 설정
                cc.enabled = false;
                other.transform.position = teleportTarget.position;
                cc.enabled = true;
            }
        }
    }
}
