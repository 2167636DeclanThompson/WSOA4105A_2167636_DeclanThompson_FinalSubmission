using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookScript : MonoBehaviour
{
    public GameObject notebook;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Open();
        }
    }

    void Open()
    {
        notebook.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        notebook.SetActive(false);
        Time.timeScale = 1;
    }
}
