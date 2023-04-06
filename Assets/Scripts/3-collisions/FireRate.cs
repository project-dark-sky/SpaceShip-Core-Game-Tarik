using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : MonoBehaviour
{

    [SerializeField] private string triggringTag;
    [SerializeField] private float duration = 6f;
    [SerializeField] private float fireRateDelay = 0.1f;


    private Coroutine coroutineFireRate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggringTag)
        {
            var laserShooter = other.GetComponent<LaserShooter>();
            if (laserShooter)
            {
                if (coroutineFireRate != null)
                {
                    laserShooter.StopCoroutine(coroutineFireRate);
                }
                coroutineFireRate = laserShooter.StartCoroutine(increaseFireRate(laserShooter));
                Destroy(gameObject);
            }
        }
    }



    IEnumerator increaseFireRate(LaserShooter laserShooter)
    {
        laserShooter.setDelayTime(fireRateDelay);
        yield return new WaitForSeconds(duration);
        laserShooter.setDelayTime(fireRateDelay);
        laserShooter.setOriginalDelay();
    }
}
