using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    [SerializeField] private TMP_Text _warningText;
    [SerializeField] private Image _warningImage;

    [SerializeField] private float _fadeSpeed = .01f;
    [SerializeField] private float _timeToWaitForText = 3f;


    private void Start()
    {
        StartCoroutine(FadeInTime());
    }

    IEnumerator FadeInTime()
    {
        while (_warningText.color.a < 1f)
        {
            Color textColor = new Color(255, 255, 255, _warningText.color.a + _fadeSpeed);

            _warningText.color = textColor;

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(_timeToWaitForText);
        while (_warningText.color.a > 0f)
        {
            Color textColor = new Color(255, 255, 255, _warningText.color.a - _fadeSpeed);
            Color imageColor = new Color(0, 0, 0, _warningImage.color.a - _fadeSpeed);
            _warningText.color = textColor;
            _warningImage.color = imageColor;

            yield return new WaitForEndOfFrame();
        }
    }

}
