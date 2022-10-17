﻿namespace Delta_rule
{
    class neuron
    {
        private int X1;
        private int X2;
        private const int X0 = -1;
        private double W1 = 0;
        private double W2 = 0;
        private double T = 0;
        private double E;
        private double NetRes;
        private int Y;
        public int N = 1;

        public void Net()
        {
            NetRes = W1 * X1 + W2 * X2 + T * X0;
        }

        public int ActivateFunction()
        {
            if (NetRes > 0)
                return 1;
            else if (NetRes <= 0)
                return -1;
            else
                return 0;
        }

        public double LearningNeuron(int X1, int X2, int D)
        {
            this.X1 = X1;
            this.X2 = X2;
            Net();
            Y = ActivateFunction();
            E = D - Y;

            W1 += N * E * this.X1;
            W2 += N * E * this.X2;
            T += N * E * X0;

            Console.WriteLine($"Net = {NetRes} Выход = {Y} Эталонное значение = {D}");
            Console.WriteLine($"Изменение весов:\n W1 = {W1}\n W2 = {W2}\n T = {T}\n E = {E}\n");

            return E;
        }

        public void SolutionOfProblem (int X1, int X2)
        {
            this.X1 = X1;
            this.X2 = X2;
            Net();
            Y = ActivateFunction();

            Console.WriteLine($"X1 = {X1}\tX2 = {X2}\tВыход = {Y}\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = new int[] { 1, 1, -1, -1 };
            int[] input2 = new int[] { 1, -1, 1, -1 };
            int[] D = new int[] { 1, 1, 1, -1 };
            neuron firstNeuron = new neuron();
            double e = 0;
            int j = 0;

            Console.WriteLine("Обучение\n");
            do
            {
                j++;
                Console.WriteLine($"Прогон {j}");
                for (int i = 0; i < D.Length; i++)
                {
                    e = firstNeuron.LearningNeuron(input1[i], input2[i], D[i]);
                }
            } while (e > 0 || e < 0);

            Console.WriteLine("Решение задачи\n");

            for (int i = 0; i < input1.Length; i++)
            {
                firstNeuron.SolutionOfProblem(input1[i], input2[i]);
            }
        }
    }
}