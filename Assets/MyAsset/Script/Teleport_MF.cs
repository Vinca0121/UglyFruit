using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teleport_MF : MonoBehaviour
{
    public int index;
    bool playerin = false;
    public Text interTxt;

    private void Update()
    {
        if (!playerin) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (index == 0)
                Teleport_F();
            else if (index == 1)
                Teleport_M();
        }
    }

    public void Teleport_M()
    {
        SceneManager.LoadScene(0);
    }

    public void Teleport_F()
    {
        SceneManager.LoadScene(1);
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
