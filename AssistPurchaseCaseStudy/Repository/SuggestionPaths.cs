using System.Collections.Generic;
using System.Linq;


namespace AssistPurchaseCaseStudy.Repository
{
    public class SuggestionPaths
    {
        private readonly Dictionary<string, List<string>> _quesDictionary = new Dictionary<string, List<string>>();

        private readonly string _question1 = "Features";
        private readonly List<string> _featuresMap = new List<string>() { "Touch_Screen", "Handle", "Alarm", "Battery" };

        private readonly List<string> _tsMap = new List<string>() { "Only Spo2", "ESN", "Resp", "CO2", "Others" };
        private readonly List<string> _handleMap = new List<string>() { "ESN", "Resp", "CO2" };
        private readonly List<string> _alarmMap = new List<string>() { "Additional Display", "ESN", "Resp", "CO2" };
        private readonly List<string> _batteryMap = new List<string>() { "Only Spo2", "ESN", "Resp", "CO2", "Others" };

        private readonly List<string> _onlySpo2Map = new List<string>() { "10-15" };
        private readonly List<string> _esnMap = new List<string>() { "upto 10", "10-15", "above 15" };
        private readonly List<string> _respMap = new List<string>() { "upto 10", "10-15", "above 15" };
        private readonly List<string> _co2Map = new List<string>() { "upto 10", "10-15", "above 15" };
        private readonly List<string> _othersMap = new List<string>() { "upto 10" };
        private readonly List<string> _addDisplayMap = new List<string>() { "above 15" };

        private readonly List<string> _displayMap = new List<string>() { "End" };

        private readonly Dictionary<string, string> _layerHierarchy = new Dictionary<string, string>()
            {{"startLayer","Features"},{"Features", "Services"}, {"Services", "DisplaySize"}, {"DisplaySize", "lastLayer"}};

        public readonly List<string> ListOfLayers = new List<string>() { "startLayer", "Features", "Services", "DisplaySize", "lastLayer" };

        public readonly Dictionary<string, List<string>> ValidLayerMembers = new Dictionary<string, List<string>>();


        public SuggestionPaths()
        {
            _quesDictionary.Add(_question1, _featuresMap);
            _quesDictionary.Add("Touch_Screen", _tsMap);
            _quesDictionary.Add("Handle", _handleMap);
            _quesDictionary.Add("Alarm", _alarmMap);
            _quesDictionary.Add("Battery", _batteryMap);
            _quesDictionary.Add("Only Spo2", _onlySpo2Map);
            _quesDictionary.Add("ESN", _esnMap);
            _quesDictionary.Add("Resp", _respMap);
            _quesDictionary.Add("CO2", _co2Map);
            _quesDictionary.Add("Additional Display", _addDisplayMap);
            _quesDictionary.Add("Others", _othersMap);
            _quesDictionary.Add("upto 10", _displayMap);
            _quesDictionary.Add("10-15", _displayMap);
            _quesDictionary.Add("above 15", _displayMap);

            ValidLayerMembers.Add(_question1, _featuresMap);
            ValidLayerMembers.Add("Services", new List<string>() { "Only Spo2", "Additional Display", "ESN", "Resp", "CO2", "Others" });
            ValidLayerMembers.Add("DisplaySize", new List<string>() { "upto 10", "10-15", "above 15" });
            ValidLayerMembers.Add("lastLayer", new List<string>() { "End" });
        }


        public string NextLayer(string previousLayer)
        {
            if (_layerHierarchy.ContainsKey(previousLayer))
            {
                return _layerHierarchy[previousLayer];
            }
            else
            {
                return "Invalid Input, layer not found";
            }
        }

        public string[] NextLayerMembers(string[] layerResponse)
        {
            var returnObjList = new List<string>();
            var lst = new List<string>();
            foreach (string response in layerResponse)
            {
                if (_quesDictionary.ContainsKey(response))
                {
                    lst = _quesDictionary[response];
                }

                returnObjList = returnObjList.Union(lst).ToList();
            }

            return returnObjList.ToArray();
        }
    }
}
