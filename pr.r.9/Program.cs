//***********************************************************************
//* Практическая работа № 9                                             *
//* Выполнила: Кондратюк Е.С., группа 2ИСП                              *
//* Задание: Высокоуровневые языки програмирования                      *
//***********************************************************************
using System;
namespace pr.r._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            while (true)
            {
                try // поиск ошибок
                {
                    // 1. Настройка консоли и приветствие
                    Console.Title = "Практическая работа №9"; // Заголовок
                    Console.BackgroundColor = ConsoleColor.DarkYellow; 
                    Console.ForegroundColor = ConsoleColor.White; 
                    Console.WriteLine("Здравствуйте!"); 
                    Console.WriteLine("Пожалуйста, введите элементы массива:"); 
                    // 2. Объявление и инициализация
                    const int sizeArrayA = 15; // задание размера массива
                    double[] arrayA = new double[sizeArrayA]; // массив вещественных чисел
                    int i = 0;
                    bool error; // error - флаг обнаружения ошибки при вводе элементов массива
                    // 3. Заполнение массива с клавиатуры
                    while (i < sizeArrayA)
                    {
                        error = false; // ошибки нет
                        Console.Write($"Введите массив {i + 1}: "); 
                        try
                        {
                            arrayA[i] = Convert.ToDouble(Console.ReadLine()); // запись числа в текущий элемент массива
                        }
                        catch (FormatException e) // обработка исключения
                        {
                            error = true; // ошибка ввода
                            Console.WriteLine("Возникла ошибка: " + e.Message); 
                        }
                        if (!error) i++; //  ошибки нет, переход к следующему элементу массива
                    }
                    // 4. Поиск минимального по модулю элемента
                    double min = arrayA[0]; // первый элемент = минимальный по модулю
                    for (i = 1; i < sizeArrayA; i++)
                    {
                        if (Math.Abs(min) > Math.Abs(arrayA[i])) // сравнение модулей текущего минимума и элемента
                        {
                            min = arrayA[i]; // найден новый минимум, обновляем значение
                        }
                    }
                    // 5. Вывод результата на экран
                    Console.WriteLine($"\nМинимальный по модулю элемент массива = {min}"); 
                }
                catch (Exception e) // обработка исключения
                {
                    Console.WriteLine("Возникла ошибка: " + e.Message);
                }
                bool rightСhoice = false; // флаг: ввел ли пользователь корректное значение
                while (!rightСhoice)
                {
                    try
                    {
                        Console.WriteLine("\nХотите выполнить программу еще раз? (0 - да, 1 - нет)");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice) // проверка выбранного значения
                        {
                            case 0:
                                rightСhoice = true;
                                break; // программа запустится заново
                            case 1:
                                return; // выход из программы
                            default:
                                Console.WriteLine("Ошибка: введите 0 или 1.");
                                break;
                        }
                    }
                    catch (FormatException) // обработка исключения 
                    {
                        Console.WriteLine("Ошибка: введено не число. Попробуйте снова.");
                    }
                    catch (Exception e) 
                    {
                        Console.WriteLine("Возникла ошибка: " + e.Message);
                    }
                }
            }
        }
    }
}