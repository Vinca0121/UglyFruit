using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teleport_MF : MonoBehaviour
{
    public int index;
    int sceneTotalIndex = 2;
    bool playerin = false;
    public Text interTxt;

    private void Update()
    {
        if (!playerin) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Teleport(index);
        }
    }

    public void Teleport(int index)
    {
        SceneManager.LoadScene(index % (sceneTotalIndex - 1));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerin = true;
            interTxt.gameObject.SetActive(true);
            if (index == 0)
                interTxt.text = "F: 농장으로 이동";
            else if (index == 1)
                interTxt.text = "F: 박물관으로 이동";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerin = false;
            interTxt.gameObject.SetActive(false);
        }
    }
}
