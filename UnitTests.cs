using System.Diagnostics;

namespace OptimalStudy;

public static class UnitTests
{
    struct TestCase
    {
        public Topic[] Topics;
        public int TimeAvailable;
        public int ExpectedQuestionsLearnt;
    }
    
    private static readonly TestCase[] TestCases = {
        new() {
            Topics = new Topic[] {
                new("Topic 1", 10, 1),
                new("Topic 2", 15, 2),
                new("Topic 3", 40, 3),
            },
            TimeAvailable = 5,
            ExpectedQuestionsLearnt = 55
        },
        new() {
            Topics = new Topic[] {
                new("Topic 1", 10, 1),
                new("Topic 2", 15, 2),
                new("Topic 3", 40, 3),
            },
            TimeAvailable = 6,
            ExpectedQuestionsLearnt = 65
        },
        new() {
            Topics = new Topic[] {
                new("Topic 1", 20, 1),
                new("Topic 2", 30, 1),
                new("Topic 3", 60, 1),
            },
            TimeAvailable = 1,
            ExpectedQuestionsLearnt = 60
        },
        new() {
            Topics = new Topic[] {
                new("Topic 1", 20, 2),
                new("Topic 2", 30, 2),
                new("Topic 3", 60, 2),
            },
            TimeAvailable = 1,
            ExpectedQuestionsLearnt = 0
        },
        new()
        {
            Topics = new Topic[] {
                new("Topic 1", 40, 4),
                new("Topic 2", 30, 3),
                new("Topic 3", 20, 2),
                new("Topic 4", 50, 5),
            },
            TimeAvailable = 10,
            ExpectedQuestionsLearnt = 100
        },
        new() {
            Topics = new Topic[] {
                new("Topic 1", 0, 0),
                new("Topic 2", 0, 20),
                new("Topic 3", 0, 40),
                new("Topic 4", 0, 80),
                new("Topic 5", 0, 120),
            },
            TimeAvailable = 100,
            ExpectedQuestionsLearnt = 0
        },
        new() {
            Topics = new Topic[] {
                new("Topic 1", 100, 0),
                new("Topic 2", 200, 0),
                new("Topic 3", 400, 0),
                new("Topic 4", 500, 0),
            },
            TimeAvailable = 1,
            ExpectedQuestionsLearnt = 1200
        },
        new() {
            Topics = new Topic[] {
                new("Topic 1", 100, 0),
                new("Topic 2", 200, 0),
                new("Topic 3", 400, 0),
                new("Topic 4", 500, 0),
            },
            TimeAvailable = 0,
            ExpectedQuestionsLearnt = 0
        },
        
    };
    
    public static void Run()
    {
        foreach (TestCase test in TestCases)
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