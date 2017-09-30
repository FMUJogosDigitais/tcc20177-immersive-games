﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChangeSceneButton : MonoBehaviour {

    private LoadSceneManager loadSceneManager;

    private void OnEnable()
    {
        SetInitialReferences();
    }
    void SetInitialReferences()
    {
        try
        {
            loadSceneManager = FindObjectOfType<LoadSceneManager>();
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            loadSceneManager = null;
        }
    }
    public void ChangeScene(int nScene)
    {
        if (loadSceneManager != null)
        {
            loadSceneManager.LoadScene(nScene);
        }
    }
}
