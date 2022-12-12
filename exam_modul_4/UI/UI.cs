
using exam_modul_4.Service;

namespace exam_modul_4.UI;

public class UI
{
    private IService service;

    public UI()
    {
        service = new exam_modul_4.Service.Service();
        Menu();
    }

    public void Menu()
    {
        Console.Clear();
        TextMenu();
        int k = int.Parse(Console.ReadLine()!);
        switch (k)
        {
            case 2:
                Environment.Exit(0);
                break;
            case 1:
                
                int role = (int)service.LoginAsync().Result;
                switch (role)
                {
                    case 0:
                        MainMenuForUser();
                        break;
                    case 1:
                        MainMenuForCompany();
                        break;
                    case 2:
                        MainMenuForAdmin();
                        break;
                }
                break;
            case 0:
                service.RegistrationAsync().Wait();
                Menu();
                break;

        }
        
    }

    public void MainMenuForUser()
    {
        Console.Clear();
        MainMenuForUser();
        int j = int.Parse(Console.ReadLine()!);
        switch (j)
        {
            case 2:
                Menu();
                break;
            case 1:

                break;
            case 0:
                break;
        }
        
    }

    public void MainMenuForAdmin()
    {
        Console.Clear();
        MainMenuTextForAdmin();
        int i = int.Parse(Console.ReadLine()!);
        switch (i)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("=======================  Applications =======================");
                service.PrintAllAplications();
                break;
            case 1:
                Console.Clear();
                Console.WriteLine("=======================  Room Add  =======================");
                service.AddRoomAsync().Wait();
                MainMenuForAdmin();
                break;
            case 2:
                Menu();
                break;
        }
    }
    public void MainMenuForCompany()
    {
        Console.Clear();
        MainMenuTextForCompany();
        int i = int.Parse(Console.ReadLine()!);
        switch (i)
        {
            case 0:
                Console.Clear();
                service.PrintAllRoomsAsync();
                Thread.Sleep(2000);
                MainMenuForCompany();
                break;
            case 1:
                Console.Write("Your planning date :");
                var date = DateTime.Parse(Console.ReadLine()!);
                service.PrintRoomsByDate(date);
                Thread.Sleep(2000);
                MainMenuForCompany();
                break;
            case 2:
                Menu();
                break;
        }
    }
    public void TextMenu()
    {
        Console.WriteLine("0. Registration");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Exit");
        Console.Write("\tChoose : ");
    }

    public void MainMenuTextForUser()
    {
        Console.WriteLine("0. Event list");
        Console.WriteLine("1. Reservation");
        Console.WriteLine("2. Exit");
        Console.Write("\tChoose : ");
    }

    public void MainMenuTextForCompany()
    {
        Console.WriteLine("0. All Rooms");
        Console.WriteLine("1. Event planing");
        Console.WriteLine("2. Exit");
        Console.Write("\tChoose : ");
    }

    public void MainMenuTextForAdmin()
    {
        Console.WriteLine("0. Applications");
        Console.WriteLine("1. Room (Update/Add/Delete)");
        Console.WriteLine("2. Exit");
        Console.Write("\tChoose : ");
    }
}
