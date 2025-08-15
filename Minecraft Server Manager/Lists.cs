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
            gameRuleList.Add("commandBlockOutput");
            gameRuleList.Add("commandblocksenabled");
            gameRuleList.Add("dodaylightcycle");
            gameRuleList.Add("doentitydrops");
            gameRuleList.Add("dofiretick");
            gameRuleList.Add("doimmediaterespawn");
            gameRuleList.Add("doinsomnia");
            gameRuleList.Add("doLimitedCrafting");
            gameRuleList.Add("domobloot");
            gameRuleList.Add("domobspawning");
            gameRuleList.Add("dotiledrops");
            gameRuleList.Add("doweathercycle");
            gameRuleList.Add("drowningdamage");
            gameRuleList.Add("falldamage");
            gameRuleList.Add("firedamage");
            gameRuleList.Add("freezedamage");
            gameRuleList.Add("keepinventory");                   
            gameRuleList.Add("locatorBar");
            gameRuleList.Add("mobgriefing");
            gameRuleList.Add("naturalregeneration");
            gameRuleList.Add("projectilesCanBreakBlocks");
            gameRuleList.Add("pvp");
            gameRuleList.Add("recipesUnlock");
            gameRuleList.Add("respawnblocksexplode");
            gameRuleList.Add("sendcommandfeedback");
            gameRuleList.Add("showbordereffect");
            gameRuleList.Add("showcoordinates");
            gameRuleList.Add("showDaysPlayed");
            gameRuleList.Add("showdeathmessages");
            gameRuleList.Add("showRecipeMessages");
            gameRuleList.Add("showtags");
            gameRuleList.Add("tntexplodes");
            gameRuleList.Add("tntExplosionDropDecay");
            return gameRuleList;
        }
    }
}
