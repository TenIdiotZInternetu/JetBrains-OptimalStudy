namespace OptimalStudy;

public class Topic
{
    public string Name { get; set; }
    public int Questions { get; private set; }
    public int TimeToLearn { get; private set; }
    
    public Topic(string name, int questions, int timeToLearn)
    {
        Name = name;
        Questions = questions;
        TimeToLearn = timeToLearn;
    }
}