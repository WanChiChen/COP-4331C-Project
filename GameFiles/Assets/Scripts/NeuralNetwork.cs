using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    // Array of input layer nodes
    public AINode[] inputLayer;

    // Array of hidden layer nodes
    public AINode[] hiddenLayer;

    // Array of output layer nodes;
    public AINode[] outputLayer;


    // Start is called before the first frame update
    void Start()
    {
        SetupLayers();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gives nodes access to network, assigns layers
    void SetupLayers()
    {
        SetupInputLayer();

        SetupHiddenLayer();

        SetupOutputLayer();
    }

    // Setup each node in input layer
    void SetupInputLayer()
    {
        foreach(AINode node in inputLayer)
        {
            // Set node as layer 0
            node.Setup(0);
        }
    }

    // Setup each node in hidden layer
    void SetupHiddenLayer()
    {
        foreach (AINode node in hiddenLayer)
        {
            // Set node as layer 1
            node.Setup(1);
        }
    }

    // Setup each node in output layer
    void SetupOutputLayer()
    {
        foreach (AINode node in outputLayer)
        {
            // Set node as layer 2
            node.Setup(2);
        }
    }
}
