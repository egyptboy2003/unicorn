using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carrot : MonoBehaviour
{
    private Vector3 ogPos;
    private float floatOffset;

    public float bounceMag;
    public float bounceSpeed;
    public TextMeshProUGUI carrotText;
    private Unicorn unicornScript;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        ogPos = transform.position;
        floatOffset = Random.Range(0, 5);

        unicornScript = GameObject.FindGameObjectWithTag("Unicorn").GetComponent<Unicorn>();
        carrotText = GameObject.FindGameObjectWithTag("score").GetComponent<TextMeshProUGUI>();
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }
    // Rendering handled as often as possible
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ogPos.y + Mathf.Sin(Time.time * bounceSpeed + floatOffset) * bounceMag, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Unicorn")
        {
            audioSource.Play();
            unicornScript.carrots += 1;
            carrotText.text = unicornScript.carrots + "/" + unicornScript.ogCarrots;
            if (unicornScript.carrots >= unicornScript.ogCarrots)
            {
                StartCoroutine(DelayedWin(1));
            } else
            {
                Destroy(gameObject);
            }
            
        }
    }

    IEnumerator DelayedWin(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        unicornScript.Win();
        Destroy(gameObject);
    }
}
