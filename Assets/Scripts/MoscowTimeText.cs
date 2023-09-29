using TMPro;
using UnityEngine;

public class MoscowTimeText : MonoBehaviour
{
    [SerializeField] private TimeController timeController;

    private TextMeshProUGUI moscowTimeText;

    private void Awake()
    {
        moscowTimeText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        timeController.OnMoscowTimeUpdated += TimeController_OnMoscowTimeUpdated;
    }

    private void TimeController_OnMoscowTimeUpdated(string moscowTime)
    {
        moscowTimeText.text = moscowTime;
    }
}
