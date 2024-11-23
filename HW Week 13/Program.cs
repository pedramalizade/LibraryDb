using HW_Week_13.AdminRepository;
using HW_Week_13.DbContextt;
using HW_Week_13.Entitis;
using HW_Week_13.Enum;
using HW_Week_13.Login_Register;
using HW_Week_13.Repository;
using HW_Week_13.Service;

IAdminRepository adminRepository = new AdminRepository();
IUserRepository userRepository = new UserRepository();
IBookRepository bookRepository = new BookRepository();
ILibraryService libraryService = new BookService();

Wellcome();
void Wellcome()
{
    while (true)
    {
        Console.WriteLine("1. Login: ");
        Console.WriteLine("2. Register: ");
        Console.WriteLine("Pleace choise an option: ");
        int Choice = int.Parse(Console.ReadLine());
        CheckOption(Choice);
    }
    void CheckOption(int choice)
    {
        switch (choice)
        {
            case 1:
                Console.Clear();
                Console.Write("Enter UserName: ");
                var username = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var password = Console.ReadLine();
                Console.Write("Enter Role: ");
                var role = int.Parse(Console.ReadLine());
                var loginUser = userRepository.Login(username, password, (RoleEnum)role);
                if(loginUser != null)
                {
                    if (role == 1)
                    {
                        UserMenu();
                    }
                    else if (role == 2)
                    {
                        AdminMenu();
                    }
                }
                else
                {
                    Wellcome();
                }


                break;
            case 2:
                Console.Clear();
                Console.Write("Enter UserName: ");
                var userName = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var Password = Console.ReadLine();
                Console.Write("Enter Email: ");
                var email = Console.ReadLine();
                Console.Write("Enter Role: ");
                var role1 = int.Parse(Console.ReadLine());
                var user = new User
                {
                    UserName = userName,
                    Password = Password,
                    Email = email,
                    Role = (RoleEnum)role1
                };
                var isRegister = userRepository.Register(user);
                if(isRegister == true)
                {
                    if (role1 == 1)
                    {
                        UserMenu();
                    }
                    else if (role1 == 2)
                    {
                        AdminMenu();
                    }
                }
                else
                {
                    Wellcome();
                }
                
                break;
            default:
                Console.WriteLine("Wrong Number!!!");
                Wellcome();
                break;
                
        }
    }
}

void UserMenu()
{
    while (true)
    {
        Console.WriteLine("----USER MENU----");
        Console.WriteLine("1. Borrowe a Book");
        Console.WriteLine("2. Return a Book");
        Console.WriteLine("3. Get List Of User Books");
        Console.WriteLine("4. Get List Of Library Books");
        Console.WriteLine("5. Logout");
        Console.Write("Chioce Option: ");

        int output = int.Parse(Console.ReadLine());
        CheckOutPut(output);
    }
    void CheckOutPut(int output)
    {
        switch (output)
        {
            case 1:
                foreach (var item in libraryService.GetListOfLibraryBooks())
                {
                    Console.WriteLine($"Id = {item.Id} + '=' + Title = {item.Title} + '|' + Writer = {item.Writer} + '|' + User Id = {item.UserId} + '|' +Genre = {item.Genre}");
                }
                Console.WriteLine("Enter Book ID: ");
                var BookId = int.Parse(Console.ReadLine());
                
                libraryService.BorrowBook(BookId, InMemoryDb.OnlineUser.Id);
                break;
            case 2:
                var userId = InMemoryDb.OnlineUser.Id;
                bookRepository.GetListOfUserBooks(userId);

                Console.WriteLine("Enter Book ID: ");
                var BookID = int.Parse(Console.ReadLine());
                libraryService.ReturnBook(BookID, userId);
                break;
            case 3:
                var userId2 = InMemoryDb.OnlineUser.Id;

                bookRepository.GetListOfUserBooks(userId2);
                break;
            case 4:
                foreach (var item in libraryService.GetListOfLibraryBooks())
                {
                    Console.WriteLine($"Id = {item.Id} + '=' + Title = {item.Title} + '|' + Writer = {item.Writer} + '|' + User Id = {item.UserId} + '|' +Genre = {item.Genre}");
                }
                break;
            case 5:
                userRepository.Logout();
                Wellcome();
                break;
            default:
                Console.WriteLine("Wrong Number!!!");
                break;
        }
    }
}

void AdminMenu()
{
    while (true)
    {
        Console.WriteLine("----ADMIN MENU----");
        Console.WriteLine("1. Show List Of Books");
        Console.WriteLine("2. Show List Of Users");
        Console.WriteLine("3. Update User");
        Console.WriteLine("3. Logout");
        Console.Write("Chioce Option: ");

        int output = int.Parse(Console.ReadLine());
        CheckOutPut2(output);
    }
    void CheckOutPut2(int output)
    {
        switch (output)
        {
            case 1:
                var books = adminRepository.ShowListOfBooks();
                foreach(var book in books)
                {
                    Console.WriteLine($"{book.Id} || {book.Title}");
                }
                break;
            case 2:
                var users = adminRepository.ShowListOfUsers();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} || {user.UserName}");
                }
                break;
            case 3:
                Console.WriteLine("ENter User Id");
                var userId = int.Parse(Console.ReadLine());
                adminRepository.UpdateUser(userId);
                break;
            case 4:
                userRepository.Logout();
                Wellcome();
                break;
            default:
                Console.WriteLine("Wrong Number!!!");
                break;
        }
    }
}
