using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using System;

namespace aramsay
{
    public class TimerScript : MonoBehaviour
    {
        private GameObject secText;
        private GameObject minText;
        private GameObject hourText;
        private GameObject curFunc;
        private GameObject onoffBtn;
        private GameObject clearBtn;

        private void Awake()
        {
            secText = GameObject.Find("secText");
            minText = GameObject.Find("minText");
            hourText = GameObject.Find("hourText");
            curFunc = GameObject.Find("curFunc");

            onoffBtn = GameObject.Find("OnOffBtn");
            clearBtn = GameObject.Find("ClearBtn");
        }

        void Start()
        {
            onoffBtn.GetComponent<Interactable>().OnClick.AddListener(onClickOnOff);
            clearBtn.GetComponent<Interactable>().OnClick.AddListener(onClickClear);
        }

        void onClickOnOff()
        {
            TextMeshPro curFuncText = curFunc.GetComponentInChildren<TextMeshPro>();
            if (curFuncText.text == "START")
            {
                InvokeRepeating("addOneSec", 0, 1.0f);
                curFuncText.text = "STOP";
            }
            else
            {
                CancelInvoke();
                curFuncText.text = "START";
            }
        }

        void setText(GameObject go, string time)
        {
            go.GetComponentInChildren<TextMeshPro>().text = time;
        }

        TextMeshPro getText(GameObject go)
        {
            return go.GetComponentInChildren<TextMeshPro>();
        }

        void onClickClear()
        {
            Debug.Log("clicked.");
            setText(secText, "00");
            setText(minText, "00:");
            setText(hourText, "00:");
        }

        void addOneMin()
        {
            int curMin = Int32.Parse(getText(minText).text.Substring(0, 2));
            if (curMin == 59)
            {
                addOneHour();
                setText(minText, "00");
            }
            else
            {
                curMin++;
                setText(minText, String.Format("{0}:", curMin.ToString("00")));
            }
        }

        void addOneHour()
        {
            int curHour = Int32.Parse(getText(hourText).text.Substring(0, 2));
            if (curHour == 23)
            {
                setText(hourText, "00");
            }
            else
            {
                curHour++;
                setText(hourText, String.Format("{0}:", curHour.ToString("00")));
            }
        }

        void addOneSec()
        {
            int curSec = Int32.Parse(getText(secText).text);
            if (curSec == 59)
            {
                addOneMin();
                setText(secText, "00");
            }
            else
            {
                curSec++;
                setText(secText, curSec.ToString("00"));
            }
        }
    }
}
