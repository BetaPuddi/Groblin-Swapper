using LogSystem;
using UnityEngine;

namespace Managers
{
    public class LogManager : MonoBehaviour
    {
        public static LogManager instance;
        [SerializeField] private GameObject logPrefab;
        [SerializeField] private GameObject logPanel;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void InstantiateTextLog(string logText)
        {
            var newLogPrefab = Instantiate(logPrefab, logPanel.transform);
            var newLogEntry = newLogPrefab.GetComponent<LogEntry>();
            newLogEntry.SetLogText(logText);
            newLogEntry.logBackground.color = Color.cyan;
            newLogEntry.logBackground.color = new Color(newLogEntry.logBackground.color.r, newLogEntry.logBackground.color.g,  newLogEntry.logBackground.color.b, 0.1215686f);
        }

        public void InstantiateDamageLog(string attacker, string defender, float damage)
        {
            var newLogPrefab = Instantiate(logPrefab, logPanel.transform);
            var newLogEntry = newLogPrefab.GetComponent<LogEntry>();
            var text = $"{attacker} hits {defender} for {Mathf.RoundToInt(Mathf.Clamp(damage, 0, Mathf.Infinity))} damage!";
            newLogEntry.SetLogText(text);
            newLogEntry.logBackground.color = Color.red;
            newLogEntry.logBackground.color = new Color(newLogEntry.logBackground.color.r, newLogEntry.logBackground.color.g,  newLogEntry.logBackground.color.b, 0.1215686f);
        }

        public void InstantiateHealLog(string user, string target, float heal)
        {
            var newLogPrefab = Instantiate(logPrefab, logPanel.transform);
            var newLogEntry = newLogPrefab.GetComponent<LogEntry>();
            var text = $"{user} heals {target} for {Mathf.RoundToInt(Mathf.Clamp(heal, 0, Mathf.Infinity))}!";
            newLogEntry.SetLogText(text);
            newLogEntry.logBackground.color = Color.green;
            newLogEntry.logBackground.color = new Color(newLogEntry.logBackground.color.r, newLogEntry.logBackground.color.g,  newLogEntry.logBackground.color.b, 0.1215686f);
        }
    }
}
