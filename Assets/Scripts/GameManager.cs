using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float distance = 100;
    [SerializeField]
    private float differenceDistance = 5;
    [Space]
    [SerializeField]
    private float time = 20;
    [SerializeField]
    private float differenceTime = 1;
    [Space]
    [SerializeField]
    private int pointCount = 5;
    [SerializeField]
    private Material material;

    [SerializeField]
    private GameObject heroPrefab;

    private float[] subDistances;
    private float[] subTimes;
    private GameObject hero;

    private void Start()
    {
        MovementCreator creator = new MovementCreator();

        hero = Instantiate(heroPrefab);

        var tuple = creator.Create(distance, differenceDistance, time, differenceTime, pointCount);
        subDistances = tuple.Item1;
        subTimes = tuple.Item2;

        ShowPath();
    }

    public void Run()
    {
        MovementManager movement = GetComponent<MovementManager>();
        movement.DistanceChanged += delegate (object sender, MovementParametersArgs args)
        {
            hero.transform.position = new Vector3(args.Distance, 0, 0);
        };
        StartCoroutine(movement.Running(subDistances, subTimes));
    }

    private void ShowPath()
    {
        for (int i = 0; i < subDistances.Length - 1; i++)
        {
            var go = new GameObject("subLine" + i);
            go.transform.SetParent(transform);
            var lineRenderer = go.AddComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;
            var color = Random.ColorHSV();
            lineRenderer.material = material;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            lineRenderer.SetPosition(0, new Vector3(subDistances[i], 0, 0));
            lineRenderer.SetPosition(1, new Vector3(subDistances[i + 1], 0, 0));
        }
    }
}
