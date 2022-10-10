using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        //создаем массив
        //по умолчанию предоставляем 0-9, где ноль не используется
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //По умолчанию игрок 1 установлен
        static int choice; //Здесь хранится выбор, в какой позиции пользователь хочет поставить отметку.
        //Переменная flag проверяет, кто выиграл, если ее значение равно 1, то кто-то выиграл матч.
        //если -1, то матч закончился, если 0, то матч продолжается
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();// когда цикл будет снова запущен, экран будет чистым.
                Console.WriteLine("Игрок1:X и Игрок2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//проверка шансов игрока
                {
                    Console.WriteLine("Игрок 2  ходит");
                }
                else
                {
                    Console.WriteLine("Игрок 1 ходит");
                }
                Console.WriteLine("\n");
                Board();// вызов доски Функция
                choice = int.Parse(Console.ReadLine());//Принимаем выбор пользователей
                // проверка того, что место, где пользователь хочет пробежаться, отмечено (X или O) или нет
                try
                {
                    if (arr[choice] != 'X' && arr[choice] != 'O')
                    {
                        if (player % 2 == 0) //если шанс принадлежит игроку 2, то отметить O, иначе отметить X
                        {
                            arr[choice] = 'O';
                            player++;
                        }
                        else
                        {
                            arr[choice] = 'X';
                            player++;
                        }
                    }
                    else
                    //Если есть место, где пользователь хочет использовать.
                    //и это уже отмечено, тогда покажите сообщение и загрузите доску снова
                    {
                        Console.WriteLine("К сожалению, строка {0} уже помечена {1}", choice, arr[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("Пожалуйста, подождите 2 секунды доска, снова загружается.....");
                        Thread.Sleep(2000);
                    }
                    flag = CheckWin();// вызов проверки выигрыша 
                }
                catch (IndexOutOfRangeException у)
                {
                    Console.WriteLine("Вы выбрали точку за границами доски");
                }

            }
            while (flag != 1 && flag != -1);
            // Этот цикл будет выполняться до тех пор, пока все ячейки сетки не будут помечены
            //с X и O или некоторый игрок не выиграл
            Console.Clear();// очистка консоли 
            Board();// снова заполненяем доску
            if (flag == 1)
            //если значение flag равно 1, то кто-то выиграл или
            //значит, кто сыграл в последний раз, тот и выиграл
            {
                Console.WriteLine("Игрок {0} победил", (player % 2) + 1);
            }
            else// если значение флага равно -1, то матч будет ничейным и никто не станет победителем
            {
                Console.WriteLine("Ничья");
            }
            Console.ReadLine();
        }
        // метод создания доски
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        //Проверка того, выиграл ли какой-либо игрок или нет
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Условие выигрыша для первого ряда
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Условие выигрыша для второго ряда
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Условие выигрыша для третьего ряда
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Условие выигрыша для первой колонки
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Условие выигрыша для второй колонки
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Условие выигрыша для третьей колонки
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            // Если все ячейки или значения заполнены X или O, то это ничья
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5'
                     && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}