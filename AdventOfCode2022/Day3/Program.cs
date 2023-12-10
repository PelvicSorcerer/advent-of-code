using System.Text.RegularExpressions;

using Day3;

var pattern = new Regex(@"([a-zA-Z]+)(\r\n|$)");
var matches = pattern.Matches(Day3.Properties.Resources.input);

//Dictionary<char, int> items = new Dictionary<char, int>();
List<char> items = new List<char>();

//var match = matches[0].Groups[1].Value;

ReadRucksacks();

int prioritySum = 0;
foreach (var item in items)
{
    //prioritySum += GetPriority(item.Key);
    prioritySum += GetPriority(item);
}



Console.WriteLine("Hello, World!");


#region Support Methods

void ReadRucksacks()
{
    foreach (var match in matches)
    {
        ReadRucksack(((Match)match).Groups[1].Value);
    }
}

void ReadRucksack(string line)
{
    //var items = new Dictionary<char, int>();
    
    Dictionary<char, int> comp1Items = new Dictionary<char, int>();
    Dictionary<char, int> comp2Items = new Dictionary<char, int>();

    var compartmentSize = line.Length/2;
    var compartment1 = line.Substring(0, compartmentSize);
    var compartment2 = line.Substring(compartmentSize, compartmentSize);

    var comp1Array = compartment1.ToArray<char>();
    var comp2Array = compartment2.ToArray<char>();

    foreach (var letter in compartment1)
    {
        //var item = new Item(letter);
        if (!comp1Items.TryAdd(letter, 1))
        {
            comp1Items[letter]++;
        }
    }

    foreach (var letter in compartment2)
    {
        //var order = new GetOrder(letter);
        if (!comp2Items.TryAdd(letter, 1))
        {
            comp2Items[letter]++;
        }
    }

    foreach(KeyValuePair<char, int> pair in comp1Items)
    {
        if (comp2Items.ContainsKey(pair.Key))
        {
            var count = pair.Value + comp2Items[pair.Key];

            items.Add(pair.Key);

            //if (!items.TryAdd(pair.Key, count))
            //{
            //    items[pair.Key] += count;
            //    //throw new NotImplementedException();
            //}
        }
    }

    //return rucksackContents;
}


void FindBadge(string line)
{
    //var items = new Dictionary<char, int>();

    Dictionary<char, int> comp1Items = new Dictionary<char, int>();
    Dictionary<char, int> comp2Items = new Dictionary<char, int>();

    var compartmentSize = line.Length / 2;
    var compartment1 = line.Substring(0, compartmentSize);
    var compartment2 = line.Substring(compartmentSize, compartmentSize);

    var comp1Array = compartment1.ToArray<char>();
    var comp2Array = compartment2.ToArray<char>();

    foreach (var letter in compartment1)
    {
        //var item = new Item(letter);
        if (!comp1Items.TryAdd(letter, 1))
        {
            comp1Items[letter]++;
        }
    }

    foreach (var letter in compartment2)
    {
        //var order = new GetOrder(letter);
        if (!comp2Items.TryAdd(letter, 1))
        {
            comp2Items[letter]++;
        }
    }

    foreach (KeyValuePair<char, int> pair in comp1Items)
    {
        if (comp2Items.ContainsKey(pair.Key))
        {
            var count = pair.Value + comp2Items[pair.Key];

            items.Add(pair.Key);

            //if (!items.TryAdd(pair.Key, count))
            //{
            //    items[pair.Key] += count;
            //    //throw new NotImplementedException();
            //}
        }
    }

    //return rucksackContents;
}



int GetPriority(char letter)
{
    int priority;
    //lower-case are -96
    //capitals are -38
    if (letter > 'Z')
        priority = letter - 96;
    else
        priority = letter - 38;

    return priority;
}

#endregion


