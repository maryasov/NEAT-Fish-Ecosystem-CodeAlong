using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeatNetwork
{
    public NeatGenome myGenome;
    public List<Node> nodes;
    public List<Node> inputNodes;
    public List<Node> outputNodes;
    public List<Node> hiddenNodes;
    public List<Connection> connections;
    // public float fitness;

    public NeatNetwork(int inp, int outp, int hid)
    {
        myGenome = CreateInitialGenome(inp, outp, hid);
        nodes = new List<Node>();
        inputNodes = new List<Node>();
        outputNodes = new List<Node>();
        hiddenNodes = new List<Node>();
        connections = new List<Connection>();
        CreateNetwork();
    }

    private NeatGenome CreateInitialGenome(int inp, int outp, int hid)
    {
        List<NodeGene> newNodeGenes = new List<NodeGene>();
        List<ConGene> newConGenes = new List<ConGene>();

        int nodeId = 0;
        for (int i = 0; i < inp; i++)
        {
            NodeGene newNodeGene = new NodeGene(nodeId, NodeGene.TYPE.Input);
            newNodeGenes.Add(newNodeGene);
            nodeId += 1;
        }
        for (int i = 0; i < outp; i++)
        {
            NodeGene newNodeGene = new NodeGene(nodeId, NodeGene.TYPE.Output);
            newNodeGenes.Add(newNodeGene);
            nodeId += 1;
        }
        
        NeatGenome newGenome = new NeatGenome(newNodeGenes, newConGenes);

        return newGenome;
    }

    private void CreateNetwork()
    {
        foreach (NodeGene nodeGene in myGenome.nodeGenes)
        {
            Node newNode = new Node(nodeGene.id);
            nodes.Add(newNode);
            if (nodeGene.type == NodeGene.TYPE.Input)
            {
                inputNodes.Add(newNode);
            }
            else if (nodeGene.type == NodeGene.TYPE.Hidden)
            {
                hiddenNodes.Add(newNode);
            }
            else if (nodeGene.type == NodeGene.TYPE.Output)
            {
                outputNodes.Add(newNode);
            }
            
        }
        foreach (ConGene conGene in myGenome.conGenes)
        {
            Connection newCon = new Connection(conGene.inputNode, conGene.outputNode, conGene.weight, conGene.isActive);
            connections.Add(newCon);

        }
        foreach (Node node in nodes)
        {
            foreach (Connection con in connections)
            {
                if (con.inputNode == node.id)
                {
                    node.outputConnections.Add(con);
                }
                else if (con.outputNode == node.id)
                {
                    node.inputConnections.Add(con);
                }
            } 
            
        }
    }
}

public class Node
{
    public int id;
    public float value;
    public List<Connection> inputConnections;
    public List<Connection> outputConnections;

    public Node(int ident)
    {
        id = ident;
        // value = 0;
        // inputConnections = new List<Connection>();
        // outputConnections = new List<Connection>();
    }
}

public class Connection
{
    public int inputNode;
    public int outputNode;
    public float weight;
    public bool isActive;

    public Connection(int inNode, int outNode, float wei, bool active)
    {
        inputNode = inNode;
        outputNode = outNode;
        weight = wei;
        isActive = active;
    }
}
