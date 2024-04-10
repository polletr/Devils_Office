using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class LoadingManager : MonoBehaviour
{

    [SerializeField]
    private Image loaderImageUI;

    float timer = 0f;
    bool holdToSkip = false;
    [SerializeField]
    float skipMultiplier = 8f;

    [SerializeField]
    float storyTimer = 30f;

    [SerializeField]
    List<GameObject> pages = new();

    int nPages;


    private void Awake()
    {
        //AudioManager.Instance.PlayUI(AudioManager.Instance._audioClip.welcomeToHell);
        pages[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            holdToSkip = true;
        }
        else
        {
            holdToSkip = false;
        }

        LoadingBar(timer, storyTimer);

        if (!holdToSkip)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer += skipMultiplier * Time.deltaTime;
        }


        if (timer > storyTimer && pages.Count > nPages)
        {
            //Next UI
            pages[nPages].SetActive(false);
            pages[nPages + 1].SetActive(true);
            nPages++;
            timer = 0f;
        }
        else if (timer > storyTimer && pages.Count == nPages)
        {
            //Load Game Scene
        }

    }

    private void LoadingBar(float indicator, float maxIndicator)
    {
        loaderImageUI.fillAmount = indicator / maxIndicator;
    }



}
