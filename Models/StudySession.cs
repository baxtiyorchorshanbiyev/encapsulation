namespace Encapsulation.Models;

class StudySession
{
    public string Topic { get; private set; }
    public int SpentMinutes { get; private set; } = 0;
    private int _plannedMinutes;
    public int PlannedMinutes
    {
        get => _plannedMinutes;
        set
        {
            if (value < 10 || value > 120 || value < SpentMinutes)
            {
                throw new ArgumentOutOfRangeException("Reja 10-120 oralig'ida va Sarflangan vaqtdan kam bo'lmasligi kerak!");
            }
            _plannedMinutes = value;
        }
    }
    public StudySession(string topic, int plannedMinutes)
    {
        Topic = string.IsNullOrWhiteSpace(topic) ? "" : topic;
        PlannedMinutes = plannedMinutes;
    }

    bool RecordMinutes(int minutes)
    {
        if (minutes > 0 && (minutes + SpentMinutes) <= PlannedMinutes)
        {
            SpentMinutes += minutes;
            return true;
        }
        return false;
    }

    public int GetRemainingMinutes() => PlannedMinutes - SpentMinutes;

    public static void RunTest()
    {
        Console.WriteLine("------");
        StudySession session = new StudySession("C#", 40);
        Console.WriteLine($"Kutilgan natija: {session.RecordMinutes(25)}; Sarflangan vaqt: {session.SpentMinutes}");
        Console.WriteLine($"Kutilgan natija: {session.RecordMinutes(20)}; Sarflangan vaqt: {session.SpentMinutes}");
        session.PlannedMinutes = 60;
        Console.WriteLine($"Reja: {session.PlannedMinutes}; Qolgan vaqt: {session.GetRemainingMinutes()}");
        try
        {
            session.PlannedMinutes = 20;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Xatolik: {ex.Message}");
        }
        Console.WriteLine($"Kutilgan natija: {session.RecordMinutes(35)}; Qolgan vaqt: {session.GetRemainingMinutes()}");
    }

}