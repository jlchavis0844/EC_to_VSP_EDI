using EC_to_VSP_EDI;
using System;
using System.IO;

public static class InterchangeTracker {
    public static string CWD = Directory.GetCurrentDirectory();
    public static string FILENAME = @"\ict.dat";

    public static uint GetInterchangeNumber() {
        if (File.Exists(CWD + FILENAME)) {
            //return Convert.ToUInt32(File.ReadAllText(CWD + FILENAME).Trim());
            return Convert.ToUInt32(File.ReadAllLines(CWD + FILENAME)[0].Trim());
        } else {
            if (CreateNewInterchange()) {
                return (uint)1;
            } else return (uint)0;
        }
    }

    public static string GetInterchangeDate() {
        if (File.Exists(CWD + FILENAME)) {
            //return Convert.ToUInt32(File.ReadAllText(CWD + FILENAME).Trim());
            return File.ReadAllLines(CWD + FILENAME)[1].Trim();
        } else {
            if (CreateNewInterchange()) {
                return GetInterchangeDate();
            } else return null;
        }
    }

    public static string GetInterchangeTime() {
        if (File.Exists(CWD + FILENAME)) {
            //return Convert.ToUInt32(File.ReadAllText(CWD + FILENAME).Trim());
            return File.ReadAllLines(CWD + FILENAME)[2].Trim();
        } else {
            if (CreateNewInterchange()) {
                return GetInterchangeTime();
            } else return null;
        }
    }

    public static uint IncrementNumber() {
        try {
            uint temp = GetInterchangeNumber() + 1;
            string value = temp + "\n" + GetInterchangeDate() + "\n" + GetInterchangeTime();
            File.WriteAllText(CWD + FILENAME, value);
            return temp;
        } catch (Exception e) {
            Form1.log.Error(e);
            //Console.WriteLine(e);
            return 0;
        }
    }

    public static uint DecrementNumber() {
        try {
            uint temp = GetInterchangeNumber() - 1;
            string value = temp + "\n" + GetInterchangeDate() + "\n" + GetInterchangeTime();
            File.WriteAllText(CWD + FILENAME, value);
            return temp;
        } catch (Exception e) {
            Form1.log.Error(e);
            return 0;
        }
    }

    public static bool SetInterchangeNumber(uint newNumber) {
        try {
            string value = newNumber + "\n" + GetInterchangeDate() + "\n" + GetInterchangeTime();
            File.WriteAllText(CWD + FILENAME, value);
        } catch (Exception e) {
            Form1.log.Error(e);
            return false;
        }

        return GetInterchangeNumber() == newNumber;
    }

    public static bool SetInterchangeDate(DateTime newDate) {
        try {
            string value = GetInterchangeNumber() + "\n" + newDate.ToString("yyMMdd") + "\n" + GetInterchangeTime();
            File.WriteAllText(CWD + FILENAME, value);
        } catch (Exception e) {
            Form1.log.Error(e);
            return false;
        }

        return GetInterchangeDate() == newDate.ToString("yyMMdd");
    }

    public static bool SetInterchangeTime(DateTime newTime) {
        try {
            string value = GetInterchangeNumber() + "\n" + GetInterchangeDate() + "\n" + newTime.ToString("hhmm");
            File.WriteAllText(CWD + FILENAME, value);
        } catch (Exception e) {
            Form1.log.Error(e);
            return false;
        }

        return GetInterchangeDate() == newTime.ToString("hhmm");
    }

    public static bool CreateNewInterchange() {
        try {
            DateTime now = DateTime.Now;
            string newFile = "1\n" + now.ToString("yyMMdd") + "\n" + now.ToString("hhmm");
            File.WriteAllText(CWD + FILENAME, newFile);
            return true;
        } catch (Exception e) {
            //Console.WriteLine(e);
            Form1.log.Error(e);
            return false;
        }
    }

    public static bool UpdateInterchange() {
        uint oldNum = GetInterchangeNumber();
        bool numUpdated = (oldNum < IncrementNumber()) && (oldNum > 1);

        if (!numUpdated)
            return false;

        DateTime now = DateTime.Now;
        if (!SetInterchangeDate(now)) {
        return false;
        } else if (!SetInterchangeTime(now)) {
            return false;
        } else return true;
    }

    public static new string ToString() {
        return GetInterchangeNumber() + "\n" + GetInterchangeDate() + "\n" + GetInterchangeTime();
    }
}
