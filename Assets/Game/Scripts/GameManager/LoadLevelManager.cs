using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour
{
    [SerializeField] float delayToLoadEndScene = 3;

    private void OnEnable()
    {
        Actions.saveDataInPlayerPrefs += LoadEndGameSceneWithDelay;
    }

    private void OnDisable()
    {
        Actions.saveDataInPlayerPrefs -= LoadEndGameSceneWithDelay;
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    void LoadEndGameSceneWithDelay()
    {
        StartCoroutine(LoadSceneWithDelayCoroutine());
    }

    IEnumerator LoadSceneWithDelayCoroutine()
    {
        yield return new WaitForSeconds(delayToLoadEndScene);
        LoadScene(2);
    }
}
