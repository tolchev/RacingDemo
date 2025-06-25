using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject heroPrefab;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        lineRenderer.SetPosition(0, new Vector3(100, 0, 0));
    }
}
