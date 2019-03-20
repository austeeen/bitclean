using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitClean.bitclean
{
	public class Brain
	{
		public Brain()
		{ }

		public void run()
		{
			/*	give data to input layer neurons
			 *	for each synapse in current layer
			 *		synapse transmits
			 *		
			 *	
			 */
		}
	}

	public class Neuron
	{
		public List<double> data;
		public double axon;

		// dendrite summation
		private double sum;
		private ActivationFunction activation;
		
		public Neuron()
		{ }
		
		public void calculateAxon()
		{
			for (int i = 0; i < data.Count; i++)
				sum += data[i];

			axon = activation.activate(sum);
		}
	}

	public class Synapse
	{
		private Neuron transmitter;
		private Neuron receiver;
		private int weight;
		private double data;

		public Synapse(Neuron transmitter, Neuron receiver, int weight)
		{
			this.transmitter = transmitter;
			this.receiver = receiver;
			this.weight = weight;
		}

		public void Transmit()
		{
			data = transmitter.axon * weight;
			receiver.data.Add(data);
		}

	}

	#region activation functions

	public abstract class ActivationFunction
	{
		public abstract double activate(double data);
	}

	public class Linear : ActivationFunction
	{
		public override double activate(double data)
		{
			return data;
		}
	}
	public class RectifiedLinear : ActivationFunction
	{
		public override double activate(double data)
		{
			if (data < 0.0)
				return 0.0;
			return data;
		}
	}

	public class Logistic : ActivationFunction
	{
		public override double activate(double data)
		{
			return 1.0 / (1.0 + Math.Exp(-(data)));
		}
	}

	public class Heaviside : ActivationFunction
	{
		public override double activate(double data)
		{
			if (data < 0.0) return 0.0;
			return 1.0;
		}
	}

	#endregion
}
