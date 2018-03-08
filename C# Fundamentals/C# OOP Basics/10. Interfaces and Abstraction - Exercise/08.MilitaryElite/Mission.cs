namespace _08.MilitaryElite
{
    public class Mission
    {      
        public Mission(string codeName, string missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string MissionState { get; set; }
        public string CodeName { get; set; }

        public override string ToString()
        {
            return $" Code Name: {this.CodeName} State: {this.MissionState}";
        }
    }
}
