using System.Collections.Generic;

public class TeamNicknameMap
{
    private Dictionary<string, string> teamListDictionary = new Dictionary<string, string>();  
    public TeamNicknameMap () 
    {
        teamListDictionary.Add("frc435", "Robodogs");
        teamListDictionary.Add("frc587", "Hedgehogs");
        teamListDictionary.Add("frc900", "The Zebracorns");
        teamListDictionary.Add("frc1225", "The Gorillas");
        teamListDictionary.Add("frc1533", "Triple Strange");
        teamListDictionary.Add("frc2059", "The Hitchhikers");
        teamListDictionary.Add("frc2640", "Hotbotz");
        teamListDictionary.Add("frc2642", "Pitt Pirates");
        teamListDictionary.Add("frc2655", "The Flying Platypi");
        teamListDictionary.Add("frc2682", "Boneyard Robotics");
        teamListDictionary.Add("frc3196", "Team SPORK");
        teamListDictionary.Add("frc3215", "Apollo");
        teamListDictionary.Add("frc3229", "Hawktimus Prime");
        teamListDictionary.Add("frc3336", "Zimanators");
        teamListDictionary.Add("frc3459", "Team PyroTech");
        teamListDictionary.Add("frc3506", "YETI");
        teamListDictionary.Add("frc3661", "RoboWolves");
        teamListDictionary.Add("frc3680", "Elemental Dragons");
        teamListDictionary.Add("frc3737", "Roto-Raptors");
        teamListDictionary.Add("frc3796", "Technical Assassins");
        teamListDictionary.Add("frc3822", "Neon Jets");
        teamListDictionary.Add("frc4290", "Bots on Wheels");
        teamListDictionary.Add("frc4291", "AstroBots");
        teamListDictionary.Add("frc4534", "Wired Wizards");
        teamListDictionary.Add("frc4561", "TerrorBytes");
        teamListDictionary.Add("frc4795", "EastBots");
        teamListDictionary.Add("frc4816", "Gadget Girls");
        teamListDictionary.Add("frc4828", "Robo Eagles");
        teamListDictionary.Add("frc4829", "Titanium Tigers");
        teamListDictionary.Add("frc4935", "T-Rex");
        teamListDictionary.Add("frc5160", "Chargers");
        teamListDictionary.Add("frc5190", "Green Hope Falcons");
        teamListDictionary.Add("frc5511", "Cortechs Robotics");
        teamListDictionary.Add("frc5518", "Techno Wolves");
        teamListDictionary.Add("frc5544", "SWIFT Robotics");
        teamListDictionary.Add("frc5607", "Team Firewall");
        teamListDictionary.Add("frc5679", "Girls on Fire");
        teamListDictionary.Add("frc5727", "REaCH Omegabytes");
        teamListDictionary.Add("frc5762", "Franklinbots - TEAM HYDRA");
        teamListDictionary.Add("frc5854", "Glitch");
        teamListDictionary.Add("frc5919", "JoCo RoBos");
        teamListDictionary.Add("frc6004", "f(x) Robotics");
        teamListDictionary.Add("frc6214", "PHEnix");
        teamListDictionary.Add("frc6215", "Armored Eagles");
        teamListDictionary.Add("frc6240", "Eagles of the Knight");
        teamListDictionary.Add("frc6332", "Bull City Botics");
        teamListDictionary.Add("frc6426", "Robo Gladiators");
        teamListDictionary.Add("frc6500", "GearCats");
        teamListDictionary.Add("frc6502", "DARC SIDE");
        teamListDictionary.Add("frc6512", "Coastal CATastrophe");
        teamListDictionary.Add("frc6565", "Team Bobcat");
        teamListDictionary.Add("frc6639", "The Mechanical Minds");
        teamListDictionary.Add("frc6729", "RobCoBots");
        teamListDictionary.Add("frc6888", "BC Breakouts");
        teamListDictionary.Add("frc6894", "Iced Java");
        teamListDictionary.Add("frc6899", "Macon Bots FRC");
        teamListDictionary.Add("frc6908", "Infuzed");
        teamListDictionary.Add("frc6932", "S.M.A.R.T.");
        teamListDictionary.Add("frc7029", "Scotbotics");
        teamListDictionary.Add("frc7265", "Skeleton Crew");
        teamListDictionary.Add("frc7270", "Penco Bots");
        teamListDictionary.Add("frc7443", "Overhills Jag-Wires");
        teamListDictionary.Add("frc7463", "Incandescent Mice");
        teamListDictionary.Add("frc7671", "Fire Hazard");
        teamListDictionary.Add("frc7675", "Spark Guardians");
        teamListDictionary.Add("frc7715", "Robo-Banditos");
        teamListDictionary.Add("frc7739", "Royal Tech Warriors");
        teamListDictionary.Add("frc7763", "CARRBOROBOTICS");
        teamListDictionary.Add("frc7815", "CavBots");
        teamListDictionary.Add("frc7890", "SeQuEnCe");
    }
    public string getTeamNickname(string teamKey)
    {
        var result = "";
        if (teamListDictionary.ContainsKey(teamKey)) {
            result = teamListDictionary[teamKey];
        }

        return result;
    }
}