using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWeight
{
    class WeightCategories
    {
        class WeightClasses
        {
            public string name = null;
            public int weight = 0;
        }

        List<WeightClasses> weightClasses = new List<WeightClasses>();

        public WeightCategories()
        {
            // Fill in weightclasses
            WeightClasses wc = new WeightClasses();
            wc.name = "Heavyweight";
            wc.weight = 100000;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Cruiserweight";
            wc.weight = 200;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Light Heavyweight";
            wc.weight = 175;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Super middleweight";
            wc.weight = 168;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Middleweight";
            wc.weight = 160;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Super Welterweight";
            wc.weight = 154;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Welterweight";
            wc.weight = 147;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Super Lightweight";
            wc.weight = 140;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Lightweight";
            wc.weight = 135;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Super Featherweight";
            wc.weight = 130;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Featherweight";
            wc.weight = 126;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Super Bantamweight";
            wc.weight = 122;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Bantamweight";
            wc.weight = 118;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Super Flyweight";
            wc.weight = 114;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Flyweight";
            wc.weight = 111;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Light Flyweight";
            wc.weight = 108;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Strawweight";
            wc.weight = 105;
            weightClasses.Add(wc);

            wc = new WeightClasses();
            wc.name = "Light Strawweight";
            wc.weight = 102;
            weightClasses.Add(wc);
        }

        public string getWeight(int inWeight)
        {
            // Find the first entry where the weight is above the input weight
            bool found = false;
            int index = weightClasses.Count;
            string returnValue = "Invalid Weight Class";
            while(!found && index > 0)
            {
                index--;
                if(weightClasses[index].weight >= inWeight)
                {
                    returnValue = weightClasses[index].name;
                    found = true;
                }
            }

            return returnValue;
        }
    }
}
