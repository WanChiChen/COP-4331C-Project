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
        // Numbers are the number of nodes for input, hidden, and output layers respectively
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
    private void SendInputs()
    {
        foreach(AINode node in inputLayer)
        {
            node.SetInput(1);
        }
    }

    // Initialize nodes in each layer
    private void InitializeNetwork(int layer1, int layer2, int layer3)
    {
        InitializeInputLayer(layer1);

        InitializeHiddenLayer(layer2);

        InitializeOutputLayer(layer3);
    }

    //Initialize nodes in input layer
    private void InitializeInputLayer(int size)
    {
        for(int i = 0; i < size; i++)
        {
            inputLayer.Add(new AINode(0));
        }
    }

    //Initialize nodes in hidden layer
    private void InitializeHiddenLayer(int size)
    {
        for (int i = 0; i < size; i++)
        {
            hiddenLayer.Add(new AINode(1));
        }

        InitializeHiddenLayerConnectionsAndWeights();
    }

    //Initialize nodes in output layer
    private void InitializeOutputLayer(int size)
    {
        for (int i = 0; i < size; i++)
        {
            outputLayer.Add(new AINode(2));
        }

        InitializeOutputLayerConnectionsAndWeights();
    }

    // Adjust hidden layer weights and connections here
    private void InitializeHiddenLayerConnectionsAndWeights()
    {
        // Hidden Layer index 0, connect to input layer index 0, weight 1
        AddConnection(1, 0, 0, 1);
    }

    // Adjust hidden layer weights and connections here
    private void InitializeOutputLayerConnectionsAndWeights()
    {
        // Output layer index 0, connect to hidden layer index 0, weight 1
        AddConnection(2, 0, 0, 1);
    }

    // Adds a connection for the node in the specified layer to the specified node in the previous layer with a weight
    private void AddConnection(int layer, int index, int connection, float weight)
    {
        if(layer == 1)
        {
            hiddenLayer[index].connections.Add(connection);
            hiddenLayer[index].weights.Add(weight);
            //hiddenLayer[index].test();
        }

        else if(layer == 2)
        {
            outputLayer[index].connections.Add(connection);
            outputLayer[index].weights.Add(weight);
            //outputLayer[index].test();
        }
    }
}
