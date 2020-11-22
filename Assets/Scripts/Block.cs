using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject impactVFX;
    
    [SerializeField] Sprite[] hitSprite;


    [SerializeField] int timesHit;

    Level level;
    GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBreakableBlocks();
            gameStatus = FindObjectOfType<GameStatus>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            int maxHits = hitSprite.Length;
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyObject();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit;
        if (hitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
        else
        {
            print("Block error" + gameObject.name);
        }
    }

    void DestroyObject()
    {
        DestroyBlockSFX();
        level.BlockDestroyed();
        ParticleVFX();
    }

    private void DestroyBlockSFX()
    {

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        gameStatus.AddToScore();
        Destroy(this.gameObject);
            
    }

    void ParticleVFX()
    {
        GameObject sparkles = Instantiate(impactVFX, this.transform.position, this.transform.rotation);
        Destroy(sparkles, 1f);
    }
}
