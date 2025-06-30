using System.Collections;
using System.Linq;
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
    [Space]
    [SerializeField]
    private int heroCount = 4;
    [SerializeField]
    private MovementManager heroPrefab;

    private MovementManager[] heros;
    private CameraMovement cameraMovement;

    private void Start()
    {
        cameraMovement = GetComponent<CameraMovement>();

        heros = new MovementManager[heroCount];
        for (int i = 0; i < heros.Length; i++)
        {
            heros[i] = Instantiate(heroPrefab);
            MovementData[] datas = MovementCreator.Create(distance, differenceDistance, time - i * (0.1f + Random.Range(0.01f, 0.1f)), differenceTime, pointCount);
            heros[i].Init(datas, material, (i - 2) * 1.5f);
        }
        cameraMovement.SetTargets(heros.Select(h => h.transform).ToArray());
    }

    public void Run()
    {
        for (int i = 0; i < heros.Length; i++)
        {
            StartCoroutine(heros[i].Running());
        }
    }
}
