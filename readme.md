This task reminds me of **0/1 Knapsack Problem**, where N is equivalent to the capacity of the Knapsack,
and topics are items inserted into it. Each topic has its weight Ti and value Ki, We want to maximise number of questions
we are able to answer, just as we want to maximise the total value of items in our knapsack.

I used the approach using dynamic programming with 1-dimensional array.
The idea is to iterate through items *i*, and for each item gradually increase the capacity of the knapsack.
hen we decide whether we include the item *i* or not by comparing configuration of items including *i*,
and configurations not containing *i* but taking up the same weight. Configuration with higher value for the current capacity is perserved.
