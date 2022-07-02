using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSImposter : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    private void Start()
    {
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText()
    {
        var second = new WaitForSeconds(1f);
        while (true)
        {
            _text.text = $"FPS: {Random.Range(60, 90)}";
            yield return second;
        }
    }
}
