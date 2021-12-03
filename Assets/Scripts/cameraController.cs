using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(PixelPerfectCamera))]
public class CameraController : MonoBehaviour
{
    private enum Direction { Up, Down, Left, Right }

    [Header("Camera-Movement Settings:")]
    [SerializeField]private float velocity = 10f;
    [Range(0,0.5f)][SerializeField] private float panAreaPercent = 0.05f;

    [Header("Border Settings:")]
    [SerializeField] private MapBorderProvider borderProvider;

    private void Update()
    {
        Vector3 newPos = this.transform.position;

        if (Input.GetKey(KeyCode.W) || IsMouseNearBorder(Direction.Up))
        {
            newPos += Vector3.up * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || IsMouseNearBorder(Direction.Down))
        {
            newPos -= Vector3.up * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || IsMouseNearBorder(Direction.Left))
        {
            newPos += Vector3.left * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || IsMouseNearBorder(Direction.Right))
        {
            newPos -= Vector3.left * velocity * Time.deltaTime;
        }

        newPos.x = Mathf.Clamp(newPos.x, borderProvider.MinX, borderProvider.MaxX);
        newPos.y = Mathf.Clamp(newPos.y, borderProvider.MinY, borderProvider.MaxY);

        this.transform.position = newPos;
    }

    private bool IsMouseNearBorder(Direction direction)
    {
        Vector3 mousePos = Input.mousePosition;

        switch (direction)
        {
            case Direction.Up:
                return mousePos.y >= Screen.height * (1 - panAreaPercent);
            case Direction.Down:
                return mousePos.y <= Screen.height * panAreaPercent;
            case Direction.Left:
                return mousePos.x <= Screen.width * panAreaPercent;
            case Direction.Right:
                return mousePos.x >= Screen.width * (1 - panAreaPercent);
            default:
                return false;
        }
    }
}
