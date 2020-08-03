using System;
using TMS.Nbrb.Core.Services;
using TMS.Nbrb.Core.Interfaces;
using Flurl.Http;



namespace TMS.Nbrb.ConsoleApp
{
    /// <summary>
    /// Действия программы.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IRequestService requestService = new RequestService();
            IFileService fileService = new FileService();
            Console.WriteLine("Welcome user!!\n");

            while (true) {
                Services.ShowMenu();
                int.TryParse(Console.ReadLine(), out int userinput);
                switch (userinput) {
                    case 1: {
                            try
                            {
                                Services.GetAllCurreciesAsync(requestService).GetAwaiter().GetResult();                             
                            }
                            catch (FlurlHttpTimeoutException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed to establish connection");
                                Console.ResetColor();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Add code currency:\n");

                            try
                            {
                                Services.ShowCurrencyAsync(requestService, fileService).GetAwaiter().GetResult();
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

                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        {
                             try
                            {
                                Services.ShowConvertAsync(requestService, fileService).GetAwaiter().GetResult();
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
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
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


    }
}