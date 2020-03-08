using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    // Array of input layer nodes
    public List<AINode> inputLayer = new List<AINode>();

    // Array of hidden layer nodes
    public List<AINode> hiddenLayer = new List<AINode>();

    // Array of output layer nodes;
    public List<AINode> outputLayer = new List<AINode>();


    // Start is called before the first frame update
    void Start()
    {
        InitializeNetwork(1, 1, 1);

        SendInputs();

        //RunHiddenLayer();

        //RunOutputLayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Send inputs to input layer nodes
    void SendInputs()
    {
        foreach(AINode node in inputLayer)
        {
            node.SetInput(1);
        }
    }

    // Initialize nodes in each layer
    void InitializeNetwork(int layer1, int layer2, int layer3)
    {
        InitializeInputLayer(layer1);

        InitializeHiddenLayer(layer2);

        InitializeOutputLayer(layer3);
    }

    //Initialize nodes in input layer
    void InitializeInputLayer(int size)
    {
        for(int i = 0; i < size; i++)
        {
            inputLayer.Add(new AINode(0));
        }
    }

    //Initialize nodes in hidden layer
    void InitializeHiddenLayer(int size)
    {
        for (int i = 0; i < size; i++)
        {
            hiddenLayer.Add(new AINode(1));
        }
    }

    //Initialize nodes in output layer
    void InitializeOutputLayer(int size)
    {
        for (int i = 0; i < size; i++)
        {
            outputLayer.Add(new AINode(2));
        }
    }
}
