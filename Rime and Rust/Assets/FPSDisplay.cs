using TMPro;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = $"{1/Time.deltaTime}";
    }
}
