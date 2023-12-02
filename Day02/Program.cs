// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! Welcome to Day 2 of Advent of Code 2023");
Console.WriteLine();

string path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "/Input.txt";
string[] lines = File.ReadAllLines(path);

int solutionPart1 = part1(lines);

Console.WriteLine($"The total sum of the ID:s if possible games is {solutionPart1}");

int solutionPart2 = part2(lines);

Console.WriteLine($"The total sum of the power of the lowest amount of cubes is {solutionPart2}");

Console.ReadLine();

static int part1(string[] lines) {
    int sumOfPossibleID = 0;

    int redCubes = 12;
    int greenCubes = 13;
    int blueCubes = 14;

    foreach (string line in lines) {
        bool isPossible = true;
        string[] firstSplitArray = line.Split(':');
        int id = Int32.Parse(new string(firstSplitArray[0].Where(Char.IsDigit).ToArray()));
        string[] secondSplitArray = firstSplitArray[1].Split(";");
        foreach(string draw in secondSplitArray) {
            string[] drawResult = draw.Split(",");
            foreach(string result in drawResult) {
                if (result.Contains("green")) {
                    int greenresult = Int32.Parse(new string(result.Where(char.IsDigit).ToArray()));
                    if(greenresult > greenCubes) {
                        isPossible = false;
                    }
                } else if(result.Contains("blue")) {
                    int blueresult = Int32.Parse(new string(result.Where(char.IsDigit).ToArray()));
                    if(blueresult > blueCubes) {
                        isPossible = false;
                    }
                } else {
                    int redresult = Int32.Parse(new string(result.Where(char.IsDigit).ToArray()));
                    if(redresult > redCubes) {
                        isPossible = false;
                    }
                }
            }
        }

        if(isPossible) {
            sumOfPossibleID += id;
        }
    }
    return sumOfPossibleID;
}

static int part2(string[] lines) {
    int sumOfPowerFromGames = 0;

    foreach (string line in lines) {
        int highestBlue = 0, highestRed = 0, highestGreen = 0;
        string[] firstSplitArray = line.Split(':');
        string[] secondSplitArray = firstSplitArray[1].Split(";");
        foreach (string draw in secondSplitArray) {
            string[] drawResult = draw.Split(",");
            foreach (string result in drawResult) {
                if (result.Contains("green")) {
                    int greenresult = Int32.Parse(new string(result.Where(char.IsDigit).ToArray()));
                    if (greenresult > highestGreen) {
                        highestGreen = greenresult;
                    }
                }
                else if (result.Contains("blue")) {
                    int blueresult = Int32.Parse(new string(result.Where(char.IsDigit).ToArray()));
                    if (blueresult > highestBlue) {
                        highestBlue = blueresult;
                    }
                }
                else {
                    int redresult = Int32.Parse(new string(result.Where(char.IsDigit).ToArray()));
                    if (redresult > highestRed) {
                        highestRed = redresult;
                    }
                }
            }
        }
        int powerOfResults = (highestRed * highestGreen * highestBlue);
        sumOfPowerFromGames += powerOfResults;
    }
    return sumOfPowerFromGames;
}