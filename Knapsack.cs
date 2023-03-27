namespace OptimalStudy;

public class Knapsack<T>
{
    struct KnapsackState
    {
        public int MaxProfit;
        public List<T> InsertedItems;
    }
    public int Capacity { get; private set; }
    public T[] ItemOptions { get; private set; }
    public int[] Weights { get; private set; }
    public int[] Values { get; private set; }
    public int ValueCount => Values.Length;
    public int MaxProfit { get; private set; }
    public List<T> OptimalItems { get; private set; }
    
    public Knapsack(int capacity, T[] itemOptions, int[] weights, int[] values)
    {
        Capacity = capacity;
        ItemOptions = itemOptions;
        Weights = weights;
        Values = values;

        GetMaxProfit();
    }
    
    private int GetMaxProfit()
    {
        OptimalItems = new List<T>();
        var stateSpace = new KnapsackState[Capacity + 1];
        int maxProfit = 0;

        for (int i = 0; i < ValueCount; i++)
        {
            for (int usedWeight = Capacity; usedWeight > 0; usedWeight--)
            {
                if (usedWeight < Weights[i])
                    continue;
                
                int itemValue = Values[i];
                ref KnapsackState currentState = ref stateSpace[usedWeight];
                
                int valueBeforeAddingItem = stateSpace[usedWeight - Weights[i]].MaxProfit;
                int valueWithItem = valueBeforeAddingItem + itemValue;
                int valueWithoutItem = currentState.MaxProfit;

                if (valueWithItem > valueWithoutItem)
                {
                    var currentItems = stateSpace[usedWeight - Weights[i]].InsertedItems;
                    currentItems ??= new List<T>();

                    currentState.InsertedItems = new List<T>(currentItems);
                    currentState.InsertedItems.Add(ItemOptions[i]);
                    currentState.MaxProfit = valueWithItem;
                } 
            }
        }

        KnapsackState finalState = stateSpace[^1];
        MaxProfit = finalState.MaxProfit;
        OptimalItems = finalState.InsertedItems;
        
        return MaxProfit;
    }
}