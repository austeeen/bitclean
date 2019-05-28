using System;
using System.Collections.Generic;

/*
 * bitclean: /system/brain.cs
 * author: Austin Herman
 * 5/8/2019
 */

namespace bitclean
{
    /// <summary>
    /// Initialise hyper parameters.
    /// </summary>
	public class HyperParameters
	{
		public int attributeCount = 0;
		public int synapseLayerCount = 0;
		public int neuronLayerCount = 0;
	}

    /// <summary>
    /// Create/Delete/Run Brain functions
    /// </summary>
	public class Brain
	{
		private List<Neuron> inputlayer;
		private List<List<Neuron>> neurons;
		private List<List<Synapse>> synapses;
		private List<List<int>> weights;
		public int attributeCount;

		public Brain(int numAtttributes)
		{
			attributeCount = numAtttributes;
			Generate();			
		}

		public double Think(double[] inputdata)
		{
			DumpMemory();

			if (inputdata.Length != attributeCount)
				Regenerate(inputdata.Length);

			for (int i = 0; i < attributeCount; i++)
				inputlayer[i].data.Add(inputdata[i]);

			for (int i = 0; i < synapses.Count; i++) {
				for (int j = 0; j < synapses[i].Count; j++)
					synapses[i][j].Transmit();
			}

			synapses[attributeCount][0].Transmit();

			return neurons[attributeCount][0].axon;
		}

		private void DumpMemory()
		{
			for (int i = 0; i < neurons.Count; i++) {
				for (int j = 0; j < neurons[i].Count; j++)
					neurons[i][j].Fry();
			}
		}

		private void Regenerate(int numAttributes)
		{
			attributeCount = numAttributes;

			for (int i = 0; i < synapses.Count; i++)
				synapses[i].Clear();
			synapses.Clear();

			for (int i = 0; i < neurons.Count; i++)
				neurons[i].Clear();
			neurons.Clear();

			Generate();
		}

		// make brain cells
		private void Generate()
		{
			GenerateNeurons();
			GenerateSynapses();
		}

		private void GenerateNeurons()
		{
			inputlayer = new List<Neuron>();

			for (int i = 0; i < attributeCount; i++)
				inputlayer.Add(new Neuron(new Linear()));

            neurons = new List<List<Neuron>> {
                inputlayer
            };

            for (int i = 1; i < attributeCount + 1; i++) {
				neurons.Add(new List<Neuron>());
				for (int j = attributeCount - i; j >= 0; j--)
					neurons[i].Add(new Neuron(new Linear()));
			}
		}

		private void GenerateSynapses()
		{
			synapses = new List<List<Synapse>>();
			weights  = new List<List<int>>();

			// transmitter | receiver | weight
			synapses.Add(new List<Synapse>());
			weights.Add(new List<int>());

			for(int n = 0; n < attributeCount; n ++) {
				weights[0].Add(0);
				synapses[0].Add(new Synapse(inputlayer[n], neurons[1][n], weights[0][n]));
			}

			for(int l = 1; l < neurons.Count - 1; l ++)
			{
				synapses.Add(new List<Synapse>());
				weights.Add(new List<int>());
				for (int n = 0; n < neurons[l].Count; n++)
				{
					for(int nn = 0; nn < neurons[l + 1].Count; nn++) {
						weights[l].Add(l);
						synapses[l].Add(new Synapse(neurons[l][n], neurons[l + 1][nn], weights[l][nn]));
					}
				}
			}

			weights.Add(new List<int>());
			synapses.Add(new List<Synapse>());

			weights[attributeCount].Add(1);
			synapses[attributeCount].Add(new Synapse(neurons[attributeCount][0], null, weights[attributeCount][0]));

		}

	}

	public class Neuron
	{
		public List<double> data = new List<double>();
		public double axon;

		// dendrite summation
		private double sum;
		private bool calculatedSum;

		private ActivationFunction func;

		public Neuron(ActivationFunction func) { this.func = func; }
		
		public void CalculateAxon()
		{
			if (calculatedSum) return;
			
			for (int i = 0; i < data.Count; i++) sum += data[i];

			axon = func.Activate(sum);
			calculatedSum = true;
		}
		
		public void Fry()
		{
			data.Clear();
			axon = 0.0;
			sum = 0.0;
			calculatedSum = false;
		}
	}

	public class Synapse
	{
		private Neuron transmitter;
		private Neuron receiver;
		private readonly int weight;
		private readonly bool squared;

		public Synapse(Neuron transmitter, Neuron receiver, int weight)
		{
			this.transmitter = transmitter;
			this.receiver = receiver;
			this.weight = weight;
            squared |= weight == 0; // if weight == 0, squared = true
        }

        public void Transmit()
		{
			transmitter.CalculateAxon();

			if(receiver != null) {
				if (squared)
					receiver.data.Add(transmitter.axon * transmitter.axon);
				else
					receiver.data.Add(transmitter.axon * weight);
			}
		}

		public void ClearReceivers()
		{
			if (receiver != null)
				receiver.data.Clear();
		}
	}

}
