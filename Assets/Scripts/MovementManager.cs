using System.Collections;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private readonly Movement movement;
    private Animator animator;
    private MovementData[] datas;
    private Material material;
    private Vector3 startPosition;

    public MovementManager()
    {
        movement = new Movement(MovementTimer.Instance);
    }

    public void Init(MovementData[] datas, Material material, float y)
    {
        this.datas = datas;
        this.material = material;
        startPosition = new Vector3(startPosition.x, startPosition.y + y, startPosition.z);
        transform.position = startPosition;
        ShowPath();
    }

    public IEnumerator Running()
    {
        animator.SetBool("Run", true);
        return movement.Running(datas);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        movement.DistanceChanged += MovementDistanceChanged;
    }

    private void OnDisable()
    {
        movement.DistanceChanged -= MovementDistanceChanged;
    }

    private void ShowPath()
    {
        for (int i = 0; i < datas.Length - 1; i++)
        {
            var go = new GameObject("subLine" + i);
            var lineRenderer = go.AddComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;
            var color = Random.ColorHSV();
            lineRenderer.material = material;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            lineRenderer.SetPosition(0, new Vector3(datas[i].Distance, -0.7f + startPosition.y, 0));
            lineRenderer.SetPosition(1, new Vector3(datas[i + 1].Distance, -0.7f + startPosition.y, 0));
        }
    }

    private void MovementDistanceChanged(object sender, MovementParametersArgs args)
    {
        transform.position = new Vector3(args.Distance, startPosition.y, startPosition.z);
    }
}
