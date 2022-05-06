using System.Collections.Generic;

namespace Minecraft_Server_Manager
{
    class Lists
    {
        public List<string> WeatherList()
        {
            List<string> weatherList = new List<string>();
            weatherList.Add("clear");
            weatherList.Add("rain");
            weatherList.Add("thunder");
            return weatherList;
        }
        public List<string> GameRuleList()
        {
            List<string> gameRuleList = new List<string>();
            gameRuleList.Add("commandblockoutput");
            gameRuleList.Add("commandblocksenabled");
            gameRuleList.Add("dodaylightcycle");
            gameRuleList.Add("doentitydrops");
            gameRuleList.Add("dofiretick");
            gameRuleList.Add("doimmediaterespawn");
            gameRuleList.Add("doinsomnia");
            gameRuleList.Add("domobloot");
            gameRuleList.Add("domobspawning");
            gameRuleList.Add("dotiledrops");
            gameRuleList.Add("doweathercycle");
            gameRuleList.Add("drowningdamage");
            gameRuleList.Add("falldamage");
            gameRuleList.Add("firedamage");
            gameRuleList.Add("keepinventory");
            gameRuleList.Add("mobgriefing");
            gameRuleList.Add("naturalregeneration");
            gameRuleList.Add("pvp");
            gameRuleList.Add("sendcommandfeedback");
            gameRuleList.Add("showcoordinates");
            gameRuleList.Add("showdeathmessages");
            gameRuleList.Add("tntexplodes");
            return gameRuleList;
        }
    }
}
