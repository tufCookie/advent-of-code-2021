using System.Reflection;
using System.IO;

public class SonarSweep {
    private int[] _array;
    private string _file;
    private int _numberOfIncreasesPerLine;
    private bool _isNumberOfIncreasesSetPerLine = false;

    private int _numberOfIncreasesPerSlidingWindow;
    private bool _isNumberOfIncreasesSetPerSlidingWindow = false;

    public SonarSweep(string file){
        _file = file;
        Console.WriteLine(_file);
        GetData();
    }

    private void GetData(){
        string[] lines = System.IO.File.ReadAllLines(_file);
        if(lines.Count() > 3)
            _array =  Array.ConvertAll(lines, s => int.Parse(s));
        else
            Console.WriteLine("Error: the file has less than 3 integers.");
    }

    public void DisplayIncreasePerLine(){
        if(_isNumberOfIncreasesSetPerLine){
            Console.WriteLine($"The number of increases is {_numberOfIncreasesPerLine}");
            return; 
        }

        int previousNumber = _array[0];
        for (int i = 1; i < _array.Count(); ++i){
            if(_array[i] > previousNumber)
                ++_numberOfIncreasesPerLine;
            previousNumber = _array[i];
        }

        Console.WriteLine($"The number of increases is {_numberOfIncreasesPerLine}");
        _isNumberOfIncreasesSetPerLine = true;
    }

    public void DisplayIncreasePerSlidingWindow(){
        if(_isNumberOfIncreasesSetPerSlidingWindow){
            Console.WriteLine($"The number of increases is {_numberOfIncreasesPerSlidingWindow}");
            return; 
        }

        int previousSum = _array[0] + _array[1] + _array[2];
        for (int i = 1; i < _array.Count() - 2; ++i){
            int sum = _array[i] + _array[i + 1] + _array[i + 2];
            if(sum > previousSum)
                ++_numberOfIncreasesPerSlidingWindow;
            previousSum = sum;
        }

        Console.WriteLine($"The number of increases is {_numberOfIncreasesPerSlidingWindow}");
        _isNumberOfIncreasesSetPerLine = true;
    }

}