using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour
{
    // Array of weights to each connection
    public int[] weights;

    // Array of numbers corresponding to connected nodes
    public int[] connections;

    // Value of the node
    private float output;

    // Node input (for input layer nodes only)
    private float input;

    // Check flag for if input node
    private bool isInputLayer;

    // Access output
    public float GetOutput()
    {
        return output;
    }

    // Set input (for input layer nodes)
    public void SetInput(float value)
    {
        input = value;
        isInputLayer = true;
    }

    // Using the established connections and weights, calculate the output
    public void calculateOutput()
    {
        // If invalid weights and connections, print error and return
        if(!validConnectionsAndWeights())
        {
            Debug.Log("Error in Neural Network: Number of weights does not match number of connections");
            return;
        }


    }

    // Check to make sure there are the same amount of connections as weights
    private bool validConnectionsAndWeights()
    {
        if(weights.Length == connections.Length)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
