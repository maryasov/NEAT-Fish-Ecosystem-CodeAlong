using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeatGenome
{
    public List<NodeGene> nodeGenes;
    public List<ConGene> conGenes;

    public NeatGenome()
    {
        nodeGenes = new List<NodeGene>();
        conGenes = new List<ConGene>();
    }
}

public class NodeGene
{
    public int id;
    
    public enum TYPE
    {
        Input, Output, Hidden
    }
    
    public TYPE type;

    public NodeGene(int givenID, TYPE givenType)
    {
        id = givenID;
        type = givenType;
        
    }
}

public class ConGene
{
    public int inputNode;
    public int outputNode;
    public float weight;
    public bool isActive;
    public int innovNumber;

    public ConGene(int inNode, int outNode, float wei, bool active, int innov)
    {
        inputNode = inNode;
        outputNode = outNode;
        weight = wei;
        isActive = active;
        innovNumber = innov;
    }
}
