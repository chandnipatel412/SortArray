using System;
using System.Collections.Generic;
using SortArray.Data;

namespace SortArray.Helpers
{
    /// Sort String type input and returns sorting steps
    public static class StringSortingAlgorithm
    {
        static string[] names;
        static int length;
        public static List<SortArrayModel> steps;
        public static List<SortArrayModel> SortAlgorithm(string inputType, string input)
        {
            steps = new List<SortArrayModel>();
            string[] words = input.Split(",");
            sort(words);
            return steps;
        }

        public static void sort(string[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }
            names = array;
            length = array.Length;
            quickSort(0, length - 1);
        }

        public static void quickSort(int lowerIndex, int higherIndex)
        {   
            int i = lowerIndex;
            int j = higherIndex;
            string pivot = names[lowerIndex + (higherIndex - lowerIndex) / 2];

            while (i <= j)
            {
                while (names[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (names[j].CompareTo(pivot) > 0)
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
            String temp = names[i];
            names[i] = names[j];
            names[j] = temp;
            _sortarray.Step = string.Join(",", names);
            _sortarray.StepNumber = (steps.Count + 1).ToString();
            steps.Add(_sortarray);
        }
    }
}