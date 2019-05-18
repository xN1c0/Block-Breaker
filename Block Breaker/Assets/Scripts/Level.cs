using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int numBlocks;
    SceneLoader loader;

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
    }

    public void addBlock()
    {
        numBlocks++;
    }

    public void removeBreakableBlock()
    {
        numBlocks--;
        if (numBlocks == 0)
        {
            loader.LoadNextScene();
        }
    }
}