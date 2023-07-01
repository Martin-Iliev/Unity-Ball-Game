using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI playerSize;
    [SerializeField] 
    TextMeshProUGUI wallText;

    public void DisplayText(string message)
    {
        playerSize.text = message;
    }

    public void DisplayTextTimer(string message, float duration)
    {
        wallText.text = message;
        wallText.enabled = true;

        StartCoroutine(HideTextAfterDelay(duration));
    }

    public IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        wallText.enabled = false;
    }
}
