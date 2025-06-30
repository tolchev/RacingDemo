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
    private int heroCount = 4;

    [SerializeField]
    private MovementManager heroPrefab;

    private MovementManager[] heros;

    private void Start()
    {
        heros = new MovementManager[heroCount];
        for (int i = 0; i < heros.Length; i++)
        {
            heros[i] = Instantiate(heroPrefab);
            MovementData[] datas = MovementCreator.Create(distance, differenceDistance, time, differenceTime, pointCount);
            heros[i].Init(datas, material, i * 1.5f);
        }
    }

    public void Run()
    {
        for (int i = 0; i < heros.Length; i++)
        {
            StartCoroutine(heros[i].Running());
        }
    }
}
