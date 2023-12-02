// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to Day 1 of Advent of Code 2023");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

int solutionPart1 = part1(lines);

Console.WriteLine($"The total sum of the calibration is {solutionPart1}");

int solutionPart2 = part2(lines);

Console.WriteLine($"The total sum of the calibration after new information is {solutionPart2}");

Console.ReadLine();

static int part1(string[] input){
    int sumOfCalibrationValues = 0;
    foreach(string line in input){
        string calibrationString = string.Concat(line.Where(Char.IsDigit));
        char[] linenumbers = new char[2];

        linenumbers[0] = calibrationString[0];
        linenumbers[1] = calibrationString[calibrationString.Length - 1];

        int calibrationNumber = Int32.Parse(new string(linenumbers));

        sumOfCalibrationValues += calibrationNumber;
    }

    return sumOfCalibrationValues;
}

static int part2(string[] input) {
    int sumOfCalibrationValues = 0;

    foreach(string line in input) {

        string manipulatedString = line;
        bool replace = true;
        while (replace) {
            if (manipulatedString.Contains("eightwo")) {
                manipulatedString = manipulatedString.Replace("eightwo", "82");
            }
            else if (manipulatedString.Contains("twone")) {
                manipulatedString = manipulatedString.Replace("twone", "21");
            }
            else if (manipulatedString.Contains("oneight")) {
                manipulatedString = manipulatedString.Replace("oneight", "18");
            }
            else if (manipulatedString.Contains("one")) {
                manipulatedString = manipulatedString.Replace("one", "1");
            }
            else if (manipulatedString.Contains("two")) {
                manipulatedString = manipulatedString.Replace("two", "2");
            }
            else if (manipulatedString.Contains("three")) {
                manipulatedString = manipulatedString.Replace("three", "3");
            }
            else if (manipulatedString.Contains("four")) {
                manipulatedString = manipulatedString.Replace("four", "4");
            }
            else if (manipulatedString.Contains("five")) {
                manipulatedString = manipulatedString.Replace("five", "5");
            }
            else if (manipulatedString.Contains("six")) {
                manipulatedString = manipulatedString.Replace("six", "6");
            }
            else if (manipulatedString.Contains("seven")) {
                manipulatedString = manipulatedString.Replace("seven", "7");
            }
            else if (manipulatedString.Contains("eight")) {
                manipulatedString = manipulatedString.Replace("eight", "8");
            }
            else if (manipulatedString.Contains("nine")) {
                manipulatedString = manipulatedString.Replace("nine", "9");
            }
            else
                replace = false;
        }

        string calibrationString = string.Concat(manipulatedString.Where(Char.IsDigit));
        char[] linenumbers = [calibrationString[0], calibrationString[calibrationString.Length - 1]];

        int calibrationNumber = Int32.Parse(new string(linenumbers));

        sumOfCalibrationValues += calibrationNumber;
    }

    return sumOfCalibrationValues;
}