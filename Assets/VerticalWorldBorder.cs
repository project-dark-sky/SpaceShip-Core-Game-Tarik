using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWorldBorder : MonoBehaviour
{

    [SerializeField] Transform changePosition;
    [SerializeField] string triggerTag = "Player";
    [SerializeField] float margin = 1f;



    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggerTag)
        {
            Vector3 newPos = new Vector3(other.transform.position.x, changePosition.position.y + margin, other.transform.position.z);
            other.transform.position = newPos;
        }
    }
}
