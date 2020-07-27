using Flurl.Http;
using System;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Services;

namespace TMS.Nbrb.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            IRequestService requestService = new RequestService();
            IFileService fileService = new FileService();
            Console.WriteLine("Welcome user!!\n");

            while (true)
            {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out int userinput);
                Console.WriteLine();
                switch (userinput)
                {
                    case 1:
                        {
                            try
                            {
                                var currencies = requestService.GetAllCurreciesAsync().GetAwaiter().GetResult();
                                foreach (var currency in currencies)
                                {
                                    Console.WriteLine(currency.Cur_ID + " " + currency.Cur_Name + " " + currency.Cur_Code + " " + currency.Cur_Abbreviation);
                                }

                                Console.WriteLine();
                            }
                            catch (FlurlHttpTimeoutException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed to establish connection");
                                Console.ResetColor();
                            }
                        }
                        break;
                    
                    case 2:
                        {
                            Console.Write("Add code currency: ");

                            try
                            {
                                string code = Console.ReadLine();
                                var rate = requestService.GetRatesAsync(code).GetAwaiter().GetResult();
                                Console.WriteLine(rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate);
                                string writeToFile = rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate;
                                fileService.WriteToFileAsync(writeToFile).GetAwaiter().GetResult();
                            }
                            catch (FlurlHttpTimeoutException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed to establish connection");
                                Console.ResetColor();
                            }
                            catch (FlurlHttpException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unknown code");
                                Console.ResetColor();
                            }
                            Console.WriteLine();
                        }
                        break;
                    
                    case 3:
                        {
                            try
                            {
                                Console.Write("Enter amount: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Add code currency: ");
                                string code = Console.ReadLine();
                                var rate = requestService.GetRatesAsync(code).GetAwaiter().GetResult();
                                Console.WriteLine(rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate);
                                string writeToFile = rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(amount + " " + rate.Cur_Abbreviation + " = " + Convert.ToDecimal(rate.Cur_OfficialRate) / rate.Cur_Scale * amount + " BYN");
                                Console.ResetColor();
                                fileService.WriteToFileAsync(writeToFile).GetAwaiter().GetResult();
                            }
                            catch (FlurlHttpTimeoutException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed to establish connection");
                                Console.ResetColor();
                            }
                            catch (FlurlHttpException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Unknown code");
                                Console.ResetColor();
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect value entered");
                                Console.ResetColor();
                            }

                            Console.WriteLine();
                        }
                        break;
                    
                    case 4:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    
                    default:
                        {
                            Console.WriteLine("Unknown command");
                        }
                        break;
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Possible actions:");
            Console.WriteLine("Click 1: Request all currincies");
            Console.WriteLine("Click 2: Request rates from one currency and write to file");
            Console.WriteLine("Click 3: Currency conversion into BYN and write to file");
            Console.WriteLine("Click 4: Exit\n");
            Console.Write("Enter: ");
        }
    }
}