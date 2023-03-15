using System;
using System.Globalization;
using System.Text;

namespace VAT_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =Encoding.Unicode;
            Set_Of_VAT_Calculation_Operations();
        }

        private static void Set_Of_VAT_Calculation_Operations()
        {
            const int MAXIMUM_NUMBER_OF_PARTIAL_DISCHARGES = 28;
            const int ARRAY_OUTSIDE_PROTECTOR = 1;
            const int NUMBER_OF_CHARACTERS = 100;

            while (true)
            {
                Console.WriteLine("Введіть кількість операцій");
                int the_Number_Of_Operations = Convert.ToInt32(Console.ReadLine());

                decimal[] transaction_Amount = new decimal[the_Number_Of_Operations];

                for (int transaction_Amount_Index = 0; transaction_Amount_Index <= the_Number_Of_Operations - ARRAY_OUTSIDE_PROTECTOR; transaction_Amount_Index++)
                {
                    Console.WriteLine($"Введіть суму операції № {transaction_Amount_Index + 1}");
                    transaction_Amount[transaction_Amount_Index] = Convert.ToDecimal(Console.ReadLine());
                }

                decimal[] VAT_Percentage = new decimal[the_Number_Of_Operations];

                for (int VAT_Percentage_Index = 0; VAT_Percentage_Index <= the_Number_Of_Operations - ARRAY_OUTSIDE_PROTECTOR; VAT_Percentage_Index++)
                {
                    Console.WriteLine($"Введіть відсоток ПДВ № {VAT_Percentage_Index + 1}");
                    VAT_Percentage[VAT_Percentage_Index] = Math.Round(Convert.ToDecimal(Console.ReadLine()),
                    MAXIMUM_NUMBER_OF_PARTIAL_DISCHARGES);
                }

                decimal[] percentage_By_Which_To_Divide = new decimal[the_Number_Of_Operations];

                for (int percentage_By_Which_To_Divide_Index = 0;
                    percentage_By_Which_To_Divide_Index <= the_Number_Of_Operations - ARRAY_OUTSIDE_PROTECTOR;
                    percentage_By_Which_To_Divide_Index++)
                {
                    Console.WriteLine($"Введіть відсоток на який треба ділити № {percentage_By_Which_To_Divide_Index + 1}");
                    percentage_By_Which_To_Divide[percentage_By_Which_To_Divide_Index] = Math.Round(Convert.ToDecimal(Console.ReadLine()),
                    MAXIMUM_NUMBER_OF_PARTIAL_DISCHARGES);
                }

                decimal result = default;

                for (int result_Index = 0; result_Index < the_Number_Of_Operations; result_Index++)
                {
                    result += transaction_Amount[result_Index] * VAT_Percentage[result_Index] / percentage_By_Which_To_Divide[result_Index];
                }

                Console.WriteLine(new string('-', NUMBER_OF_CHARACTERS));

                foreach (var item in transaction_Amount)
                {
                    Console.WriteLine($"сума операції {item}");
                }

                foreach (var item in VAT_Percentage)
                {
                    Console.WriteLine($"Відсоток ПДВ {item}%");
                }

                foreach (var item in percentage_By_Which_To_Divide)
                {
                    Console.WriteLine($"Відсоток на якій було поділено {item}%");
                }

                Console.WriteLine($"Загальна сума ПДВ {string.Format(new CultureInfo(string.Empty), "{0:c}", result)}");
                Console.WriteLine(new string('-', NUMBER_OF_CHARACTERS));
                Console.WriteLine();
            }
        }
    }
}
