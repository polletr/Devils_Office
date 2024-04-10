using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingManager : MonoBehaviour
{
    InputControls action;


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

        LoadingBar(timer, storyTimer);

        if (!holdToSkip)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer += skipMultiplier * Time.deltaTime;
        }


        if (timer > storyTimer && pages.Count - 1 > nPages)
        {
            Debug.Log(pages.Count);
            //Next UI
            pages[nPages].SetActive(false);
            pages[nPages + 1].SetActive(true);
            nPages++;
            timer = 0f;
        }
        else if (timer > storyTimer && pages.Count - 1 == nPages)
        {
            SceneManager.LoadScene(2);
        }

    }

    private void Skip(bool skip)
    {
        holdToSkip = skip;
    }


    private void LoadingBar(float indicator, float maxIndicator)
    {
        loaderImageUI.fillAmount = indicator / maxIndicator;
    }

    private void OnEnable()
    {

        action = new InputControls();
        action.KeyboardLeft.Move.performed += (val) => Skip(true);
        action.KeyboardLeft.Move.canceled += (val) => Skip(false);

        action.KeyboardRight.Move.performed += (val) => Skip(true);
        action.KeyboardRight.Move.canceled += (val) => Skip(false);

        action.GamePad.Move.performed += (val) => Skip(true);
        action.GamePad.Move.canceled += (val) => Skip(false);

        action.Enable();
        return;

    }



}
