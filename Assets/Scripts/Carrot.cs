using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Vector3 ogPos;
    private float floatOffset;

    public float bounceMag;
    public float bounceSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ogPos = transform.position;
        floatOffset = Random.Range(0, 5);
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
            Unicorn unicornScript = collider.gameObject.GetComponent<Unicorn>();
            unicornScript.carrots += 1;
            Debug.Log("Carrots: " + unicornScript.carrots);
            Destroy(gameObject);
        }
    }
}
