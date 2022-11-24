using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public GameObject trash;
    public DragScript dragScript;
    private Vector2 spawnPosition;
    public AudioSource trashSource;

    private void Awake()
    {
        spawnPosition = this.gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trashSource.Play();
        dragScript.isDragging = false;
        dragScript.selectedObject = null;
        trash.SetActive(true);
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.SetActive(false);
    }
}
