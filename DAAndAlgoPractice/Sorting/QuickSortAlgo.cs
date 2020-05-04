namespace DAAndAlgoPractice.Sorting
{
    public class QuickSortAlgo
    {
        public static void Processor()
        {
            int[] A = { 6, 8, 1, 5, int.MaxValue };
            int n = A.Length;
            QuickSort(A, 0, n - 1);
        }

        private static void QuickSort(int[] A, int l, int h)
        {
            int j;

            if (l < h)
            {
                j = Partition(A, l, h);
                QuickSort(A, l, j);
                QuickSort(A, j + 1, h);
            }
        }

        private static int Partition(int[] A, int l, int h)
        {
            int i = l, j = h;
            int pivot = A[l];
            do
            {
                // find I position
                do
                {
                    i++;
                }
                while (pivot >= A[i]);

                // find J position
                do
                {
                    j--;
                }
                while (pivot < A[j]);

                if (i < j)
                {
                    // let's swap 
                    int tempVar = A[i];
                    A[i] = A[j];
                    A[j] = tempVar;
                }

            } while (i < j);

            // let's swap the first Pivot element with the selected indexed element. 
            int temp = A[l];
            A[l] = A[j];
            A[j] = temp;

            // this is the exact position of Pivot element. 
            return j;
        }
    }
}
