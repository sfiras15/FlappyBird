using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = -9.8f;
    public float strength = 3f;
    private Vector3 direction;
    public Sprite[] sprites;
    public int currentFrame;
    public bool loop = true;
    private SpriteRenderer spriteRenderer;
    public GameManager gameManager;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
        transform.position = Vector3.zero;
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimatedRenderer), 0.33f, 0.33f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction = Vector2.up * strength;   
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    public void AnimatedRenderer()
    {
        currentFrame++;
        if (currentFrame >= sprites.Length && loop)
        {
            currentFrame = 0;
        }
        if (currentFrame >= 0 && currentFrame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[currentFrame];
        }
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pipe") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            gameManager.GameOver();
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Score"))
        {
            gameManager.IncreaseScore();

        }
    }
}
