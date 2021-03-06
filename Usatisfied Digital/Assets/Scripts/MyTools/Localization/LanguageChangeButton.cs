﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.Localization
{
    [RequireComponent(typeof(Button))]
    public class LanguageChangeButton : MonoBehaviour
    {
        public Image iconFlag;
        public LocalizationManager.Languages languages;
        private LocalizationManager localizeManager;
        private string textLocalize;
        private void OnEnable()
        {
            SetInitialReferences();
            localizeManager.OnChangeLanguage += OnChangeLanguage;
        }
        private void OnDisable()
        {
            localizeManager.OnChangeLanguage -= OnChangeLanguage;
        }
        private void SetInitialReferences()
        {
            localizeManager = FindObjectOfType<LocalizationManager>();
        }
        private void Awake()
        {
            if (GetComponentInChildren<Text>())
                textLocalize = GetComponentInChildren<Text>().text;
        }
        void Start()
        {
            textLocalize = LocalizationManager.GetLanguageName(languages);
            OnChangeLanguage(localizeManager);
            Button btn = GetComponent<Button>();
            btn.name = languages.ToString();
            btn.GetComponentInChildren<Text>().text = LocalizationManager.GetLanguageName(languages);
            iconFlag.sprite = LocalizationManager.GetLanguageFlag(languages);
            btn.onClick.AddListener(() => localizeManager.ChangeLanguage(languages));
        }
        void OnChangeLanguage(LocalizationManager lang)
        {
            if (GetComponentInChildren<Text>())
                GetComponentInChildren<Text>().text = LocalizationManager.GetText(textLocalize);
        }
        public void SetInitialText(string text)
        {
            textLocalize = text;
        }
    }
}