using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    [SerializeField] private Vector2 xRotationSpeedRange = new Vector2(-100f, 100f);
    [SerializeField] private Vector2 yRotationSpeedRange = new Vector2(-100f, 100f);
    [SerializeField] private Vector2 zRotationSpeedRange = new Vector2(-100f, 100f);

    private Vector3 rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRotationSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply the rotation
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void InitializeRotationSpeed()
    {
        rotationSpeed = new Vector3(
            Random.Range(xRotationSpeedRange.x, xRotationSpeedRange.y),
            Random.Range(yRotationSpeedRange.x, yRotationSpeedRange.y),
            Random.Range(zRotationSpeedRange.x, zRotationSpeedRange.y)
        );
    }

    // Call this method to re-randomize rotation speed if needed
    public void ResetRotationSpeed()
    {
        InitializeRotationSpeed();
    }
}