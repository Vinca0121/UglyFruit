using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFruit : MonoBehaviour
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

    float currTime;
    public int result;
    public float time;
    void Start()
    {
        result = 0;
    }        

    void Update()
    {


        currTime += Time.deltaTime;
        if (currTime > time)
        {
            result = result + 1;
            if (result == 1)
            {
                GameObject b = Instantiate(FruitFactory1);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
            }
            else if(result == 2)
            {
                GameObject b = Instantiate(FruitFactory2);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
            }
            else if (result == 3)
            {
                GameObject b = Instantiate(FruitFactory3);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
            }
            else if (result == 4)
            {
                GameObject b = Instantiate(FruitFactory4);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
            }
            else if (result == 5)
            {
                GameObject b = Instantiate(FruitFactory5);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
            }
            else if (result == 6)
            {
                GameObject b = Instantiate(FruitFactory6);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
            }
            else if (result == 7)
            {
                GameObject b = Instantiate(FruitFactory7);
                b.transform.position = FruitPosition.transform.position;
                Destroy(b, time);
                result = 0;
            }


            currTime = 0;

        }



    }


    
}
