using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using aramsay;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

namespace aramsay
{
    public class stepButtons : MonoBehaviour
    {
        private static int stepIdx;
        private static List<String> stepList;
        private static DirectoryInfo rcpDir;
        private static Dictionary<string, GameObject> gos;

        private void Awake()
        {
            if (gos.Count == 0)
            {
                gos.Add("instText", GameObject.Find("instText"));
                gos.Add("stepTitle", GameObject.Find("stepTitle"));
            }
            stepIdx = 0;
            leftMost();
        }

        private static void loadParseStep()
        {
            string recipePath = String.Format("{0}\\stepList.txt", rcpDir.FullName);
            foreach (string line in File.ReadLines(recipePath))
            {
                stepList.Add(line);
            }
        }

        static stepButtons()
        {
            stepList = new List<string>();
            rcpDir = null;
            gos = new Dictionary<string, GameObject>();
        }

        public static void startDisplay(DirectoryInfo rd)
        {
            gos.Clear();
            stepList.Clear();
            rcpDir = rd;
            loadParseStep();
            SceneManager.LoadScene("InstructionScene");
        }

        private TextMeshPro getTMP(string name)
        {
            GameObject instText = gos[name];
            return instText.GetComponentInChildren<TextMeshPro>();
        }

        private void setTMP(string inst, string component)
        {
            TextMeshPro instText = getTMP(component);
            if (instText)
            {
                instText.text = inst;
            }
            else
            {
                instText.text = "ERROR: cannot find instruction text component";
            }
        }

        private void leftMost()
        {
            setTMP(rcpDir.Name.Substring(rcpDir.Name.LastIndexOf("\\") + 1), "stepTitle");
            setTMP(
                "<b><i>Let's Get Started!</i></b>",
                "instText"
            );
            stepIdx = 0;
        }

        private void rightMost()
        {
            setTMP("CONGRATULATIONS!", "stepTitle");
            setTMP(
                "<b><i>Well done!</i></b>",
                "instText"
            );
            stepIdx = stepList.Count + 1;
        }

        public void onClickLeft()
        {
            stepIdx--;
            if (stepIdx <= 0)
            {
                leftMost();
            }
            else
            {
                string inst = stepList[stepIdx - 1];
                setTMP(String.Format("Step {0}/{1}", stepIdx, stepList.Count), "stepTitle");
                setTMP(inst, "instText");
            }
        }

        public void onClickRight()
        {
            if (stepIdx >= stepList.Count)
            {
                rightMost();
            }
            else
            {
                setTMP(stepList[stepIdx++], "instText");
                setTMP(String.Format("Step {0}/{1}", stepIdx, stepList.Count), "stepTitle");
            }
        }

        public void onClickHome()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
