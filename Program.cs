// Updated at 11.10.2023

DateTime currentDate = DateTime.Now;

string[] daysOfWeek = {"Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"};
int currentDayOfWeek = (int) currentDate.DayOfWeek;
TimeSpan currentTime = currentDate.TimeOfDay;

/*
    Array with class and breaks schedule for lessons 1-5
*/

string[] classSchedule = {
"08:30", "09:15", "09:20", "10:05",
"10:15", "11:00", "11:05", "11:50",
"12:10", "12:55", "13:00", "13:45",
"14:00", "14:45", "14:50", "15:35",
"15:55", "16:40", "16:45", "17:30"};

string[] classScheduleExtended = {
    "1 пара, 1 половина",
    "перерыв 5 минут (пятиминутка) внутри 1 пары",
    "1 пара, 2 половина",
    "перерыв 10-20 минут между 1 и 2 парой",
    "2 пара, 1 половина",
    "перерыв 5 минут (пятиминутка) внутри 2 пары",
    "2 пара, 2 половина",
    "перерыв 10-20 минут между 2 и 3 парой",
    "3 пара, 1 половина",
    "перерыв 5 минут (пятиминутка) внутри 3 пары",
    "3 пара, 2 половина",
    "перерыв 10-20 минут между 3 и 4 парой",
    "4 пара, 1 половина",
    "перерыв 5 минут (пятиминутка) внутри 4 пары",
    "4 пара, 2 половина",
    "перерыв 10-20 минут между 4 и 5 парой",
    "5 пара, 1 половина",
    "перерыв 5 минут (пятиминутка) внутри 5 пары",
    "5 пара, 2 половина",
    "перерыв 10-20 минут между 5 и 6 парой",
};

/*
    Array with lessons shchedule: starting from Sunday, lessons 1-5
*/
string[,] weekSchedule = {
    {"Нет занятия", "Нет занятия", "Нет занятия", "Нет занятия", "Нет занятия"},
    {"[ЭОС] +ФКиС", "[ЭОС] -История", "[ЭОС] +ОРГ -История", "Нет занятия", "Нет занятия"},
    {"Нет занятия", "История", "Англ яз", "Зар. литер", "ОРГ"},
    {"Нет занятия", "Англ яз пр.", "УНТ", "Проза (Редькин)", "УНТ #2"},
    {"ФКиС", "Нет занятия", "ФКиС ЭЛ", "-ФКиС 2", ""},
    {"-Русская орфография", "Русская орфография", "Зар. литер", "Литературоведение", "+ Литературоведение"},
    {"Нет занятия", "Нет занятия", "Нет занятия", "Нет занятия", "Нет занятия"},
};

int currentLesson = 0;
foreach (string lesson in classSchedule) {
    TimeSpan lessonTimeSpan = TimeSpan.Parse(lesson);
    if (currentTime < lessonTimeSpan)
    {
        break;
    }
    else
    {
        currentLesson += 1;
    }
}

int pair = (currentLesson / 4) + 1;

Console.WriteLine("");
Console.WriteLine("#### Расписание ####");
Console.WriteLine($"# Текущий день: {currentDate.Day}.{currentDate.Month}.{currentDate.Year}, {daysOfWeek[currentDayOfWeek]}");
Console.WriteLine($"# Текущее время: {currentTime.Hours}:{currentTime.Minutes}");

Console.WriteLine("#### Текущее занятие ####");
if (currentLesson < 1)
{
    Console.WriteLine("# Занятия ещё не начались, либо имеется ошибка часов");
}
else
{
    Console.WriteLine($"# Сейчас промежуток № {currentLesson}, относится к {pair} паре");
    Console.WriteLine($"# В общем расписании: {classScheduleExtended[currentLesson-1]} ({classSchedule[currentLesson-1]}-{classSchedule[currentLesson]})");
    Console.WriteLine($"# Это занятие: {weekSchedule[currentDayOfWeek, pair-1]}");
}

int nextDayOfWeek = 0;
if (currentDayOfWeek == 6) {
    nextDayOfWeek = 0;
} else {
    nextDayOfWeek = currentDayOfWeek + 1;
}
Console.WriteLine("#### Завтра ####");
Console.WriteLine($"# Следующий день: {daysOfWeek[nextDayOfWeek]}");
Console.Write("# Вам на занятие: ");
for (int counter = 0; counter < 5; counter +=1 ) 
{
    if (weekSchedule[nextDayOfWeek, counter] != "Нет занятия")
    {
        Console.Write(weekSchedule[nextDayOfWeek, counter]);
        Console.Write($", это {counter+1} пара (к {classSchedule[counter*4]}).");
        break;
    }
}

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Нажмите ENTER, чтобы закрыть...");
Console.ReadLine();