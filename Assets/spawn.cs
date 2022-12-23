using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject FruitFactory1;
    public GameObject FruitFactory2;
    public GameObject FruitFactory3;
    public GameObject FruitFactory4;
    public GameObject FruitFactory5;
    public GameObject FruitFactory6;
    public GameObject FruitFactory7;
    // ÃÑ±¸
    public GameObject FruitPosition;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {

    }

    IEnumerator Spawn()
    {
        SpawnFruit();
        yield return new WaitForSeconds(15.0f);
    }

    void SpawnFruit()
    {
        GameObject b = Instantiate(FruitFactory1);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);

        b = Instantiate(FruitFactory2);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);

        b = Instantiate(FruitFactory3);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);

        b = Instantiate(FruitFactory4);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);

        b = Instantiate(FruitFactory5);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);

        b = Instantiate(FruitFactory6);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);

        b = Instantiate(FruitFactory7);
        b.transform.position = FruitPosition.transform.position;
        Destroy(b, 2);
    }
}
