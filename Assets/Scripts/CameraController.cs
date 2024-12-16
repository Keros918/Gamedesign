using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cam1;
    [SerializeField] private Transform cam2;
    [SerializeField] private Vector2 deadZoneSize = new Vector2(2f, 2f);
    [SerializeField] private float cameraFollowSpeed = 5f;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = cam1.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 cameraTargetPosition = player.position + offset;

        Vector2 playerToCamera = new Vector2(
            Mathf.Abs(cameraTargetPosition.x - cam1.position.x),
            Mathf.Abs(cameraTargetPosition.y - cam1.position.y)
        );

        if (playerToCamera.x > deadZoneSize.x || playerToCamera.y > deadZoneSize.y)
        {
            Vector3 position = Vector3.Lerp(
                cam1.position,
                cameraTargetPosition,
                Time.deltaTime * cameraFollowSpeed
            );

            cam1.position = position;
            cam2.position = position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(cam1.position, new Vector3(deadZoneSize.x * 2, deadZoneSize.y * 2, 0));
    }
}
