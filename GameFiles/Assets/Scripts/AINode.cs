﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode
{
    // Array of weights to each connection
    public List<float> weights = new List<float>();

    // Array of numbers corresponding to connected nodes
    public List<int> connections = new List<int>();

    // Value of the node
    private float output;

    // Node input (for input layer nodes only)
    private float input;

    // Layer of this node
    private int layer;

    // Reference to network
    private NeuralNetwork network;

    // Give node access to neural network, set layer of node
    public AINode(int layer)
    {
        this.network = GameObject.FindGameObjectWithTag("Network").GetComponent<NeuralNetwork>();
        this.layer = layer;
        this.output = 0;
    }

    // Access output
    public float GetOutput()
    {
        return output;
    }

    // Set input (for input layer nodes)
    public void SetInput(float value)
    {
        input = value;
        Debug.Log("Node input = " + input);
    }

    // Using the established connections and weights, calculate the output
    public void CalculateOutput()
    {
        // If this is an input layer node, we just set output equal to input
        if (layer == 0)
        {
            output = input;
            return;
        }

        // If invalid weights and connections, print error and return
        if (!ValidConnectionsAndWeights())
        {
            Debug.Log("Error in Neural Network: Number of weights does not match number of connections");
            return;
        } 

        // Standard output calculation
        CalcOutput();
    }

    // Check to make sure there are the same amount of connections as weights
    private bool ValidConnectionsAndWeights()
    {
        if(weights.Capacity == connections.Capacity)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    // Inner workings of CalculateOutput
    // Gets output from connections and multiplies them by the weight for that connection
    private void CalcOutput()
    {
        int i = 0;

        foreach(int connect in connections)
        {
            if(layer == 1)
            {
                float val = network.inputLayer[connect].GetOutput();
                output +=  val * weights[i];
                i++;
            }

            else
            {
                float val = network.hiddenLayer[connect].GetOutput();
                output += val * weights[i];
                i++;
            }
        }
    }

    public void test()
    {
        foreach (int i in connections)
        {
            Debug.Log("Connection: " + i);
        }

        foreach (float f in weights)
        {
            Debug.Log("Weights: " + f);
        }
    }
}
