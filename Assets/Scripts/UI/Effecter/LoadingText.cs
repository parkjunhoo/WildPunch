using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    TextMeshProUGUI _text;
    string _originalText;
    int _count;

    bool _isActive;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _originalText = _text.text;
    }
    void Update()
    {
        if (_isActive) return;
        StartCoroutine(Active());
    }

    IEnumerator Active()
    {
        _isActive = true;

        yield return new WaitForSecondsRealtime(0.5f);

        _count++;
        if (_count <= 3)
        {
            _text.text = _text.text + ".";
        }
        else
        {
            _count = 0;
            _text.text = _originalText;
        }
        _isActive = false;
    }

}
