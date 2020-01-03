using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] numbers;

        public Lake(int[] numbers)
        {
            this.numbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < numbers.Length; i+=2)
            {
                yield return this.numbers[i];
            }

            if (numbers.Length % 2 != 0)
            {
                for (int i = this.numbers.Length - 2; i >= 0; i-=2)
                {
                    yield return this.numbers[i];
                }
            }
            else
            {
                for (int i = this.numbers.Length - 1; i >= 0; i-=2)
                {
                    yield return this.numbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
