﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPresets : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPreset;
    [SerializeField]
    private Transform content;
    void Start()
    {
        ListTemplatesActions();
    }

    private void ListTemplatesActions()
    {
        ModelActions[] presets = GameManager.GetInstance().GetTemplates();
        int i = presets.Length;
        if (i > 0)
        {
            for (int x = 0; x < i; x++)
            {
                if (presets[x].actionType != ModelActions.ActionType.Challenger)
                {
                    GameObject go = Instantiate<GameObject>(buttonPreset, content);
                    go.GetComponent<Presets_Buttons>().presetID = x;
                    go.GetComponent<Presets_Buttons>().SetupButton(x);
                }
            }
        }
        else
        {
            Debug.Log("Precisa adicionar algum templete no Game manager");
        }
    }
}
