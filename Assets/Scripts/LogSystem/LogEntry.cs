using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace LogSystem
{
    public class LogEntry : MonoBehaviour
    {
        public TextMeshProUGUI logText;
        public Image logBackground;

        public void OnEnable()
        {
            logBackground =  GetComponent<Image>();
        }

        public void SetLogText(string newLogText)
        {
            logText.text = newLogText;
        }
    }
}