using System.Diagnostics;
using System.Text.Json;

namespace OptimalStudy;

public class UnitTests
{
    struct TestCase
    {
        public Topic[] Topics { get; init; }
        public int TimeAvailable { get; init; }
        public int ExpectedQuestionsLearnt { get; init; }
    }

    private readonly TestCase[] _testCases;
        
    public UnitTests(string jsonTestFile)
    {
        var jsonContent = File.ReadAllText(jsonTestFile);
        _testCases = JsonSerializer.Deserialize<TestCase[]>(jsonContent);
    }

    public void Run()
    {
        foreach (TestCase test in _testCases)
        {
            var solution = new Knapsack<Topic>(
                test.TimeAvailable,
                test.Topics,
                test.Topics.Select(topic => topic.TimeToLearn).ToArray(),
                test.Topics.Select(topic => topic.Questions).ToArray()
            );
            
            Debug.Assert(solution.MaxProfit == test.ExpectedQuestionsLearnt);
        }
    }
}