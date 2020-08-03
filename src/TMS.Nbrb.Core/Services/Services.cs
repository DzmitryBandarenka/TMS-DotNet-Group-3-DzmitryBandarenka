
using System;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Services;

public class Services

{
    /// <summary>
    /// Показать меню.
    /// </summary>
    public static void ShowMenu()
    {

        Console.WriteLine("Possible actions:\n");
        Console.WriteLine("Click 1: Request all currincies");
        Console.WriteLine("Click 2: Request rates from one currency and write to file");
        Console.WriteLine("Click 3: Currency conversion into BYN and write to file");
        Console.WriteLine("Click 4: Exit");
    }

    /// <summary>
    /// Показать список всех валют.
    /// </summary>
    /// <param name="requestService">список валют</param>
    /// <returns></returns>
    public static async Task GetAllCurreciesAsync(IRequestService requestService)
    {
        var data = await requestService.GetAllCurreciesAsync();
        foreach (var item in data)
        {
            Console.WriteLine(item.Cur_ID + " " + item.Cur_Name + " " + item.Cur_Code + " " + item.Cur_Abbreviation);
        }
    }
   /// <summary>
   /// Показать валюту
   /// </summary>
   /// <param name="requestService">Список валют.</param>
   /// <param name="fileService">Закпись в файл.</param>
   /// <returns></returns>
        public static async Task ShowCurrencyAsync(IRequestService requestService, IFileService fileService)
        {
            string code = Console.ReadLine();
            var rate =await requestService.GetRatesAsync(code);
            Console.WriteLine(rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate);
            string writeToFile = rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate;
            fileService.WriteToFileAsync(writeToFile);
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestService">Список валют.</param>
    /// <param name="fileService">Запись в файл.</param>
    /// <returns></returns>
    public static async Task ShowConvertAsync(IRequestService requestService, IFileService fileService)
    {
    Console.WriteLine("Enter amount:\n");
    decimal amount = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Add code currency:\n");
    string code = Console.ReadLine();
    var rate = await requestService.GetRatesAsync(code);
    Console.WriteLine(rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate);
    string writeToFile = rate.Cur_ID + " " + rate.Cur_Abbreviation + " " + rate.Cur_Name + " " + rate.Cur_OfficialRate;
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(amount + " " + rate.Cur_Abbreviation + " = " + Convert.ToDecimal(rate.Cur_OfficialRate) / rate.Cur_Scale* amount + " BYN");
    Console.ResetColor();
    fileService.WriteToFileAsync(writeToFile);
    } 
}
