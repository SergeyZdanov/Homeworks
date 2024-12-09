namespace Otus28
{
    internal class WorkingWithNumbers
    {
        internal int[] RandomArrayFilling(int[] mas)
        {
            Random random = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next(100);
            }

            return mas;
        }
    }
}
