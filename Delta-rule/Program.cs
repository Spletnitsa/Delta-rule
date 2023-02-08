namespace Delta_rule
{
    class Neuron
    {
        private int _x1;
        private int _x2;
        private int _y;
        private int _n = 1;
        private const int _x0 = -1;
        private double _w1 = 0;
        private double _w2 = 0;
        private double _t = 0;
        private double _e = 0;

        public double Net()
        {
            return _w1 * _x1 + _w2 * _x2 + _t * _x0;
        }

        public int ActivateFunction(double NetRes)
        {
            if (NetRes > 0)
                return 1;
            else if (NetRes <= 0)
                return -1;
            else
                return 0;
        }

        public void LearningNeuron(int[] X1, int[] X2, int[] D)
        {
            int j = 0;

            Console.WriteLine("Начато обучение\n");
            do
            {
                j++;
                Console.WriteLine($"Прогон {j}");
                for (int i = 0; i < D.Length; i++)
                {
                    _x1 = X1[i];
                    _x2 = X2[i];
                    _y = ActivateFunction(Net());
                    _e = D[i] - _y;

                    _w1 += _n * _e * _x1;
                    _w2 += _n * _e * _x2;
                    _t += _n * _e * _x0;

                    Console.WriteLine($"Выход = {_y} Эталонное значение = {D[i]}");
                    Console.WriteLine($"Изменение весов:\n W1 = {_w1}\n W2 = {_w2}\n T = {_t}\n E = {_e}\n");
                }
            } while (_e > 0 || _e < 0);

            Console.WriteLine("Обучение завершено!\n");
        }

        public void SolutionOfProblem (int X1, int X2)
        {
            _x1 = X1;
            _x2 = X2;
            _y = ActivateFunction(Net());

            Console.WriteLine($"X1 = {_x1}\tX2 = {_x2}\tВыход = {_y}\n");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = new int[] { 1, 1, -1, -1 };
            int[] input2 = new int[] { 1, -1, 1, -1 };
            int[] D = new int[] { 1, -1, -1, -1 };
            Neuron universalNeuron = new Neuron();

            universalNeuron.LearningNeuron(input1, input2, D);

            Console.WriteLine("Решение задачи:");

            for (int i = 0; i < input1.Length; i++)
            {
                universalNeuron.SolutionOfProblem(input1[i], input2[i]);
            }
        }
    }
}