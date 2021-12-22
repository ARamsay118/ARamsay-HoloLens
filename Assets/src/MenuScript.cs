using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using aramsay;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

namespace aramsay
{
    public class MenuScript : MonoBehaviour
    {
        private DirectoryInfo[] rcpDirs;
        private Interactable selectBtn;
        private GameObject[] rows;
        private GameObject menuPanel;
        private GameObject recipePanel;
        private static String[] rowNames = {"firstRow", "secondRow", "thirdRow"};

        private void Awake()
        {
            DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
            rcpDirs = dataDir.GetDirectories();

            Array.Sort(rcpDirs, delegate (DirectoryInfo d1, DirectoryInfo d2)
            {
                return d2.LastAccessTime.CompareTo(d1.LastAccessTime);
            });

            selectBtn = GameObject.Find("SelectRecipeBtn").GetComponent<Interactable>();
            rows = new GameObject[rowNames.Length];

            menuPanel = GameObject.Find("MenuPanel");
            recipePanel = GameObject.Find("RecipePanel");

            for (int i = 0; i < rowNames.Length; i++)
            {
                rows[i] = GameObject.Find(rowNames[i]);
                int x = i;
                rows[i].GetComponent<Interactable>().OnClick.AddListener(() => onClickRecipe(x));
            }
        }

        private void Start()
        {
            // Can't find inactive gameobject and its children.
            selectBtn.OnClick.AddListener(onClickSelect);
            menuPanel.SetActive(true);
            recipePanel.SetActive(false);
        }

        private void setRow(int i)
        {
            TextMeshPro content = rows[i].GetComponentInChildren<TextMeshPro>();
            string recipeName = rcpDirs[i].Name.Substring(rcpDirs[i].Name.LastIndexOf("\\") + 1);
            content.text = recipeName;
        }

        public void onClickSelect()
        {
            menuPanel.SetActive(false);
            recipePanel.SetActive(true);
            for (int i = 0; i < rcpDirs.Length; i++)
            {
                setRow(i);
            }
        }

        public void onClickRecipe(int idx)
        {
            stepButtons.startDisplay(rcpDirs[idx]);
        }
    }
}
