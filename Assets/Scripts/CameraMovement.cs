using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;

    private Transform[] targets;

    public void SetTargets(Transform[] targets)
    {
        this.targets = targets;
    }

    void Update()
    {
        var position = targetCamera.transform.position;
        targetCamera.transform.position = new Vector3(targets.Select(t => t.position.x).Average(), position.y, position.z);
    }
}
