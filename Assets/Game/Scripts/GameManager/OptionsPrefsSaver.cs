using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPrefsSaver : MonoBehaviour
{
    [Space]
    [SerializeField] Slider timeSlider;
    [Space]
    [SerializeField] Slider spawnSlider;
    [Space]
    [SerializeField] GameObject confirmationBox;

    public void SaveOptionsPrefs()
    {
        PlayerPrefs.SetInt("SessionTime", (int)timeSlider.value);
        PlayerPrefs.SetInt("EnemySpawnTime", (int)spawnSlider.value);

        StartCoroutine(ConfirmationBoxCoroutine());
    }

    IEnumerator ConfirmationBoxCoroutine()
    {
        confirmationBox.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationBox.SetActive(false);
    }
}
