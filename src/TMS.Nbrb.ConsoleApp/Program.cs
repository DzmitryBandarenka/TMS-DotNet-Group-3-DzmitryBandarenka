using System;
using TMS.Nbrb.Core.Services;
using TMS.Nbrb.Core.Interfaces;
using Flurl.Http;
using System.Dynamic;


namespace TMS.Nbrb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IRequestService requestService = new RequestService();
            IFileService fileService = new FileService();
            Console.WriteLine("Welcome user!!\n");

            while (true) {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out int userinput);
                switch (userinput) {
                    case 1: {
                            try
                            {
                                var data = requestService.GetAllCurreciesAsync().GetAwaiter().GetResult();
                                foreach (var item in data)
                                {
                                    Console.WriteLine(item.Cur_ID + " " + item.Cur_Name + " " + item.Cur_Code + " " + item.Cur_Abbreviation);
                                }
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
                            Console.WriteLine("Add code currency:\n");

                            try
                            {
                                string code = Console.ReadLine();
                                var rate = requestService.GetRatesAsync(code).GetAwaiter().GetResult();
                                Console.WriteLine(rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate);
                                string writeToFile = rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate;
                                fileService.WriteToFileAsync(writeToFile);
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
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        {
                          

                            try
                            {
                                Console.WriteLine("Enter amount:\n");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Add code currency:\n");
                                string code = Console.ReadLine();
                                var rate = requestService.GetRatesAsync(code).GetAwaiter().GetResult();
                                Console.WriteLine(rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate);
                                string writeToFile = rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(amount + " " + rate.Cur_Abbreviation + " = " + Convert.ToDecimal(rate.Cur_OfficialRate) / rate.Cur_Scale * amount + " BYN");
                                Console.ResetColor();
                                fileService.WriteToFileAsync(writeToFile);
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

                            Console.ReadLine();
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

        public static void ShowMenu() {
            
            Console.WriteLine("Possible actions:\n");
            Console.WriteLine("Click 1: Request all currincies");
            Console.WriteLine("Click 2: Request rates from one currency and write to file");
            Console.WriteLine("Click 3: Currency conversion into BYN and write to file");
            Console.WriteLine("Click 4: Exit");
        }
    }
}