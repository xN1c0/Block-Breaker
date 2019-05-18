using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    int maxHits;


    void Start()
    {
        maxHits = hitSprites.Length + 1;
        timesHit = 0;
        level = FindObjectOfType<Level>();
        if(this.tag == "Breakable")
        {
            level.addBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(this.tag == "Breakable")
        {
            FindObjectOfType<GameStatus>().addPoints();
            timesHit++;
            if(timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
            
    }

    private void ShowNextHitSprite()
    {
        
        if (timesHit >= 1)
        {
            int spriteIndex = timesHit - 1;
            if(hitSprites[spriteIndex] != null)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
            else
            {
                Debug.LogError("Block Spriter is missing");
            }
            
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
        TriggerSparklesVFX();
        level.removeBreakableBlock();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
