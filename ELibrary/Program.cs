using ELibrary.Repository;

namespace ELibrary
{
    internal class Program
    {
        static BookRepository bookRepository;
        static UserRepository userRepository;
        static void Main(string[] args)
        {
            bookRepository= new BookRepository();
            userRepository= new UserRepository();

            Console.WriteLine("Список доступных операций:");
            Console.WriteLine("1 - добавить нового пользователя");
            Console.WriteLine("2 - удалить пользователя по id");
            Console.WriteLine("3 - обновить имя пользователя");
            Console.WriteLine("4 - выбрать всех пользователей");
            Console.WriteLine("5 - выбрать пользователя по id");
            Console.WriteLine("6 - добавить новую книгу");
            Console.WriteLine("7 - удалить книгу по id");
            Console.WriteLine("8 - обновить данные книги");
            Console.WriteLine("9 - выбрать все книги");
            Console.WriteLine("10 - выбрать книгу по id");
            Console.WriteLine("11 - получить список книг по жанру и за указанный период");
            Console.WriteLine("12 - получить кол-во книг определенного автора");
            Console.WriteLine("13 - получить кол-во книг определенного жанра");
            Console.WriteLine("14 - есть ли книга указанного автора и жанра");
            Console.WriteLine("15 - есть ли определенная книга на руках у пользователя");
            Console.WriteLine("16 - кол-во книг на руках у пользователя");
            Console.WriteLine("17 - получить последунюю вышедшую книгу");
            Console.WriteLine("18 - список всех книг в алфавитном порядке");
            Console.WriteLine("19 - список всех книг в порядке убывания года выхода");
            Console.WriteLine("stop - остановить выполнение операций");

            Console.WriteLine();
            string operation;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите номер операции:");
                operation = Console.ReadLine();
                Console.WriteLine();
                switch (operation)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите имя пользователя:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите email пользователя:");
                            string? email = Console.ReadLine();
                            Console.WriteLine("Введите роль пользвоателя:");
                            string role = Console.ReadLine();
                            userRepository.Add(name, email, role);
                            Console.WriteLine("Пользователь успешно добавлен!");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите id пользователя для удаления:");
                            userRepository.Delete(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Пользователь успешно удален!");
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите id пользователя для обновления:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новое имя пользователя");
                            string name = Console.ReadLine();
                            userRepository.UpdateUserName(id, name);
                            Console.WriteLine("Данные пользователя успешно обновлены!");
                            break;
                        }
                    case "4":
                        {
                            var listUsers = userRepository.SelectAll();
                            foreach (var user in listUsers)
                            {
                                Console.WriteLine($"id: {user.Id}; Имя: {user.Name}; Роль: {user.Role}; Email: {user.Email}");
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите id пользователя:");
                            int id = int.Parse(Console.ReadLine());
                            var user = userRepository.SelectByID(id);
                            Console.WriteLine($"Выбранный пользователь: имя: {user.Name}; email: {user.Email}");
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Введите наименование книги:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите год выпуска:");
                            int year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите автора:");
                            string author = Console.ReadLine();
                            Console.WriteLine("Введите жанр:");
                            string genre = Console.ReadLine();
                            bookRepository.Add(name, year, author, genre);
                            Console.WriteLine("Книга успешно добавлена!");
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Введите id книги для удаления:");
                            bookRepository.Delete(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Книга успешно удалена!");
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Введите id книги для обновления:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новое наименование книги:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите год выпуска книги:");
                            int year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите автора книги:");
                            string author = Console.ReadLine();
                            Console.WriteLine("Введите жанр книги:");
                            string genre = Console.ReadLine();
                            bookRepository.Update(id, name, year, author, genre);
                            Console.WriteLine("Данные пользователя успешно обновлены!");
                            break;
                        }
                    case "9":
                        {
                            var listBooks = bookRepository.SelectAll();
                            foreach (var book in listBooks)
                            {
                                Console.WriteLine($"id: {book.Id}; Имя: {book.Name}; Год выпуска: {book.Year}; Автор: {book.Author}; Жанр: {book.Genre}");
                            }
                            break;
                        }
                    case "10":
                        {
                            Console.WriteLine("Введите id книги:");
                            int id = int.Parse(Console.ReadLine());
                            var book = bookRepository.SelectByID(id);
                            Console.WriteLine($"Выбранная книга: наименвоание: {book.Name}; Год выпуска: {book.Year}; Автор: {book.Author}; Жанр: {book.Genre}");
                            break;
                        }
                    case "11":
                        {
                            Console.WriteLine("Введите жанр книги:");
                            string genre = Console.ReadLine();
                            Console.WriteLine("Введите начало периода:");
                            int startPeriod = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите конец периода:");
                            int endPeriod = int.Parse(Console.ReadLine());
                            var listBooks = bookRepository.ListOfBooksByGenreAndYear(genre, endPeriod, endPeriod);
                            if (listBooks.Count() == 0)
                                Console.WriteLine("По указанным критериям отбора ничего не найдено!");
                            foreach (var book in listBooks)
                            {
                                Console.WriteLine($"id: {book.Id}; Имя: {book.Name}; Год выпуска: {book.Year}; Автор: {book.Author}; Жанр: {book.Genre}");
                            }
                            break;
                        }
                    case "12":
                        {
                            Console.WriteLine("Введите автора книги:");
                            string author = Console.ReadLine();
                            var count = bookRepository.CountOfBokksByAuthor(author);
                            Console.WriteLine($"Количество книг автора {author} - {count.ToString()}");
                            break;
                        }
                    case "13":
                        {
                            Console.WriteLine("Введите жанр книги:");
                            string genre = Console.ReadLine();
                            var count = bookRepository.CountOfBoksByGenre(genre);
                            Console.WriteLine($"Количество книг жанра {genre} - {count.ToString()}");
                            break;
                        }
                    case "14":
                        {
                            Console.WriteLine("Введите автора книги:");
                            string author = Console.ReadLine(); 
                            Console.WriteLine("Введите жанр книги:");
                            string genre = Console.ReadLine();
                            var existsBook = bookRepository.ExistsBookByAuthorAndGenre(author, genre);
                            Console.WriteLine(existsBook == true ? "Книга есть в блиблиотеке" : "Книги нет в библиотеке");
                            break;
                        }
                    case "15":
                        {
                            Console.WriteLine("Введите id книги:");
                            int id = int.Parse(Console.ReadLine());
                            var existsBook = bookRepository.ExistsUserHaveBook(id);
                            Console.WriteLine(existsBook == true ? "Книга на руках у пользователя" : "Книга в библиотеке");
                            break;
                        }
                    case "16":
                        {
                            Console.WriteLine("Введите id пользователя:");
                            int id = int.Parse(Console.ReadLine());
                            var cout = bookRepository.CountOfBooksHasUser(id);
                            Console.WriteLine($"У пользователя с id: {id} {cout.ToString()} книг");
                            break;
                        }
                    case "17":
                        { 
                            var book = bookRepository.LastPublishedBooks();
                            Console.WriteLine($"Последняя вышедшая книга: '{book.Name}' автора '{book.Author}'");
                            break;
                        }
                    case "18":
                        {
                            var listBooks = bookRepository.AllBooksOrderByName();
                            foreach (var book in listBooks)
                            {
                                Console.WriteLine($"id: {book.Id}; Имя: {book.Name}; Год выпуска: {book.Year}; Автор: {book.Author}; Жанр: {book.Genre}");
                            }
                            break;
                        }
                    case "19":
                        {
                            var listBooks = bookRepository.AllBooksOrderByYearDesc();
                            foreach (var book in listBooks)
                            {
                                Console.WriteLine($"id: {book.Id}; Имя: {book.Name}; Год выпуска: {book.Year}; Автор: {book.Author}; Жанр: {book.Genre}");
                            }
                            break;
                        }
                }
            }
            while (operation != "stop");
        }
    }
}