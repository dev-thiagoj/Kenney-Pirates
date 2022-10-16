using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelManager : MonoBehaviour
{
    [SerializeField] float delayToLoadEndScene = 3;

    #region Actions
    private void OnEnable()
    {
        Actions.saveDataInPlayerPrefs += LoadEndGameSceneWithDelay;
    }

    private void OnDisable()
    {
        Actions.saveDataInPlayerPrefs -= LoadEndGameSceneWithDelay;
    }
    #endregion

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
