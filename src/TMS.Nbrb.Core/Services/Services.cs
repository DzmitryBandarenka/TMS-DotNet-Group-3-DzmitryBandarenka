
using System;
using System.Threading.Tasks;
using TMS.Nbrb.Core.Interfaces;
using TMS.Nbrb.Core.Services;

public class Services

{
    IRequestService requestService = new RequestService();
    IFileService fileService = new FileService();

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

}