using System.Text.RegularExpressions;

using Day3;

var pattern = new Regex(@"([a-zA-Z]+)(\n|$)");
var matches = pattern.Matches(Day3.Properties.Resources.input);

Dictionary<char, int> items = new Dictionary<char, int>();

var match = matches[0].Groups[1].Value;

ReadRucksacks();



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

    var compartmentSize = match.Length/2;
    var compartment1 = match.Substring(0, compartmentSize);
    var compartment2 = match.Substring(compartmentSize, compartmentSize);

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

            if (!items.TryAdd(pair.Key, count))
            {
                items[pair.Key] += count;
                //throw new NotImplementedException();
            }
        }
    }

    //return rucksackContents;
}

int GetOrder(char letter)
{
    int order;
    //lower-case are -96
    //capitals are -38
    if (letter > 'Z')
        order = letter - 96;
    else
        order = letter - 38;

    return order;
}

#endregion


