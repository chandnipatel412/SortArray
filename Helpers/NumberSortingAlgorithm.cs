using System;
using System.Collections.Generic;
using SortArray.Data;

namespace SortArray.Helpers
{
    /// Sort number type input and returns sorting steps
    public static class NumberSortingAlgorithm
    {
        static int[] number;
        static int length;
        public static List<SortArrayModel> steps;
        public static List<SortArrayModel> SortAlgorithm(string input)
        {
            steps = new List<SortArrayModel>();
            int[] words = Array.ConvertAll(input.Split(","), int.Parse);
            sort(words);
            return steps;
        }

        public static void sort(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }
            number = array;
            length = array.Length;
            quickSort(0, length - 1);
        }

        public static void quickSort(int lowerIndex, int higherIndex)
        {   
            int i = lowerIndex;
            int j = higherIndex;
            int pivot = number[lowerIndex + (higherIndex - lowerIndex) / 2];

            while (i <= j)
            {
                while (number[i] < pivot)
                {
                    i++;
                }

                while (number[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    exchangeNames(i, j);
                    i++;
                    j--;
                }
            }
            
            //call quickSort recursively
            if (lowerIndex < j)
            {
                quickSort(lowerIndex, j);
            }
            if (i < higherIndex)
            {
                quickSort(i, higherIndex);
            }
        }

        public static void exchangeNames(int i, int j)
        {
            SortArrayModel _sortarray = new SortArrayModel();
            int temp = number[i];
            number[i] = number[j];
            number[j] = temp;
            _sortarray.Step = string.Join(",", number);
            _sortarray.StepNumber = (steps.Count + 1).ToString();
            steps.Add(_sortarray);
        }

    }
}