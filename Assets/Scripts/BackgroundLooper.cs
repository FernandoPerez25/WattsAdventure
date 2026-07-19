using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float backgroundWidth = 64f;

    void Update()
    {
        float distance = transform.position.x - cameraTransform.position.x;

        if (distance < -backgroundWidth)
        {
            transform.position += new Vector3(
                backgroundWidth * 3,
                0,
                0
            );
        }
    }
}