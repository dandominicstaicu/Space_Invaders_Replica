using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonUI : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void UIPauseButton()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
