using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Booking_System
{
    public class Seats
    {
        public string[,] posisi = new string[6, 8];

        public Seats()
        {
            for (int i = 0; i < posisi.GetLength(0); i++)
            {
                for (int j = 0; j < posisi.GetLength(1); j++)
                {
                    posisi[i, j] = Convert.ToString(i + 1) + Convert.ToString(j + 1);
                }
            }
        }

        public void printAvailableSeats()
        {
            Console.WriteLine("\n----------SCREEN---------");
            for (int i = 0; i < posisi.GetLength(0); i++)
            {
                for (int j = 0; j < posisi.GetLength(1); j++)
                {
                    if (j == 4)
                    {
                        Console.Write("  ");
                    }
                    Console.Write(string.Format("{0} ", posisi[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public bool Reserve(string[] letak)
        {
            foreach (string word in letak)
            {
                int[] reserve = word.Select(c => c - '0').ToArray();
                try
                {

                    int j = (int)reserve[0] - 1;
                    int k = (int)reserve[1] - 1;
                    if (posisi[j, k] == "Rs")
                    {
                        Console.WriteLine("Error! Posisi tidak tersedia");
                        return false;
                    }
                    //mengecek terlebih dahulu semua anggota valid atau tidak
                }

                catch (Exception)
                {
                    Console.WriteLine("Error! Posisi tidak valid");
                    return false;
                }
            }

            foreach (string word in letak)
            {
                int[] reserve = word.Select(c => c - '0').ToArray();
 
                int j = (int)reserve[0] - 1;
                int k = (int)reserve[1] - 1;
                posisi[j, k] = "Rs";
            }
            return true;
        }

        public string[] ConvertToArray(string letak, int num)
        {
            char[] separator = { ' ' };
            string[] temporary = letak.Split(separator);
            if (num != temporary.Length)
            {
                Console.WriteLine("Error! input posisi tidak sesuai dengan jumlah tiket yang ingin dibeli!!!");
                return null;
            }

            for (int i=0; i<num; i++)
            {
                for (int j = i+1; j<num; j++)
                {
                    if (temporary[i] == temporary[j])
                    {
                        Console.WriteLine("Error! input posisi tidak boleh sama!!!");
                        return null;
                    }
                }
            }
            return temporary;
        }
    }
}
