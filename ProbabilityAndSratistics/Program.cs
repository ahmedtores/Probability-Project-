using System;

namespace ProbabilityAndSratistics
{
    class Program
    {
        static public int[] insertionsort(int[] arra)
        {

            for (int i = 1; i < arra.Length; i++)
            {
                int key = arra[i];
                int j = i - 1;
                while (j >= 0 && arra[j] > key)
                {
                    arra[j + 1] = arra[j];
                    j--;
                }
                arra[j + 1] = key;
            }
            return arra;
        }

        public static void quartile(int[] arra)
        {

            arra = insertionsort(arra);
            double Q1, Q3, p90;
            int lengthOfArray = arra.Length;

            int elemnt = lengthOfArray / 4;
            Q1 = arra[elemnt - 1] + arra[elemnt];
            Q1 = Q1 / 2;
            Console.WriteLine("Q1 =" + Q1);
            elemnt = 3 * lengthOfArray / 4;
            Q3 = (arra[elemnt - 1] + arra[elemnt]);
            Q3 = Q3 / 2;
            Console.WriteLine("Q3 =" + Q3);

            elemnt = lengthOfArray / 2;
            double IQR = (Q3 - Q1);
            Console.WriteLine("IQR = " + IQR);
           

            double lowerBound = Q1 - 1.5 * IQR;
            double upperBound = Q3 + 1.5 * IQR;
            
          


            p90 = 0.9;
            p90 = p90 * (lengthOfArray-1);


            Console.WriteLine("P90 =" + arra[(int)p90]);

            Console.WriteLine("Outlier Boundaries: " + lowerBound + " - " + upperBound);


            Console.Write("Enter a value to check if it's an outlier: ");
            double input = double.Parse(Console.ReadLine());

            if (Outlier(input, lowerBound, upperBound))
            {
                Console.WriteLine(input + " is an outlier.");
            }
            else
            {
                Console.WriteLine(input + " is not an outlier.");
            }

            static bool Outlier(double value, double lowerBound, double upperBound)
            {
                return value < lowerBound || value > upperBound;
            }
        }

        
        static public int mode(int[] arra)
        {
            int max2 = 0;
            int index = 0;
            for (int i=0; i<arra.Length;i++)
            {
                
                int max = 0;
                int j = i + 1;
                while (j<arra.Length)
                {
                    if (arra[j]==arra[i] )
                    {
                        max++;

                        if (max > max2)
                        {
                            max2 = max;
                            index = i;
                        }
                    }
                    j++;

                }
            }
            if (max2 == 0)
            {
                return 1000000;
            }
            return index;

        }
        static void median(int[] arra)
        {
            double median;
            int[] ara2 = insertionsort(arra);
            int elments = arra.Length;

            //if even
            if (elments % 2 == 0)
            {
                median = (ara2[(elments / 2) - 1] + ara2[(elments / 2)]) / 2.0F;
            }
            else
            {
                median = (elments / 2.0F);
               int median2 = (int)Math.Floor(median);
                median = ara2[median2];
            }
            Console.WriteLine("median =" + median);
        }
        
        static int range(int [] arra)
        {
            Array.Sort(arra);
            int min = arra[0];
            int max = arra[arra.Length - 1];
            int range = max - min;
            return range;
        }
        
      

        
        

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number of your element");
            int elments = int.Parse(Console.ReadLine());
            int[] arra = new int[elments];
            int nums;
            for (int i = 0; i < elments; i++)
            {
                Console.WriteLine("enter the num {0}", i + 1);
                nums = int.Parse(Console.ReadLine());
                arra[i] = nums;
            }
            int index = mode(arra);
            if (index == 1000000)
            {
                Console.WriteLine("not found mod");
            }
            else
            {
                Console.WriteLine("Mode =" + arra[index]);
            }
            int[] arra2 = arra;
            Console.WriteLine("range = " + range(arra));
            
            median(arra);
            quartile(arra);
           

            
           

           

        }
        

    }
}
