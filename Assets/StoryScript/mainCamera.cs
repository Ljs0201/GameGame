using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (예: 플레이어)

    // 이동 제한 값 (인스펙터 창에서 수정 가능)
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            // 1. 목표의 현재 위치를 가져옴
            float targetX = target.position.x;
            float targetY = target.position.y;

            // 2. Mathf.Clamp를 이용해 범위를 제한
            // Mathf.Clamp(현재값, 최소값, 최대값)
            float clampedX = Mathf.Clamp(targetX, minX, maxX);
            float clampedY = Mathf.Clamp(targetY, minY, maxY);

            // 3. 제한된 좌표를 카메라 위치에 적용 (Z축은 카메라 고유의 값 유지)
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}