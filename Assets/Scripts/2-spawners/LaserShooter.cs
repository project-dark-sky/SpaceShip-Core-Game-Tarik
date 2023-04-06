using System.Collections;
using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooter : ClickSpawner
{
    [SerializeField] NumberField scoreField;

    private float originalDelay;
    

    public void setOriginalDelay()
    {
        this.delayTime = originalDelay;
    }
    private void Start()
    {
        originalDelay = delayTime;
    }

    protected override GameObject spawnObject()
    {
        GameObject newObject = base.spawnObject();  // base = super

        // Modify the text field of the new object.
        ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
        if (newObjectScoreAdder)
            newObjectScoreAdder.SetScoreField(scoreField);

        return newObject;
    }
}
