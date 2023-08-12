using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpookManager : MonoBehaviour
{
    [SerializeField] private GameObject _rawImageRenderer;
    [SerializeField] private GameObject _videoPlayer;

    [SerializeField] private float _videoPause = 1.5f;

    public void AfternoonSpookTriggered()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        _rawImageRenderer.SetActive(true);
        _videoPlayer.SetActive(true);

        yield return new WaitForEndOfFrame();

        SceneManager.LoadScene(1);

        yield return new WaitForSeconds(_videoPause);

        _rawImageRenderer.SetActive(false);
        _videoPlayer.SetActive(false);
    }
}
