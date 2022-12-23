using EvolveGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestFarm : MonoBehaviour
{
    [SerializeField] int portalIndex = 0;
    [SerializeField] float growTime = 30f;
    [SerializeField] Text interText;
    [SerializeField] Text growText;
    public GameObject[] plantObj;
    bool inTriggerPlayer = false;
    int isGrowing = 0;
    PlayerController pc;
    public GameObject sparkEffect;
    public GameObject paticlepos;
    GameObject spakling;
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.AddTextFunc();
    }

    void Update()
    {
        if (!inTriggerPlayer) return;
        if (isGrowing == 1) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(portalIndex == 0)
            {
                StartCoroutine(nameof(StartPortal_0));
            }
            else if(portalIndex == 1)
            {
                if(isGrowing == 0)
                    StartCoroutine(nameof(StartPortal_1));
                else if(isGrowing == 2)
                    StartCoroutine(nameof(ClearPortal_1));
            }
        }

    }

    IEnumerator StartPortal_0()
    {
        Debug.Log("���� ȹ�� ����");
        pc.seedCount++;
        growText.text = "���� ȹ�� ����";
        yield return null;
    }

    IEnumerator StartPortal_1()
    {
        if (pc.seedCount == 0)
        {
            growText.text = "���� ����";
            yield break;
        }

        Debug.Log("��� ����");
        pc.seedCount--;
        isGrowing = 1;
        interText.gameObject.SetActive(false);
        spakling = Instantiate(sparkEffect, paticlepos.transform.position, Quaternion.identity) as GameObject;
        Destroy(spakling, 2f);

        growText.text = "�ڶ�� ��...";

        GrowPlantActive(0);

        float time = 0f;
        bool isOne = false;

        while (time <= growTime)
        {
            time += Time.deltaTime;

            if (Mathf.Round(time) == (Mathf.Round(growTime / 2) + 1f) && !isOne)
            {
                GrowPlantActive(1);
                spakling = Instantiate(sparkEffect, paticlepos.transform.position, Quaternion.identity) as GameObject;
                isOne = true;

            }
            Destroy(spakling, 2f);

            yield return null;
        }

        GrowPlantActive(2);
        isGrowing = 2;
        growText.text = "�Ϸ�";
        spakling = Instantiate(sparkEffect, paticlepos.transform.position, Quaternion.identity) as GameObject;
        Destroy(spakling, 2f);
        Debug.Log("��� ��");
    }

    void GrowPlantActive(int index)
    {
        for(int i = 0; i < plantObj.Length; i++)
        {
            if (i == index)
                plantObj[i].SetActive(true);
            else
                plantObj[i].SetActive(false);
        }
    }

    IEnumerator ClearPortal_1()
    {
        interText.gameObject.SetActive(false);
        GrowPlantActive(1000);

        float random = Random.Range(0f, 1f);
        Debug.Log("Random: " + random);

        if (random < 0.5)
        {
            growText.text = "������ ä�� ȹ��";
            pc.uglyCount++;
        }
        else
        {
            growText.text = "���� ä�� ȹ��";
            pc.goodCount++;
        }

        pc.AddTextFunc();
        isGrowing = 0;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(portalIndex == 0)
            {
                interText.text = "F: ���� ����";
            }
            else if (portalIndex == 1)
            {
                if(isGrowing == 0) 
                    interText.text = "F: ���۹� �ɱ�";
                else if(isGrowing == 1)
                    interText.text = "F: �ڶ�� ��...";
                else if(isGrowing == 2)
                    interText.text = "F: ��Ȯ�ϱ�";
            }

            inTriggerPlayer = true;
            interText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTriggerPlayer = false;
            interText.gameObject.SetActive(false);
        }
    }

}
