// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using System.Collections;
using UnityEngine;

public class SwarmManager : MonoBehaviour
{
    // External parameters/variables
    [SerializeField] private GameObject enemyTemplate;
    [SerializeField] private int enemyRows;
    [SerializeField] private int enemyCols;
    [SerializeField] private float enemySpacing;
    [SerializeField] private float stepSize;
    [SerializeField] private float stepTime;
    [SerializeField] private float leftBoundaryX;
    [SerializeField] private float rightBoundaryX;
    [SerializeField] private int direction = 1;

    private void Start()
    {
        // Initialise the swarm by instantiating enemy prefabs.
        GenerateSwarm();
        
        // Start swarm at the far left.
        transform.localPosition = new Vector3(this.leftBoundaryX, 0f, 0f);

        // Use a coroutine to periodically step the swarm. Coroutines are worth
        // learning about if you are unfamiliar with them. In Unity they allow
        // us to define sequences that span multiple frames in a very clean way.
        // Although it might look like it, using coroutines is *not* the same as
        // using multithreading! Read more here:
        // https://docs.unity3d.com/Manual/Coroutines.html
        StartCoroutine(StepSwarmPeriodically());
    }
    
    private IEnumerator StepSwarmPeriodically() 
    {
        // Yep, this is an infinite loop, but the gameplay isn't ever "halted"
        // since the function is invoked as a coroutine. It's also automatically 
        // stopped when the game object is destroyed.
        while (true)
        {
            yield return new WaitForSeconds(this.stepTime); // Not blocking!
            StepSwarm();
        }
    }

    // Automatically generate swarm of enemies based on the given serialized
    // attributes/parameters.
    private void GenerateSwarm()
    {
        // Write code here...
         // Loop through each row
    for (int i = 0; i < enemyCols; i++)
    {
        // Loop through each column
        for (int j = 0; j < enemyRows; j++)
        {
            // Calculate the position for each enemy based on its row and column, as well as the defined spacing.
            float xPosition = i * enemySpacing;
            float zPosition =  j* enemySpacing; // Negative since we want to move downwards for each row.

            // Instantiate the enemy at the calculated position.
            // Quaternion.identity means "no rotation".
            var enemy = Instantiate(enemyTemplate, transform);
            // Make the instantiated enemy a child of the SwarmManager to keep the hierarchy organized.
            
            enemy.transform.localPosition = new Vector3(xPosition, 0f, zPosition);
        }
    }
    }

    // Step the swarm across the screen, based on the current direction, or down
    // and reverse when it reaches the edge.
    private void StepSwarm()
    {
        // Write code here...
        var swarmWidth = (this.enemyCols - 1) * this.enemySpacing;
        var swarmMinX = transform.localPosition.x;
        var swarmMaxX = swarmMinX + swarmWidth;


        if(swarmMinX < this.leftBoundaryX && this.direction == -1  || 
           swarmMaxX > this.rightBoundaryX && this.direction == 1)
        {
            transform.Translate(Vector3.back * this.stepSize);
            this.direction = -this.direction;

        }else{
             transform.Translate(Vector3.right * (this.direction * this.stepSize));


        }
        // Tip: You probably want a private variable to keep track of the
        // direction the swarm is moving. You could alternate this between 1 and
        // -1 to serve as a vector multiplier when stepping the swarm.
    }
}
